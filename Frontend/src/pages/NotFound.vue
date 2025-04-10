<script setup lang="ts">
import MaxWidthWrapper from "@/components/common/MaxWidthWrapper.vue";
import { Button } from "@/components/ui/button";
import { useRouter } from "vue-router";

const router = useRouter();

const goToHome = () => {
  router.push("/assignments");
};
</script>

<template>
  <div class="flex justify-center items-center w-screen h-screen">
    <MaxWidthWrapper class="max-w-4xl">
      <div class="flex flex-col justify-center items-center gap-2 text-center">
        <h1 class="m-0 p-0 text-sky-600 text-9xl">404</h1>
        <h2 class="text-slate-700 text-4xl">Page Not Found</h2>
        <p class="text-slate-500 text-lg">
          The page you are looking for does not exist.
        </p>
        <p class="text-slate-500 text-lg">You can go back to the home page.</p>
        <Button
          @click="goToHome"
          class="bg-sky-600 hover:bg-sky-700 mt-4 px-4 py-2 rounded-lg text-white transition duration-200"
        >
          Go to Home
        </Button>
      </div>
    </MaxWidthWrapper>
  </div>
</template>

<style scoped></style>
