<script setup>
import ButtonCustom from "./ButtonCustom.vue";
import InputCustom from "./InputCustom.vue";
import { ref } from "vue";
import { store } from "../store";

const props = defineProps({
  handleNotAddAssigned: Function,
  handleShowAddAssigned: Function,
  keepId: Number,
});

const name = ref("");

const addAssigned = () => {
  const data = {};
  data.id = props.keepId;
  data.name = name.value;
  console.log(data);
  if (data.name && data.id) {
    store.dispatch("addAssigned", data);
    name.value = "";
  }
  props.handleShowAddAssigned();
};
</script>

<template>
  <div class="background"></div>
  <form class="form-container">
    <ButtonCustom
      titel="close"
      :someEvent="handleNotAddAssigned"
      style="margin-left: 80%"
    />
    <InputCustom
      type="text"
      placeholder="enter your name"
      :text="name"
      :inputHandler="(event) => (name = event.target.value)"
    />
    <ButtonCustom
      titel="submit"
      :someEvent="addAssigned"
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
