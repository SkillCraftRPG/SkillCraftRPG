<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsqu’un personnage subit une chute, il reçoit des points de dégâts contondants létaux et tombe en position
      <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink>.
    </p>
    <p>Ces points de dégâts sont de 1d6 par tranche de 1,5 mètres de hauteur.</p>
    <h2 class="h3">Amortir sa chute</h2>
    <p>
      Il peut tenter d’amortir sa chute par un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink
        to="/regles/competences/acrobaties"
        >Acrobaties</NuxtLink
      >
      de <NuxtLink to="/regles/competences/tests/difficulte">difficulté moyenne</NuxtLink> afin de réduire l’impact de la chute.
    </p>
    <ul>
      <li>Lorsqu’il réussit le test, les deux premiers dés de dégâts sont convertis en dégâts non létaux.</li>
      <li>Également, lorsqu’il réussit le test, il n’atterrit pas en position renversée s’il n’a reçu aucun point de dégâts létal.</li>
      <li>Il se voit conférer l’<NuxtLink to="/regles/competences/tests/avantage-desavantage">avantage</NuxtLink> au test s’il a sauté volontairement.</li>
      <li>Il se voit également conférer l’avantage lorsqu’il atterrit sur une surface solide mais molle, par exemple dans la boue.</li>
    </ul>
    <h2 class="h3">Surface liquide</h2>
    <p>
      Lorsqu’un personnage atterrit dans une surface liquide, par example dans l’eau, si la profondeur de cette surface est d’au moins 3 mètres, les points de
      dégâts reçus sont réduits de moitié.
    </p>
    <p>
      Lorsqu’il saute dans une surface liquide, il ne peut amortir sa chute, mais il peut plutôt effectuer un plongeon. Il effectue un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté moyenne</NuxtLink>. Les mêmes modalités et conséquences positives s’appliquent que pour
      amortir sa chute, tel que décrit plus haut.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Aventure", to: "/regles/aventure" },
  { text: "Environnement", to: "/regles/aventure/environnement" },
];
const title: string = "Chute";

useSeo({
  title,
  description:
    "Découvrez les règles de chute : dégâts par hauteur, jets d’Acrobaties ou d’Athlétisme pour amortir ou plonger, et modificateurs selon la surface.",
});
</script>
