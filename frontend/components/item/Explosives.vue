<template>
  <div>
    <table class="table table-striped text-center">
      <thead>
        <tr>
          <th scope="col" class="w-third">Explosif</th>
          <th scope="col" class="w-third">Prix (deniers)</th>
          <th scope="col" class="w-third">Poids (kg)</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="explosive in items" :key="explosive.id">
          <td>{{ explosive.name }}</td>
          <td>{{ $n(explosive.price, "price") }}</td>
          <td>{{ $n(explosive.weight, "weight") }}</td>
        </tr>
      </tbody>
    </table>
    <h3 class="h5">Descriptions</h3>
    <ul>
      <li>
        <strong>Baril de poudre noire.</strong> Un petit baril contenant {{ $n(12.5, "weight") }} kilogrammes de poudre noire. Il permet de déplacer une grande
        quantité de poudre noire.
        <ul>
          <li>Le baril n’est pas hydrofuge, il doit donc être tenu à distance de toute source d’humidité afin d’éviter de perdre son contenu.</li>
          <li>
            Si le baril est enflammé, la poudre noire qu’il contient détonne. Toute créature située à 6 mètres ou moins du baril doit effectuer un
            <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties"
              >Acrobaties</NuxtLink
            >
            et un jet de sauvegarde de <NuxtLink to="/regles/competences/resistance">Résistance</NuxtLink> de
            <NuxtLink to="/regles/competences/tests/difficulte">difficulté élevée</NuxtLink>. L’explosion inflige 12d6 points de dégâts de feu en cas d’échec du
            jet de sauvegarde d’Acrobaties ou la moitié en cas de réussite. Une créature est
            <NuxtLink to="/regles/combat/conditions/renverse">renversée</NuxtLink> si elle échoue le jet de sauvegarde d’Acrobaties, et elle est assourdie
            pendant 1d4 rounds de <NuxtLink to="/regles/aventure/temps">6 secondes</NuxtLink> en cas d’échec du jet de sauvegarde de Résistance. Les flammes
            s’étendent dans les coins, et les objets inflammables dans la zone qui ne sont pas tenus ni portés prennent feu. Un nuage épais de fumée englobe la
            zone pendant 3 rounds, créant une zone <NuxtLink to="/regles/aventure/environnement/vision">lourdement obscurcie</NuxtLink>.
          </li>
        </ul>
      </li>
      <li>
        <strong>Bombe.</strong> La bombe est considérée comme une arme de <NuxtLink to="/regles/equipement/armes/proprietes">Jet (4/12)</NuxtLink> simple (+2 à
        l’<NuxtLink to="/regles/equipement/armes/attaque">Attaque</NuxtLink>). Elle est composée d’une chambre métallique et d’une mèche, et contient 250
        grammes de poudre noire.
        <ul>
          <li>
            Elle peut être allumée par une action <strong>Objet</strong>, puis lancée par une action <NuxtLink to="/regles/combat/attaque">Attaque</NuxtLink> en
            effectuant un <NuxtLink to="/regles/competences/tests">test</NuxtLink> d’<NuxtLink to="/regles/competences/orientation">Orientation</NuxtLink>.
            Lorsqu’elle percute le sol, une créature ou un objet, elle détone. Toute créature située à 3 mètres ou moins de l’impact doit effectuer un
            <NuxtLink to="/regles/competences/tests/sauvegarde">jet de sauvegarde</NuxtLink> d’<NuxtLink to="/regles/competences/acrobaties"
              >Acrobaties</NuxtLink
            >
            de <NuxtLink to="/regles/competences/tests/difficulte">difficulté</NuxtLink> égale au résultat test de l’attaque. L’explosion inflige 2d6 + moitié
            de la <NuxtLink to="/regles/statistiques/precision">Précision</NuxtLink> points de dégâts de feu en cas d’échec du jet de sauvegarde ou la moitié en
            cas de réussite.
          </li>
          <li>
            Elle peut être fabriquée en étant formé avec les <NuxtLink to="/regles/equipement/outils">outils de bricoleur et de forgeron</NuxtLink>. Le
            personnage doit posséder tous ces outils et doit pouvoir les utiliser. Sa fabrication nécessite
            <NuxtLink to="/regles/aventure/temps">une heure</NuxtLink>, et elle peut s’effectuer pendant une
            <NuxtLink to="/regles/aventure/repos/halte">halte</NuxtLink>.
          </li>
        </ul>
      </li>
      <li>
        <strong>Poire à poudre.</strong> Cette poire contient 250 grammes de poudre noire, la quantité nécessaire pour tirer 24 fois avec une arme à feu.
        <ul>
          <li>Le contenant est hydrofuge, c’est-à-dire qu’il protège son contenu l’humidité lorsqu’il est scellé.</li>
          <li>
            Lorsqu’elle contient au moins la moitié de sa capacité en poudre noire, on peut allumer la poire pour l’utiliser comme une bombe
            <NuxtLink to="/regles/equipement/armes/improvisees">improvisée</NuxtLink>. Son fonctionnement et ses effets sont identiques à la bombe.
          </li>
        </ul>
      </li>
    </ul>
  </div>
</template>

<script setup lang="ts">
import type { Item } from "~/types/items";

const items = ref<Item[]>([
  {
    id: "6b4df75b-f1c2-4371-927d-727ec8dbddc3",
    slug: "baril-de-poudre-noire",
    name: "Baril de poudre noire",
    price: 250,
    weight: 20,
    description: "",
  },
  {
    id: "b57795e1-d865-4857-ad4c-3a0472f994f1",
    slug: "bombe",
    name: "Bombe",
    price: 50,
    weight: 1,
    description: "",
  },
  {
    id: "88d0b47b-861b-4903-b899-db109feaa5f2",
    slug: "poire-a-poudre",
    name: "Poire à poudre",
    price: 7.5,
    weight: 0.5,
    description: "",
  },
]);
</script>
