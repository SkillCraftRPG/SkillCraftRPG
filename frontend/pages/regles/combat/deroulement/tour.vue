<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Au cours d’un round, une créature peut :</p>
    <ul>
      <li>Utiliser jusqu’à 3 actions.</li>
      <li>Effectuer un nombre indéfini d’actions libres.</li>
      <li>Prendre sa réaction.</li>
    </ul>
    <p>Une créature <NuxtLink to="/regles/combat/deroulement/surprise">surprise</NuxtLink> perd son premier tour.</p>
    <h2 class="h3">Actions</h2>
    <p>Pendant son tour, une créature peut utiliser jusqu’à 3 actions.</p>
    <p>
      Les <NuxtLink to="/regles/combat/activites">activités</NuxtLink> ont un coût variable en actions, illustré par un nombre de diamants « <IconAction /> ».
    </p>
    <p>Une créature peut effectuer plusieurs fois la même activité, sauf indication contraire, tant qu’elle ne dépasse pas sa limite d’actions.</p>
    <p>À la fin de son tour, tout action inutilisée est perdue. Au début de son prochain tour, elle peut à nouveau utiliser jusqu’à 3 actions.</p>
    <h2 class="h3">Actions libres</h2>
    <p>
      Les actions libres ne coûtent aucun action, car leur temps d’exécution est instantané, où elles peuvent être effectuées en même temps qu’une autre action.
    </p>
    <p>
      Une créature peut effectuer autant d’action libres pendant un round que la logique le permet. Par exemple, elle peut parler, mais son discours ne doit pas
      durer plus de 6 secondes. En langue française, on peut exprimer approximativement 25 mots par round.
    </p>
    <h2 class="h3">Réaction</h2>
    <p>Une créature peut réagir à l’action d’une autre créature lorsque la situation le permet.</p>
    <p>Le tour de la créature interrompue est suspendu le temps de résoudre la réaction, et il reprend ensuite son cours.</p>
    <p>Une créature peut réagir à la réaction d’une autre créature, même lorsque cette réaction se produit pendant son propre tour.</p>
    <p>
      La majorité des réactions correspondent à une <strong>attaque d’opportunité</strong>, mais certaines capacités permettent d’effectuer d’autres activités
      en réaction.
    </p>
    <p>Une créature <NuxtLink to="/regles/combat/deroulement/depourvu">prise au dépourvu</NuxtLink> ne peut utiliser sa réaction.</p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Combat", to: "/regles/combat" },
  { text: "Déroulement", to: "/regles/combat/deroulement" },
];
const title: string = "Tour";

useSeo({
  title,
  description: "Découvrez le déroulement d’un tour de combat : actions, actions libres et réactions, ainsi que leurs limites et possibilités stratégiques.",
});
</script>
