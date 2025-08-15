<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>
      Lorsqu’un personnage débute l’aventure, celui-ci est doté d’un équipement de départ. Une des étapes de la
      <NuxtLink to="/regles/personnages/creation#step-10">création de personnage</NuxtLink> consiste à déterminer cet équipement de départ.
    </p>
    <h2 class="h3">Table des matières</h2>
    <ul>
      <li>
        <a href="#richesse">Richesse de départ</a>
      </li>
      <li>
        <a href="#achat">Achat d’équipement</a>
      </li>
      <li>
        <a href="#selections">Sélections</a>
        <ul>
          <li>
            <a href="#selection-base">Sélection de base</a>
          </li>
          <li>
            <a href="#selections-personnalisees">Sélections personnalisées</a>
          </li>
        </ul>
      </li>
    </ul>
    <h2 class="h3" id="richesse">Richesse de départ</h2>
    <p>
      La fortune dont le personnage dispose dès sa création est calculée en effectuant un jet de dés défini par sa
      <NuxtLink to="/regles/castes">caste</NuxtLink> et en multipliant le résultat par un facteur défini par son
      <NuxtLink to="/regles/educations">éducation</NuxtLink>.
      <br />
      Le résultat obtenu est un nombre de <NuxtLink to="/regles/equipement/monnaie">deniers</NuxtLink>.
    </p>
    <p>
      Par exemple, pour un personnage appartenant à la caste <NuxtLink to="/regles/castes/amuseur">Amuseur</NuxtLink> <strong>(8d6)</strong> et ayant reçu une
      éducation par un <NuxtLink to="/regles/educations/mentor-venerable">Mentor vénérable</NuxtLink> <strong>(×8)</strong>, jetez 8d6 et multipliez le résultat
      par 8. <br />
      Si vous obtenez 36 en jetant les dés, votre personnage débutera donc l’aventure avec 288 deniers en sa possession.
    </p>
    <h2 class="h3" id="achat">Achat d’équipement</h2>
    <p>Avant de démarrer l’aventure, vous devez acheter de l’équipement à votre personnage en dépensant une partie ou la totalité de sa richesse de départ.</p>
    <p>Au moment de sa création, votre personnage ne possède aucun équipement, pas même une bourse ni des vêtements.</p>
    <p>
      Celui-ci débute l’aventure avec tout l’équipement acheté ainsi que toute richesse non dépensée. Il ne peut évidemment pas dépenser plus d’argent qu’il
      n’en possède.
    </p>
    <p>
      Utilisez les tables dans les autres sections afin d’acheter à votre personnage <strong>vêtements</strong>, <strong>contenants</strong>,
      <strong>armes</strong>, <NuxtLink to="/regles/equipement/armure">armures</NuxtLink>, <NuxtLink to="/regles/equipement/boucliers">boucliers</NuxtLink>,
      <strong>outils et ensembles</strong> et <strong>articles divers</strong>.
    </p>
    <p>
      <font-awesome-icon icon="fas fa-lightbulb" /> Surveillez le poids de l’équipement que vous achetez. Assurez-vous de ne pas
      <NuxtLink to="/regles/equipement/encombrement">encombrer</NuxtLink> votre personnage.
    </p>
    <h2 class="h3" id="selections">Sélections</h2>
    <p>
      Au vu de la quantité et variété impressionnantes d’équipements disponibles, il peut être normal que vous ne sachiez pas quoi acheter à votre personnage.
      Les étapes suivantes peuvent vous guider dans ce processus.
    </p>
    <ol>
      <li>Débutez avec la <a href="#selection-base">sélection de base</a>.</li>
      <li>Ajoutez ensuite une <a href="#selections-personnalisees">sélection personnalisée</a> en fonction de l’historique de votre personnage.</li>
      <li>
        Si votre personnage est formé au maniement d’armes, achetez une ou plusieurs <strong>armes</strong>.
        <br />
        <font-awesome-icon icon="fas fa-triangle-exclamation" /> Si vous achetez des armes à distance, n’oubliez pas les munitions et les étuis à munitions.
        Ceux-ci ne sont pas inclus dans le prix et poids des armes à distance.
      </li>
      <li>
        Si votre personnage est <NuxtLink to="/regles/equipement/armure/formation">formé au port d’amure</NuxtLink>, achetez une
        <NuxtLink to="/regles/equipement/armure">armure</NuxtLink>.
      </li>
      <li>
        Si votre personnage est formé à l’utilisation du <NuxtLink to="/regles/equipement/boucliers">bouclier</NuxtLink> et qu’il désire combattre avec un
        bouclier, achetez un bouclier.
      </li>
    </ol>
    <p>Les prix et poids indiqués dans les tables ci-dessous sont pour une unité.</p>
    <h3 class="h5" id="selection-base">Sélection de base ({{ $n(baseTotal, "price") }} deniers)</h3>
    <p>Cette sélection contient le matériel d’aventure nécessaire à tout aventurier.</p>
    <ItemSelectionTable v-if="baseSelection.length" :items="baseSelection" />
    <h3 class="h5" id="selections-personnalisees">Sélections personnalisées</h3>
    <p>Ces sélections contiennent le matériel adapté à certaines catégories d’aventuriers.</p>
    <template v-for="selection in customSelections" :key="selection.key">
      <h4 class="h6">{{ selection.name }} ({{ $n(selection.total, "price") }} deniers)</h4>
      <p>{{ selection.description }}</p>
      <ItemSelectionTable v-if="selection.items.length" :items="selection.items" />
    </template>
    <button class="btn btn-lg btn-primary position-fixed bottom-0 end-0 m-3 rounded-circle" @click="scrollToTop">
      <font-awesome-icon icon="fas fa-arrow-up" />
    </button>
  </main>
