<script setup>
defineProps({
  error: String,
  handleShowError: Function,
});
</script>

<template>
  <div class="background-error"></div>
  <div class="main">
    <button class="local-btn" @click="handleShowError">x</button>
    <h2>error: {{ error }}</h2>
  </div>
</template>

<style scoped>
.local-btn {
  margin-left: 94%;
  background-color: burlywood;
  cursor: pointer;
}

.main {
  position: absolute;
  z-index: 30;
  width: 40%;
  top: 30%;
  left: 30%;
  background-color: white;
  padding: 10px;
  border: solid 10px red;
  border-radius: 5px;
  min-height: 20vh;
}

.background-error {
  position: absolute;
  z-index: 20;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  background-color: black;
  opacity: 0.65;
}
</style>
