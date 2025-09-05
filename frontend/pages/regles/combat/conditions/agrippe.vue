<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Une créature agrippée est immobilisée, elle ne peut donc pas <strong>se déplacer</strong>.</p>
    <p>La condition prend fin lorsque survient l’une des situations suivantes :</p>
    <ul>
      <li>La créature agrippée réussit à <strong>s’échapper</strong>.</li>
      <li>La créature l’ayant agrippé la lâche, volontairement ou non, ou devient <NuxtLink to="/regles/combat/conditions/incapable">incapable</NuxtLink>.</li>
      <li>La créature agrippée est déplacée à l’extérieur de la portée de la créature l’agrippant par un effet quelconque.</li>
    </ul>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Conditions", to: "/regles/combat/conditions" },
];
const title: string = "Agrippé";

useSeo({
  title,
  description: "Découvrez la condition Agrippé : immobilisation d’une créature, ses effets, ainsi que les différentes façons de mettre fin à cette contrainte.",
});
</script>
