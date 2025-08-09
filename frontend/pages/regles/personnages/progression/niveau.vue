<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le niveau d’un personnage est une valeur progressant généralement de 0 à 100. Il augmente lorsque l’<NuxtLink
        to="/regles/personnages/progression/experience"
        >expérience</NuxtLink
      >
      du personnage atteint un certain seuil.
    </p>
    <p>Lorsque le niveau du personnage augmente, ses capacités augmentent également.</p>
    <ul>
      <li>
        Lorsqu’il atteint le niveau 5 et à chaque tranche suivante de dix niveaux (5, 15, 25, 35, 45, 55, 65, 75, 85, 95), il obtient
        <strong>1 point d’attribut</strong>. Il peut le dépenser afin d’augmenter la valeur d’un <NuxtLink to="/regles/attributs">attribut</NuxtLink> de 1.
      </li>
      <li>
        Les <NuxtLink to="/regles/statistiques">statistiques</NuxtLink> suivantes augmentent :
        <NuxtLink to="/regles/statistiques/apprentissage">Apprentissage</NuxtLink>, <NuxtLink to="/regles/statistiques/energie">Énergie</NuxtLink> et
        <NuxtLink to="/regles/statistiques/vitalite">Vitalité</NuxtLink>.
      </li>
      <li>
        Ses <strong>points de compétence</strong> augmentent afin de refléter sa nouvelle valeur d’Apprentissage. Il peut dépenser ces points afin d’augmenter
        le <NuxtLink to="/regles/competences/rang">rang</NuxtLink> de ses <NuxtLink to="/regles/competences">compétences</NuxtLink>.
      </li>
      <li>
        Il reçoit <strong>1 point de talent</strong>. Il peut dépenser celui-ci afin d’acquérir un nouveau <NuxtLink to="/regles/talents">talent</NuxtLink> ou
        <NuxtLink to="/regles/pouvoirs">pouvoir</NuxtLink>.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const title: string = "Niveau";

const parent = computed<Breadcrumb[]>(() => [
  { text: "Personnages", to: "/regles/personnages" },
  { text: "Progression", to: "/regles/personnages/progression" },
]);

useSeo({
  title,
  description: "Le niveau reflète la progression globale du personnage et améliore ses attributs, statistiques, compétences, talents et pouvoirs.",
});
</script>
