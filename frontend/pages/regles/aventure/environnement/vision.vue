<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>L’habileté du personnage à percevoir les objets et événements de son environnement est gouvernée par le niveau de lumière.</p>
    <h2 class="h3">Zone obscurcie</h2>
    <p>
      Une zone <strong>légèrement obscurcie</strong> impose le <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink> aux
      <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de <NuxtLink to="/regles/competences/perception">Perception</NuxtLink> en lien avec la vision
      effectués dans la zone. Voici des exemples de zones légèrement obscurcies : brouillard léger, végétation dense, pénombre.
    </p>
    <p>
      Une zone <strong>lourdement obscurcie</strong> <NuxtLink to="/regles/combat/conditions/aveugle">aveugle</NuxtLink> les créatures à l’intérieur de
      celle-ci. Voici des exemples de zones lourdement obscurcies : brouillard épais, tempête, obscurité.
    </p>
    <h2 class="h3">Lumière</h2>
    <p>
      La plupart des activités se produisent à la <strong>clarté</strong>, la lumière produite par exemple par le Soleil ou à proximité d’une torche, d’une
      lanterne ou d’un feu de camp.
    </p>
    <p>
      Une zone de <strong>pénombre</strong> est décrite par une lumière qui est plus faible, par exemple à l’aube ou au crépuscule, sous une Lune brillante ou à
      une certaine distance d’une lanterne ou d’un feu de camp la nuit.
    </p>
    <p>Un emplacement dans le noir complet, sans source de lumière, est dans l’<strong>obscurité</strong>.</p>
    <h2 class="h3">Types de vision</h2>
    <p>Une créature dotée de <strong>vision aveugle</strong> peut percevoir son environnement sans yeux.</p>
    <p>
      Une créature dotée de <strong>vision dans le noir</strong> peut voir dans l’obscurité de la même manière qu’elle peut voir dans la pénombre, à condition
      que cette obscurité ne soit pas magique. Néanmoins, elle ne voit dans l’obscurité qu’en teintes de gris et il lui est presque impossible de discerner les
      couleurs.
    </p>
    <p>Une créature dotée de <strong>vision absolue</strong> peut voir dans l’obscurité, même si elle est magique, et acquiert les capacités suivantes.</p>
    <ul>
      <li>Elle peut percevoir les objets et créatures <NuxtLink to="/regles/combat/conditions/invisible">invisibles</NuxtLink>.</li>
      <li>
        Elle détecte les illusions visuelles et réussit automatiquement ses
        <NuxtLink to="/regles/competences/tests/sauvegarde">jets de sauvegarde</NuxtLink> contre ces illusions.
      </li>
      <li>Elle voit sous leur forme normale les créatures métamorphosées.</li>
      <li>Elle peut percevoir dans le monde spirituel.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Environnement", to: "/regles/aventure/environnement" },
];
const title: string = "Vision";

useSeo({
  title,
  description: "Découvrez l’impact de la lumière et des types de vision sur la perception : obscurité, pénombre, vision dans le noir, aveugle ou absolue.",
});
</script>
