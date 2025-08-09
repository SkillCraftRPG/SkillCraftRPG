<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Le personnage est formé pour une <NuxtLink to="/regles/competences">compétence</NuxtLink> lorsqu’il acquiert le
      <NuxtLink to="/regles/talents">talent</NuxtLink> portant le même nom que celle-ci.
    </p>
    <p>Un personnage formé pour une compétence maîtrise les aptitudes et savoir-faire, contrairement à une créature qui n’est pas formée.</p>
    <p>
      Lorsqu’il est formé pour une compétence, il ne subit pas de pénalité au <NuxtLink to="/regles/competences/rang">rang</NuxtLink> lorsqu’il effectue un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> associé à cette compétence.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [{ text: "Compétences", to: "/regles/competences" }];
const title: string = "Formation";

useSeo({
  title,
  description: "Découvrez comment la formation à une compétence supprime les pénalités et garantit la pleine maîtrise des aptitudes et savoir-faire associés.",
});
</script>
