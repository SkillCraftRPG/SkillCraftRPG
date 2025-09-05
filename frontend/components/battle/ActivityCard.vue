<template>
  <LinkCard class="d-flex flex-column h-100" :text="activity.summary" :title="activity.name" :to="activity.path">
    <template #subtitle-override>
      <h3 v-if="hasSubtitle" class="card-subtitle h6 mb-2 text-body-secondary">
        <IconAction v-for="index in activity.actions.mandatory" :key="index" class="me-1" />
        <IconAction v-for="index in activity.actions.optional" :key="index" class="me-1" optional />
        <IconReaction v-if="activity.reaction" class="me-1" />
        <IconOpportunity v-if="activity.threatening" class="me-1" :variable="mayBeThreatening" />
      </h3>
    </template>
  </LinkCard>
</template>

<script setup lang="ts">
import type { Activity } from "~/types/game";

const props = defineProps<{
  activity: Activity;
}>();

const hasSubtitle = computed<boolean>(() =>
  Boolean(props.activity.actions.mandatory > 0 || props.activity.actions.optional > 0 || props.activity.reaction || props.activity.threatening),
);
const mayBeThreatening = computed<boolean>(() => props.activity.threatening === "maybe");
</script>
