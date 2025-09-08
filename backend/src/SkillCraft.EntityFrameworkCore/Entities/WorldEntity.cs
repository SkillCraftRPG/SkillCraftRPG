using Krakenar.EntityFrameworkCore.Relational.Entities;
using SkillCraft.Core.Worlds;
using SkillCraft.Core.Worlds.Events;

namespace SkillCraft.EntityFrameworkCore.Entities;

internal class WorldEntity : Aggregate
{
  public int WorldId { get; private set; }
  public Guid Id { get; private set; }

  public string Name { get; private set; } = string.Empty;
  public string? Description { get; private set; }

  public WorldEntity(WorldCreated @event) : base(@event)
  {
    Id = new WorldId(@event.StreamId).ToGuid();

    Name = @event.Name.Value;
  }

  private WorldEntity() : base()
  {
  }

  public void Update(WorldUpdated @event)
  {
    base.Update(@event);

    if (@event.Name is not null)
    {
      Name = @event.Name.Value;
    }
    if (@event.Description is not null)
    {
      Description = @event.Description.Value?.Value;
    }
  }

  public override string ToString() => $"{Name} | {base.ToString()}";
}
