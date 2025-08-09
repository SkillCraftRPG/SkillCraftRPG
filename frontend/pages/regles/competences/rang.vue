<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le rang d’une <NuxtLink to="/regles/competences">compétence</NuxtLink> est similaire au
      <NuxtLink to="/regles/personnages/progression/niveau">niveau</NuxtLink> d’un personnage. Il est ajouté aux
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de cette compétence. Seulement la moitié du rang est ajoutée si le personnage n’est pas
      <NuxtLink to="/regles/competences/formation">formé</NuxtLink>
      pour cette compétence.
    </p>
    <p>
      Un personnage possède un nombre de points de compétence égal à son <NuxtLink to="/regles/statistiques/apprentissage">Apprentissage</NuxtLink>. Il peut
      dépenser un point afin d’augmenter de 1 le rang d’une compétence.
    </p>
    <p>
      Lorsqu’un personnage acquiert un <NuxtLink to="/regles/talents">talent</NuxtLink> associé à une compétence, le rang de celle-ci augmente de 1. Si le rang
      maximal était atteint avant l’acquisition, le personnage récupère un point de compétence qu’il peut dépenser afin d’augmenter le rang d’une aure
      compétence.
    </p>
    <p>Le rang maximal des compétences d’un personnage est défini par son <NuxtLink to="/regles/personnages/progression/tiers">tiers</NuxtLink>.</p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Tiers du personnage</th>
          <th scope="col" class="w-50">Rang maximal</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>0</td>
          <td>2</td>
        </tr>
        <tr>
          <td>1</td>
          <td>5</td>
        </tr>
        <tr>
          <td>2</td>
          <td>9</td>
        </tr>
        <tr>
          <td>3</td>
          <td>14</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Compétences", to: "/regles/competences" }];
const title: string = "Rang de compétence";

useSeo({
  title,
  description: "Découvrez comment les rangs de compétence influencent les tests, leur progression, le rôle des talents et les limites fixées par les tiers.",
});
</script>
