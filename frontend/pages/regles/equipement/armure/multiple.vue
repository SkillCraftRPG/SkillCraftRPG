<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Un personnage possédant la formation appropriée peut porter deux armures simultanément.</p>
    <p>Il est impossible de porter deux couches d’armure appartenant à la même <NuxtLink to="/regles/equipement/armure/categorie">catégorie</NuxtLink>.</p>
    <p>
      Lorsqu’un personnage porte deux couches d’armure, les morceaux de l’armure appartenant à la catégorie la plus légère n’offrent que la moitié des
      <strong>points de Défense</strong>.
    </p>
    <p>
      S’il porte deux armures <NuxtLink to="/regles/equipement/armure/partielle">complètes</NuxtLink>, alors il bénéficie des
      <NuxtLink to="/regles/equipement/armure/proprietes">propriétés</NuxtLink> combinées des deux armures.
    </p>
    <p>Le talent suivant forme le personnage au port de deux couches d’armure :</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armure", to: "/regles/equipement/armure" },
];
const title: string = "Armures multiples";

useSeo({
  title,
  description: "Découvrez les règles pour porter deux couches d’armure et combiner leurs effets.",
});

// TODO(fpion): /regles/talents/blinde
// TODO(fpion): exemple(s)
</script>
