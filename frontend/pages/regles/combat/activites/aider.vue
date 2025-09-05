<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Vous aidez une créature située à 1,5 mètres ou moins de votre position à accomplir une action quelconque.</p>
    <p>
      Pendant votre <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, vous vous préparez par une action. Vous utilisez ensuite votre réaction afin
      de conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> au
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’une créature.
    </p>
    <p>
      Votre réaction n’est pas perdue si vous ne l’utilisez pas. Également, si vous l’utilisez pour autre chose, par exemple afin d’effectuer une
      <strong>attaque d’opportunité</strong>, vous ne pouvez pas aider la créature. Évidemment, l’ensemble de l’œuvre doit être logique.
    </p>
    <p>Si l’action entreprise par la créature aidée déclenche une attaque d’opportunité, alors l’action d’aider cette créature en déclenche également une.</p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à aider :</p>
    <div class="row">
      <div v-for="talent in talents" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
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
const slugs: Set<string> = new Set(["diplomatie", "distraction", "emboiter-le-pas"]);
const title: string = "Aider";
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
  description: "Découvrez l’action Aider et ses variantes : conférer l’avantage à un allié, étendre la portée avec Diplomatie ou Distracter les ennemis.",
});
</script>
