<script setup lang="ts">
import {
  AlertDialog,
  AlertDialogAction,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
  AlertDialogTrigger,
} from "@/components/ui/alert-dialog";

defineProps<{
  title: string;
  message: string;
  confirmText: string;
  cancelText: string;
  onConfirm: () => void;
}>();
</script>

<template>
  <AlertDialog>
    <AlertDialogTrigger as-child>
      <slot />
    </AlertDialogTrigger>
    <AlertDialogContent>
      <AlertDialogHeader>
        <AlertDialogTitle class="text-xl">{{ title }}</AlertDialogTitle>
        <AlertDialogDescription>
          {{ message }}
        </AlertDialogDescription>
      </AlertDialogHeader>
      <AlertDialogFooter>
        <AlertDialogAction @click="onConfirm" class="cursor-pointer">
          {{ confirmText }}
        </AlertDialogAction>
        <AlertDialogCancel class="cursor-pointer">{{
          cancelText
        }}</AlertDialogCancel>
      </AlertDialogFooter>
    </AlertDialogContent>
  </AlertDialog>
</template>

<style scoped></style>
