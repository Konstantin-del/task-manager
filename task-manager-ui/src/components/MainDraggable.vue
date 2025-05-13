<script setup>
import TaskComponent from "./TaskComponent.vue";
import { store } from "../store";
import { ref, onMounted, defineExpose, onUnmounted } from "vue";
import { VueDraggableNext } from "vue-draggable-next";

// defineProps({
//   showNewTask: Boolean,
//   //showNewTask: Function,
// });

const draggable = VueDraggableNext;

const tasksInProgress = ref([]);
const tasksToDo = ref([]);
const tasksDone = ref([]);

onMounted(() => {
  store.dispatch("fetchTasks").then(() => {
    sortAndUpdateRefWithTasks(store.state.tasks);
  });
});

function sortAndUpdateRefWithTasks(array) {
  const arr1 = [];
  const arr2 = [];
  const arr3 = [];
  array.forEach((element) => {
    if (element.status === 1) {
      arr1.push(element);
    } else if (element.status === 2) {
      arr2.push(element);
    } else if (element.status === 3) {
      arr3.push(element);
    } else {
      console.error("task have vrong status");
    }
  });

  tasksToDo.value = arr1.sort((a, b) => a.index - b.index);
  tasksInProgress.value = arr2.sort((a, b) => a.index - b.index);
  tasksDone.value = arr3.sort((a, b) => a.index - b.index);
}

const showNewTask = () => {
  let result = store.getters.allTasks;
  sortAndUpdateRefWithTasks(result);
  updateTasksInDb(null);
};

defineExpose({
  showNewTask,
});

function updateTasksInDb(event) {
  let tasksForUpdateIndex = [];

  if (event) {
    let newContainerId = event.to.id;
    let oldContainerId = event.from.id;

    if (oldContainerId === "1") tasksForUpdateIndex.push(tasksToDo.value);
    if (oldContainerId === "2") tasksForUpdateIndex.push(tasksInProgress.value);
    if (oldContainerId === "3") tasksForUpdateIndex.push(tasksDone.value);

    if (oldContainerId !== newContainerId) {
      const data = {};
      data.id = event.item._underlying_vm_.id;
      data.status = newContainerId;
      store.dispatch("updateStatusTask", data);

      if (newContainerId === "1") tasksForUpdateIndex.push(tasksToDo.value);
      if (newContainerId === "2")
        tasksForUpdateIndex.push(tasksInProgress.value);
      if (newContainerId === "3") tasksForUpdateIndex.push(tasksDone.value);
    }
  } else {
    tasksForUpdateIndex.push(tasksToDo.value);
  }

  const tasksList = updateIndex(tasksForUpdateIndex);
  store.dispatch("updateIndexTask", tasksList);
}

function updateIndex(array) {
  let tasksWithNewIndex = [];
  array.forEach((element) => {
    element.forEach((t, index) => {
      t.index = index;
    });
    tasksWithNewIndex = tasksWithNewIndex.concat(element);
  });
  return tasksWithNewIndex;
}
</script>

<template>
  <div class="main-container">
    <div class="middle-container">
      <h2>To Do</h2>
      <draggable
        v-model="tasksToDo"
        group="tasks"
        @end="updateTasksInDb"
        class="tasks-container"
        id="1"
      >
        <template v-for="task in tasksToDo" :key="task.id">
          <TaskComponent :task="task" />
        </template>
      </draggable>
    </div>
    <div class="middle-container">
      <h2>In Progras</h2>
      <draggable
        v-model="tasksInProgress"
        group="tasks"
        @end="updateTasksInDb"
        class="tasks-container"
        id="2"
      >
        <template v-for="task in tasksInProgress" :key="task.id">
          <TaskComponent :task="task" />
        </template>
      </draggable>
    </div>
    <div class="middle-container">
      <h2>Done</h2>
      <draggable
        v-model="tasksDone"
        group="tasks"
        @end="updateTasksInDb"
        class="tasks-container"
        id="3"
      >
        <template v-for="task in tasksDone" :key="task.id">
          <TaskComponent :task="task" />
        </template>
      </draggable>
    </div>
  </div>
</template>

<style>
.main-container {
  display: flex;
  justify-content: space-around;
  margin-top: 10vh;
  padding: 20px;
}

.middle-container {
  min-width: 25%;
}

.tasks-container {
  padding: 10px;
  box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.2);
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
  box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.2);
}
</style>
