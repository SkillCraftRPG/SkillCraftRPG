<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Les armes à feu sont une technologie avancée permettant de tirer des <NuxtLink to="/regles/equipement/armes/munitions">projectiles</NuxtLink> à grande
      vitesse grâce à une explosion produite avec de la poudre noire. Grâce à cette vitesse fulgurante, les projectiles des armes à feu ignorent la propriété
      <NuxtLink to="/regles/equipement/armures/proprietes">Hybride</NuxtLink> des <NuxtLink to="/regles/equipement/armures">armures</NuxtLink>.
    </p>
    <p>
      Un personnage peut fabriquer une arme à feu s’il est formé avec les
      <NuxtLink to="/regles/equipement/outils">outils de bricoleur, de forgeron et de sculpteur sur bois</NuxtLink>. Il doit posséder tous ces outils et doit
      pouvoir les utiliser. La fabrication d’une arme à feu est généralement complexe, longue et coûteuse.
    </p>
    <p>
      Il peut fabriquer des munitions d’armes à feu s’il est formé avec les
      <NuxtLink to="/regles/equipement/outils">outils de bricoleur, de forgeron et de joaillier</NuxtLink>. Il doit posséder tous ces outils et doit pouvoir les
      utiliser. La fabrication d’une munition nécessite <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>, et elle peut s’effectuer pendant une
      <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#poudre-noire">Poudre noire</a>
      </li>
      <li>
        <a href="#defectuosite">Défectuosité</a>
      </li>
      <li>
        <a href="#simples">Armes simples</a>
      </li>
      <li>
        <a href="#martiales">Armes martiales</a>
      </li>
    </ul>
    <h2 id="poudre-noir" class="h3">Poudre noire</h2>
    <p>
      La poudre noire sert à opérer à les armes à feu et l’artillerie. Lorsqu’un personnage <strong>charge</strong> son arme à feu, il verse d’abord environ un
      tiers d’once de poudre noire dans le canon de l’arme, puis il y place la <NuxtLink to="/regles/equipement/armes/munitions">munition</NuxtLink>.
    </p>
    <p>
      Elle est produite à partir d’un mélange homogène de charbon de bois, de soufre et de salpêtre séparément broyés finement. Sa production étant complexe,
      dangereuse et stratégique, elle est généralement contrôlée par les royaumes et autres états.
    </p>
    <p>
      La poudre noire craint l’humidité, car le salpêtre forme des grumeaux en absorbant l’eau. Si elle prend l’eau, elle devient inutilisable, puisque sa
      combustion devient irrégulière voire impossible.
    </p>
    <p>
      Un personnage peut produire une petite explosion en allumant 10 grammes de poudre noire, ce qui produit un vif éclair de lumière. Toute créature située à
      1,5 mètres de l’explosion doit alors effectuer un <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> de
      <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté élevée</NuxtLink> afin de ne pas être
      <NuxtLink to="/regles/combat/conditions/aveugle">aveuglée</NuxtLink> pendant un round de <NuxtLink to="/regles/aventure/temps">6 secondes</NuxtLink>.
      Également, une nuage léger de fumée englobe la zone pendant un round, créant une zone
      <NuxtLink to="/regles/aventure/environnement/vision">légèrement obscurcie</NuxtLink>.
    </p>
    <ItemExplosives />
    <h2 id="defectuosite" class="h3">Défectuosité</h2>
    <p>
      Lorsqu’une arme à feu est endommagée, les probabilités qu’elle se bloque sont de ⅓ ({{ $n(1 / 3, "percentage") }}). Elle se bloque automatiquement en cas
      d’<NuxtLink to="/regles/competences/tests/critique">échec critique</NuxtLink>.
    </p>
    <p>
      Une arme bloquée ne peut être utilisée tant qu’elle n’est pas débloquée. Elle peut être débloquée par l’action <strong>Objet</strong>, en utilisant des
      <NuxtLink to="/regles/equipement/outils">outils de bricoleur</NuxtLink> et en réussissant un
      <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/artisanat">Artisanat</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté moyenne</NuxtLink>.
    </p>
    <p>
      Lorsqu’une arme à feu brise, les probabilités qu’elle explose sont de ⅓ ({{ $n(1 / 3, "percentage") }}). Elle explose automatiquement en cas d’<NuxtLink
        to="/regles/competences/tests/critique"
        >échec critique</NuxtLink
      >. L’explosion inflige 9 + 1d6 points de dégâts de feu au personnage tenant l’arme.
    </p>
    <p>
      Toute créature située dans une case adjacente à celle du personnage doit effectuer un
      <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink> de
      <NuxtLink to="/regles/competences/tests/difficulte">difficulté moyenne</NuxtLink>. En cas d’échec, la créature reçoit également les points de dégâts.
    </p>
    <h2 id="simples" class="h3">Armes simples</h2>
    <p>Armes simples à feu accessibles, pratiques mais limitées en portée et en puissance.</p>
    <ItemWeaponList :items="simple" multiple />
    <h2 id="martiales" class="h3">Armes martiales</h2>
    <p>Armes martiales à feu puissantes et variées, exigeant entraînement et maîtrise.</p>
    <ItemWeaponList :items="martial" multiple />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Weapon } from "~/types/items";
import { getFirearms } from "~/services/items";

const parent: Breadcrumb[] = [
  { text: "Équipement", to: "/regles/equipement" },
  { text: "Armes", to: "/regles/equipement/armes" },
];
const title: string = "Armes à feu";
const { orderBy } = arrayUtils;

const firearms = ref<Weapon[]>(getFirearms());

const simple = computed<Weapon[]>(() =>
  orderBy(
    firearms.value.filter(({ category }) => category === "Simple"),
    "slug",
  ),
);
const martial = computed<Weapon[]>(() =>
  orderBy(
    firearms.value.filter(({ category }) => category === "Martial"),
    "slug",
  ),
);

useSeo({
  title,
  description:
    "Découvrez les armes à feu et la poudre noire : fonctionnement, coûts, risques de défectuosité et large arsenal de pistolets, mousquets et arquebuses.",
});
</script>
