<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Arme</th>
          <th scope="col" class="w-15">Prix (deniers)</th>
          <th scope="col" class="w-15">Poids (kg)</th>
          <th scope="col" class="w-10">Attaque</th>
          <th scope="col" class="w-15">Dégâts</th>
          <th scope="col" class="w-30">Propriétés</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="weapon in items" :key="weapon.id">
          <td>{{ weapon.name }}</td>
          <td>{{ $n(weapon.price, "price") }}</td>
          <td>{{ $n(weapon.weight, "weight") }}</td>
          <td>{{ formatAttack(weapon) }}</td>
          <td v-html="formatDamage(weapon)"></td>
          <td v-html="formatProperties(weapon)"></td>
        </tr>
      </tbody>
    </table>
    <h4 class="h6">Descriptions</h4>
    <ul>
      <li v-for="weapon in items" :key="weapon.id">
        <strong>{{ weapon.name }}.</strong> {{ weapon.description }}
        <ul v-if="weapon.special">
          <li>
            <strong><font-awesome-icon icon="fas fa-flag" /> Spéciale.</strong> {{ weapon.special }}
          </li>
        </ul>
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { stringUtils } from "logitar-js";

import type { Weapon } from "~/types/items";

const { isNullOrWhiteSpace, unaccent } = stringUtils;

defineProps<{
  items: Weapon[];
}>();

function formatAttack(weapon: Weapon): string {
  let attack: number = 2;
  const properties: string[] = weapon.properties.map((property) => unaccent(property.trim().toLowerCase()));
  if (properties.includes("legere")) {
    attack = 1;
  } else if (!isNullOrWhiteSpace(weapon.damage?.versatile ?? "")) {
    attack = 3;
  } else if (properties.includes("deux mains")) {
    attack = 4;
  }
  return $n(attack, "attack");
}

const damageTypes: Map<string, string> = new Map([
  ["Bludgeoning", "Contondant"],
  ["Piercing", "Perçant"],
  ["Slashing", "Tranchant"],
]);
function formatDamage(weapon: Weapon): string {
  if (weapon.damage) {
    const type: string | undefined = damageTypes.get(weapon.damage.type);
    if (type) {
      return [weapon.damage.roll, type].join(" ").toLowerCase();
    }
  }
  return `<span class="text-muted">—</span>`;
}

function formatProperties(weapon: Weapon): string {
  const properties: string[] = [];
  weapon.properties.forEach((property) => {
    switch (property) {
      case "Finesse":
        properties.push("Finesse");
        break;
      case "Heavy":
        properties.push("Lourde");
        break;
      case "Light":
        properties.push("Légère");
        break;
      case "Loading":
        properties.push("Chargement");
        break;
      case "Reach":
        properties.push("Allonge");
        break;
      case "TwoHanded":
        properties.push("Deux mains");
        break;
    }
  });
  if (weapon.ammunition) {
    properties.push(`Munition (${weapon.ammunition.standard}/${weapon.ammunition.long})`);
  }
  if (weapon.reload && weapon.reload > 1) {
    properties.push(`Barillet (${weapon.reload})`);
  }
  if (weapon.special) {
    properties.push("Spéciale");
  }
  if (weapon.thrown) {
    properties.push(`Jet (${weapon.thrown.standard}/${weapon.thrown.long})`);
  }
  if (weapon.damage?.versatile) {
    properties.push(`Versatile (${weapon.damage.versatile})`);
  }
  if (!properties.length) {
    return `<span class="text-muted">—</span>`;
  }
  return properties.sort((a, b) => (a > b ? 1 : a < b ? -1 : 0)).join(", ");
}
</script>
