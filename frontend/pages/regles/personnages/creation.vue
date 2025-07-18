<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb active="Création" :parent="parent" />
    <p>Avant de commencer à jouer, vous devez créer un personnage.</p>
    <p>Utilisez les étapes ci-dessous ainsi que votre imagination afin de créer le personnage que vous désirez incarner.</p>
    <p>Vous concevrez les différentes facettes de votre personnage, notamment son apparence, sa personnalité et son historique.</p>
    <p>Vous pouvez justifier vos choix par des calculs d’optimisation mathématique, mais vous aurez bien plus de plaisir si vous utilisez votre créativité.</p>
    <p>
      De manière générale, un personnage débute avec <NuxtLink to="/regles/personnages/progression/experience">0 point d’expérience</NuxtLink>, il est de
      <NuxtLink to="/regles/personnages/progression/niveau">niveau 0</NuxtLink> et de <NuxtLink to="/regles/personnages/progression/tiers">tiers 0</NuxtLink>.
    </p>
    <CharacterCreationContents />
    <CharacterCreationIntroduction />
    <CharacterCreationStep1 />
    <CharacterCreationStep2 />
    <CharacterCreationStep3 />
    <CharacterCreationStep4 />
    <CharacterCreationStep5 />
    <CharacterCreationStep6 />
    <CharacterCreationStep7 />
    <CharacterCreationStep8 />
    <CharacterCreationStep9 />
    <CharacterCreationStep10 />
    <CharacterCreationReview />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const title: string = "Création de personnage";

const parent = computed<Breadcrumb[]>(() => [{ text: "Personnages", to: "/regles/personnages" }]);

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description:
    "Créez un personnage unique grâce à des étapes guidées, en définissant son apparence, sa personnalité, son histoire et ses caractéristiques initiales.",
});
</script>
