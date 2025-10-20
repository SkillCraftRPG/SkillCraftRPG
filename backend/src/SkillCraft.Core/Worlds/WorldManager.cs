namespace SkillCraft.Core.Worlds;

public interface IWorldManager
{
  Task SaveAsync(World world, CancellationToken cancellationToken = default);
}

internal class WorldManager : IWorldManager
{
  private readonly IWorldRepository _worldRepository;

  public WorldManager(IWorldRepository worldRepository)
  {
    _worldRepository = worldRepository;
  }

  public async Task SaveAsync(World world, CancellationToken cancellationToken)
  {
    // TODO(fpion): ensure enough storage

    await _worldRepository.SaveAsync(world, cancellationToken);

    // TODO(fpion): update storage
  }
}
