using CsvHelper;
using FluentValidation.Results;
using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Models.Items;
using SkillCraft.Rules.Compiler.Validators.Items;

namespace SkillCraft.Rules.Compiler.Tasks.Items;

internal class CompileGoods : RuleCompilerTask
{
  public override string? Description { get; protected set; } = "Compiles goods rules.";
}

internal class CompileGoodsHandler : ICommandHandler<CompileGoods>
{
  private readonly ILogger<CompileGoodsHandler> _logger;

  public CompileGoodsHandler(ILogger<CompileGoodsHandler> logger)
  {
    _logger = logger;
  }

  public async Task HandleAsync(CompileGoods command, CancellationToken cancellationToken)
  {
    IReadOnlyCollection<GoodsPayload> payloads = await ExtractAsync(cancellationToken);
    Dictionary<Guid, GoodsPayload[]> goodsById = payloads.GroupBy(x => x.Id).ToDictionary(x => x.Key, x => x.ToArray());
    Dictionary<string, GoodsPayload[]> goodsBySlug = payloads.GroupBy(x => Normalize(x.Slug)).ToDictionary(x => x.Key, x => x.ToArray());

    List<Goods> goodsList = [];
    GoodsValidator validator = new();
    foreach (GoodsPayload payload in payloads)
    {
      ValidationResult result = validator.Validate(payload);
      if (!result.IsValid)
      {
        foreach (ValidationFailure failure in result.Errors)
        {
          string error = JsonSerializer.Serialize(failure, Constants.SerializerOptions);
          _logger.LogWarning("Goods 'Id={Id}, Name={Name}' is not valid: {Error}", payload.Id, payload.Name, error);
        }
        continue;
      }

      if (goodsById[payload.Id].Length > 1)
      {
        _logger.LogWarning("Goods ID '{Id}' has conflicts.", payload.Id);
        continue;
      }

      string slug = Normalize(payload.Slug.ToLowerInvariant());
      if (goodsBySlug[slug].Length > 1)
      {
        _logger.LogWarning("Goods Slug '{Slug}' has conflicts.", payload.Slug);
        continue;
      }

      Goods goods = new()
      {
        Id = payload.Id,
        Category = payload.Category,
        Slug = slug,
        Name = payload.Name.Trim(),
        Price = payload.Price,
        Weight = payload.Weight,
        Description = payload.Description.Trim().Replace("\\n", "\n")
      };
      goodsList.Add(goods);
    }

    await LoadAsync(goodsList, cancellationToken);

    _logger.LogInformation("Compiled {Count} goods.", goodsList.Count);
  }

  private static string Normalize(string value) => value.Trim().ToLowerInvariant();

  private static async Task<IReadOnlyCollection<GoodsPayload>> ExtractAsync(CancellationToken cancellationToken)
  {
    using StreamReader reader = new("data\\input\\items\\goods.csv", Constants.Encoding);
    using CsvReader csv = new(reader, Constants.Culture);
    IAsyncEnumerable<GoodsPayload> records = csv.GetRecordsAsync<GoodsPayload>(cancellationToken);

    List<GoodsPayload> goodsList = [];
    await foreach (GoodsPayload goods in records)
    {
      goodsList.Add(goods);
    }

    return goodsList.AsReadOnly();
  }

  private static async Task LoadAsync(IEnumerable<Goods> goods, CancellationToken cancellationToken)
  {
    string json = JsonSerializer.Serialize(goods, Constants.SerializerOptions);
    await File.WriteAllTextAsync("data\\output\\items\\goods.json", json, Constants.Encoding, cancellationToken);
  }
}
