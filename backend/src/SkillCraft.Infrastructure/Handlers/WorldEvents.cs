using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SkillCraft.Core;
using SkillCraft.Core.Worlds.Events;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure.Handlers;

internal class WorldEvents : IEventHandler<WorldCreated>, IEventHandler<WorldUpdated>
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IEventHandler<WorldCreated>, WorldEvents>();
    services.AddTransient<IEventHandler<WorldUpdated>, WorldEvents>();
  }

  private readonly GameContext _context;

  public WorldEvents(GameContext context)
  {
    _context = context;
  }

  public async Task HandleAsync(WorldCreated @event, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _context.Worlds.AsNoTracking().SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (world is not null)
    {
      return; // TODO(fpion): implement
    }

    world = new(@event);
    _context.Worlds.Add(world);

    await _context.SaveChangesAsync(cancellationToken);
    // TODO(fpion): implement
  }

  public async Task HandleAsync(WorldUpdated @event, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _context.Worlds.SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (world is null || world.Version != (@event.Version - 1))
    {
      return; // TODO(fpion): implement
    }

    world.Update(@event);

    await _context.SaveChangesAsync(cancellationToken);
    // TODO(fpion): implement
  }
}
