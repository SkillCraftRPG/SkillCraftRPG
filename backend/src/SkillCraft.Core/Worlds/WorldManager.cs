using SkillCraft.Core.Storages;

namespace SkillCraft.Core.Worlds;

public interface IWorldManager
{
  Task SaveAsync(World world, CancellationToken cancellationToken = default);
}

internal class WorldManager : IWorldManager
{
  private readonly IStorageManager _storageManager;
  private readonly IWorldRepository _worldRepository;

  public WorldManager(IStorageManager storageManager, IWorldRepository worldRepository)
  {
    _storageManager = storageManager;
    _worldRepository = worldRepository;
  }

  public async Task SaveAsync(World world, CancellationToken cancellationToken)
  {
    await _storageManager.EnsureAvailableAsync(world, cancellationToken);

    await _worldRepository.SaveAsync(world, cancellationToken);

    await _storageManager.UpdateAsync(world, cancellationToken);
  }
}
