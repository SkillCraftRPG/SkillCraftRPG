<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>
      Les compétences sont des aptitudes et savoir-faire des personnages et créatures. Elles régissent leurs actions en jeu, influençant leur probabilité de
      réussite.
    </p>
    <p>
      La plupart des compétences sont associées à un <NuxtLink to="/regles/attributs">attribut</NuxtLink>. L’attribut d’autres compétences varie en fonction de
      la situation. Cet attribut intervient en ajoutant un bonus ou une pénalité au test d’une compétence.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <template v-if="skills.length">
      <h2 class="h3">Liste des compétences</h2>
      <SkillList :items="skills" />
    </template>
  </main>
</template>

<script setup lang="ts">
import type { SearchResults, Skill } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Compétences";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/competences/formation",
    title: "Formation",
    description: "Rôle et effets de la formation aux compétences.",
  },
  {
    path: "/regles/competences/rang",
    title: "Rang",
    description: "Fonctionnement et progression des rangs de compétence.",
  },
  {
    path: "/regles/competences/tests",
    title: "Tests",
    description: "Permet de déterminer si une action intentée est une réussite ou un échec.",
  },
  {
    path: "/regles/competences/esperance-damnation",
    title: "Espérance et Damnation",
    description: "Permettent aux joueurs et au maître de jeu d’influencer l’histoire.",
  },
];

const { data } = await useFetch("/api/skills", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const skills = computed<Skill[]>(() => (data.value as SearchResults<Skill>)?.items ?? []);

useSeo({
  title,
  description: "Découvrez comment les compétences traduisent les savoir-faire, aptitudes et expertises de vos héros.",
});
</script>
