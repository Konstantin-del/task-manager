<script setup>
import ButtonCustom from "./ButtonCustom.vue";

const props = defineProps({
  task: Object,
  handleShowTask: Function,
});

const local = formatDateTimeOffset(props.task.createdTime);

function formatDateTimeOffset(dateTimeOffset) {
  const date = new Date(dateTimeOffset);

  const day = String(date.getDate()).padStart(2, "0");
  const month = String(date.getMonth() + 1).padStart(2, "0");
  const hours = String(date.getHours()).padStart(2, "0");
  const minutes = String(date.getMinutes()).padStart(2, "0");

  return `${day}.${month} ${hours}:${minutes}`;
}
</script>

<template>
  <div class="background"></div>
  <div class="middle-container">
    <h2>{{ task.title }}</h2>
    <div class="tasks-container">
      <ButtonCustom
        titel="close"
        :someEvent="handleShowTask"
        style="margin-left: 80%; width: 20%"
      />
      <h3>{{ task.createdBy }}</h3>
      <h3>{{ task.description }}</h3>
      <h3>{{ local }}</h3>
    </div>
  </div>
</template>

<style scoped>
.middle-container {
  position: absolute;
  z-index: 15;
  min-width: 40%;
  top: 30%;
  left: 30%;
}

.tasks-container {
  background-color: white;
  padding: 10px;
  border-radius: 5px;
  min-height: 20vh;
}

.tasks-container > h3 {
  border: 2px groove rgb(250, 250, 250, 0.2);
  border-radius: 3px;
  padding: 5px;
  overflow: hidden;
  word-break: break-all;
}

h2 {
  background-color: burlywood;
  border-radius: 5px;
  padding: 5px;
}

.background {
  position: absolute;
  z-index: 10;
  width: 100%;
  height: 100%;
  background-color: black;
  opacity: 0.65;
}
</style>
