<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Dès que le combat commence, toute créature y participant est <strong>prise au dépourvu</strong>.</p>
    <p>Dès qu’elle prend son premier <NuxtLink to="/regles/combat/deroulement/tour">tour</NuxtLink>, la condition cesse.</p>
    <p>Une créature prise au dépourvu ne peut utiliser sa réaction.</p>
    <p>
      Une créature ayant acquis le <NuxtLink to="/regles/talents">talent</NuxtLink> <NuxtLink to="/regles/talents/vigilance">Vigilance</NuxtLink> n’est jamais
      prise au dépourvu.
    </p>
    <p>Certaines capacités peuvent infliger cette condition à une créature.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Déroulement", to: "/regles/combat/deroulement" },
];
const title: string = "Pris au dépourvu";

useSeo({
  title,
  description: "Découvrez la condition Pris au dépourvu : ses effets au début d’un combat, ses limites et comment certains talents ou capacités l’annulent.",
});
</script>
