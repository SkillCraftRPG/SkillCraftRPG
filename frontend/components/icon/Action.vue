<template>
  <span>
    <template v-if="isOptional">(</template>
    <font-awesome-icon icon="fas fa-gem" />
    <template v-if="isOptional">)</template>
  </span>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  optional?: boolean;
}>();

const isOptional = computed<boolean>(() => parseBoolean(props.optional) ?? false);
</script>
