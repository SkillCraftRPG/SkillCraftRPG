using Krakenar.Contracts;
using Logitar;

namespace SkillCraft.Core.Permissions;

public class PermissionDeniedException : ErrorException
{
  private const string ErrorMessage = "The specified permission was denied.";

  public Guid UserId
  {
    get => (Guid)Data[nameof(UserId)]!;
    private set => Data[nameof(UserId)] = value;
  }
  public string Action
  {
    get => (string)Data[nameof(Action)]!;
    private set => Data[nameof(Action)] = value;
  }
  public IEntity? Resource
  {
    get => (IEntity?)Data[nameof(Resource)];
    private set => Data[nameof(Resource)] = value;
  }

  public override Error Error => new(this.GetErrorCode(), ErrorMessage);

  public PermissionDeniedException(UserId userId, string action, IEntity? resource = null)
    : base(BuildMessage(userId, action, resource))
  {
    UserId = userId.ToGuid();
    Action = action;
    Resource = resource;
  }

  private static string BuildMessage(UserId userId, string action, IEntity? resource) => new ErrorMessageBuilder(ErrorMessage)
    .AddData(nameof(UserId), userId.ToGuid())
    .AddData(nameof(Action), action)
    .AddData("Entity.Kind", resource?.Kind, "<null>")
    .AddData("Entity.Identifier", resource?.Identifier, "<null>")
    .Build();
}
