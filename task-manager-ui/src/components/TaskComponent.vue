<script setup>
//import ButtonCustom from "./ButtonCustom.vue";
//import InputCustom from "./InputCustom.vue";
//import TextariaCustom from "./TextariaCustom.vue";
// import { ref } from "vue";
// import { store } from "../store";

defineProps({
  //createdBy: String,
  task: Object,
  //description: String,
});

// const task = ref({
//   CreatedBy: "",
//   title: "",
//   description: "",
// });
</script>

<template>
  <h3>{{ task.title }}</h3>
</template>

<style scoped>
/* .container {
  padding: 10px;
  max-width: 20%;
  box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.2);
  border-radius: 10px;
}

.container > * {
  border: 2px groove rgb(250, 250, 250, 0.2);
  border-radius: 3px;
  padding: 5px;
  overflow: hidden;
  word-break: break-all;
} */
</style>
