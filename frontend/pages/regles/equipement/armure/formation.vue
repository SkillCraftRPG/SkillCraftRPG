<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Tout personnage peut revêtir une armure. Néanmoins, une formation est nécessaire afin d’être protégé convenablement.</p>
    <h2 class="h3">Talents</h2>
    <p>
      Les talents suivants forment le personnage au port des armures d’une certaine <NuxtLink to="/regles/equipement/armure/categorie">catégorie</NuxtLink> :
    </p>
    <h2 class="h3">Pénalités</h2>
    <p>Si une créature porte une armure pour laquelle elle n’est pas formée, elle se voit affligée des pénalités suivantes :</p>
    <ul>
      <li>
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">Désavantage</NuxtLink> au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
        <NuxtLink to="/regles/competences">compétences</NuxtLink> associées à l’<NuxtLink to="/regles/attributs/adresse">Adresse</NuxtLink>, à la
        <NuxtLink to="/regles/attributs/vigueur">Vigueur</NuxtLink> et au surnaturel, notamment :
        <ul>
          <li>
            <NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/artisanat">Artisanat</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/roublardise">Roublardise</NuxtLink>
          </li>
        </ul>
      </li>
      <li>Incapacité à canaliser un <NuxtLink to="/regles/pouvoirs">pouvoir</NuxtLink> nécessitant la composante <strong>Somatique</strong>.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armure", to: "/regles/equipement/armure" },
];
const title: string = "Formation";

useSeo({
  title,
  description: "Découvrez l’importance de la formation au port d’armure et les pénalités encourues sans compétence adéquate.",
});

/* TODO(fpion): Talents
 * /regles/talents/orientation
 * /regles/talents/melee
 * /regles/talents/formation-martiale
 * /regles/talents/cuirasse
 */
</script>
