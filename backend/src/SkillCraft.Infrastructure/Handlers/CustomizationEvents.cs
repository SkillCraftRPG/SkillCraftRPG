using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core.Customizations;
using SkillCraft.Core.Customizations.Events;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Handlers;

internal class CustomizationEvents : IEventHandler<CustomizationCreated>, IEventHandler<CustomizationUpdated>
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IEventHandler<CustomizationCreated>, CustomizationEvents>();
    services.AddTransient<IEventHandler<CustomizationUpdated>, CustomizationEvents>();
  }

  private readonly SkillCraftContext _context;

  public CustomizationEvents(SkillCraftContext context)
  {
    _context = context;
  }

  public async Task HandleAsync(CustomizationCreated @event, CancellationToken cancellationToken)
  {
    CustomizationEntity? customization = await _context.Customizations.AsNoTracking().SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (customization is not null)
    {
      // TODO(fpion): handle error
      return;
    }

    WorldEntity world = await _context.LoadWorldAsync(new CustomizationId(@event.StreamId).WorldId, cancellationToken);

    customization = new CustomizationEntity(world, @event);
    _context.Customizations.Add(customization);

    await _context.SaveChangesAsync(cancellationToken);
    // TODO(fpion): success log
  }

  public async Task HandleAsync(CustomizationUpdated @event, CancellationToken cancellationToken)
  {
    CustomizationEntity? customization = await _context.Customizations.SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (customization is null || customization.Version != (@event.Version - 1))
    {
      // TODO(fpion): handle error
      return;
    }

    customization.Update(@event);

    await _context.SaveChangesAsync(cancellationToken);
    // TODO(fpion): success log
  }
}
