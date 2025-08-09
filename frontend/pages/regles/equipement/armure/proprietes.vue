<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Les armures sont presque toutes dotées d’au moins une propriété.</p>
    <p>Ces propriétés sont décrites ci-dessous, et elles sont toutes compatibles entre elles.</p>
    <ul>
      <li>
        <strong>Bruyante.</strong> Les <NuxtLink to="/regles/competences/tests">tests</NuxtLink> de
        <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink> du personnage se voient affligés du
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">désavantage</NuxtLink>. Cette propriété s’applique dès que le personnage porte une pièce
        d’armure en étant dotée.
      </li>
      <li>
        <strong>Confortable.</strong> Le personnage peut <strong>dormir</strong> en portant cette armure sans subir de pénalité à sa régénération. Cette
        propriété ne s’applique plus du moment qu’il porte une pièce d’armure n’étant pas dotée de cette propriété.
      </li>
      <li>
        <strong>Ferme.</strong> La fabrication de cette armure confère au personnage la <strong>résistance</strong> aux
        <strong>dégâts physiques tranchants</strong>, que cela soit par un ensemble de pièces très fermement maintenues entre elles, ou par sa composition de
        pièces extrêmement solides. Si son armure est magique, alors il est résistant à tout dégât tranchant (physique et magique).
      </li>
      <li>
        <strong>Hybride.</strong> Les multiples couches de matériaux différents composant cette armure confèrent au personnage la résistance aux dégâts
        physiques perçants. Si son armure est magique, alors il est résistant à tout dégât perçant (physique et magique).
      </li>
      <li>
        <strong>Matelassée.</strong> La grande quantité de rembourrage constituant cette armure confère au personnage la résistance aux dégâts physiques
        contondants. Si son armure est magique, alors il est résistant à tout dégât perçant (physique et magique).
      </li>
      <li>
        <strong>Rempart.</strong> Lorsque le personnage doit effectuer un
        <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>,
        il peut remplacer son <NuxtLink to="/regles/competences/rang">rang de compétence</NuxtLink> par la valeur de <strong>Défense</strong> de l’équipement.
        S’il porte <NuxtLink to="/regles/equipement/armure/multiple">deux couches d’armure</NuxtLink> ou un
        <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink> conférant cette propriété, alors les valeurs indiquées sont cumulées.
      </li>
    </ul>
    <p>
      Afin de bénéficier des propriétés <strong>Ferme</strong>, <strong>Hybride</strong> et <strong>Matelassée</strong>, le personnage doit porter une
      <NuxtLink to="/regles/equipement/armure/partielle">pièce d’armure</NuxtLink> conférant cette propriété sur chaque membre de son corps (tête, torse, deux
      bras ainsi que deux jambes). Ces pièces peuvent appartenir à un type ou à une
      <NuxtLink to="/regles/equipement/armure/categorie">catégorie d’armure</NuxtLink> différente.
    </p>
  </main>
</template>

<script setup lang="ts">
import type { Breadcrumb } from "~/types/components";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armure", to: "/regles/equipement/armure" },
];
const title: string = "Propriétés des armures";

useSeo({
  title,
  description: "Découvrez les différentes propriétés d’armure et leurs effets, influençant la défense, le confort, la furtivité et les résistances du porteur.",
});
</script>
