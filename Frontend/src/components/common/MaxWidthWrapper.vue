<script setup lang="ts">
import { cn } from "@/lib/utils";
import type { HTMLAttributes } from "vue";

interface Props {
  class?: HTMLAttributes["class"];
}

const props = defineProps<Props>();
</script>

<template>
  <div
    :class="cn('mx-auto px-5 md:px-20 w-full max-w-screen-xl', props.class)"
  >
    <slot />
  </div>
</template>

<style lang="scss" scoped></style>
