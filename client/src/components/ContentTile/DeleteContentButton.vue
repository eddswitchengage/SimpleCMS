<template>
  <i
    class="las la-trash delete-content-button"
  ></i>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "DeleteContentButton",
  props: {
    id: Number,
  },
});
</script>

<style scoped>
.delete-content-button {
  color: var(--clr-text-light);
}

.delete-content-button:hover {
  color: var(--clr-danger);
  cursor: pointer;
}

.delete-content-button:active {
  margin-bottom: 8px;
}

.delete-content-button.active {
  color: var(--clr-highlight);
}
</style>