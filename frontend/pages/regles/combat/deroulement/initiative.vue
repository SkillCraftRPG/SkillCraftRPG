<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Dès l’entrée en situation de combat, toute créature participant au combat effectue un test d’Initiative. Lancez 1d10 et ajoutez son
      <NuxtLink to="/regles/statistiques/initiative">Initiative</NuxtLink>.
    </p>
    <p>L’ordre des tours dans chaque round se déroule en ordre décroissant des résultats du test.</p>
    <p>
      En cas d’égalité, la créature possédant le plus haut bonus d’Initiave a préséance. En cas d’égalité des bonus, utilisez le hasard (par exemple un jet de
      dés, pile ou face, roche-papier-ciseau) pour déterminer l’ordre de jeu.
    </p>
    <h2 class="h3">Ennemis</h2>
    <p>En cas d’égalité, les créatures adversaires et personnages non-joueur prennent leur tour après celui des joueurs.</p>
    <p>
      Le maître de jeu peut également décider de ne pas faire effectuer de test d’Initiative aux créatures ennemies et aux personnages non-joueur. Il pourrait
      fonctionner comme tel :
    </p>
    <ol>
      <li>Le boss, ou ennemi en tête, joue en premier.</li>
      <li>Les actions du repaire s’exécutent toujours à l’Initiative 20.</li>
      <li>La moitié des joueurs ayant obtenu les résultats les plus élevés prennent leur tour en ordre.</li>
      <li>Les serviteurs du boss prennent ensuite leur tour dans n’importe quel ordre.</li>
      <li>La moitié des joueurs ayant obtenu les résultats les plus faible prennent leur tour en ordre.</li>
      <li>Les créatures neutres, par exemple bêtes sauvages sur les lieux, prennent leur tour en dernier, dans n’importe quel ordre.</li>
    </ol>
    <h2 class="h3">Talents</h2>
    <p>Les talents suivants confèrent des bonus à l’Initiative.</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
    <h2 class="h3">Cartes à jouer</h2>
    <p>Il est également possible d’utiliser un paquet de 52 cartes plutôt que 1d10.</p>
    <ul>
      <li>Les cartes pointées portent la valeur indiquée sur la carte (entre 2 et 10).</li>
      <li>Le Valet vaut 11, la Dame vaut 12, et le Roi vaut 13.</li>
      <li>L’As vaut 14.</li>
      <li>
        Le joker (facultatif, maximum 2) permet à la créature de prendre son tour à n’importe quel moment pendant le round : au début, à la fin, ou entre le
        tour de deux créatures.
      </li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Déroulement", to: "/regles/combat/deroulement" },
];
const slugs: Set<string> = new Set(["initiative-accrue", "initiative-extraordinaire", "initiative-superieure", "vigilance"]);
const title: string = "Initiative";
const { orderBy } = arrayUtils;

const allTalents = ref<Talent[]>(getTalents());

const talents = computed<Talent[]>(() =>
  orderBy(
    allTalents.value.filter(({ slug }) => slugs.has(slug)),
    "tier",
  ),
);

useSeo({
  title,
  description: "Découvrez comment fonctionne l’Initiative au combat, l’ordre des tours, les talents associés et l’option de tirage avec des cartes.",
});
</script>
