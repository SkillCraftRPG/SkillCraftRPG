<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsqu’un personnage doit effectuer un test, mais que le joueur n’est pas au courant, et que le maître de jeu désire ne pas éveiller ses soupçons, il peut
      effectuer un test passif.
    </p>
    <p>Il remplace alors les <NuxtLink to="/regles/competences/tests/2d10">dés d’Espérance et de Damnation</NuxtLink> par la moyenne, soit 10.</p>
    <p>
      Les tests passifs n’octroient jamais de conséquences négatives ou positives, ni de
      <NuxtLink to="/regles/competences/esperance-damnation">points d’Espérance ni de Damnation</NuxtLink>.
    </p>
    <p>
      Chaque <NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> confère un bonus (+5) au test passif. Au contraire, chaque
      désavantage inflige une pénalité (-5) au test passif.
    </p>
    <h2 class="h3">Exemples</h2>
    <ul>
      <li>
        <strong><NuxtLink to="/regles/competences/diplomatie">Diplomatie</NuxtLink>.</strong> Un personnage discute avec un paysan craintif envers les
        étrangers, sans savoir que ce dernier évalue sa fiabilité en écoutant ses propos.
      </li>
      <li>
        <strong><NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>.</strong> Un personnage se déplace normalement, sans essayer d’être discret
        mais sans être bruyant non plus, alors que des sentinelles bien dissimulées sont aux aguets.
      </li>
      <li>
        <strong><NuxtLink to="/regles/competences/intuition">Intuition</NuxtLink>.</strong> Un personnage entend une discussion sans y porter attention, absorbé
        dans un bouquin. Un des interlocuteurs dit un mensonge flagrant.
      </li>
      <li>
        <strong><NuxtLink to="/regles/competences/perception">Perception</NuxtLink>.</strong> Un groupe d’aventuriers foule un sentier forestier en marchant à
        vitesse normale, sans se douter qu’une embuscade leur est entendue plus loin par un groupe de bandits.
      </li>
      <li>
        <strong><NuxtLink to="/regles/competences/survie">Survie</NuxtLink>.</strong> Un groupe d’aventuriers arpente une vaste étendue sauvage, suivant des
        directions ou une carte, sans toutefois bénéficier d’un chemin direct ou de repères évidents.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Test passif";

useSeo({
  title,
  description: "Découvrez quand et comment utiliser un test passif pour simuler une action sans alerter le joueur qu’un test est en cours.",
});
</script>
