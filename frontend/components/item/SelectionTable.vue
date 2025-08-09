<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-25">Article</th>
        <th scope="col" class="w-25">Quantité</th>
        <th scope="col" class="w-25">Prix (deniers)</th>
        <th scope="col" class="w-25">Poids (kg)</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in filteredItems" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ $n(item.quantity, "integer") }}</td>
        <td>{{ $n(item.price, "price") }}</td>
        <td>{{ $n(item.weight, "weight") }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { SelectionItem } from "~/types/items";

const { orderBy } = arrayUtils;

const props = defineProps<{
  items: SelectionItem[];
}>();

const filteredItems = computed<SelectionItem[]>(() => orderBy(props.items, "name"));
</script>
