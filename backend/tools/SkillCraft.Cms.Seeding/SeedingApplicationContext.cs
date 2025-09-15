﻿using Krakenar.Contracts.Logging;
using Krakenar.Contracts.Settings;
using Krakenar.Core;
using Krakenar.Core.Caching;
using Krakenar.Core.Realms;
using Krakenar.Core.Tokens;
using Logitar.EventSourcing;
using Configuration = Krakenar.Contracts.Configurations.Configuration;
using Realm = Krakenar.Contracts.Realms.Realm;

namespace SkillCraft.Cms.Seeding;

internal record SeedingApplicationContext : IApplicationContext
{
  private readonly ICacheService _cacheService;

  public SeedingApplicationContext(ICacheService cacheService)
  {
    _cacheService = cacheService;
  }

  protected virtual Configuration Configuration => _cacheService.Configuration ?? throw new InvalidOperationException("The configuration was not found in the cache.");

  public ActorId? ActorId { get; set; }

  public string BaseUrl { get; } = "seeding";

  public Realm? Realm { get; set; }
  public RealmId? RealmId => Realm is null ? null : new RealmId(Realm.Id);

  public Secret Secret => new(Realm?.Secret ?? Configuration.Secret ?? string.Empty);
  public IUniqueNameSettings UniqueNameSettings => Realm?.UniqueNameSettings ?? Configuration.UniqueNameSettings;
  public IPasswordSettings PasswordSettings => Realm?.PasswordSettings ?? Configuration.PasswordSettings;
  public bool RequireUniqueEmail => Realm?.RequireUniqueEmail ?? false;
  public bool RequireConfirmedAccount => Realm?.RequireConfirmedAccount ?? false;

  public ILoggingSettings LoggingSettings => Configuration.LoggingSettings;
}
