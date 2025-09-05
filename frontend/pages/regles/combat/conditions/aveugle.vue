<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature aveuglée ne voit rien.</p>
    <ul>
      <li>
        Elle échoue automatiquement les <NuxtLink to="/regles/competences/tests">tests</NuxtLink> requérant la
        <NuxtLink to="/regles/aventure/environnement/vision">vue</NuxtLink>.
      </li>
      <li>
        Les <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> dirigées contre la créature sont effectuées avec
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink>.
      </li>
      <li>
        Les <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> de la créature sont affligées du
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Aveuglé";

useSeo({
  title,
  description:
    "Découvrez les effets de l’aveuglement en combat : échec automatique des tests visuels, attaques subies avec avantage et désavantage aux attaques.",
});
</script>
