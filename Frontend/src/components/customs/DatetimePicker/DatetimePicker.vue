<script lang="ts" setup>
import {
  CalendarCell,
  CalendarCellTrigger,
  CalendarGrid,
  CalendarGridBody,
  CalendarGridHead,
  CalendarGridRow,
  CalendarHeadCell,
  CalendarHeader,
  CalendarHeading,
  CalendarNextButton,
  CalendarPrevButton,
} from "@/components/ui/calendar";
import { cn } from "@/lib/utils";
import { CalendarDate } from "@internationalized/date";
import {
  CalendarRoot,
  type CalendarRootProps,
  useForwardPropsEmits,
} from "reka-ui";
import { computed, type HTMLAttributes, ref, watch } from "vue";
import TimePicker from "@/components/customs/DatetimePicker/TimePicker.vue";
const props = defineProps<
  CalendarRootProps & { class?: HTMLAttributes["class"] }
>();
const formattedProps = computed(() => {
  const { class: _, ...delegated } = props;
  return delegated;
});
const forwarded = useForwardPropsEmits(formattedProps);
const dateTimeValue = defineModel();
function initializeTime() {
  if (dateTimeValue.value instanceof Date) {
    return dateTimeValue.value;
  }
  return new Date(new Date().setHours(0, 0, 0, 0));
}
const selectedTime = ref(initializeTime());
function initializeCalendarDate() {
  if (dateTimeValue.value instanceof Date) {
    const today = new Date(dateTimeValue.value);
    return new CalendarDate(
      today.getFullYear(),
      today.getMonth() + 1,
      today.getDate()
    );
  }
  return null;
}
const selectedCalendarDate = ref(initializeCalendarDate());
function createCombinedDateTime() {
  if (selectedCalendarDate.value == null) {
    const today = new Date();
    selectedCalendarDate.value = new CalendarDate(
      today.getFullYear(),
      today.getMonth() + 1,
      today.getDate()
    );
  }
  const combinedDateTime = new Date(selectedCalendarDate.value);
  combinedDateTime.setHours(selectedTime.value.getHours());
  combinedDateTime.setMinutes(selectedTime.value.getMinutes());
  return combinedDateTime;
}
watch([selectedCalendarDate, selectedTime], () => {
  dateTimeValue.value = createCombinedDateTime();
});
</script>

<template>
  <div>
    <CalendarRoot
      v-slot="{ grid, weekDays }"
      :class="cn('p-3', props.class)"
      v-bind="forwarded"
      v-model="selectedCalendarDate"
    >
      <CalendarHeader>
        <CalendarPrevButton />
        <CalendarHeading />
        <CalendarNextButton />
      </CalendarHeader>

      <div class="flex sm:flex-row flex-col gap-y-4 sm:gap-x-4 sm:gap-y-0 mt-4">
        <CalendarGrid v-for="month in grid" :key="month.value.toString()">
          <CalendarGridHead>
            <CalendarGridRow>
              <CalendarHeadCell v-for="day in weekDays" :key="day">
                {{ day }}
              </CalendarHeadCell>
            </CalendarGridRow>
          </CalendarGridHead>
          <CalendarGridBody>
            <CalendarGridRow
              v-for="(weekDates, index) in month.rows"
              :key="`weekDate-${index}`"
              class="mt-2 w-full"
            >
              <CalendarCell
                v-for="weekDate in weekDates"
                :key="weekDate.toString()"
                :date="weekDate"
              >
                <CalendarCellTrigger :day="weekDate" :month="month.value" />
              </CalendarCell>
            </CalendarGridRow>
          </CalendarGridBody>
        </CalendarGrid>
      </div>

      <TimePicker
        v-model:date="selectedTime"
        with-labels
        class="-mx-3 mt-4 px-4 pt-3 border-t"
      />
    </CalendarRoot>
  </div>
</template>
