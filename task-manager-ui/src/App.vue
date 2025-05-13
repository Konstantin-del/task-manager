<script setup>
import Header from "./components/Header.vue";
import AddTaskPopup from "./components/AddTaskPopup.vue";
import MainDraggable from "./components/MainDraggable.vue";
import { ref } from "vue";

const isShow = ref(false);
const childRef = ref(null);

function isShowTogle() {
  isShow.value = !isShow.value;
}

function handleAddTask() {
  isShowTogle();
  childRef.value.showNewTask();
}
</script>

<template>
  <Header title="jopa!" :isShowTogle="isShowTogle" />
  <AddTaskPopup
    v-if="isShow"
    :isShowTogle="isShowTogle"
    @callIsShowTogle="handleAddTask"
  />
  <MainDraggable ref="childRef" />
</template>

<style>
/* @media (min-width: 1024px) {
} */
body {
  position: relative;
  margin: 0 0;
  padding: 0 0;
  width: 100%;
  height: 100vh;
}

#app {
  height: 100vh;
}
</style>
