﻿using Krakenar.Core.Contents;
using SkillCraft.Core;
using SkillCraft.EntityFrameworkCore.Handlers.Materialization;
using AggregateEntity = Krakenar.EntityFrameworkCore.Relational.Entities.Aggregate;

namespace SkillCraft.EntityFrameworkCore.Entities.Rules;

internal class CustomizationEntity : AggregateEntity
{
  public int CustomizationId { get; private set; }
  public Guid Id { get; private set; }

  public string Slug { get; private set; } = string.Empty;
  public CustomizationKind Kind { get; private set; }

  public string Name { get; private set; } = string.Empty;
  public string? Summary { get; private set; }
  public string? Description { get; private set; }

  public CustomizationEntity(CustomizationPublished published) : base(published.Event)
  {
    Id = new ContentId(published.Event.StreamId).EntityId;

    Update(published);
  }

  private CustomizationEntity() : base()
  {
  }

  public void Update(CustomizationPublished published)
  {
    base.Update(published.Event);

    ContentLocale invariant = published.Invariant;
    ContentLocale locale = published.Locale;

    Slug = locale.FindStringValue(Fields.Customizations.Slug).ToLowerInvariant();

    IReadOnlyCollection<string> kinds = invariant.FindSelectValue(Fields.Customizations.Kind);
    if (kinds.Count == 1)
    {
      Kind = Enum.Parse<CustomizationKind>(kinds.Single());
    }
    else
    {
      throw new NotImplementedException(); // TODO(fpion): implement
    }

    Name = locale.DisplayName?.Value ?? locale.UniqueName.Value;
    Summary = locale.TryGetStringValue(Fields.Customizations.Summary);
    Description = locale.TryGetStringValue(Fields.Customizations.Description);
  }
}
