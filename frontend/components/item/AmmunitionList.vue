<template>
  <div>
    <h3 class="h5">Munitions</h3>
    <p>
      La table ci-dessous spécifie les munitions nécessaires pour les armes dotées de la propriété <strong>Munition</strong>, ainsi que le contenant pour ces
      munitions.
    </p>
    <p>Un personnage doit posséder le bon contenant pour chaque type de munition. Chaque contenant peut contenir un nombre maximal de munitions.</p>
    <p>Lorsqu’il perd toutes ses munitions, le personnage n’a besoin que de racheter celles-ci, il conserve le contenant qu’il possède déjà.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-eighth">Munition</th>
          <th scope="col" class="w-eighth">Prix (deniers)</th>
          <th scope="col" class="w-eighth">Poids (kg)</th>
          <th scope="col" class="w-eighth">Armes</th>
          <th scope="col" class="w-eighth">Contenant</th>
          <th scope="col" class="w-eighth">Prix (deniers)</th>
          <th scope="col" class="w-eighth">Poids (kg)</th>
          <th scope="col" class="w-eighth">Capacité</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="item in items" :key="item.id">
          <td>{{ item.name }}</td>
          <td>{{ $n(item.price, "price") }}</td>
          <td>{{ $n(item.weight, "weight") }}</td>
          <td>{{ item.weapons }}</td>
          <td>{{ item.container.name }}</td>
          <td>{{ $n(item.container.price, "price") }}</td>
          <td>{{ $n(item.container.weight, "weight") }}</td>
          <td>
            <template v-if="item.container.capacity">{{ $n(item.container.capacity, "capacity") }}</template>
            <span v-else class="text-muted">{{ "—" }}</span>
          </td>
        </tr>
      </tbody>
    </table>
    <h4 class="h6">Descriptions</h4>
    <ul>
      <li v-for="item in allItems" :key="item.id">
        <strong>{{ item.name }}.</strong> {{ item.description }}
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Ammunition, Item } from "~/types/items";

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: Ammunition[];
}>();

const allItems = computed<Item[]>(() => {
  const items: Item[] = [...props.items];
  props.items.forEach((ammunition) => items.push(ammunition.container));
  return orderBy(items, "slug");
});
</script>
