<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les armures sont composées de plusieurs morceaux. À des fins de simplification, on peut diviser la majorité des armures en six morceaux : tête, torse,
      deux bras ainsi que deux jambes.
    </p>
    <p>
      Un personnage porte une armure complète lorsqu’il porte tous les morceaux. Au contraire, il porte une armure partielle dès qu’il lui manque une pièce.
    </p>
    <p>
      Les armures achetées chez un marchand aux prix indiqués sont généralement vendues complètes. Les pièces d’armure peuvent faire partie d’un butin ou être
      la récompense d’une quête. Un personnage peut également assembler une armure un morceau à la fois.
    </p>
    <p>
      Il également possible de porter des morceaux de différents types et <NuxtLink to="/regles/equipement/armure/categorie">catégories</NuxtLink> d’armure.
    </p>
    <p>Lorsqu’une armure partielle est portée, elle offre moins de <strong>Défense</strong> qu’une armure complète.</p>
    <p>On calcule ce nombre de points de Défense par une règle de trois, en additionnant les types d’armures, puis on tronque le résultat final.</p>
    <h2 class="h3">Exemples</h2>
    <ul>
      <li>
        Supposons une armure conférant 3 points de Défense. Si le personnage n’en porte que les jambières (2 sur 6 pièces), alors son armure lui confère 1 point
        de Défense.
        <br />
        <code>2 pièces portées ÷ 6 pièces × 3 points de Défense = 1 point de Défense</code>
      </li>
      <li>
        Supposons une armure conférant 8 points de Défense. Si le personnage porte seulement le torse, alors son armure ne lui confère qu’un seul point de
        Défense. S’il porte 5 morceaux sur 6 de cette armure, par exemple toutes pièces sauf le casque, son armure lui confère 6 points de Défense.
        <br />
        <code>1 pièce portée ÷ 6 pièces × 8 points de Défense = 1 point de Défense</code>
        <br />
        <code>5 pièces portées ÷ 6 pièces × 8 points de Défense = 6 point de Défense</code>
      </li>
      <li>
        Supposons une armure conférant 5 points et une armure conférant 3 points de Défense. Si le personnage porte 2 pièces de la première (par exemple, les
        jambières) et 3 pièces de la deuxième (par exemple, les protections des bras et du torse), alors ces deux armures partielles lui confèrent un total de 3
        points de Défense.
        <br />
        <code>(2 pièces portées ÷ 6 pièces × 5 points de Défense) + (3 pièces portées ÷ 6 pièces × 3 points de Défense) = 3 points de Défense</code>
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armure", to: "/regles/equipement/armure" },
];
const title: string = "Armure partielle";

useSeo({
  title,
  description: "Découvrez comment calculer la Défense des armures partielles en combinant différents morceaux et types d’équipement.",
});
</script>
