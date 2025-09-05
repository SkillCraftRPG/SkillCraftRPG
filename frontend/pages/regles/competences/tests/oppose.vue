<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Lorsque deux créatures ou personnages effectuent un test l’un contre l’autre, il s’agit d’un test opposé.</p>
    <p>
      Le <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink> est remplacé par le résultat du
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> de la cible.
    </p>
    <p>
      De manière générale, les tests opposés n’octroient pas de
      <NuxtLink to="/regles/competences/esperance-damnation">point d’Espérance ni de Damnation</NuxtLink>. Le maître de jeu peut toutefois octroyer des
      conséquences positives ou négatives. La décision finale lui appartient.
    </p>
    <p>Certains tests opposés sont effectués avec la même <NuxtLink to="/regles/competences">compétence</NuxtLink> pour l’acteur et la cible, par exemple :</p>
    <ul>
      <li>
        <strong><NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>.</strong> Course de vitesse ou à obstacles, compétition de cirque.
      </li>
      <li>
        <strong><NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink>.</strong> Concours de force, bras de fer, tir à la corde, lutte.
      </li>
      <li>
        <strong><NuxtLink to="/regles/competences/diplomatie">Diplomatie</NuxtLink>.</strong> Un acheteur et un vendeur négocient un prix.
      </li>
      <li>
        <strong><NuxtLink to="/regles/competences/linguistique">Linguistique</NuxtLink>.</strong> Une créature tente de comprendre un message caché ou encrypté
        par une autre créature.
      </li>
      <li>
        <strong><NuxtLink to="/regles/competences/roublardise">Roublardise</NuxtLink>.</strong> Une créature tente de dénouer ou de s’échapper de liens noués
        par une autre créature.
      </li>
    </ul>
    <p>Certains tests opposés sont effectués avec une compétence différente pour l’acteur et pour sa cible, par exemple :</p>
    <ul>
      <li>
        Une créature tente d’<NuxtLink to="/regles/combat/activites/agripper">agripper</NuxtLink> une autre créature (<NuxtLink
          to="/regles/competences/athletisme"
          >Athlétisme</NuxtLink
        >), qui tente se filer entre ses doigts (<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>).
      </li>
      <li>
        Une créature tente de <NuxtLink to="/regles/combat/activites/cacher">se cacher</NuxtLink>, de se déplacer furtivement ou de se faire discrète (<NuxtLink
          to="/regles/competences/furtivite"
          >Furtivité</NuxtLink
        >), alors qu’une autre tente de la repérer (<NuxtLink to="/regles/competences/perception">Perception</NuxtLink>).
      </li>
      <li>
        Une créature tente de mentir ou de cacher la vérité (<NuxtLink to="/regles/competences/tromperie">Tromperie</NuxtLink>), tandis qu’une autre tente de
        discerner le mensonge de la vérité (<NuxtLink to="/regles/competences/intuition">Intuition</NuxtLink>).
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
const title: string = "Test opposé";

useSeo({
  title,
  description: "Découvrez comment gérer les tests opposés entre personnages, qu’ils utilisent la même compétence ou des compétences différentes.",
});
</script>
