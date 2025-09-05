<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>La <strong>surprise</strong> survient lorsqu’un des deux camps ignore la présence de l’autre en début de combat, par exemple lors d’une embuscade.</p>
    <p>Cette condition peut aussi survenir si la cible de l’action hostile ne suspectait pas qu’elle serait victime d’une action de telle sorte.</p>
    <p>
      Une créature surprise ne peut prendre son premier <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>. Elle est donc
      <NuxtLink to="/regles/combat/deroulement/depourvu">prise au dépourvu</NuxtLink> jusqu’au début de son second tour.
    </p>
    <p>
      Le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/vigilance">Vigilance</NuxtLink> permet à une créature d’effectuer des
      actions limitées même lorsqu’elle est surprise.
    </p>
    <p>
      Une créature ayant acquis le talent <NuxtLink to="/regles/talents/observateur">Observateur</NuxtLink> n’est jamais surprise. Cela signifie qu’elle ne perd
      jamais son premier tour, mais une autre créature peut tout de même être <NuxtLink to="/regles/combat/activites/cacher">dissimulée</NuxtLink> à ses yeux.
    </p>
    <p>Certaines capacités permettent de prendre avantage de la surprise d’une autre créature.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Déroulement", to: "/regles/combat/deroulement" },
];
const title: string = "Surprise";

useSeo({
  title,
  description:
    "Découvrez la condition Surprise : ses effets en début de combat, ses interactions avec les talents et comment certaines capacités en tirent profit.",
});
</script>
