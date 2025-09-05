<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous tentez de trouver une créature <NuxtLink to="/regles/combat/activites/cacher">dissimulée</NuxtLink> ou
      <NuxtLink to="/regles/combat/conditions/invisible">invisible</NuxtLink>, ou un objet caché, par exemple un piège ou un passage secret.
    </p>
    <p>
      Effectuez un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de <NuxtLink to="/regles/competences/perception">Perception</NuxtLink>. Vous
      détectez la présence des créatures et objets cachés si votre résultat est supérieur ou égal au résultat du test de
      <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>
      de ceux-ci.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à chercher :</p>
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
const slugs: Set<string> = new Set(["focus", "surveillance", "observateur", "perception"]);
const title: string = "Chercher";
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
  description: "Découvrez comment détecter créatures dissimulées, invisibles ou objets cachés grâce à la perception, l’observation et la surveillance.",
});
</script>
