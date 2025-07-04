<template>
  <TarSelect
    :floating="floating"
    :id="id"
    :label="label"
    :model-value="modelValue"
    :options="options"
    :placeholder="placeholder"
    @update:model-value="onModelValueUpdate"
  />
</template>

<script setup lang="ts">
import { TarSelect, type SelectOption } from "logitar-vue3-ui";
import { arrayUtils, parsingUtils } from "logitar-js";

import type { GameSkill, Skill } from "~/types/game";
import { System } from "~/types/constants";

const { orderBy } = arrayUtils;
const { parseBoolean } = parsingUtils;

const now: string = new Date().toISOString();
const anySkill: Skill = {
  id: "any",
  version: 0,
  createdBy: System,
  createdOn: now,
  updatedBy: System,
  updatedOn: now,
  slug: "",
  value: "" as GameSkill,
  name: "N’importe laquelle",
};
const noneSkill: Skill = {
  id: "none",
  version: 0,
  createdBy: System,
  createdOn: now,
  updatedBy: System,
  updatedOn: now,
  slug: "",
  value: "" as GameSkill,
  name: "Aucune",
};

const props = withDefaults(
  defineProps<{
    extended?: boolean | string;
    floating?: boolean | string;
    id?: string;
    label?: string;
    modelValue?: string;
    placeholder?: string;
    skills?: Skill[];
  }>(),
  {
    floating: true,
    id: "skill",
    label: "Compétence",
    placeholder: "Sélectionnez une compétence",
    skills: () => [],
  },
);

const options = computed<SelectOption[]>(() => {
  const options: SelectOption[] = orderBy(
    props.skills.map(({ id, name }) => ({ text: name, value: id })),
    "text",
  );
  if (parseBoolean(props.extended)) {
    options.splice(0, 0, { text: noneSkill.name, value: noneSkill.id }, { text: anySkill.name, value: anySkill.id });
  }
  return options;
});

const emit = defineEmits<{
  (e: "selected", value?: Skill): void;
  (e: "update:model-value", value?: string): void;
}>();

function onModelValueUpdate(value?: string): void {
  emit("update:model-value", value);

  let skill: Skill | undefined = undefined;
  if (value === anySkill.id) {
    skill = anySkill;
  } else if (value === noneSkill.id) {
    skill = noneSkill;
  } else if (value) {
    skill = props.skills.find(({ id }) => id === value);
  }
  emit("selected", skill);
}
</script>
