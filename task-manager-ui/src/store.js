import { createStore } from "vuex";
import axios from "axios";

export const store = createStore({
  state: {
    tasks: [],
    error: null,
  },
  mutations: {
    SET_TASKS(state, tasks) {
      state.tasks = tasks;
      state.error = null;
    },
    ADD_TASK(state, task) {
      state.tasks.push(task);
      state.error = null;
    },
    UPDATE_STATUS_TASK(state, updatedTask) {
      const index = state.tasks.findIndex((task) => task.id === updatedTask.id);
      if (index !== -1) {
        state.tasks.splice(index, 1, updatedTask);
      }
      state.error = null;
    },
    UPDATE_INDEX_TASK(state, updatedTask) {
      state.tasks = updatedTask;
      state.error = null;
    },
    SET_ERROR(state, error) {
      state.error = error;
      console.log(state.error);
    },
  },
  actions: {
    async fetchTasks({ commit }) {
      try {
        const response = await axios.get("https://localhost:7232/api/tasks");
        commit("SET_TASKS", response.data);
      } catch (error) {
        commit(
          "SET_ERROR",
          error.response ? error.response.data.title : "Unknown error"
        );
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
        commit(
          "SET_ERROR",
          error.response ? error.response.data : "Unknown error"
        );
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
        commit(
          "SET_ERROR",
          error.response ? error.response.data : "Unknown error"
        );
        console.error("Error updating ststus task:", error);
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
        commit(
          "SET_ERROR",
          error.response ? error.response.data : "Unknown error"
        );
        console.error("Error updating index task:", error);
      }
    },
    async addAssigned({}, data) {
      try {
        await axios.patch(
          `https://localhost:7232/api/tasks/assigned?id=${data.id}&name=${data.name}`
        );
      } catch (error) {
        commit(
          "SET_ERROR",
          error.response ? error.response.data : "Unknown error"
        );
        console.error("Error adding assigned:", error);
      }
    },
  },
  getters: {
    allTasks: (state) => state.tasks,
    error: (state) => state.error,
  },
});
