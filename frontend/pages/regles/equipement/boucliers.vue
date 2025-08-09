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
    <!-- TODO(fpion): talents -->
    <h3 id="capacites" class="h5">Capacités</h3>
    <p>Les talents suivants confèrent au personnage une ou plusieurs capacités lorsqu’il porte un bouclier :</p>
    <!-- TODO(fpion): talents -->
    <h2 id="liste" class="h3">Liste des boucliers</h2>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-15">Bouclier</th>
          <th scope="col" class="w-15">Prix (deniers)</th>
          <th scope="col" class="w-15">Poids (kg)</th>
          <th scope="col" class="w-15">Défense</th>
          <th scope="col" class="w-15">Résistance</th>
          <th scope="col" class="w-25">Propriétés</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td colspan="6"><i>Boucliers légers</i></td>
        </tr>
        <tr v-for="armor in light" :key="armor.id">
          <td>{{ armor.name }}</td>
          <td>{{ $n(armor.price, "price") }}</td>
          <td>{{ $n(armor.weight, "weight") }}</td>
          <td>{{ $n(armor.defense, "defense") }}</td>
          <td>{{ $n(armor.resistance, "resistance") }}</td>
          <td>{{ armor.properties.length ? armor.properties.join(", ") : "—" }}</td>
        </tr>
        <tr>
          <td colspan="6"><i>Boucliers moyens</i></td>
        </tr>
        <tr v-for="armor in medium" :key="armor.id">
          <td>{{ armor.name }}</td>
          <td>{{ $n(armor.price, "price") }}</td>
          <td>{{ $n(armor.weight, "weight") }}</td>
          <td>{{ $n(armor.defense, "defense") }}</td>
          <td>{{ $n(armor.resistance, "resistance") }}</td>
          <td>{{ armor.properties.length ? armor.properties.join(", ") : "—" }}</td>
        </tr>
        <tr>
          <td colspan="6"><i>Boucliers lourds</i></td>
        </tr>
        <tr v-for="armor in heavy" :key="armor.id">
          <td>{{ armor.name }}</td>
          <td>{{ $n(armor.price, "price") }}</td>
          <td>{{ $n(armor.weight, "weight") }}</td>
          <td>{{ $n(armor.defense, "defense") }}</td>
          <td>{{ $n(armor.resistance, "resistance") }}</td>
          <td>{{ armor.properties.length ? armor.properties.join(", ") : "—" }}</td>
        </tr>
      </tbody>
    </table>
    <h3 id="legers" class="h5">Boucliers légers</h3>
    <ul>
      <li v-for="armor in light" :key="armor.id">
        <strong>{{ armor.name }}.</strong> {{ armor.description }}
      </li>
    </ul>
    <h3 id="moyens" class="h5">Boucliers moyens</h3>
    <ul>
      <li v-for="armor in medium" :key="armor.id">
        <strong>{{ armor.name }}.</strong> {{ armor.description }}
      </li>
    </ul>
    <h3 id="lourds" class="h5">Boucliers lourds</h3>
    <ul>
      <li v-for="armor in heavy" :key="armor.id">
        <strong>{{ armor.name }}.</strong> {{ armor.description }}
      </li>
    </ul>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import shields from "~/assets/data/items/shields.json";
import type { Breadcrumb } from "~/types/components";
import type { Shield } from "~/types/items";

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Boucliers";

const heavy = computed<Shield[]>(() => shields.filter(({ category }) => category === "Heavy"));
const light = computed<Shield[]>(() => shields.filter(({ category }) => category === "Light"));
const medium = computed<Shield[]>(() => shields.filter(({ category }) => category === "Medium"));

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description: "Découvrez les catégories, propriétés, talents et particularités des boucliers, ainsi que leur prix, poids, défense et résistances.",
});

/* TODO(fpion): Talents
 * /regles/talents/coup-de-bouclier
 * /regles/talents/protection
 * /regles/talents/blinde
 */
</script>
