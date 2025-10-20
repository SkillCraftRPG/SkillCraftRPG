namespace SkillCraft.Core.Models;

public class ActorModel
{
  public Guid Id { get; set; }
  public ActorType Type { get; set; }
  public bool IsDeleted { get; set; }

  public string DisplayName { get; set; }
  public string? EmailAddress { get; set; }
  public string? PictureUrl { get; set; }

  public ActorModel() : this(ActorType.System.ToString())
  {
  }

  public ActorModel(string displayName)
  {
    DisplayName = displayName;
  }
}
