using Krakenar.Core;
using Krakenar.EntityFrameworkCore.Relational.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SkillCraft.Core.Worlds.Events;
using SkillCraft.EntityFrameworkCore.Entities;

namespace SkillCraft.EntityFrameworkCore.Handlers;

internal class WorldEvents : IEventHandler<WorldCreated>, IEventHandler<WorldDeleted>, IEventHandler<WorldUpdated>
{
  public static void Register(IServiceCollection services)
  {
    services.AddTransient<IEventHandler<WorldCreated>, WorldEvents>();
    services.AddTransient<IEventHandler<WorldDeleted>, WorldEvents>();
    services.AddTransient<IEventHandler<WorldUpdated>, WorldEvents>();
  }

  private readonly SkillCraftContext _context;
  private readonly ILogger<WorldEvents> _logger;

  public WorldEvents(SkillCraftContext context, ILogger<WorldEvents> logger)
  {
    _context = context;
    _logger = logger;
  }

  public async Task HandleAsync(WorldCreated @event, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _context.Worlds.AsNoTracking()
      .SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (world is not null)
    {
      _logger.LogUnexpectedVersion(@event, world);
      return;
    }

    world = new WorldEntity(@event);
    _context.Worlds.Add(world);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogSuccess(@event);
  }

  public async Task HandleAsync(WorldDeleted @event, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _context.Worlds.AsNoTracking()
      .SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (world is null)
    {
      _logger.LogUnexpectedVersion(@event, world);
      return;
    }

    _context.Worlds.Remove(world);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogSuccess(@event);
  }

  public async Task HandleAsync(WorldUpdated @event, CancellationToken cancellationToken)
  {
    WorldEntity? world = await _context.Worlds.AsNoTracking()
      .SingleOrDefaultAsync(x => x.StreamId == @event.StreamId.Value, cancellationToken);
    if (world is null || world.Version != (@event.Version - 1))
    {
      _logger.LogUnexpectedVersion(@event, world);
      return;
    }

    world.Update(@event);

    await _context.SaveChangesAsync(cancellationToken);
    _logger.LogSuccess(@event);
  }
}
