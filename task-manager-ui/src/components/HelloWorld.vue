<!-- <script setup>
defineProps({
  msg: {
    type: String,
    required: true,
  },
});
</script> -->

<template>
  <div>
    <!-- <draggable v-model="tasks" @end="onDragEnd"> -->
    <div v-for="task in tasks" :key="task.TaskId" class="task-item">
      <h3>{{ task.Title }}ccc</h3>
      <p>{{ task.Description }}ccc</p>
      <p>Status: {{ task.Status }}ccc</p>
    </div>
    <!-- </draggable> -->
  </div>
</template>

<script>
import { mapGetters } from "vuex";
import draggable from "vue-draggable";

export default {
  // components: { draggable },
  computed: {
    ...mapGetters(["allTasks"]),
  },
  data() {
    return {
      tasks: this.allTasks,
    };
  },
  methods: {
    onDragEnd(event) {
      const movedTaskId = this.tasks[event.oldIndex].TaskId;
      const newStatus = this.getNewStatus(event.newIndex);
      this.updateTaskStatus(movedTaskId, newStatus);
    },
    getNewStatus(index) {
      // Логика для определения нового статуса задачи
    },
    async updateTaskStatus(TaskId, status) {
      try {
        await this.$store.dispatch("updateTask", { TaskId, Status: status });
      } catch (error) {
        console.error("Error updating task status:", error);
      }
    },
  },
  watch: {
    allTasks: {
      handler(newTasks) {
        this.tasks = newTasks;
      },
      immediate: true,
    },
  },
};
</script>

<style>
.task-item {
  border: 1px solid #ccc;
  margin: 5px;
  padding: 10px;
  border-radius: 5px;
}
</style>
