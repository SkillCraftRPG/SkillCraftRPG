<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>🚧</p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#betail">Bétail</a>
      </li>
      <li>
        <a href="#epices">Épices</a>
      </li>
      <li>
        <a href="#nourriture">Nourriture</a>
        <ul>
          <li>
            <a href="#repas">Repas</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#metaux">Métaux</a>
      </li>
      <li>
        <a href="#textiles">Textiles</a>
      </li>
    </ul>
    <h2 id="betail" class="h3">Bétail</h2>
    <p>🚧</p>
    <ItemList :items="cattle" />
    <h2 id="epices" class="h3">Épices</h2>
    <p>🚧</p>
    <ItemList :items="spices" />
    <h2 id="nourriture" class="h3">Nourriture</h2>
    <p>🚧</p>
    <ItemList :items="food" />
    <h3 id="repas" class="h5">Repas</h3>
    <p>
      La nourriture fraîche est bien plus savoureuse et moins onéreuse que les rations. En revanche, elle est périssable, moins calorique que les rations, et on
      doit cuisiner en lot afin d’obtenir un faible prix. Le prix indiqué est un prix par portion, et un personnage doit cuisiner 4 portions ou plus afin de
      bénéficier de ce bas prix. Chaque portion pèse entre 300 et 500 grammes, et 3 portions doivent être consommées chaque jour afin de ne pas souffrir de la
      <strong>faim</strong>. Étant périssable, cette nourriture se conserve généralement 24 heures ou moins. Il faut donc quotidiennement prendre le temps de se
      rendre au marché afin d’acheter la nourriture, puis de la cuisiner.
    </p>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-50">Style de vie</th>
          <th scope="col" class="w-50">Prix (deniers)</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>Misérable</td>
          <td>0,01</td>
        </tr>
        <tr>
          <td>Sordide</td>
          <td>0,02</td>
        </tr>
        <tr>
          <td>Pauvre</td>
          <td>0,2</td>
        </tr>
        <tr>
          <td>Modeste</td>
          <td>0,1</td>
        </tr>
        <tr>
          <td>Confortable</td>
          <td>0,2</td>
        </tr>
        <tr>
          <td>Fortuné</td>
          <td>0,3</td>
        </tr>
        <tr>
          <td>Aristocratique</td>
          <td>1</td>
        </tr>
      </tbody>
    </table>
    <h2 id="metaux" class="h3">Métaux</h2>
    <p>🚧</p>
    <ItemList :items="metals" />
    <h2 id="textiles" class="h3">Textiles</h2>
    <p>🚧</p>
    <ItemList :items="textiles" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Goods } from "~/types/items";
import { getGoodsItems } from "~/services/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Marchandise";
const { orderBy } = arrayUtils;

const goods = ref<Goods[]>(getGoodsItems());

const cattle = computed<Goods[]>(() =>
  orderBy(
    goods.value.filter(({ category }) => category === "Cattle"),
    "slug",
  ),
);
const food = computed<Goods[]>(() =>
  orderBy(
    goods.value.filter(({ category }) => category === "Food"),
    "slug",
  ),
);
const metals = computed<Goods[]>(() =>
  orderBy(
    goods.value.filter(({ category }) => category === "Metal"),
    "slug",
  ),
);
const spices = computed<Goods[]>(() =>
  orderBy(
    goods.value.filter(({ category }) => category === "Spice"),
    "slug",
  ),
);
const textiles = computed<Goods[]>(() =>
  orderBy(
    goods.value.filter(({ category }) => category === "Textile"),
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
