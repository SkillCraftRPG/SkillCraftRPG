<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#artisanat-trousses">Outils d’artisanat et trousses</a>
      </li>
      <li>
        <a href="#ensembles-jeu">Ensembles de jeu</a>
      </li>
      <li>
        <a href="#instruments-musique">Instruments de musique</a>
      </li>
    </ul>
    <h2 id="artisanat-trousses" class="h3">Outils d’artisanat et trousses</h2>
    <p>🚧</p>
    <ItemList :items="crafting" />
    <h2 id="ensembles-jeu" class="h3">Ensembles de jeu</h2>
    <p>🚧</p>
    <ItemList :items="playingSets" />
    <h2 id="instruments-musique" class="h3">Instruments de musique</h2>
    <p>🚧</p>
    <ItemList :items="musicalInstruments" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Tool } from "~/types/items";
import { getTools } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Outils et trousses";
const { orderBy } = arrayUtils;

const tools = ref<Tool[]>(getTools());

const crafting = computed<Tool[]>(() =>
  orderBy(
    tools.value.filter(({ category }) => category === "Crafting"),
    "slug",
  ),
);
const playingSets = computed<Tool[]>(() =>
  orderBy(
    tools.value.filter(({ category }) => category === "PlayingSet"),
    "slug",
  ),
);
const musicalInstruments = computed<Tool[]>(() =>
  orderBy(
    tools.value.filter(({ category }) => category === "MusicalInstrument"),
    "slug",
  ),
);

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description: "🚧",
});
</script>
