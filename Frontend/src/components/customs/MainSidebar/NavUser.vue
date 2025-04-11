<script setup lang="ts">
import { Avatar, AvatarFallback, AvatarImage } from "@/components/ui/avatar";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuGroup,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuSeparator,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import {
  SidebarMenu,
  SidebarMenuButton,
  SidebarMenuItem,
  useSidebar,
} from "@/components/ui/sidebar";
import { useAuthStore } from "@/stores";
import { Bell, ChevronsUpDown, CircleUser, LogOut } from "lucide-vue-next";
import { useRouter } from "vue-router";

const { isMobile } = useSidebar();
const auth = useAuthStore();
const router = useRouter();

const props = defineProps<{
  user?: {
    name: string;
    email: string;
    avatar: string;
  };
}>();

const handleLogout = () => {
  auth.logout();
  router.push({ name: "login" });
};
</script>

<template>
  <SidebarMenu>
    <SidebarMenuItem>
      <DropdownMenu>
        <DropdownMenuTrigger as-child class="cursor-pointer">
          <SidebarMenuButton
            size="lg"
            class="data-[state=open]:bg-sidebar-accent data-[state=open]:text-sidebar-accent-foreground"
          >
            <Avatar class="rounded-lg w-8 h-8">
              <AvatarImage :src="user?.avatar || ''" :alt="user?.name" />
              <AvatarFallback class="rounded-lg">
                {{ user?.name?.substring(0, 2).toUpperCase() }}
              </AvatarFallback>
            </Avatar>
            <div class="flex-1 grid text-sm text-left leading-tight">
              <span class="font-semibold truncate">{{ user?.name }}</span>
              <span class="text-muted-foreground text-xs truncate">
                {{ user?.email || '' }}
              </span>
            </div>
            <ChevronsUpDown class="ml-auto size-4" />
          </SidebarMenuButton>
        </DropdownMenuTrigger>
        <DropdownMenuContent
          class="rounded-lg w-[--reka-dropdown-menu-trigger-width] min-w-56"
          :side="isMobile ? 'bottom' : 'right'"
          align="end"
          :side-offset="4"
        >
          <DropdownMenuLabel class="p-0 font-normal">
            <div class="flex items-center gap-2 px-1 py-1.5 text-sm text-left">
              <Avatar class="rounded-lg w-8 h-8">
                <AvatarImage :src="user?.avatar || ''" :alt="user?.name" />
                <AvatarFallback class="rounded-lg">
                  {{ user?.name?.substring(0, 2).toUpperCase() }}
                </AvatarFallback>
              </Avatar>
              <div class="flex-1 grid text-sm text-left leading-tight">
                <span class="font-semibold truncate">{{ user?.name }}</span>
                <span class="text-muted-foreground text-xs truncate">
                  {{ user?.email || '' }}
                </span>
              </div>
            </div>
          </DropdownMenuLabel>
          <DropdownMenuSeparator />
          <DropdownMenuGroup>
            <DropdownMenuItem class="cursor-pointer">
              <CircleUser />
              Account
            </DropdownMenuItem>
            <DropdownMenuItem class="cursor-pointer">
              <Bell />
              Notifications
            </DropdownMenuItem>
            <DropdownMenuSeparator />
            <DropdownMenuItem class="cursor-pointer" @click="handleLogout">
              <LogOut />
              Logout
            </DropdownMenuItem>
          </DropdownMenuGroup>
        </DropdownMenuContent>
      </DropdownMenu>
    </SidebarMenuItem>
  </SidebarMenu>
</template>

<style scoped></style>
