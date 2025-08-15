using CsvHelper;
using FluentValidation.Results;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileContainers : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles container rules.";
}

internal class CompileContainersHandler : ICommandHandler<CompileContainers>
{
  private readonly ILogger<CompileContainersHandler> _logger;

  public CompileContainersHandler(ILogger<CompileContainersHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileContainers command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<ContainerPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, ContainerPayload[]> containersById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, ContainerPayload[]> containersBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Container> containers = [];
    ContainerValidator validator = new();
    foreach (ContainerPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Container 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (containersById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Container ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (containersBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Container Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Container container = new()
      {
        Id = payload.Id,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        Weight = payload.Weight,
        Capacity = payload.Capacity,
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };

      if (payload.Volume.HasValue && !string.IsNullOrWhiteSpace(payload.VolumeUnit))
      {
        container.Volume = new ContainerVolume(payload.Volume.Value, payload.VolumeUnit.Trim());
      }

      containers.Add(container);
    }

    await LoadAsync(containers, cancellationToken);

    _logger.LogInformation("Compiled {Count} containers.", containers.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<ContainerPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\containers.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<ContainerPayload> records = csv.GetRecordsAsync<ContainerPayload>(cancellationToken);

    List<ContainerPayload> containers = [];
    await foreach (ContainerPayload container in records)
    {
      containers.Add(container);
    }

    return containers.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Container> containers, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(containers, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\containers.json", json, Constants.Encoding, cancellationToken);
  }
}
