<template>
  <div class="search-bar">
    <i class="las la-search"></i>
    <input type="text" placeholder="Search..." />
    <i class="las la-question-circle tooltip">
      <span class="tooltip-text">Add # prefix to search by id.</span>
    </i>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "SearchBar"
});
</script>

<style scoped>
.search-bar {
  background-color: var(--clr-background);
  padding: 5px 10px;
  border-radius: 6px;
  height: 24px;
  display: flex;
  align-items: center;

  position: relative;

  border: 1px solid transparent;
  transition-duration: 100ms;
}

.search-bar:focus-within {
  border: 1px solid var(--clr-highlight);
  transition-duration: 150ms;
}

.search-bar input {
  font-size: 18px;
}

.search-bar i:first-of-type {
  color: var(--clr-text);
  margin-right: 5px;
  width: 16px;
  height: 16px;
}

.search-bar i:last-of-type {
  color: var(--clr-text-light);
}
.search-bar i:last-of-type:hover {
  color: var(--clr-text);
}
</style>