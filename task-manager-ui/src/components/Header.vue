<script setup>
import ButtonCustom from "./ButtonCustom.vue";

defineProps({
  title: String,
  isShowTogle: Function,
});
</script>

<template>
  <header class="header">
    <h1>{{ title }}</h1>
    <ButtonCustom titel="add task" :someEvent="isShowTogle" />
  </header>
</template>

<style scoped>
h1 {
  margin: 0 0;
}

header {
  position: sticky;
  top: 0;
  width: 100%;
  height: 10vh;
  background-color: burlywood;
  display: flex;
  justify-content: space-around;
  align-items: center;
  padding: 0 20px;
}

.btn {
  background-color: white;
  border-radius: 6px;
  padding: 5px;
}
</style>
