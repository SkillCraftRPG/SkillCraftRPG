<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <h2 class="h3">Réussite critique</h2>
    <p>
      Lorsque vos dés <NuxtLink to="/regles/competences/tests/2d10">d’Espérance et de Damnation</NuxtLink> tombent sur la même face et que cette face est 6, 7,
      8, 9 ou 0, vous obtenez une réussite critique.
    </p>
    <p>
      L’action entreprise est une réussite (vous ne calculez pas le total du <NuxtLink to="/regles/competences/tests">test</NuxtLink>), peu importe vos
      bonus/pénalités (<NuxtLink to="/regles/attributs">attribut</NuxtLink>, <NuxtLink to="/regles/competences">compétence</NuxtLink> et situationnels) et le
      <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink>.
    </p>
    <p>
      En plus de réussir automatiquement, vous bénéficiez 2 conséquences positives. Votre maître de jeu peut également vous donner 2
      <NuxtLink to="/regles/competences/esperance-damnation">points d’Espérance</NuxtLink>, ou une conséquence positive et un point d’Espérance. La décision
      finale lui appartient.
    </p>
    <h2 class="h3">Échec critique</h2>
    <p>
      Lorsque vos dés <NuxtLink to="/regles/competences/tests/2d10">d’Espérance et de Damnation</NuxtLink> tombent sur la même face et que cette face est 1, 2,
      3, 4 ou 5, vous obtenez un échec critique.
    </p>
    <p>
      L’action intentée est un échec (vous ne calculez pas le total du <NuxtLink to="/regles/competences/tests">test</NuxtLink>), peu importe vos
      bonus/pénalités (<NuxtLink to="/regles/attributs">attribut</NuxtLink>, <NuxtLink to="/regles/competences">compétence</NuxtLink> et situationnels) et le
      <NuxtLink to="/regles/competences/tests/difficulte">degré de difficulté</NuxtLink>.
    </p>
    <p>
      En plus d’échouer automatiquement, vous êtes affligés de 2 conséquences négatives. Votre maître de jeu peut également s’allouer 2
      <NuxtLink to="/regles/competences/esperance-damnation">points de Damnation</NuxtLink>, ou vous infliger une conséquence négative et s’allouer un point de
      Damnation. La décision finale lui appartient.
    </p>
    <h2 class="h3">Attaque</h2>
    <p>
      Lorsque vous effectuez une <strong>Attaque</strong>, certains talents ou certaines capacités peuvent augmenter vos chances d’obtenir une réussite critique
      ou réduire vos chances d’obtenir un échec critique. Certaines capacités ou conditions peuvent également réduire ces chances, voire les nullifier.
    </p>
    <p>L’obtention d’une réussite critique ne signifie pas que vous infligez des <strong>points de dégâts</strong> supplémentaires, sauf lorsque indiqué.</p>
    <p>Les talents suivants augmentent vos chances d’obtenir une réussite critique lorsque vous effectuez une attaque :</p>
    <h2 class="h3"><font-awesome-icon icon="fas fa-triangle-exclamation" /> Attention</h2>
    <p>Lorsqu’une action est impossible à échouer ou à réussir, aucun <NuxtLink to="/regles/competences/tests">test</NuxtLink> n’est effectué.</p>
    <p>
      Ainsi, l’obtention d’une réussite critique ne permet pas de réussir une action impossible à réussir, tout comme l’obtention d’un échec critique n’impose
      pas l’échec à une action impossible à échouer.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Compétences", to: "/regles/competences" },
  { text: "Tests", to: "/regles/competences/tests" },
];
const title: string = "Critique";

useSeo({
  title,
  description: "Découvrez les effets et conséquences des réussites critiques et échecs critiques dans le système SkillCraft.",
});

/* TODO(fpion): Talents
 * /regles/talents/coup-critique
 * /regles/talents/critique-accru
 * /regles/talents/critique-superieur
 * /regles/talents/critique-extraordinaire
 */
</script>
