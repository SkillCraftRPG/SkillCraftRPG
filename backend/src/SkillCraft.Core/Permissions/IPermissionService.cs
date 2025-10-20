namespace SkillCraft.Core.Permissions;

public interface IPermissionService
{
  Task CheckAsync(ActionKind action, object resource, CancellationToken cancellationToken = default);
  Task CheckAsync(string action, object resource, CancellationToken cancellationToken = default);

  Task CheckCreateWorldAsync(CancellationToken cancellationToken = default);
}
