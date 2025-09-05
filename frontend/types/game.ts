export type Actions = {
  mandatory: number;
  optional: number;
  reaction: boolean;
};

export type Activity = {
  id: string;
  path: string;
  name: string;
  actions: Actions;
  threatening: boolean | "maybe";
  summary: string;
};

export type Actor = {
  realmId?: string | null;
  type: ActorType;
  id: string;
  isDeleted: boolean;
  displayName: string;
  emailAddress?: string | null;
  pictureUrl?: string | null;
};

export type ActorType = "System" | "ApiKey" | "User";

export type Aggregate = {
  id: string;
  version: number;
  createdBy: Actor;
  createdOn: string;
  updatedBy: Actor;
  updatedOn: string;
};

export type Attribute = {
  id: string;
  slug: string;
  value: GameAttribute;
  category?: AttributeCategory | null;
  name: string;
  summary?: string | null;
  description?: string | null;
  notes?: string | null;
  statistics: Statistic[];
  skills: Skill[];
};

export type AttributeCategory = "Mental" | "Physical";

export type Caste = {
  id: string;
  slug: string;
  name: string;
  skillId: string;
  skill?: Skill | null;
  wealthRoll: string;
  summary?: string | null;
  description?: string | null;
  feature?: Feature | null;
  notes?: string | null;
};

export type Customization = {
  id: string;
  kind: CustomizationKind;
  slug: string;
  name: string;
  summary?: string | null;
  description?: string | null;
  notes?: string | null;
};

export type CustomizationKind = "Disability" | "Gift";

export type DamageType = "Bludgeoning" | "Piercing" | "Slashing";

export type Feature = {
  name: string;
  description?: string | null;
};

export type Education = {
  id: string;
  slug: string;
  name: string;
  skillId: string;
  skill?: Skill | null;
  wealthMultiplier: number;
  summary?: string | null;
  description?: string | null;
  feature?: Feature | null;
  notes?: string | null;
};

export type GameAttribute = "Dexterity" | "Health" | "Intellect" | "Senses" | "Vigor";

export type GameSkill =
  | "Acrobatics"
  | "Athletics"
  | "Crafting"
  | "Deception"
  | "Diplomacy"
  | "Discipline"
  | "Insight"
  | "Investigation"
  | "Knowledge"
  | "Linguistics"
  | "Medicine"
  | "Melee"
  | "Occultism"
  | "Orientation"
  | "Perception"
  | "Performance"
  | "Resistance"
  | "Stealth"
  | "Survival"
  | "Thievery";

export type GameStatistic = "Dodge" | "Encumbrance" | "Initiative" | "Learning" | "Power" | "Precision" | "Stamina" | "Stratagem" | "Strength" | "Vitality";

export type SearchResults<T> = {
  items: T[];
  total: number;
};

export type SizeCategory = "Diminutive" | "Tiny" | "Small" | "Medium" | "Large" | "Huge" | "Gargantuan" | "Colossal";

export type Skill = {
  id: string;
  slug: string;
  value: GameSkill;
  name: string;
  attributeId?: string | null;
  attribute?: Attribute | null;
  summary?: string | null;
  description?: string | null;
  notes?: string | null;
};

export type Statistic = {
  id: string;
  slug: string;
  value: GameStatistic;
  name: string;
  attributeId: string;
  attribute?: Attribute | null;
  summary?: string | null;
  description?: string | null;
  notes?: string | null;
};

export type Talent = {
  id: string;
  tier: number;
  slug: string;
  name: string;
  allowMultiplePurchases: boolean;
  skillId?: string | null;
  skill?: Skill | null;
  requiredTalentId?: string | null;
  requiredTalent?: Talent | null;
  requiringTalents: Talent[];
  summary?: string | null;
  description?: string | null;
  notes?: string | null;
};
