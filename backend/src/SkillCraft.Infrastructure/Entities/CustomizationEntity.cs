using SkillCraft.Contracts;
using SkillCraft.Core.Customizations;
using SkillCraft.Core.Customizations.Events;

namespace SkillCraft.Infrastructure.Entities;

internal class CustomizationEntity : AggregateEntity
{
  public int CustomizationId { get; private set; }

  public WorldEntity? World { get; private set; }
  public int WorldId { get; private set; }
  public Guid WorldUid { get; private set; }

  public Guid EntityId { get; private set; }

  public CustomizationKind Kind { get; private set; }
  public string Name { get; private set; } = string.Empty;
  public string? Description { get; private set; }

  public CustomizationEntity(WorldEntity world, CustomizationCreated @event) : base(@event)
  {
    World = world;
    WorldId = world.WorldId;
    WorldUid = world.EntityId;

    EntityId = new CustomizationId(@event.StreamId).EntityId;

    Kind = @event.Kind;
    Name = @event.Name.Value;
  }

  private CustomizationEntity()
  {
  }

  public void Update(CustomizationUpdated @event)
  {
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
