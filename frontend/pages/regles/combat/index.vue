<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <p>Un des importants piliers du jeu est le combat.</p>
    <p>Simple escarmouche ou bataille décisive d’une guerre, le combat est un pur alliage d’adrénaline, de brutalité et de chaos.</p>
    <p>Rare est l’aventurier qui n’expérimente pas le danger du combat au fil de ses voyages.</p>
    <p>
      Victime d’une embuscade ou membre d’un camp tentant de faire valoir ses intérêts par l’affrontement, l’aventurier devra faire preuve de force et de
      résolution.
    </p>
    <div class="row">
      <div v-for="(item, index) in items" :key="index" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <LinkCard class="d-flex flex-column h-100" :text="item.description" :title="item.title" :to="item.path" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
const title: string = "Combat";

type MenuItem = {
  path: string;
  title: string;
  description: string;
};
const items: MenuItem[] = [
  {
    path: "/regles/combat/deroulement",
    title: "Déroulement",
    description: "Organisation d’un combat : rounds, initiative, tours et conditions spéciales.",
  },
  {
    path: "/regles/combat/activites",
    title: "Activités",
    description: "🚧",
  },
  {
    path: "/regles/combat/conditions",
    title: "Conditions",
    description: "🚧",
  },
];

useSeo({
  title,
  description: "🚧",
});
</script>
