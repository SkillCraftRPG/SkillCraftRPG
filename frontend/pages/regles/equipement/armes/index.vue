<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les armes permettent aux aventuriers de se défendre contre une agression ou de tourner une situation à leur avantage.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
    <h2 class="h3">Liste des armes</h2>
    <h3 class="h5">Armes simples</h3>
    <ItemWeaponList :items="simple" />
    <h3 class="h5">Armes martiales</h3>
    <ItemWeaponList :items="martial" />
    <ItemAmmunitionList :items="ammunition" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Ammunition, Weapon } from "~/types/items";
import { getAmmunition, getWeapons } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Armes";
const { orderBy } = arrayUtils;

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/armes/categorie",
    title: "Catégories d’armes",
    description: "Présentation des deux catégories d’armes et de leurs particularités.",
  },
  {
    path: "/regles/equipement/armes/formation",
    title: "Formation",
    description: "La formation nécessaire pour manier une arme et les pénalités sans.",
  },
  {
    path: "/regles/equipement/armes/proprietes",
    title: "Propriétés",
    description: "Propriétés des armes et effets sur le maniement.",
  },
  {
    path: "/regles/equipement/armes/improvisees",
    title: "Armes improvisées",
    description: "Règles pour l’usage et les dégâts des armes improvisées.",
  },
  {
    path: "/regles/equipement/armes/argent",
    title: "Plaquage d’argent",
    description: "Plaquage en argent pour armes contre créatures résistantes.",
  },
  {
    path: "/regles/equipement/armes/attaque",
    title: "Attaque",
    description: "Bonus au test d’attaque selon la taille de l’arme.",
  },
  // TODO(fpion): Armes à feu et explosifs
  // TODO(fpion): Armes affûtées
  // TODO(fpion): Armes brisées
];

const ammunition = ref<Ammunition[]>(orderBy(getAmmunition(), "slug"));
const weapons = ref<Weapon[]>(getWeapons());

const simple = ref<Weapon[]>(
  orderBy(
    weapons.value.filter(({ category }) => category === "Simple"),
    "slug",
  ),
);
const martial = ref<Weapon[]>(
  orderBy(
    weapons.value.filter(({ category }) => category === "Martial"),
    "slug",
  ),
);

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description: "Découvrez le fonctionnement des armes, qui permettent aux aventuriers de se défendre et à leurs adversaires de les assaillir.",
});
</script>
