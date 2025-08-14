﻿using Krakenar.Core;
using Krakenar.Core.Contents;
using Krakenar.Core.Contents.Events;
using Krakenar.Core.Localization;
using Krakenar.Core.Realms;
using Krakenar.EntityFrameworkCore.Relational;
using Logitar.EventSourcing;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;

namespace SkillCraft.EntityFrameworkCore.Handlers;

internal class RuleContentEvents : IEventHandler<ContentLocalePublished>, IEventHandler<ContentLocaleUnpublished>
{
  private const string Realm = "skillcraft";

  private readonly IEventStore _events;
  private readonly KrakenarContext _krakenar;
  private readonly ILogger<RuleContentEvents> _logger;
  private readonly IMediator _mediator;

  public RuleContentEvents(IEventStore events, KrakenarContext krakenar, ILogger<RuleContentEvents> logger, IMediator mediator)
  {
    _events = events;
    _krakenar = krakenar;
    _logger = logger;
    _mediator = mediator;
  }

  public async Task HandleAsync(ContentLocalePublished @event, CancellationToken cancellationToken)
  {
    Context? context = await ContextualizeAsync(@event, @event.LanguageId, cancellationToken);
    if (context is null)
    {
      return;
    }

    IReadOnlyCollection<DomainEvent> events = await _events.FetchAsync(@event, cancellationToken);
    ContentSnapshot content = new(events);
    ContentLocale? locale;
    if (content.PublishedInvariant is null)
    {
      _logger.LogInformation("Event '{EventType} (Id={Id})' ignored, since the content invariant is not published.", @event.GetType(), @event.Id);
      return;
    }
    else if (!content.PublishedLocales.TryGetValue(context.DefaultLanguageId, out locale))
    {
      _logger.LogInformation("Event '{EventType} (Id={Id})' ignored, since the content default locale is not published.", @event.GetType(), @event.Id);
      return;
    }

    switch (context.Kind)
    {
      case EntityKind.Attribute:
        await _mediator.Publish(new AttributePublished(@event, content.PublishedInvariant, locale), cancellationToken);
        break;
      case EntityKind.Caste:
        await _mediator.Publish(new CastePublished(@event, content.PublishedInvariant, locale), cancellationToken);
        break;
      case EntityKind.Education:
        await _mediator.Publish(new EducationPublished(@event, content.PublishedInvariant, locale), cancellationToken);
        break;
      case EntityKind.Skill:
        await _mediator.Publish(new SkillPublished(@event, content.PublishedInvariant, locale), cancellationToken);
        break;
      case EntityKind.Statistic:
        await _mediator.Publish(new StatisticPublished(@event, content.PublishedInvariant, locale), cancellationToken);
        break;
    }

    _logger.LogInformation("Event '{EventType} (Id={Id})' handled successfully.", @event.GetType(), @event.Id);
  }

  public async Task HandleAsync(ContentLocaleUnpublished @event, CancellationToken cancellationToken)
  {
    Context? context = await ContextualizeAsync(@event, @event.LanguageId, cancellationToken);
    if (context is null)
    {
      return;
    }

    switch (context.Kind)
    {
      case EntityKind.Attribute:
        await _mediator.Publish(new AttributeUnpublished(@event), cancellationToken);
        break;
      case EntityKind.Caste:
        await _mediator.Publish(new CasteUnpublished(@event), cancellationToken);
        break;
      case EntityKind.Education:
        await _mediator.Publish(new EducationUnpublished(@event), cancellationToken);
        break;
      case EntityKind.Skill:
        await _mediator.Publish(new SkillUnpublished(@event), cancellationToken);
        break;
      case EntityKind.Statistic:
        await _mediator.Publish(new StatisticUnpublished(@event), cancellationToken);
        break;
    }

    _logger.LogInformation("Event '{EventType} (Id={Id})' handled successfully.", @event.GetType(), @event.Id);
  }

  private async Task<Context?> ContextualizeAsync(DomainEvent @event, LanguageId? languageId, CancellationToken cancellationToken)
  {
    ContentId contentId = new(@event.StreamId);
    RealmId? realmId = contentId.RealmId;
    if (!realmId.HasValue)
    {
      _logger.LogInformation("Event '{EventType} (Id={Id})' ignored, since it does not belong to a realm.", @event.GetType(), @event.Id);
      return null;
    }

    var data = await _krakenar.Languages.AsNoTracking()
      .Include(x => x.Realm)
      .Where(x => x.Realm!.StreamId == realmId.Value.Value && x.IsDefault)
      .Select(x => new
      {
        Realm = x.Realm!.UniqueSlug,
        DefaultLanguageId = x.StreamId
      })
      .SingleOrDefaultAsync(cancellationToken);
    if (data is null)
    {
      _logger.LogInformation("Event '{EventType} (Id={Id})' ignored, since the default language was not found for realm '{Realm}'.", @event.GetType(), @event.Id, realmId);
      return null;
    }
    else if (!data.Realm.Equals(Realm, StringComparison.InvariantCultureIgnoreCase))
    {
      _logger.LogInformation("Event '{EventType} (Id={Id})' ignored, since it does not belong to the realm '{Expected}' (actual: {Actual}).", @event.GetType(), @event.Id, Realm, data.Realm);
      return null;
    }

    LanguageId defaultLanguageId = new(data.DefaultLanguageId);
    if (languageId.HasValue && languageId.Value != defaultLanguageId)
    {
      _logger.LogInformation("Event '{EventType} (Id={Id})' ignored, since its language '{Language}' is not default ({Default}).", @event.GetType(), @event.Id, languageId, defaultLanguageId);
      return null;
    }

    Guid? languageUid = languageId?.EntityId;
    string? contentType = await _krakenar.ContentLocales.AsNoTracking()
      .Include(x => x.Content).ThenInclude(x => x!.ContentType)
      .Where(x => x.LanguageUid == languageUid && x.Content!.StreamId == contentId.Value)
      .Select(x => x.ContentType!.UniqueName)
      .SingleOrDefaultAsync(cancellationToken);

    if (string.IsNullOrWhiteSpace(contentType) || !Enum.TryParse(contentType, out EntityKind kind))
    {
      _logger.LogInformation("Event '{EventType} (Id={Id})' ignored, since the content type is not materialized.", @event.GetType(), @event.Id);
      return null;
    }

    return new Context(defaultLanguageId, kind);
  }

  private record Context(LanguageId DefaultLanguageId, EntityKind? Kind);
}
