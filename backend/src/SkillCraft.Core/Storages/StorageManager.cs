namespace SkillCraft.Core.Storages;

public interface IStorageManager
{
  Task EnsureAvailableAsync(object resource, CancellationToken cancellationToken = default);
  Task UpdateAsync(object resource, CancellationToken cancellationToken = default);
}

internal class StorageManager : IStorageManager
{
  public Task EnsureAvailableAsync(object resource, CancellationToken cancellationToken)
  {
    throw new NotImplementedException(); // TODO(fpion): implement
  }

  public Task UpdateAsync(object resource, CancellationToken cancellationToken)
  {
    throw new NotImplementedException(); // TODO(fpion): implement
  }
}
