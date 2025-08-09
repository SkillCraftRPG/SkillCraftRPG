<template>
  <main class="container">
    <template v-if="title">
      <h1>{{ title }}</h1>
      <AppBreadcrumb :active="title" :parent="parent" />
    </template>
    <table v-if="average" class="table table-striped">
      <tbody>
        <tr>
          <th scope="row">Argent de départ</th>
          <td>{{ caste?.wealthRoll }} ({{ average }})</td>
        </tr>
      </tbody>
    </table>
    <div v-if="html" v-html="html"></div>
    <template v-if="skill">
      <h2 class="h3">Compétence</h2>
      <p>
        Cette <NuxtLink to="/regles/competences">compétence</NuxtLink> est fondamentale aux personnages de cette caste. Au moment de sa
        <NuxtLink to="/regles/personnages/creation">création</NuxtLink>, il doit être <NuxtLink to="/regles/competences/formation">formé</NuxtLink> pour
        celle-ci.
      </p>
      <SkillCard class="mb-4" :skill="skill" />
    </template>
    <template v-if="feature">
      <h2 class="h3">Particularité : {{ caste?.feature?.name }}</h2>
      <div v-html="feature"></div>
    </template>
  </main>
</template>

<script setup lang="ts">
import { marked } from "marked";

import type { Caste, Skill } from "~/types/game";
import type { Breadcrumb } from "~/types/components";

const config = useRuntimeConfig();
const route = useRoute();

const { data } = await useFetch(`/api/castes/${route.params.slug}`, {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
});

const caste = computed<Caste | undefined>(() => data.value as Caste | undefined);
const average = computed<number | undefined>(() => {
  const wealthRoll = caste.value?.wealthRoll ?? "";
  const parts: string[] = wealthRoll.split("d");
  const dice: number = Number(parts[0]);
  const sides: number = Number(parts[1]);
  if (isNaN(dice) || isNaN(sides) || dice <= 0 || sides <= 0) {
    return undefined;
  }
  const average: number = (sides + 1) / 2;
  return Math.floor(dice * average);
});
const feature = computed<string | undefined>(() => (caste.value?.feature?.description ? (marked.parse(caste.value.feature.description) as string) : undefined));
const html = computed<string | undefined>(() => (caste.value?.description ? (marked.parse(caste.value.description) as string) : undefined));
const parent = computed<Breadcrumb[]>(() => [{ text: "Castes", to: "/regles/castes" }]);
const skill = computed<Skill | undefined>(() => caste.value?.skill ?? undefined);
const title = computed<string | undefined>(() => caste.value?.name);

useSeo({
  title: title.value,
  description: caste.value?.summary,
});
</script>
