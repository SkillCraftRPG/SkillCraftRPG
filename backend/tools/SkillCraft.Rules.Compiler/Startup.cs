using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Tasks;
using SkillCraft.Rules.Compiler.Tasks.Items;

namespace SkillCraft.Rules.Compiler;

internal class Startup
{
  private readonly IConfiguration _configuration;

  public Startup(IConfiguration configuration)
  {
    _configuration = configuration;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddHostedService<RuleCompiler>();

    services.AddTransient<ICommandBus, CommandBus>();
    services.AddTransient<ICommandHandler<CompileArmors>, CompileArmorsHandler>();
    services.AddTransient<ICommandHandler<CompileAttributes>, CompileAttributesHandler>();
    services.AddTransient<ICommandHandler<CompileCastes>, CompileCastesHandler>();
    services.AddTransient<ICommandHandler<CompileClothing>, CompileClothingHandler>();
    services.AddTransient<ICommandHandler<CompileContainers>, CompileContainersHandler>();
    services.AddTransient<ICommandHandler<CompileCustomizations>, CompileCustomizationsHandler>();
    services.AddTransient<ICommandHandler<CompileEducations>, CompileEducationsHandler>();
    services.AddTransient<ICommandHandler<CompileGeneralItems>, CompileGeneralItemsHandler>();
    services.AddTransient<ICommandHandler<CompileGoods>, CompileGoodsHandler>();
    services.AddTransient<ICommandHandler<CompileSkills>, CompileSkillsHandler>();
    services.AddTransient<ICommandHandler<CompileStatistics>, CompileStatisticsHandler>();
    services.AddTransient<ICommandHandler<CompileTalents>, CompileTalentsHandler>();
    services.AddTransient<ICommandHandler<CompileTools>, CompileToolsHandler>();
    services.AddTransient<ICommandHandler<CompileWeapons>, CompileWeaponsHandler>();
  }
}
