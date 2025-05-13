import { createStore } from "vuex";
import axios from "axios";

export const store = createStore({
  state: {
    tasks: [],
  },
  mutations: {
    SET_TASKS(state, tasks) {
      state.tasks = tasks;
    },
    ADD_TASK(state, task) {
      state.tasks.push(task);
    },
    UPDATE_STATUS_TASK(state, updatedTask) {
      const index = state.tasks.findIndex((task) => task.id === updatedTask.id);
      if (index !== -1) {
        state.tasks.splice(index, 1, updatedTask);
      }
    },
    UPDATE_INDEX_TASK(state, updatedTask) {
      state.tasks = updatedTask;
    },
  },
  actions: {
    async fetchTasks({ commit }) {
      try {
        const response = await axios.get("https://localhost:7232/api/tasks");
        commit("SET_TASKS", response.data);
      } catch (error) {
        console.error("Error fetching tasks:", error);
      }
    },
    async addTask({ commit }, task) {
      try {
        const response = await axios.post(
          "https://localhost:7232/api/tasks",
          task
        );
        commit("ADD_TASK", response.data);
      } catch (error) {
        console.error("Error adding task:", error);
      }
    },
    async updateStatusTask({ commit }, data) {
      try {
        const response = await axios.patch(
          `https://localhost:7232/api/tasks/status?id=${data.id}&status=${data.status}`
        );
        commit("UPDATE_STATUS_TASK", response.data);
      } catch (error) {
        console.error("Error updating task:", error);
      }
    },
    async updateIndexTask({ commit }, data) {
      try {
        const response = await axios.patch(
          `https://localhost:7232/api/tasks`,
          data
        );
        commit("UPDATE_INDEX_TASK", response.data);
      } catch (error) {
        console.error("Error updating task:", error);
      }
    },
  },
  getters: {
    allTasks: (state) => state.tasks,
  },
});
