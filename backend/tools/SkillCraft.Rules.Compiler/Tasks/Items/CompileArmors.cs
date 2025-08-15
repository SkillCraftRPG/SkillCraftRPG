using CsvHelper;
using FluentValidation.Results;
using SkillCraft.Core.Items;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileArmors : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles armor rules.";
}

internal class CompileArmorsHandler : ICommandHandler<CompileArmors>
{
  private readonly ILogger<CompileArmorsHandler> _logger;

  public CompileArmorsHandler(ILogger<CompileArmorsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileArmors command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<ArmorPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, ArmorPayload[]> armorsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, ArmorPayload[]> armorsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Armor> armors = [];
    ArmorValidator validator = new();
    foreach (ArmorPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Armor 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (armorsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Armor ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (armorsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Armor Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Armor armor = new()
      {
        Id = payload.Id,
        Category = payload.Category,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        Weight = payload.Weight,
        Defense = payload.Defense,
        Resistance = payload.Resistance,
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };

      if (!string.IsNullOrWhiteSpace(payload.Properties))
      {
        armor.Properties = payload.Properties.Split(',')
          .Select(value => Enum.Parse<ArmorProperty>(value.Trim(), ignoreCase: true))
          .Distinct()
          .OrderBy(x => x)
          .ToList();
      }

      armors.Add(armor);
    }

    await LoadAsync(armors, cancellationToken);

    _logger.LogInformation("Compiled {Count} armors.", armors.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<ArmorPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\armor.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<ArmorPayload> records = csv.GetRecordsAsync<ArmorPayload>(cancellationToken);

    List<ArmorPayload> armors = [];
    await foreach (ArmorPayload armor in records)
    {
      armors.Add(armor);
    }

    return armors.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Armor> armors, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(armors, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\armor.json", json, Constants.Encoding, cancellationToken);
  }
}
