<script setup>
defineProps({
  task: Object,
  handleShowTask: Function,
});
</script>

<template>
  <h3 @dblclick="handleShowTask(task)">{{ task.title }}</h3>
</template>

<style scoped></style>
