<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Attentif" :parent="parent" />
    <p>Une créature peut être attentive à son environnement pendant un déplacement.</p>
    <ul>
      <li>
        En situation de combat ou de tour-par-tour, elle peut percevoir activement par l’action
        <NuxtLink to="/regles/combat/activites/chercher">Chercher</NuxtLink>. Elle effectue alors un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de
        <NuxtLink to="/regles/competences/perception">Perception</NuxtLink>.
      </li>
      <li>
        En période de voyage, elle effectue un <NuxtLink to="/regles/competences/tests/passif">test passif</NuxtLink> de Perception. Le test est effectué en
        secret par le maître de jeu afin de ne pas alerter les joueurs s’il échoue.
      </li>
    </ul>
    <p>Si la créature se déplace rapidement, alors elle subit une pénalité à ce test.</p>
    <ul>
      <li>
        En situation de combat ou de tour-par-tour, si elle <NuxtLink to="/regles/aventure/mouvement/types">court</NuxtLink>, son test est affligé du
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>.
      </li>
      <li>
        En période de voyage, son test passif subit une pénalité (-5) si elle se déplace à
        <NuxtLink to="/regles/aventure/mouvement/voyage">cadence hâtive</NuxtLink>.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Déplacement attentif";

useSeo({
  title,
  description:
    "Découvrez les règles de l’état attentif : perception active en combat, tests passifs en voyage, et pénalités liées à la vitesse de déplacement.",
});
</script>
