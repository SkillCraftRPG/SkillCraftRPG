<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’armure est une protection physique, et parfois magique, portée par les aventuriers, les hommes d’armes ainsi que certaines créatures.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Liste des armures</h2>
    <h3 class="h5">Armures légères</h3>
    <ItemArmorList :items="light" />
    <h3 class="h5">Armures moyennes</h3>
    <ItemArmorList :items="medium" />
    <h3 class="h5">Armures lourdes</h3>
    <ItemArmorList :items="heavy" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Armor } from "~/types/items";
import type { Breadcrumb } from "~/types/components";
import { getArmor } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Armure";
const { orderBy } = arrayUtils;

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/armure/categorie",
    title: "Catégories d’armure",
    description: "Présentation des trois catégories d’armure et de leurs particularités.",
  },
  {
    path: "/regles/equipement/armure/formation",
    title: "Formation",
    description: "La formation nécessaire pour porter une armure et les pénalités sans.",
  },
  {
    path: "/regles/equipement/armure/proprietes",
    title: "Propriétés",
    description: "Propriétés des armures et effets sur le porteur.",
  },
  {
    path: "/regles/equipement/armure/partielle",
    title: "Armure partielle",
    description: "Assembler, combiner et calculer la Défense des armures partielles.",
  },
  {
    path: "/regles/equipement/armure/multiple",
    title: "Armures multiples",
    description: "Porter deux couches d’armure et combiner leurs effets.",
  },
  {
    path: "/regles/equipement/armure/enfiler-retirer",
    title: "Enfiler ou retirer son armure",
    description: "Temps pour enfiler ou retirer une armure selon sa catégorie.",
  },
  // TODO(fpion): Armures renforcées
];

const armor = ref<Armor[]>(getArmor());

const heavy = computed<Armor[]>(() =>
  orderBy(
    armor.value.filter(({ category }) => category === "Heavy").map((armor) => ({ ...armor, sort: [armor.defense, armor.slug].join("_") })),
    "sort",
  ),
);
const light = computed<Armor[]>(() =>
  orderBy(
    armor.value.filter(({ category }) => category === "Light").map((armor) => ({ ...armor, sort: [armor.defense, armor.slug].join("_") })),
    "sort",
  ),
);
const medium = computed<Armor[]>(() =>
  orderBy(
    armor.value.filter(({ category }) => category === "Medium").map((armor) => ({ ...armor, sort: [armor.defense, armor.slug].join("_") })),
    "sort",
  ),
);

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description:
    "Découvrez le fonctionnement des armures, ces protections physiques et parfois magiques, portées par les aventuriers, les hommes d’armes et certaines créatures.",
});
</script>
