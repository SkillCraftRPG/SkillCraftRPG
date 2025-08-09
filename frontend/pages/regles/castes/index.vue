<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Les castes représentent les différentes classes sociales composant le tissu sociétaire.</p>
    <p>Le joueur assigne une caste à son personnage au moment de sa <NuxtLink to="/regles/personnages/creation">création</NuxtLink>.</p>
    <p>
      Chaque caste définit une <NuxtLink to="/regles/competences">compétence</NuxtLink> pour laquelle le personnage est
      <NuxtLink to="/regles/competences/formation">formé</NuxtLink>, un jet de dés permettant de déterminer sa
      <NuxtLink to="/regles/equipement/depart">richesse de départ</NuxtLink>, ainsi qu’une particularité qui lui est propre.
    </p>
    <CasteList v-if="castes.length" :items="castes" />
  </main>
</template>

<script setup lang="ts">
import type { Caste, SearchResults } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Castes";

const { data } = await useFetch("/api/castes", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const castes = computed<Caste[]>(() => (data.value as SearchResults<Caste>)?.items ?? []);

useSeo({
  title,
  description: "Les castes définissent la position sociale d’un personnage, sa compétence de départ, sa richesse initiale et une particularité unique.",
});
</script>
