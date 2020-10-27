<template>
  <div class="loading-overlay">
    <h1>simplecms</h1>
    <activity-indicator />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import ActivityIndicator from "./ActivityIndicator.vue";
export default Vue.extend({
  name: "LoadingOverlay",
  components: { ActivityIndicator },
});
</script>

<style scoped>
.loading-overlay {
  display: flex;
  flex: 1;
  justify-content: center;
  align-items: center;
  flex-direction: column;
  height: 100%;
}

.loading-overlay h1 {
  font-size: 72px;
  margin: 0;
  margin-bottom: 24px;
  font-weight: normal;
  color: var(--clr-text);
  font-family: "Montserrat", sans-serif;
  cursor: pointer;
  transition-duration: 2.5s;
}

.loading-overlay h1:hover {
  color: var(--clr-highlight);
  transition-duration: 5s;
}
</style>
