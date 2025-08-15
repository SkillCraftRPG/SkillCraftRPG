import type { DamageType } from "./game";

export type Ammunition = Item & {
  weapons: string;
  container: Container;
};

export type Armor = Item & {
  category: ArmorCategory;
  defense: number;
  resistance: number;
  properties: ArmorProperty[];
};

export type ArmorCategory = "Light" | "Medium" | "Heavy";

export type ArmorProperty = "Bulwark" | "Comfortable" | "Firm" | "Hybrid" | "Noisy" | "Quilted";

export type Container = Item & {
  volume?: ContainerVolume;
  capacity?: number | null;
};

export type ContainerVolume = {
  value: number;
  unit: string;
};

export type Goods = Item & {
  category: GoodsCategory;
};

export type GoodsCategory = "Cattle" | "Food" | "Metal" | "Spice" | "Textile";

export type Item = {
  id: string;
  slug: string;
  name: string;
  price: number;
  weight: number;
  description: string;
};

export type SelectionItem = Item & {
  quantity: number;
};

export type Shield = Item & {
  category: string;
  defense: ShieldDefense;
  resistance: number;
  properties: ShieldProperty[];
};

export type ShieldDefense = {
  standard: number;
  raised?: number | null;
};

export type ShieldProperty = "Bulwark" | "Noisy";

export type Tool = Item & {
  category: ToolCategory;
};

export type ToolCategory = "Crafting" | "PlayingSet" | "MusicalInstrument";

export type Weapon = Item & {
  category: WeaponCategory;
  damage?: WeaponDamage | null;
  ammunition?: WeaponRange | null;
  reload?: number | null;
  special?: string | null;
  thrown?: WeaponRange | null;
  properties: WeaponProperty[];
};

export type WeaponCategory = "Simple" | "Martial";

export type WeaponDamage = {
  roll: string;
  versatile?: string | null;
  type: DamageType;
};

export type WeaponProperty = "Heavy" | "Finesse" | "Light" | "Loading" | "Reach" | "TwoHanded";

export type WeaponRange = {
  standard: number;
  long: number;
};
