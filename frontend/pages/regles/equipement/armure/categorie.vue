<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les armures sont réparties en trois catégories :</p>
    <ul>
      <li><strong>Légères.</strong> Des protections minces au poids léger qui ne restreignent pratiquement pas.</li>
      <li><strong>Moyennes.</strong> Ces armures offrent le meilleur compromis entre protection et mobilité.</li>
      <li><strong>Lourdes.</strong> Ces armures offrent une protection maximale, au prix d’un poids élevé ou d’une mobilité réduite.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armure", to: "/regles/equipement/armure" },
];
const title: string = "Catégories d’armure";

useSeo({
  title,
  description: "Découvrez les trois catégories d’armure : légères, moyennes et lourdes, et leurs caractéristiques.",
});
</script>
