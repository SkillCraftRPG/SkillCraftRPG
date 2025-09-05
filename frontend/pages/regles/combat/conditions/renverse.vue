<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature renversée ne peut <strong>se déplacer</strong> qu’en <NuxtLink to="/regles/aventure/mouvement/types">rampant</NuxtLink>. Elle met fin à la
      condition en <NuxtLink to="/regles/aventure/mouvement/types">se relevant</NuxtLink>.
    </p>
    <ul>
      <li>
        Les <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> de cette créature sont affligées du
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
      </li>
      <li>
        Les <strong>attaques de mêlée</strong> dirigées contre cette créature se voient conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage"
          >avantage</NuxtLink
        >.
      </li>
      <li>
        Les <strong>attaques à distance</strong> dirigées contre cette créature sont affligées du
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
const title: string = "Renversé";

useSeo({
  title,
  description:
    "Découvrez la condition Renversé : une créature rampante subit désavantage à ses attaques et aux tirs, mais les attaques de mêlée contre elle gagnent avantage.",
});
</script>
