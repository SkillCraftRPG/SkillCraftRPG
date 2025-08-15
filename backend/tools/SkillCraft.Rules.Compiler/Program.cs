namespace SkillCraft.Rules.Compiler;

internal class Program
{
  public static void Main(string[] args)
  {
    HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);
    IConfiguration configuration = builder.Configuration;

    Startup startup = new(configuration);
    startup.ConfigureServices(builder.Services);

    Directory.CreateDirectory("data\\output\\items");

    IHost host = builder.Build();
    host.Run();
  }
}
