using Logitar;
using Logitar.EventSourcing;
using SkillCraft.Core.Models;
using SkillCraft.Core.Worlds.Models;
using SkillCraft.Infrastructure.Entities;

namespace SkillCraft.Infrastructure;

internal class Mapper
{
  private readonly Dictionary<ActorId, ActorModel> _actors = [];
  private readonly ActorModel _system = new();

  public Mapper()
  {
  }

  public Mapper(IEnumerable<KeyValuePair<ActorId, ActorModel>> actors)
  {
    foreach (KeyValuePair<ActorId, ActorModel> actor in actors)
    {
      _actors[actor.Key] = actor.Value;
    }
  }

  public WorldModel ToWorld(WorldEntity source)
  {
    WorldModel destination = new()
    {
      Id = source.EntityId,
      Name = source.Name,
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

  private ActorModel FindActor(string? id) => FindActor(id is null ? null : new ActorId(id));
  private ActorModel FindActor(ActorId? id) => (id.HasValue ? TryFindActor(id.Value) : null) ?? _system;

  private ActorModel? TryFindActor(string? id) => id is null ? null : TryFindActor(new ActorId(id));
  private ActorModel? TryFindActor(ActorId? id) => id.HasValue ? (_actors.TryGetValue(id.Value, out ActorModel? actor) ? actor : null) : null;
}
