using CsvHelper;
using FluentValidation.Results;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileTools : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles tool rules.";
}

internal class CompileToolsHandler : ICommandHandler<CompileTools>
{
  private readonly ILogger<CompileToolsHandler> _logger;

  public CompileToolsHandler(ILogger<CompileToolsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileTools command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<ToolPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, ToolPayload[]> toolsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, ToolPayload[]> toolsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Tool> tools = [];
    ToolValidator validator = new();
    foreach (ToolPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Tool 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (toolsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Tool ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (toolsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Tool Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Tool tool = new()
      {
        Id = payload.Id,
        Category = payload.Category,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        Weight = payload.Weight,
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };
      tools.Add(tool);
    }

    await LoadAsync(tools, cancellationToken);

    _logger.LogInformation("Compiled {Count} tools.", tools.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<ToolPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\tools.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<ToolPayload> records = csv.GetRecordsAsync<ToolPayload>(cancellationToken);

    List<ToolPayload> tools = [];
    await foreach (ToolPayload tool in records)
    {
      tools.Add(tool);
    }

    return tools.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Tool> tools, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(tools, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\tools.json", json, Constants.Encoding, cancellationToken);
  }
}
