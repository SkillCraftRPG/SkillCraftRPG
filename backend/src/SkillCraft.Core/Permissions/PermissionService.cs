namespace SkillCraft.Core.Permissions;

public interface IPermissionService
{
  Task CheckAsync(ActionKind action, object resource, CancellationToken cancellationToken = default);
  Task CheckAsync(string action, object resource, CancellationToken cancellationToken = default);

  Task CheckCreateWorldAsync(CancellationToken cancellationToken = default);
}

internal class PermissionService : IPermissionService
{
  public async Task CheckAsync(ActionKind action, object resource, CancellationToken cancellationToken) => await CheckAsync(action.ToString(), resource, cancellationToken);
  public async Task CheckAsync(string action, object resource, CancellationToken cancellationToken)
  {
    await Task.Delay(1000, cancellationToken); // TODO(fpion): implement
  }

  public async Task CheckCreateWorldAsync(CancellationToken cancellationToken)
  {
    await Task.Delay(1000, cancellationToken); // TODO(fpion): implement
  }
}
