<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      On désigne par <strong>terrain difficile</strong> une surface entravant les déplacements. Cette entrave peut être constituée d’un ou de plusieurs éléments
      parmi la liste suivant :
    </p>
    <ul>
      <li>Pente inclinée, par exemple le flanc d’une élévation (montagne, colline).</li>
      <li>Surface glissante, par exemple une plaque de glace ou un pavé mouillé par la pluie.</li>
      <li>Surface étroite ou instable, par exemple une corde d’équilibriste ou un pont suspendu.</li>
      <li>Zone très encombrée, par exemple un placard jonché de babioles ou une végétation très dense.</li>
      <li>
        <NuxtLink to="/regles/aventure/mouvement/espace-occupe">Espace occupé</NuxtLink> par une créature de
        <NuxtLink to="/regles/especes/taille">taille</NuxtLink> moyenne ou supérieure.
      </li>
    </ul>
    <p>
      Une créature se déplaçant dans du terrain difficile voit sa <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> réduite de moitié. De
      plus, si elle <NuxtLink to="/regles/aventure/mouvement/types">court</NuxtLink> sur du terrain difficile, elle doit réussir un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>
      afin de ne pas tomber <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> au sol. La
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> varie en fonction de la quantité d’entraves sur le terrain. Généralement, cette
      difficulté est de 10 + 5 fois le nombre d’entraves.
    </p>
    <ul>
      <li>
        En situation de combat ou de tour-par-tour, elle doit dépenser <NuxtLink to="/regles/aventure/mouvement/vitesse">2 points de mouvement</NuxtLink> par
        case traversée.
      </li>
      <li>
        En période de voyage, elle doit adopter une <NuxtLink to="/regles/aventure/mouvement/voyage">cadence prudente</NuxtLink>. Si la zone est très encombrée,
        elle ne peut s’y <NuxtLink to="/regles/aventure/mouvement/furtif">déplacer furtivement</NuxtLink>. Sinon, elle peut s’y déplacer furtivement sans
        réduire davantage la distance parcourue.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Mouvement", to: "/regles/aventure/mouvement" },
];
const title: string = "Terrain difficile";

useSeo({
  title,
  description:
    "Découvrez les règles du terrain difficile : vitesse réduite, risques de chute en courant, points de mouvement doublés et cadence prudente en voyage.",
});
</script>
