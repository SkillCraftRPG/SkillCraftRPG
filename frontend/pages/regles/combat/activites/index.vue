<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" :parent="parent" />
    <p>Cette page liste les activités pouvant être effectuées en combat.</p>
    <h2 class="h3">Légende</h2>
    <ul>
      <li>
        Les diamants « <IconAction /> » représentent le nombre d’<NuxtLink to="/regles/combat/deroulement/tour">actions</NuxtLink>
        nécessaires afin d’effectuer cette activité. Certaines activités ont un nombre variable d’actions.
      </li>
      <li>Les activités marquées de « <IconReaction /> » nécessitent d’utiliser sa <NuxtLink to="/regles/combat/deroulement/tour">réaction</NuxtLink>.</li>
      <li>
        Les activités marquées de « <IconOpportunity /> » déclenchent une <strong>attaque d’opportunité</strong>. L’astérisque « * » indique que l’activité ne
        déclenche pas toujours l’attaque d’opportunité.
      </li>
    </ul>
    <h2 class="h3">Liste des activités</h2>
    <!-- TODO(fpion): filter by category (1-2-3 actions, reaction, action libre) -->
    <!-- TODO(fpion): filtrer par attaque d’opportunité -->
    <!-- TODO(fpion): sort by category, name  -->
    <!-- TODO(fpion): grid vs table  -->
    <div class="row">
      <div v-for="activity in sortedActivities" :key="activity.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <BattleActivityCard :activity="activity" />
      </div>
    </div>
    <!-- TODO(fpion): tableau des attaques d’opportunité ici ou dans la page d’attaque d’opportunité, https://www.d20srd.org/srd/combat/actionsInCombat.htm -->
  </main>
</template>

<script setup lang="ts">
import { arrayUtils } from "logitar-js";

import type { Activity } from "~/types/game";
import type { Breadcrumb } from "~/types/components";
import { getActivities } from "~/services/battle";

const parent: Breadcrumb[] = [{ text: "Combat", to: "/regles/combat" }];
const title: string = "Activités";
const { orderBy } = arrayUtils;

const activities = ref<Activity[]>(getActivities());

const sortedActivities = computed<Activity[]>(() => orderBy(activities.value, "name"));

useSeo({
  title,
  description: "🚧",
});
</script>
