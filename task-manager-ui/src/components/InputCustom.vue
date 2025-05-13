<script setup>
defineProps({
  type: String,
  placeholder: String,
  text: String,
  inputHandler: Function,
});
</script>

<template>
  <input
    :value="text"
    v-on:input="inputHandler"
    :type="type"
    :placeholder="placeholder"
    class="input-style"
  />
</template>

<style scoped>
.input-style {
  padding-left: 10px;
  padding-right: 10px;
  height: 30px;
  font-size: 15px;
  border-radius: 2px;
  outline: none;
  border: none;
  box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.2);
}

.input-style:focus {
  color: rgb(45, 21, 21);
}
</style>
