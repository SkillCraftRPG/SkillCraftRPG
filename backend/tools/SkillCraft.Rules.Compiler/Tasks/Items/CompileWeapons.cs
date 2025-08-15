using CsvHelper;
using FluentValidation.Results;
using Logitar;
using SkillCraft.Core.Items;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileWeapons : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles weapon rules.";
}

internal class CompileWeaponsHandler : ICommandHandler<CompileWeapons>
{
  private readonly ILogger<CompileWeaponsHandler> _logger;

  public CompileWeaponsHandler(ILogger<CompileWeaponsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileWeapons command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<WeaponPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, WeaponPayload[]> weaponsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, WeaponPayload[]> weaponsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Weapon> weapons = [];
    WeaponValidator validator = new();
    foreach (WeaponPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Weapon 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (weaponsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Weapon ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (weaponsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Weapon Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Weapon weapon = new()
      {
        Id = payload.Id,
        Category = payload.Category,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        Weight = payload.Weight,
        Special = payload.Special?.CleanTrim()?.Replace("\\n", "\n"),
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };

      if (!string.IsNullOrWhiteSpace(payload.DamageRoll) && payload.DamageType.HasValue)
      {
        weapon.Damage = new WeaponDamage(payload.DamageRoll, payload.DamageType.Value, payload.Versatile?.CleanTrim());
      }

      if (payload.AmmunitionStandard.HasValue && payload.AmmunitionLong.HasValue)
      {
        weapon.Ammunition = new WeaponRange(payload.AmmunitionStandard.Value, payload.AmmunitionLong.Value);
      }

      if (payload.ThrownStandard.HasValue && payload.ThrownLong.HasValue)
      {
        weapon.Thrown = new WeaponRange(payload.ThrownStandard.Value, payload.ThrownLong.Value);
      }

      if (!string.IsNullOrWhiteSpace(payload.Properties))
      {
        weapon.Properties = payload.Properties.Split(',')
          .Select(value => Enum.Parse<WeaponProperty>(value.Trim(), ignoreCase: true))
          .Distinct()
          .OrderBy(x => x)
          .ToList();
      }

      weapons.Add(weapon);
    }

    await LoadAsync(weapons, cancellationToken);

    _logger.LogInformation("Compiled {Count} weapons.", weapons.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<WeaponPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\weapons.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<WeaponPayload> records = csv.GetRecordsAsync<WeaponPayload>(cancellationToken);

    List<WeaponPayload> weapons = [];
    await foreach (WeaponPayload weapon in records)
    {
      weapons.Add(weapon);
    }

    return weapons.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Weapon> weapons, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(weapons, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\weapons.json", json, Constants.Encoding, cancellationToken);
  }
}
