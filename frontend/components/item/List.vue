<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-20">Nom</th>
        <th scope="col" class="w-10">Prix (deniers)</th>
        <th scope="col" class="w-10">Poids (kg)</th>
        <th scope="col" class="w-60">Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ $n(item.price, "price") }}</td>
        <td>{{ $n(item.weight, "weight") }}</td>
        <td>{{ item.description }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { Item } from "~/types/items";

defineProps<{
  items: Item[];
}>();
</script>
