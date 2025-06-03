﻿using Krakenar.Contracts.Contents;

namespace SkillCraft.Seeding.Krakenar.Payloads;

internal record ContentTypePayload : CreateOrReplaceContentTypePayload
{
  public Guid Id { get; set; }

  public List<FieldDefinitionPayload> Fields { get; set; } = [];
}
