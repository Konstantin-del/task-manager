<script setup>
defineProps({
  titel: String,
  someEvent: Function,
});
</script>

<template>
  <button class="btn" @click.prevent="someEvent">{{ titel }}</button>
</template>

<style scoped>
.btn {
  border: none;
  background-color: white;
  border-radius: 6px;
  padding: 5px;
  box-shadow: 0px 0px 30px rgba(0, 0, 0, 0.2);
  cursor: pointer;
}

.btn:hover {
  background-color: rgb(179, 170, 170);
}
</style>
