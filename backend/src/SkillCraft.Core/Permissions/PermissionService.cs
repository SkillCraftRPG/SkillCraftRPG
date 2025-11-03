using SkillCraft.Core.Worlds;

namespace SkillCraft.Core.Permissions;

public interface IPermissionService
{
  Task CheckAsync(ActionKind action, CancellationToken cancellationToken = default);
  Task CheckAsync(string action, CancellationToken cancellationToken = default);
  Task CheckAsync(ActionKind action, object? resource, CancellationToken cancellationToken = default);
  Task CheckAsync(string action, object? resource, CancellationToken cancellationToken = default);
}

internal class PermissionService : IPermissionService
{
  private readonly IApplicationContext _applicationContext;

  public PermissionService(IApplicationContext applicationContext)
  {
    _applicationContext = applicationContext;
  }

  public async Task CheckAsync(ActionKind action, CancellationToken cancellationToken)
  {
    await CheckAsync(action.ToString(), cancellationToken);
  }
  public async Task CheckAsync(string action, CancellationToken cancellationToken)
  {
    await CheckAsync(action, resource: null, cancellationToken);
  }
  public async Task CheckAsync(ActionKind action, object? resource, CancellationToken cancellationToken)
  {
    await CheckAsync(action.ToString(), resource, cancellationToken);
  }
  public async Task CheckAsync(string action, object? resource, CancellationToken cancellationToken)
  {
    UserId userId = _applicationContext.UserId;

    Entity? entity = null;
    bool isAllowed = false;
    if (resource is null)
    {
      isAllowed = await CheckAsync(userId, action, cancellationToken);
    }
    else if (resource is World world)
    {
      entity = new(EntityKind.World, world.Id.EntityId.ToString());
      isAllowed = Check(userId, action, world);
    }

    if (!isAllowed)
    {
      throw new PermissionDeniedException(userId, action, entity);
    }
  }

  private static Task<bool> CheckAsync(UserId userId, string action, CancellationToken cancellationToken) => action switch
  {
    "CreateWorld" => Task.FromResult(true),// TODO(fpion): implement WorldLimit
    _ => Task.FromResult(false),
  };

  private static bool Check(UserId userId, string action, World world) => action switch
  {
    "Update" => world.OwnerId == userId,
    _ => false,
  };
}
