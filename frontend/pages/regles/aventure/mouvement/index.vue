<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les mouvements en jeu peuvent être représentés par une grille carrée ou hexagonale.</p>
    <ul>
      <li>L’arête de chaque case de la grille carrée mesure <strong>1,5 mètres</strong>.</li>
      <li>La distance entre le centre de deux cases adjacentes de la grille hexagonale mesure <strong>1,5 mètres</strong>.</li>
    </ul>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Aventure", to: "/regles/aventure" }];
const title: string = "Mouvement";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/aventure/mouvement/vitesse",
    title: "Vitesse",
    description: "Vitesse en combat : m/s, points de mouvement, distances et effets du terrain.",
  },
  {
    path: "/regles/aventure/mouvement/types",
    title: "Types de mouvement",
    description: "Les divers types de mouvement : marche, vol, nage et plus.",
  },
  {
    path: "/regles/aventure/mouvement/voyage",
    title: "Voyage",
    description: "Voyage en jeu : cadences, lieue, marche forcée et activités.",
  },
  {
    path: "/regles/aventure/mouvement/furtif",
    title: "Déplacement furtif",
    description: "Règles du déplacement furtif : tests, vitesse réduite, points de mouvement et cadence.",
  },
  {
    path: "/regles/aventure/mouvement/attentif",
    title: "Déplacement attentif",
    description: "Règles de l’état attentif : perception active ou passive et pénalités.",
  },
  {
    path: "/regles/aventure/mouvement/terrain-difficile",
    title: "Terrain difficile",
    description: "Terrain difficile : déplacements ralentis, risques accrus et pénalités.",
  },
  {
    path: "/regles/aventure/mouvement/espace-occupe",
    title: "Espace occupé",
    description: "Tableau des tailles et espace occupé (carrés/hexagones) avec règles de mouvement.",
  },
];

useSeo({
  title,
  description:
    "Découvrez les règles de déplacement des créatures : vitesse, cadence, types de mouvement, terrain difficile, furtivité et perception en voyage.",
});

// TODO(fpion): retirer toute mention de "case adjacent(e)" des règles
// TODO(fpion): free item interaction
</script>
