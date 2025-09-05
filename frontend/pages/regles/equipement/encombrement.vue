<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Une créature peut porter une quantité d’objets et d’équipements limités par le poids de ceux-ci. Le poids d’une autre créature qu’elle porte est également
      limité.
    </p>
    <p>Le poids qu’une créature peut porter sans être encombrée correspond à la <NuxtLink to="/regles/statistiques/charge">Charge</NuxtLink>.</p>
    <p>
      Lorsqu’une créature porte un poids supérieur à cette limite, elle est encombrée. Sa
      <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse de déplacement</NuxtLink> subit une pénalité proportionnelle à l’excès de poids, sans toutefois
      descendre en-deçà d’un point de mouvement.
    </p>
    <p>Afin de calculer cette pénalité :</p>
    <ol>
      <li>Divisez le poids porté par la Charge.</li>
      <li>Retirez 1 de cette valeur.</li>
      <li>Multipliez cette valeur par le nombre de points de mouvement.</li>
      <li>La pénalité doit être inférieure au nombre de points de mouvement.</li>
    </ol>
    <p>
      Par exemple, la Charge d’une créature est de 60, elle porte un poids de 90 kilogrammes, et elle possède 6 points de mouvement. Elle sera donc affligée
      d’une pénalité de 3 points de mouvement, réduisant de moitié sa vitesse. Si elle porte un poids de 120 kilogrammes, cette pénalité sera de 5 points de
      mouvement. Ses déplacements seront donc limités à un seul point de mouvement.
    </p>
    <p>
      La <NuxtLink to="/regles/especes/taille">taille</NuxtLink> d’une créature affecte sa Charge. Une créature appartenant à une catégorie inférieure sera plus
      rapidement encombrée, au contraire d’une créature appartenant à une catégorie supérieure.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Catégorie de taille</th>
          <th scope="col" class="w-50">Facteur de Charge</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>{{ $t("size.category.options.Diminutive") }}</td>
          <td>×¼</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Tiny") }}</td>
          <td>×½</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Small") }}</td>
          <td>×{{ getLoadMultiplier("Small") }}</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Medium") }}</td>
          <td>×{{ getLoadMultiplier("Medium") }}</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Large") }}</td>
          <td>×{{ getLoadMultiplier("Large") }}</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Huge") }}</td>
          <td>×{{ getLoadMultiplier("Huge") }}</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Gargantuan") }}</td>
          <td>×{{ getLoadMultiplier("Gargantuan") }}</td>
        </tr>
        <tr>
          <td>{{ $t("size.category.options.Colossal") }}</td>
          <td>×{{ getLoadMultiplier("Colossal") }}</td>
        </tr>
      </tbody>
    </table>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Encombrement";

useSeo({
  title,
  description: "Découvrez comment calculer la charge maximale qu’une créature peut porter et les pénalités de mouvement en cas d’encombrement.",
});
</script>
