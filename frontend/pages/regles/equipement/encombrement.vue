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
      Lorsqu’une créature porte un poids supérieur à cette limite, elle est encombrée. Sa vitesse de déplacement subit une pénalité proportionnelle à l’excès de
      poids, sans toutefois descendre en-deçà d’un point de mouvement.
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
          <td>Infime</td>
          <td>×¼</td>
        </tr>
        <tr>
          <td>Minuscule</td>
          <td>×½</td>
        </tr>
        <tr>
          <td>Petite</td>
          <td>×1</td>
        </tr>
        <tr>
          <td>Moyenne</td>
          <td>×1</td>
        </tr>
        <tr>
          <td>Grande</td>
          <td>×2</td>
        </tr>
        <tr>
          <td>Énorme</td>
          <td>×3</td>
        </tr>
        <tr>
          <td>Gigantesque</td>
          <td>×4</td>
        </tr>
        <tr>
          <td>Colossale</td>
          <td>×8</td>
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
