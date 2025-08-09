<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <!-- TODO(fpion): explanation text -->
    <p>{{ "[…]" }}</p>
  </main>
</template>

<script setup lang="ts">
const title: string = "Taille";

useSeo({
  title,
  description: "", // TODO(fpion): meta description
});
</script>
