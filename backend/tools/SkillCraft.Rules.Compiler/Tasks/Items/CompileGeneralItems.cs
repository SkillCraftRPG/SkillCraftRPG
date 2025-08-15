using CsvHelper;
using FluentValidation.Results;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileGeneralItems : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles general item rules.";
}

internal class CompileGeneralItemsHandler : ICommandHandler<CompileGeneralItems>
{
  private readonly ILogger<CompileGeneralItemsHandler> _logger;

  public CompileGeneralItemsHandler(ILogger<CompileGeneralItemsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileGeneralItems command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<ItemPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, ItemPayload[]> itemsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, ItemPayload[]> itemsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Item> items = [];
    ItemValidator validator = new();
    foreach (ItemPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("General item 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (itemsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("General item ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (itemsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("General item Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Item item = new()
      {
        Id = payload.Id,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        Weight = payload.Weight,
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };
      items.Add(item);
    }

    await LoadAsync(items, cancellationToken);

    _logger.LogInformation("Compiled {Count} general items.", items.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<ItemPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\general.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<ItemPayload> records = csv.GetRecordsAsync<ItemPayload>(cancellationToken);

    List<ItemPayload> items = [];
    await foreach (ItemPayload item in records)
    {
      items.Add(item);
    }

    return items.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Item> items, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(items, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\general.json", json, Constants.Encoding, cancellationToken);
  }
}
