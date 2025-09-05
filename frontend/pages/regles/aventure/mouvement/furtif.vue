<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Furtif" :parent="parent" />
    <p>
      Une créature peut <NuxtLink to="/regles/combat/activites/cacher">se faire furtive</NuxtLink> lorsqu’elle se déplace ou se tient dans une
      <NuxtLink to="/regles/aventure/environnement/vision">zone n’étant pas complètement dégagée</NuxtLink>.
    </p>
    <p>
      Elle doit effectuer un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>
      {{ " " }} <NuxtLink to="/regles/competences/tests/oppose">opposé</NuxtLink> à un test de
      <NuxtLink to="/regles/competences/perception">Perception</NuxtLink> contre toute créature pouvant détecter sa présence.
    </p>
    <p>Afin de se déplacer furtivement, une créature doit réduire sa vitesse.</p>
    <ul>
      <li>
        En situation de combat ou de tour-par-tour, elle doit dépenser <NuxtLink to="/regles/aventure/mouvement/vitesse">2 points de mouvement</NuxtLink> par
        case traversée.
      </li>
      <li>En période de voyage, elle doit adopter une <NuxtLink to="/regles/aventure/mouvement/voyage">cadence prudente</NuxtLink>.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Déplacement furtif";

useSeo({
  title,
  description:
    "Découvrez les règles de déplacement furtif : test opposé Furtivité/Perception, réduction de vitesse, points de mouvement et cadence prudente en voyage.",
});
</script>
