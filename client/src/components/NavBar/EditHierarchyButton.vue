<template>
  <button
    class="edit-hierarchy-button"
    v-on:click="toggleEditHierarchyModalShown"
    v-bind:class="{ active: isActive }"
  >
    <i class="las la-sitemap"></i>
  </button>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters, mapActions } from "vuex";

export default Vue.extend({
  name: "EditHierarchyButton",

  methods: {
    ...mapActions(["toggleEditHierarchyModalShown"]),
  },
  computed: {
    ...mapGetters({ isActive: "getEditHierarchyModalShown" }),
  },
});
</script>

<style scoped>
.edit-hierarchy-button {
  position: relative;
  font-size: 32px;
  padding: 0;
  outline: none;
  border: none;
  background: none;
  color: var(--clr-text-light);
  transition-duration: 100ms;
}

.edit-hierarchy-button:hover {
  cursor: pointer;
  color: var(--clr-text);
  transition-duration: 150ms;
}

.edit-hierarchy-button:active {
  top: 4px;
}

.edit-hierarchy-button.active {
  color: var(--clr-text);
}
</style>
