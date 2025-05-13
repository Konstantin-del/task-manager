<script setup>
defineProps({
  rows: String,
  placeholder: String,
  text: String,
  textariaHandler: Function,
});
</script>

<template>
  <textarea
    :rows="rows"
    :placeholder="placeholder"
    class="textarea-style"
    @input="textariaHandler"
    :value="text"
  />
</template>

<style scoped>
.textarea-style {
  padding: 10px;
  height: 30%;
  font-size: 15px;
  border-radius: 2px;
  outline: none;
  border: none;
  box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.2);
  resize: none;
}
</style>
