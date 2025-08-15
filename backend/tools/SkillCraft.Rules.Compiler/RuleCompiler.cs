using SkillCraft.Rules.Compiler.Commands;
using SkillCraft.Rules.Compiler.Tasks;
using SkillCraft.Rules.Compiler.Tasks.Items;

namespace SkillCraft.Rules.Compiler;

public class RuleCompiler : BackgroundService
{
  private const string GenericErrorMessage = "An unhanded exception occurred.";

  private readonly IHostApplicationLifetime _hostApplicationLifetime;
  private readonly ILogger<RuleCompiler> _logger;
  private readonly IServiceProvider _serviceProvider;

  private ICommandBus? _commandBus = null;
  private ICommandBus CommandBus => _commandBus ?? throw new InvalidOperationException("The command bus has not been initialized.");

  private LogLevel _result = LogLevel.Information; // NOTE(fpion): "Information" means success.

  public RuleCompiler(IHostApplicationLifetime hostApplicationLifetime, ILogger<RuleCompiler> logger, IServiceProvider serviceProvider)
  {
    _hostApplicationLifetime = hostApplicationLifetime;
    _logger = logger;
    _serviceProvider = serviceProvider;
  }

  protected override async Task ExecuteAsync(CancellationToken cancellationToken)
  {
    Stopwatch chrono = Stopwatch.StartNew();
    _logger.LogInformation("Worker executing at {Timestamp}.", DateTimeOffset.Now);

    using IServiceScope scope = _serviceProvider.CreateScope();
    _commandBus = scope.ServiceProvider.GetRequiredService<ICommandBus>();

    try
    {
      // NOTE(fpion): the order of these tasks matter.
      await ExecuteAsync(new CompileAttributes(), cancellationToken);
      await ExecuteAsync(new CompileStatistics(), cancellationToken);
      await ExecuteAsync(new CompileSkills(), cancellationToken);
      await ExecuteAsync(new CompileCustomizations(), cancellationToken);
      await ExecuteAsync(new CompileCastes(), cancellationToken);
      await ExecuteAsync(new CompileEducations(), cancellationToken);
      await ExecuteAsync(new CompileTalents(), cancellationToken);

      await ExecuteAsync(new CompileArmors(), cancellationToken);
      await ExecuteAsync(new CompileWeapons(), cancellationToken);
      await ExecuteAsync(new CompileGeneralItems(), cancellationToken);
      await ExecuteAsync(new CompileContainers(), cancellationToken);
      await ExecuteAsync(new CompileClothing(), cancellationToken);
      await ExecuteAsync(new CompileGoods(), cancellationToken);
      await ExecuteAsync(new CompileTools(), cancellationToken);
    }
    catch (Exception exception)
    {
      _logger.LogError(exception, GenericErrorMessage);
      _result = LogLevel.Error;

      Environment.ExitCode = exception.HResult;
    }
    finally
    {
      chrono.Stop();

      long seconds = chrono.ElapsedMilliseconds / 1000;
      string secondText = seconds <= 1 ? "second" : "seconds";
      switch (_result)
      {
        case LogLevel.Error:
          _logger.LogError("Seeding failed after {Elapsed}ms ({Seconds} {SecondText}).", chrono.ElapsedMilliseconds, seconds, secondText);
          break;
        case LogLevel.Warning:
          _logger.LogWarning("Seeding completed with warnings in {Elapsed}ms ({Seconds} {SecondText}).", chrono.ElapsedMilliseconds, seconds, secondText);
          break;
        default:
          _logger.LogInformation("Seeding succeeded in {Elapsed}ms ({Seconds} {SecondText}).", chrono.ElapsedMilliseconds, seconds, secondText);
          break;
      }

      _hostApplicationLifetime.StopApplication();
    }
  }

  private async Task ExecuteAsync(RuleCompilerTask task, CancellationToken cancellationToken)
  {
    await ExecuteAsync(task, continueOnError: false, cancellationToken);
  }
  private async Task ExecuteAsync(RuleCompilerTask task, bool continueOnError, CancellationToken cancellationToken)
  {
    bool hasFailed = false;
    try
    {
      await CommandBus.ExecuteAsync(task, cancellationToken);
    }
    catch (Exception exception)
    {
      if (continueOnError)
      {
        _logger.LogWarning(exception, GenericErrorMessage);
        hasFailed = true;
      }
      else
      {
        throw;
      }
    }
    finally
    {
      task.Complete();

      LogLevel result = LogLevel.Information;
      if (hasFailed)
      {
        _result = LogLevel.Warning;
        result = LogLevel.Warning;
      }

      int milliseconds = task.Duration?.Milliseconds ?? 0;
      int seconds = milliseconds / 1000;
      string secondText = seconds <= 1 ? "second" : "seconds";
      _logger.Log(result, "Task '{Name}' succeeded in {Elapsed}ms ({Seconds} {SecondText}).", task.Name, milliseconds, seconds, secondText);
    }
  }
}
