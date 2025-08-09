<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les tiers de personnage représentent des paliers de progression importants. Ils sont des échelons catégorisant l’ampleur des objectifs et intérêts des
      personnages. Un tiers plus élevé signifie des aventures plus éprouvantes et plus dangereuses.
    </p>
    <h2 class="h3">Limites</h2>
    <p>Le tiers limite les capacités maximales du personnage, tel que décrit ci-dessous.</p>
    <ul>
      <li>
        Le <NuxtLink to="/regles/competences/rang">rang maximal</NuxtLink> de ses <NuxtLink to="/regles/competences">compétences</NuxtLink> est limité par son
        tiers.
      </li>
      <li>Il ne peut acquérir des <NuxtLink to="/regles/talents">talents</NuxtLink> dont le tiers est supérieur au sien.</li>
      <li>De la même manière, il ne peut acquérir des <NuxtLink to="/regles/pouvoirs">pouvoirs</NuxtLink> dont le tiers est supérieur au sien.</li>
      <li>
        Il ne peut se spécialiser si le tiers de la <NuxtLink to="/regles/specialisations">spécialisation</NuxtLink> convoitée est plus élevé de deux tiers ou
        plus que le sien.
      </li>
    </ul>
    <h2 class="h3">Augmentation</h2>
    <p>
      Afin d’augmenter son tiers, un personnage doit se spécialiser. Lorsqu’il en fait ainsi, son tiers augmente à la même valeur que le tiers de la
      spécialisation acquise.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const title: string = "Tiers";

const parent = computed<Breadcrumb[]>(() => [
  { text: "Personnages", to: "/regles/personnages" },
  { text: "Progression", to: "/regles/personnages/progression" },
]);

useSeo({
  title,
  description: "Les tiers de personnage marquent des étapes clés de progression et fixent les limites des talents, compétences et pouvoirs accessibles.",
});
</script>
