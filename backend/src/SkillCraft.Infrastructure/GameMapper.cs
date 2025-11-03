using Krakenar.Contracts.Actors;
using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Infrastructure.Entities;
using AggregateModel = Krakenar.Contracts.Aggregate;

namespace SkillCraft.Infrastructure;

internal class GameMapper
{
  private readonly Dictionary<ActorId, Actor> _actors = [];
  private readonly Actor _system = new();

  public GameMapper()
  {
  }

  public GameMapper(IEnumerable<KeyValuePair<ActorId, Actor>> actors)
  {
    foreach (KeyValuePair<ActorId, Actor> actor in actors)
    {
      _actors[actor.Key] = actor.Value;
    }
  }

  public WorldModel ToWorld(WorldEntity source)
  {
    WorldModel destination = new(source.Name)
    {
      Id = source.Id,
      Description = source.Description
    };

    MapAggregate(source, destination);

    return destination;
  }

  private void MapAggregate(AggregateEntity source, AggregateModel destination)
  {
    destination.Version = source.Version;

    destination.CreatedBy = FindActor(source.CreatedBy);
    destination.CreatedOn = source.CreatedOn.AsUniversalTime();

    destination.UpdatedBy = FindActor(source.UpdatedBy);
    destination.UpdatedOn = source.UpdatedOn.AsUniversalTime();
  }

  private Actor FindActor(string? id) => FindActor(string.IsNullOrWhiteSpace(id) ? null : new ActorId(id));
  private Actor FindActor(ActorId? id) => TryFindActor(id) ?? _system;
  private Actor? TryFindActor(string? id) => TryFindActor(string.IsNullOrWhiteSpace(id) ? null : new ActorId(id));
  private Actor? TryFindActor(ActorId? id)
  {
    if (id.HasValue)
    {
      return _actors.TryGetValue(id.Value, out Actor? actor) ? actor : null;
    }
    return null;
  }
}
