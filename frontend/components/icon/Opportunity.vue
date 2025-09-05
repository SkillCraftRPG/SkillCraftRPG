<template>
  <span>
    <font-awesome-icon icon="fas fa-exclamation" />
    <template v-if="isVariable">*</template>
  </span>
</template>

<script setup lang="ts">
import { parsingUtils } from "logitar-js";

const { parseBoolean } = parsingUtils;

const props = defineProps<{
  variable?: boolean;
}>();

const isVariable = computed<boolean>(() => parseBoolean(props.variable) ?? false);
</script>
