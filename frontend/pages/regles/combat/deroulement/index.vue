<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>La situation de combat est déclenchée lorsqu’une créature tente une action hostile envers une autre créature.</p>
    <p>
      Les combats sont découpés en <strong>rounds</strong> d’une durée de <NuxtLink to="/regles/aventure/temps">6 secondes</NuxtLink> pendant lesquels chaque
      créature peut jouer un <strong>tour</strong>.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Déroulement";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/combat/deroulement/initiative",
    title: "Initiative",
    description: "Règles d’Initiative : ordre des tours, bonus de talents et option avec cartes.",
  },
  {
    path: "/regles/combat/deroulement/tour",
    title: "Tour",
    description: "Fonctionnement d’un tour de combat : actions, actions libres et réactions.",
  },
  {
    path: "/regles/combat/deroulement/depourvu",
    title: "Pris au dépourvu",
    description: "Condition de combat limitant les réactions en début d’affrontement.",
  },
  {
    path: "/regles/combat/deroulement/surprise",
    title: "Surprise",
    description: "Condition de combat affectant l’initiative et limitant les actions au premier tour.",
  },
];

useSeo({
  title,
  description: "Découvrez le déroulement d’un combat : rounds de 6 secondes, initiative, tours, réactions et conditions comme la surprise ou le dépourvu.",
});
</script>
