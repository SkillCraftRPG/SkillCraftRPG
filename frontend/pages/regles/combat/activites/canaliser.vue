<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous canalisez un <NuxtLink to="/regles/pouvoirs">pouvoir</NuxtLink>.</p>
    <p>
      Par une action, vous pouvez également commencer à canaliser un pouvoir. Lors de votre prochain
      <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, il vous coûtera une action en moins afin de compléter la canalisation. L’action est perdue
      si vous ne terminez pas la canalisation lors de votre prochain tour, ou si vous canalisez un autre pouvoir entretemps. Vous n’avez pas besoin de vous
      <strong>concentrer</strong> sur cette canalisation, et vous ne déclenchez une <strong>attaque d’opportunité</strong> qu’au moment où vous complétez la
      canalisation.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à canaliser :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Talent } from "~/types/game";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Activités", to: "/regles/combat/activites" },
];
const slugs: Set<string> = new Set(["magie-guerriere", "magie-precise", "magie-puissante", "maximisation-magique", "optimisation-magique"]);
const title: string = "Canaliser";
const { orderBy } = arrayUtils;

const allTalents = ref<Talent[]>(getTalents());

const talents = computed<Talent[]>(() =>
  orderBy(
    allTalents.value.filter(({ slug }) => slugs.has(slug)).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

useSeo({
  title,
  description:
    "Découvrez comment canaliser un pouvoir : règles, actions requises et talents spéciaux pour améliorer puissance, précision, défense et optimisation magique.",
});

// TODO(fpion): magie-guerriere enlève l'attaque d'opportunité, pas le désavantage de canaliser en présence d'ennemis
</script>
