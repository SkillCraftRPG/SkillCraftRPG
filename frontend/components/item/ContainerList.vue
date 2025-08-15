<template>
  <table class="table table-striped text-center">
    <thead>
      <tr>
        <th scope="col" class="w-10">Nom</th>
        <th scope="col" class="w-10">Prix (deniers)</th>
        <th scope="col" class="w-10">Poids (kg)</th>
        <th scope="col" class="w-10">Volume</th>
        <th scope="col" class="w-10">Capacité (kg)</th>
        <th scope="col" class="w-50">Description</th>
      </tr>
    </thead>
    <tbody>
      <tr v-for="item in items" :key="item.id">
        <td>{{ item.name }}</td>
        <td>{{ $n(item.price, "price") }}</td>
        <td>{{ $n(item.weight, "weight") }}</td>
        <td>
          <template v-if="item.volume">{{ $n(item.volume.value, "volume") }} {{ item.volume.unit }}</template>
          <span v-else class="text-muted">{{ "—" }}</span>
        </td>
        <td>
          <template v-if="item.capacity">{{ $n(item.capacity, "capacity") }}</template>
          <span v-else class="text-muted">{{ "—" }}</span>
        </td>
        <td>{{ item.description }}</td>
      </tr>
    </tbody>
  </table>
</template>

<script setup lang="ts">
import type { Container } from "~/types/items";

defineProps<{
  items: Container[];
}>();
</script>
