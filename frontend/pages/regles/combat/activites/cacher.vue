<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Vous tentez de vous dissimuler de vos ennemis. Effectuez un <NuxtLink to="/regles/competences/tests">test</NuxtLink> de
      <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>. Vous obtenez certains <strong>bénéfices</strong> lorsque vous êtes dissimulés.
    </p>
    <p>
      Si une créature vous observe, vous n’êtes pas dissimulés à ses yeux. Si une créature vous voit aller vous cacher, par exemple derrière un arbre ou dans un
      placard, alors vous êtes dissimulés à ses yeux, mais elle connaît tout de même votre position.
    </p>
    <p>
      Lorsque vous êtes dissimulés, une créature peut vous <NuxtLink to="/regles/combat/activites/chercher">chercher</NuxtLink> activement. Une créature qui ne
      vous cherche pas peut tout de même remarquer votre présence si son <NuxtLink to="/regles/competences/tests/passif">test passif</NuxtLink> de
      <NuxtLink to="/regles/competences/perception">Perception</NuxtLink> est supérieur au résultat de votre test de Furtivité.
    </p>
    <p>
      Vous ne pouvez pas vous dissimuler en pleine <NuxtLink to="/regles/aventure/environnement/vision">clarté</NuxtLink>, dans une zone complètement dégagée.
      Vous ne pouvez pas non plus vous y <NuxtLink to="/regles/aventure/mouvement/furtif">déplacer furtivement</NuxtLink>. Certains talents permettent
      d’outrepasser ces restrictions. Faites preuve de logique dans votre suite d’actions.
    </p>
    <p>
      Une créature <NuxtLink to="/regles/combat/conditions/invisible">invisible</NuxtLink> peut toujours tenter de se dissimuler. Elle doit se faire discrète
      même si elle est invisible, car des signes de son passage peuvent tout de même être perceptibles.
    </p>
    <p>
      Votre position est révélée si vous êtes découverts, vous cessez de vous cacher, ou que vous attirez l’attention, par exemple en faisant du bruit, en
      effectuant une <NuxtLink to="/regles/combat/attaque">attaque</NuxtLink> ou toute autre action hostile.
    </p>
    <p>Les <NuxtLink to="/regles/talents">talents</NuxtLink> suivants améliorent votre capacité à vous cacher :</p>
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
const slugs: Set<string> = new Set(["disparition", "embuscade", "furtivite", "maraudage"]);
const title: string = "Se cacher";
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
  description: "Découvrez comment se dissimuler des ennemis grâce à la furtivité, l’embuscade ou la disparition, et éviter d’être repéré en combat.",
});

// TODO(fpion): Furtivité pourrait permettre de se cacher même dans le "open", alors que quelqu’un normalement doit être dans une zone légèrement obscurcie.
// TODO(fpion): Maraudage semble entrer en conflit avec Déplacement furtif, pourrait permettre de se déplacer dans le "open".
</script>
