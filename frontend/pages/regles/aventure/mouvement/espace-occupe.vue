<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature occupe un espace déterminé en fonction de sa <NuxtLink to="/regles/especes/taille">taille</NuxtLink>, tel qu’illustré dans le tableau
      ci-dessous.
    </p>
    <p>Une créature de grande taille occupera plusieurs cases, tandis que plusieurs créatures de petite taille peuvent partager la même case.</p>
    <p>
      Une case occupée par une créature de taille moyenne ou supérieure est considérée comme du
      <NuxtLink to="/regles/aventure/mouvement/terrain-difficile">terrain difficile</NuxtLink>.
    </p>
    <p>
      Une créature ne peut arrêter son <strong>déplacement</strong> dans une case occupée par une autre créature, sauf si la taille des créatures le permet.
    </p>
    <p>
      Une créature ne peut également pas traverser une case occupée par une créature hostile, sauf si la différence entre leur taille est d’au moins deux
      catégories. Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/culbutes">Culbutes</NuxtLink> permet d’outrepasser cette
      restriction.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-third">Catégorie de taille</th>
          <th scope="col" class="w-third">Espace occupé (carrés)</th>
          <th scope="col" class="w-third">Espace occupé (hexagones)</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{{ $t("size.category.options.Diminutive") }}</td>
          <td>¼</td>
          <td>¼</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Tiny") }}</td>
          <td>½</td>
          <td>½</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Small") }}</td>
          <td>1</td>
          <td>1</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Medium") }}</td>
          <td>1</td>
          <td>1</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Large") }}</td>
          <td>2 × 2 (4)</td>
          <td>3</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Huge") }}</td>
          <td>3 × 3 (9)</td>
          <td>7</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Gargantuan") }}</td>
          <td>4 × 4 (16)</td>
          <td>12</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Colossal") }}</td>
          <td>5 × 5 (25) et plus</td>
          <td>30 et plus</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Espace occupé";

useSeo({
  title,
  description:
    "Découvrez comment chaque catégorie de taille influence l’espace occupé sur la grille, en carrés ou hexagones, avec règles de mouvement associées.",
});
</script>
