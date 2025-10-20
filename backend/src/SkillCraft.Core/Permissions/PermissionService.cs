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
  public Task CheckAsync(string action, object resource, CancellationToken cancellationToken)
  {
    throw new NotImplementedException(); // TODO(fpion): implement
  }

  public Task CheckCreateWorldAsync(CancellationToken cancellationToken)
  {
    throw new NotImplementedException(); // TODO(fpion): implement
  }
}
