<template>
  <main class="container">
    <h1>{{ title }}</h1>
    <AppBreadcrumb :active="title" />
    <!-- TODO(fpion): explanation text -->
    <p>{{ "[…]" }}</p>
    <div class="row">
      <div v-for="skill in skills" :key="skill.id" class="col-xs-12 col-sm-6 col-md-4 col-lg-3 mb-4">
        <SkillCard class="d-flex flex-column h-100" :skill="skill" />
      </div>
    </div>
  </main>
</template>

<script setup lang="ts">
import type { SearchResults, Skill } from "~/types/game";

const config = useRuntimeConfig();
const title: string = "Compétences";

const { data } = await useFetch("/api/skills", {
  baseURL: config.public.apiBaseUrl,
  cache: "no-cache",
  server: false,
});
const skills = computed<Skill[]>(() => (data.value as SearchResults<Skill>)?.items ?? []);

useSeo({
  title,
  description: "Découvrez comment les compétences traduisent les savoir-faire, aptitudes et expertises de vos héros.",
});
</script>
