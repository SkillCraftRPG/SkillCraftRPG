<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature invisible ne peut être vue sans l’aide de la magie ou de la
      <NuxtLink to="/regles/aventure/environnement/vision">vision absolue</NuxtLink>.
    </p>
    <p>
      Elle est considérée comme <NuxtLink to="/regles/aventure/environnement/vision">lourdement obscurcie</NuxtLink> lorsqu'elle tente de
      <NuxtLink to="/regles/combat/activites/cacher">se cacher</NuxtLink>. Sa position peut être révélée si elle laisse des traces ou si elle fait du bruit en
      se déplaçant.
    </p>
    <p>
      Les <NuxtLink to="/regles/combat/attaque">attaques</NuxtLink> de la créature sont effectuées avec
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink>, et les attaques la prenant pour cible sont affligées du
      <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Invisible";

useSeo({
  title,
  description:
    "Découvrez la condition Invisible : avantages aux attaques, désavantages pour l’ennemi, et règles pour détecter une créature dissimulée par magie.",
});
</script>
