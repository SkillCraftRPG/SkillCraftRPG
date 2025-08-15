<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Un bouclier est une protection tenue par une ou plusieurs mains.</p>
    <p>De manière générale, il doit être dégainé de la même manière qu’une <strong>arme</strong>, et il peut être jeté au sol en action libre.</p>
    <p>Une créature peut bénéficier de plusieurs boucliers à la fois, mais elle ne peut lever qu’un seul bouclier à la fois.</p>
    <p>
      Les boucliers partagent les mêmes <NuxtLink to="/regles/equipement/armure/categorie">catégories</NuxtLink> et
      <NuxtLink to="/regles/equipement/armure/proprietes">propriétés</NuxtLink> que les <NuxtLink to="/regles/equipement/armure">armures</NuxtLink>.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#particularites">Particularités</a>
      </li>
      <li>
        <a href="#talents">Talents</a>
        <ul>
          <li>
            <a href="#formation">Formation</a>
          </li>
          <li>
            <a href="#capacites">Capacités</a>
          </li>
        </ul>
      </li>
      <li>
        <a href="#liste">Liste des boucliers</a>
        <ul>
          <li>
            <a href="#legers">Boucliers légers</a>
          </li>
          <li>
            <a href="#moyens">Boucliers moyens</a>
          </li>
          <li>
            <a href="#lourds">Boucliers lourds</a>
          </li>
        </ul>
      </li>
    </ul>
    <h2 id="particularites" class="h3">Particularités</h2>
    <p>
      Les boucliers <strong>légers</strong> peuvent être attachés au bras de leur porteur grâce à leur faible poids. Lorsqu’un personnage en fait ainsi, il n’a
      pas besoin de le dégainer par une action, et le bouclier ne tombe pas au sol lorsqu’il le lâche. Néanmoins, son porteur doit quand même le tenir à une
      main afin de bénéficier de sa protection.
    </p>
    <p>
      Le talent <NuxtLink to="/regles/talents/formation-martiale">Formation martiale</NuxtLink> permet au porteur d’un bouclier <strong>léger</strong> ou
      <strong>moyen</strong> de dégainer son bouclier en action libre en même temps qu’il dégaine une arme, et de ranger son bouclier en action libre au même
      moment qu’il rengaine son arme.
    </p>
    <p>
      Les boucliers <strong>lourds</strong> peuvent être levés par une action. Lorsqu’une créature lève son bouclier, celui-ci lui confère des
      <strong>points de Défense</strong> supplémentaires et elle peut bénéficier de la propriété <i>Rempart</i> du bouclier, mais sa vitesse de réduite de
      moitié. Elle peut abaisser son bouclier en action libre afin d’annuler les bénéfices et pénalités associés.
    </p>
    <h2 id="talents" class="h3">Talents</h2>
    <p>Les talents suivants sont utiles aux utilisateurs de boucliers.</p>
    <h3 id="formation" class="h5">Formation</h3>
    <p>
      Un personnage est formé au port des boucliers de la même manière qu’il est
      <NuxtLink to="/regles/equipement/armure/formation">formé au port des armures</NuxtLink>.
    </p>
    <p>Lorsqu’un personnage porte un bouclier pour lequel il n’est pas formé, il subit les pénalités suivantes :</p>
    <ul>
      <li>
        Pénalité (égale au nombre de points de Défense conférés par le bouclier) au <NuxtLink to="/regles/competences/tests">test</NuxtLink> des
        <NuxtLink to="/regles/competences">compétences</NuxtLink> associées à l’<NuxtLink to="/regles/attributs/adresse">Adresse</NuxtLink>, à la
        <NuxtLink to="/regles/attributs/vigueur">Vigueur</NuxtLink> et au surnaturel, notamment :
        <ul>
          <li>
            <NuxtLink to="/regles/competences/acrobaties">Acrobaties</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/artisanat">Artisanat</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/athletisme">Athlétisme</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/furtivite">Furtivité</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/melee">Mêlée</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/occultisme">Occultisme</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink>
          </li>
          <li>
            <NuxtLink to="/regles/competences/roublardise">Roublardise</NuxtLink>
          </li>
        </ul>
      </li>
      <li>
        <NuxtLink to="/regles/competences/tests/avantage-desavantage">Désavantage</NuxtLink> aux tests d’Occultisme afin de canaliser un
        <NuxtLink to="/regles/pouvoirs">pouvoir</NuxtLink> nécessitant la composante <strong>Somatique</strong>.
      </li>
    </ul>
    <p>Les talents suivants forment le personnage au port des boucliers d’une certaine catégorie :</p>
    <div class="row">
      <div v-for="talent in talentsFormation" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
    <h3 id="capacites" class="h5">Capacités</h3>
    <p>Les talents suivants confèrent au personnage une ou plusieurs capacités lorsqu’il porte un bouclier :</p>
    <div class="row">
      <div v-for="talent in talentsCapacity" :key="talent.id" class="col-xs-12 col-sm-6 col-md-4 mb-4">
        <TalentCard class="d-flex flex-column h-100" :talent="talent" />
      </div>
    </div>
    <h2 id="liste" class="h3">Liste des boucliers</h2>
    <h3 id="legers" class="h5">Boucliers légers</h3>
    <ItemShieldList :items="light" />
    <h3 id="moyens" class="h5">Boucliers moyens</h3>
    <ItemShieldList :items="medium" />
    <h3 id="lourds" class="h5">Boucliers lourds</h3>
    <ItemShieldList :items="heavy" />
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Breadcrumb } from "~/types/components";
import type { Shield } from "~/types/items";
import type { Talent } from "~/types/game";
import { getShields } from "~/services/items";
import { getTalents } from "~/services/talents";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const slugsCapacity: Set<string> = new Set(["blinde", "coup-de-bouclier", "protection"]);
const slugsFormation: Set<string> = new Set(["melee", "formation-martiale", "cuirasse"]);
const title: string = "Boucliers";
const { orderBy } = arrayUtils;

const shields = ref<Shield[]>(getShields());
const talents = ref<Talent[]>(getTalents({ requiredTalent: true, skill: true }));

const heavy = computed<Shield[]>(() =>
  orderBy(
    shields.value.filter(({ category }) => category === "Heavy"),
    "slug",
  ),
);
const light = computed<Shield[]>(() =>
  orderBy(
    shields.value.filter(({ category }) => category === "Light"),
    "slug",
  ),
);
const medium = computed<Shield[]>(() =>
  orderBy(
    getShields().filter(({ category }) => category === "Medium"),
    "slug",
  ),
);

const talentsCapacity = computed<Talent[]>(() =>
  orderBy(
    talents.value.filter(({ slug }) => slugsCapacity.has(slug)).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);
const talentsFormation = computed<Talent[]>(() =>
  orderBy(
    talents.value.filter(({ slug }) => slugsFormation.has(slug)).map((talent) => ({ ...talent, sort: [talent.tier, talent.slug].join("_") })),
    "sort",
  ),
);

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description: "Découvrez les catégories, propriétés, talents et particularités des boucliers, ainsi que leur prix, poids, défense et résistances.",
});
</script>
