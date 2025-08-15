<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Butins et trésors sont souvent les motivations des jeunes aventuriers intrépides.</p>
    <p>Sur leur route, ils trouveront des objets de valeur multiple et auront besoin d’équipement adapté à leurs voyages.</p>
    <p>Armes et armures, objets magiques, marchandises et autres objets de valeur pourront être troqués ou achetés à différents endroits.</p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
const title: string = "Équipement";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/equipement/monnaie",
    title: "Système de monnaie",
    description: "Systèmes monétaires, pièces de monnaie, valeurs et conversions.",
  },
  {
    path: "/regles/equipement/depart",
    title: "Équipement de départ",
    description: "Déterminer la richesse de départ et sélectionner l’équipement de départ.",
  },
  {
    path: "/regles/equipement/encombrement",
    title: "Encombrement",
    description: "Définit la limite de poids qu’une créature peut porter et les pénalités.",
  },
  {
    path: "/regles/equipement/vente-reparation",
    title: "Vente et réparation",
    description: "Lignes directrices pour revendre, échanger et réparer l’équipement.",
  },
  {
    path: "/regles/equipement/depenses",
    title: "Dépenses",
    description: "Styles de vie, quotidiens et confort offert entre deux aventures.",
  },
  {
    path: "/regles/equipement/armes",
    title: "Armes",
    description: "Objets offensifs ou défensif utilisés par les personnages et créatures.",
  },
  {
    path: "/regles/equipement/armure",
    title: "Armure",
    description: "Protection portée par les aventuriers et hommes d’armes.",
  },
  {
    path: "/regles/equipement/boucliers",
    title: "Boucliers",
    description: "Catégories, propriétés, talents et particularités des boucliers.",
  },
  {
    path: "/regles/equipement/general",
    title: "Équipement général",
    description: "Articles généraux, conteneurs et vêtements.",
  },
  {
    path: "/regles/equipement/outils",
    title: "Outils et trousses",
    description: "Outils d’artisan, trousses, ensembles à jouer et instruments de musique.",
  },
  {
    path: "/regles/equipement/marchandise",
    title: "Marchandise",
    description: "Bétail, épices, nourriture, métaux et textiles.",
  },
];

/* TODO(fpion):
 * Défense
 * Résistance
 * Montures et véhicules : Bêtes, Accessoires, Véhicules, Navires
 * Services : Gîte et couvert, Professionnels, Occultes, Artisans et Marchands, Passage en navire
 */

useSeo({
  title,
  description: "", // TODO(fpion): implement
});
</script>