</template>

<script setup lang="ts">
import { arrayUtils, parsingUtils } from "logitar-js";

import selections from "~/assets/data/items/selections.json";
import type { Breadcrumb } from "~/types/components";
import type { Item, SelectionItem } from "~/types/items";
import { getClothingItems, getContainers, getGeneralItems, getTools } from "~/services/items";

type CustomSelection = {
  key: string;
  name: string;
  description: string;
  items: SelectionItem[];
  total: number;
};

const { orderBy } = arrayUtils;
const { parseNumber } = parsingUtils;

const parent: Breadcrumb[] = [{ text: "Équipement", to: "/regles/equipement" }];
const title: string = "Équipement de départ";

const items = ref<Map<string, Item>>(new Map());
getClothingItems().forEach((clothes) => items.value.set(clothes.slug, clothes));
getContainers().forEach((container) => items.value.set(container.slug, container));
getGeneralItems().forEach((item) => items.value.set(item.slug, item));
getTools().forEach((tool) => items.value.set(tool.slug, tool));

const baseSelection = ref<SelectionItem[]>([]);
const customSelections = ref<CustomSelection[]>([]);

const baseTotal = computed<number>(() => baseSelection.value.reduce((sum, { quantity, price }) => sum + quantity * price, 0));

function toSelectionItem(value: string): SelectionItem {
  const parts: string[] = value.split(":");
  const slug: string = parts[0];
  const item: Item | undefined = items.value.get(slug.toLowerCase());
  if (!item) {
    throw new Error(`The item "${slug}" was not found.`);
  }

  const quantity: number = (parts.length > 0 ? parseNumber(parts[1]) : undefined) ?? 1;
  if (quantity < 1) {
    throw new Error(`The item "${slug}" quantity must be greater than 0.`);
  }

  return { ...item, quantity };
}
onMounted(() => {
  baseSelection.value = orderBy(selections.base.map(toSelectionItem), "name");
  customSelections.value = orderBy(
    selections.custom.map((selection) => {
      const items: SelectionItem[] = selection.items.map(toSelectionItem);
      return {
        ...selection,
        items,
        total: items.reduce((sum, { quantity, price }) => sum + quantity * price, 0),
      };
    }),
    "key",
  );
});

function scrollToTop(): void {
  window.history.replaceState(window.history.state, "", window.location.pathname + window.location.search);
  window.scrollTo({ top: 0, left: 0, behavior: "smooth" });
}

useSeo({
  title,
  description: "Découvrez comment déterminer la richesse et l’équipement de départ de votre personnage pour bien débuter votre aventure.",
});
</script>
