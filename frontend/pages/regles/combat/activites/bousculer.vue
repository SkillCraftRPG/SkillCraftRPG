<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous tentez de faire tomber ou de repousser une créature. La <NuxtLink to="/regles/especes/taille">taille</NuxtLink> de la cible doit être d’au plus une
      catégorie supérieure à la vôtre.
    </p>
    <p>
      Effectuez un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> {{ " " }}
      <NuxtLink to="/regles/competences/tests/oppose">opposé</NuxtLink> à un test d’Athlétisme ou d’<NuxtLink to="/regles/competences/acrobaties"
        >Acrobaties</NuxtLink
      >
      de la cible (au choix de celle-ci). Si vous réussissez le test, la cible tombe <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> au
      sol, ou est repoussée de 1,5 mètres dans une direction opposée, à votre choix.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à bousculer, ou à y résister :</p>
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
const slugs: Set<string> = new Set(["astuce", "colosse", "coup-de-bouclier", "mefait-feutre", "protection"]);
const title: string = "Bousculer";
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
  description: "Découvrez la règle de bousculade : test opposé d’Athlétisme ou d’Acrobaties pour renverser ou repousser une cible, avec talents associés.",
});
</script>
