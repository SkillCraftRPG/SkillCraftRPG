namespace SkillCraft.Core.Models;

public abstract class AggregateModel
{
  public Guid Id { get; set; }
  public long Version { get; set; }

  public ActorModel? CreatedBy { get; set; }
  public DateTime CreatedOn { get; set; }

  public ActorModel? UpdatedBy { get; set; }
  public DateTime UpdatedOn { get; set; }
}
