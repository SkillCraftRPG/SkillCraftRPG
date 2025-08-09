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
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Armure</th>
          <th scope="col" class="w-15">Prix (deniers)</th>
          <th scope="col" class="w-15">Poids (kg)</th>
          <th scope="col" class="w-15">Défense</th>
          <th scope="col" class="w-15">Résistance</th>
          <th scope="col" class="w-25">Propriétés</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td colspan="6"><i>Armures légères</i></td>
        </tr>
        <tr v-for="armor in light" :key="armor.id">
          <td>{{ armor.name }}</td>
          <td>{{ $n(armor.price, "price") }}</td>
          <td>{{ $n(armor.weight, "weight") }}</td>
          <td>{{ $n(armor.defense, "defense") }}</td>
          <td>{{ $n(armor.resistance, "resistance") }}</td>
          <td>{{ armor.properties.length ? armor.properties.join(", ") : "—" }}</td>
        </tr>
        <tr>
          <td colspan="6"><i>Armures moyennes</i></td>
        </tr>
        <tr v-for="armor in medium" :key="armor.id">
          <td>{{ armor.name }}</td>
          <td>{{ $n(armor.price, "price") }}</td>
          <td>{{ $n(armor.weight, "weight") }}</td>
          <td>{{ $n(armor.defense, "defense") }}</td>
          <td>{{ $n(armor.resistance, "resistance") }}</td>
          <td>{{ armor.properties.length ? armor.properties.join(", ") : "—" }}</td>
        </tr>
        <tr>
          <td colspan="6"><i>Armures lourdes</i></td>
        </tr>
        <tr v-for="armor in heavy" :key="armor.id">
          <td>{{ armor.name }}</td>
          <td>{{ $n(armor.price, "price") }}</td>
          <td>{{ $n(armor.weight, "weight") }}</td>
          <td>{{ $n(armor.defense, "defense") }}</td>
          <td>{{ $n(armor.resistance, "resistance") }}</td>
          <td>{{ armor.properties.length ? armor.properties.join(", ") : "—" }}</td>
        </tr>
      </tbody>
    </table>
    <h3 class="h5">Armures légères</h3>
    <ul>
      <li v-for="armor in light" :key="armor.id">
        <strong>{{ armor.name }}.</strong> {{ armor.description }}
      </li>
    </ul>
    <h3 class="h5">Armures moyennes</h3>
    <ul>
      <li v-for="armor in medium" :key="armor.id">
        <strong>{{ armor.name }}.</strong> {{ armor.description }}
      </li>
    </ul>
    <h3 class="h5">Armures lourdes</h3>
    <ul>
      <li v-for="armor in heavy" :key="armor.id">
        <strong>{{ armor.name }}.</strong> {{ armor.description }}
      </li>
    </ul>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import armor from "~/assets/data/items/armor.json";
import type { Armor } from "~/types/items";
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Armure";

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
    path: "/regles/equipement/armure/proprietes",
    title: "Propriétés",
    description: "Propriétés des armures et effets sur le porteur.",
  },
  {
    path: "/regles/equipement/armure/enfiler-retirer",
    title: "Enfiler ou retirer son armure",
    description: "Temps pour enfiler ou retirer une armure selon sa catégorie.",
  },
];

const heavy = computed<Armor[]>(() => armor.filter(({ category }) => category === "Heavy"));
const light = computed<Armor[]>(() => armor.filter(({ category }) => category === "Light"));
const medium = computed<Armor[]>(() => armor.filter(({ category }) => category === "Medium"));

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
