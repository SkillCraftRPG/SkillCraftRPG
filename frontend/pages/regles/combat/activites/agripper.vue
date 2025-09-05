<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous tentez d’agripper une autre créature. Vous devez avoir une main libre, et la <NuxtLink to="/regles/especes/taille">taille</NuxtLink> de la cible doit
      être d’au plus une catégorie supérieure à la vôtre.
    </p>
    <p>
      Effectuez un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> {{ " " }}
      <NuxtLink to="/regles/competences/tests/oppose">opposé</NuxtLink> à un test d’Athlétisme ou d’<NuxtLink to="/regles/competences/acrobaties"
        >Acrobaties</NuxtLink
      >
      de la cible (ou choix de celle-ci). Si vous réussissez le test, la cible est <NuxtLink to="/regles/combat/conditions/agrippe">agrippée</NuxtLink>, et elle
      ne peut pas <strong>se déplacer</strong> de son plein gré.
    </p>
    <p>
      À tout moment, vous pouvez <strong>lâcher</strong> la cible en <NuxtLink to="/regles/combat/deroulement/tour">action libre</NuxtLink>. Une créature
      agrippée peut tenter de se déprendre en <strong>s’échappant</strong>.
    </p>
    <p>
      Vous pouvez vous déplacer en traînant la cible avec vous. Cependant, votre <NuxtLink to="/regles/aventure/mouvement/vitesse">vitesse</NuxtLink> est
      réduite de moitié si la taille de la cible n’est pas d’au moins deux catégories inférieures à la votre.
    </p>
    <p>
      Une créature peut être agrippée par plusieurs créatures. Si vous tentez de traîner une cible agrippée par au moins une autre créature, effectuez un test
      d’Athlétisme opposé à un test d’Athlétisme contre chaque créature. Les créatures échouant le test lâchent la cible. Si toutes les autres créatures lâchent
      volontairement la cible ou échouent le test, vous pouvez alors traîner la cible avec vous.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à agripper :</p>
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
const slugs: Set<string> = new Set(["colosse", "lutte", "otage", "poigne-de-fer"]);
const title: string = "Agripper";
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
  description: "Découvrez les règles pour agripper une créature : conditions, tests opposés, déplacements réduits et options pour s’échapper ou lâcher prise.",
});
</script>
