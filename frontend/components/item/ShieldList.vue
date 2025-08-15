<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Bouclier</th>
          <th scope="col" class="w-15">Prix (deniers)</th>
          <th scope="col" class="w-15">Poids (kg)</th>
          <th scope="col" class="w-15">Défense</th>
          <th scope="col" class="w-15">Résistance</th>
          <th scope="col" class="w-25">Propriétés</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="shield in items" :key="shield.id">
          <td>{{ shield.name }}</td>
          <td>{{ $n(shield.price, "price") }}</td>
          <td>{{ $n(shield.weight, "weight") }}</td>
          <td>
            {{ $n(shield.defense.standard, "defense") }}
            <template v-if="shield.defense.raised"> ou {{ $n(shield.defense.raised, "defense") }} (levé) </template>
          </td>
          <td>{{ $n(shield.resistance, "resistance") }}</td>
          <td v-html="formatProperties(shield)"></td>
        </tr>
      </tbody>
    </table>
    <h4 class="h6">Descriptions</h4>
    <ul>
      <li v-for="shield in items" :key="shield.id">
        <strong>{{ shield.name }}.</strong> {{ shield.description }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import type { Shield } from "~/types/items";

defineProps<{
  items: Shield[];
}>();

function formatProperties(shield: Shield): string {
  const properties: string[] = [];
  shield.properties.forEach((property) => {
    switch (property) {
      case "Bulwark":
        properties.push("Rempart");
        break;
      case "Noisy":
        properties.push("Bruyant");
        break;
    }
  });
  if (!properties.length) {
    return `<span class="text-muted">—</span>`;
  }
  return properties.sort((a, b) => (a > b ? 1 : a < b ? -1 : 0)).join(", ");
}
</script>
