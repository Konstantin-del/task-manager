<script setup>
import ButtonCustom from "./ButtonCustom.vue";
import InputCustom from "./InputCustom.vue";
import TextariaCustom from "./TextariaCustom.vue";
import { ref } from "vue";
import { store } from "../store";

const props = defineProps({
  isShowTogle: Function,
  callIsShowTogle: Function,
  customHandleError: Function,
});

const task = ref({
  createdBy: "",
  title: "",
  description: "",
  index: -1,
});

const addNewTask = () => {
  if (task.value.createdBy && task.value.title && task.value.description) {
    store.dispatch("addTask", task.value).then(() => {
      const error = store.getters.error;
      if (error) props.customHandleError(error);
      else {
        props.callIsShowTogle();
        task.value.createdBy = "";
        task.value.title = "";
        task.value.description = "";
      }
    });
  }
};
</script>

<template>
  <div class="background"></div>
  <form class="form-container">
    <ButtonCustom
      titel="close"
      :someEvent="isShowTogle"
      style="margin-left: 80%"
    />
    <InputCustom
      type="text"
      placeholder="enter your name"
      :text="task.createdBy"
      :inputHandler="(event) => (task.createdBy = event.target.value)"
    />
    <InputCustom
      type="text"
      placeholder="enter title task"
      :text="task.title"
      :inputHandler="(event) => (task.title = event.target.value)"
    />
    <TextariaCustom
      rows="10"
      placeholder="enter description"
      :text="task.description"
      :textariaHandler="(event) => (task.description = event.target.value)"
    />
    <ButtonCustom
      titel="submit"
      :someEvent="addNewTask"
      style="margin-right: 80%"
    />
  </form>
</template>

<style scoped>
.background {
  position: absolute;
  z-index: 10;
  width: 100%;
  height: 100%;
  background-color: black;
  opacity: 0.65;
}

.form-container {
  position: absolute;
  z-index: 15;
  top: 30%;
  left: 30%;
  width: 40%;
  display: flex;
  flex-direction: column;
  justify-content: center;
  gap: 5px;
  background-color: white;
  padding: 20px;
  border-radius: 10px;
}
</style>
