<script setup lang="ts">
import { AssignmentCard } from "@/components/customs/AssignmentCard";
import {
  Breadcrumb,
  BreadcrumbItem,
  BreadcrumbLink,
  BreadcrumbList,
  BreadcrumbPage,
  BreadcrumbSeparator,
} from "@/components/ui/breadcrumb";
import { Separator } from "@/components/ui/separator";
import { SidebarInset, SidebarTrigger } from "@/components/ui/sidebar";
</script>

<template>
  <SidebarInset>
    <header
      class="flex items-center gap-2 h-16 group-has-[[data-collapsible=icon]]/sidebar-wrapper:h-12 transition-[width,height] ease-linear shrink-0"
    >
      <div class="flex items-center gap-2 px-4">
        <SidebarTrigger class="-ml-1 cursor-pointer" />
        <Separator orientation="vertical" class="mr-2 h-4" />
        <Breadcrumb>
          <BreadcrumbList>
            <BreadcrumbItem>
              <BreadcrumbLink href="/assignments">Assignments</BreadcrumbLink>
            </BreadcrumbItem>
            <BreadcrumbSeparator class="hidden md:block" />
            <BreadcrumbItem>
              <BreadcrumbPage>Today</BreadcrumbPage>
            </BreadcrumbItem>
          </BreadcrumbList>
        </Breadcrumb>
      </div>
    </header>
    <div class="flex flex-col flex-1 gap-4 bg-blue-100 p-4 pt-0">
      <div class="flex flex-col gap-2 mx-[10%] my-10 h-full">
        <AssignmentCard
          :color="'text-blue-500'"
          :assignment="{
            id: '1',
            userId: '123',
            title: 'Important Assignment',
            description: 'This is a description of the important assignment.',
            dueDate: '2023-10-31',
            status: 'In progress',
            priority: 'High',
            createdAt: '2023-10-01',
            updatedAt: '2023-10-15',
          }"
        />
        <AssignmentCard
          :color="'text-blue-500'"
          :assignment="{
            id: '1',
            userId: '123',
            title: 'Important Assignment',
            description: 'This is a description of the important assignment.',
            dueDate: '2023-10-31',
            status: 'In progress',
            priority: 'High',
            createdAt: '2023-10-01',
            updatedAt: '2023-10-15',
          }"
        />
        <AssignmentCard
          :color="'text-blue-500'"
          :assignment="{
            id: '1',
            userId: '123',
            title: 'Important Assignment',
            description: 'This is a description of the important assignment.',
            dueDate: '2023-10-31',
            status: 'In progress',
            priority: 'High',
            createdAt: '2023-10-01',
            updatedAt: '2023-10-15',
          }"
        />
        <AssignmentCard
          :color="'text-blue-500'"
          :assignment="{
            id: '1',
            userId: '123',
            title: 'Important Assignment',
            description: 'This is a description of the important assignment.',
            dueDate: '2023-10-31',
            status: 'In progress',
            priority: 'High',
            createdAt: '2023-10-01',
            updatedAt: '2023-10-15',
          }"
        />
      </div>
    </div>
  </SidebarInset>
</template>

<style lang="scss" scoped></style>
