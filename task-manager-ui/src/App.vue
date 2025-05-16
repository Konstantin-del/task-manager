<script setup>
import Header from "./components/Header.vue";
import AddTaskModal from "./components/AddTaskModal.vue";
import MainDraggable from "./components/MainDraggable.vue";
import AddAssignedModal from "./components/AddAssignedModal.vue";
import TaskModal from "./components/TaskModal.vue";
import CatchError from "./components/CatchError.vue";
import { ref } from "vue";

const isShowAddAssigned = ref(false);
const isShow = ref(false);
const childRef = ref(null);
const isShowTask = ref(false);
const isError = ref(false);

function handleShowAddTask() {
  isShow.value = !isShow.value;
}

function handleAddTask() {
  handleShowAddTask();
  childRef.value.showNewTask();
}

let keepId = -1;

function handleShowAddAssigned(id) {
  if (id) keepId = id;
  isShowAddAssigned.value = !isShowAddAssigned.value;
}

function handleNotAddAssigned() {
  if (keepId) childRef.value.returnItemBack(keepId);
  isShowAddAssigned.value = !isShowAddAssigned.value;
}

let currentTask = {};

function handleShowTask(task) {
  if (task) currentTask = task;
  isShowTask.value = !isShowTask.value;
}

let curentError = null;
function customHandleError(error) {
  console.log(error, "app");
  curentError = error.title ?? error;
  handleShowError();
}

function handleShowError() {
  isError.value = !isError.value;
}
</script>
<template>
  <Header title="task manager!" :isShowTogle="handleShowAddTask" />
  <AddTaskModal
    v-if="isShow"
    :isShowTogle="handleShowAddTask"
    :callIsShowTogle="handleAddTask"
    :customHandleError="customHandleError"
  />
  <AddAssignedModal
    v-if="isShowAddAssigned"
    :keepId="keepId"
    :handleNotAddAssigned="handleNotAddAssigned"
    :handleShowAddAssigned="handleShowAddAssigned"
  />
  <TaskModal
    v-if="isShowTask"
    :task="currentTask"
    :handleShowTask="handleShowTask"
  />
  <CatchError
    v-if="isError"
    :error="curentError"
    :handleShowError="handleShowError"
  />
  <MainDraggable
    ref="childRef"
    :handleShowAddAssigned="handleShowAddAssigned"
    :handleShowTask="handleShowTask"
    :customHandleError="customHandleError"
  />
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
