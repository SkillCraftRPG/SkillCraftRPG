<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Enfiler ou retirer une pièce d’armure nécessite un certain temps en fonction de la
      <NuxtLink to="/regles/equipement/armure/categorie">catégorie</NuxtLink> de celle-ci.
    </p>
    <p>
      Pour enfiler toute son armure, le temps nécessaire est la somme du temps pour chaque
      <NuxtLink to="/regles/equipement/armure/partielle">pièce d’armure</NuxtLink>.
    </p>
    <p>
      C’est pourquoi certains aventuriers choisissent de dormir en armure, nuisant ainsi à leur <strong>sommeil</strong>, mais ils sont alors prêts à toute
      éventualité en cas d’escarmouche nocturne.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-33">Catégorie</th>
          <th scope="col" class="w-33">Enfiler</th>
          <th scope="col" class="w-33">Retirer</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Légère</td>
          <td>2 rounds (12 secondes)</td>
          <td>2 rounds (12 secondes)</td>
        </tr>
        <tr>
          <td>Moyenne</td>
          <td>10 rounds (1 minute)</td>
          <td>4 rounds (24 secondes)</td>
        </tr>
        <tr>
          <td>Lourde</td>
          <td>20 rounds (2 minutes)</td>
          <td>10 rounds (1 minute)</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armure", to: "/regles/equipement/armure" },
];
const title: string = "Enfiler ou retirer son armure";

useSeo({
  title,
  description: "Découvrez les temps nécessaires pour enfiler ou retirer chaque pièce d’armure selon sa catégorie, ainsi que leurs implications en jeu.",
});
</script>
