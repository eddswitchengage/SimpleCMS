<template>
  <button
    v-on:click="toggleSettingsBarShown"
    v-bind:class="{ active: isActive }"
    class="settings-button"
  >
    <i class="las la-cog"></i>
  </button>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters, mapActions } from "vuex";

export default Vue.extend({
  name: "SettingsButton",

  computed: {
    ...mapGetters({
      isActive: "getSettingsBarShown",
    }),
  },
  methods: {
    ...mapActions(["toggleSettingsBarShown"]),
  },
});
</script>

<style scoped>
.settings-button {
  position: relative;
  font-size: 32px;
  padding: 0;
  outline: none;
  border: none;
  background: none;
  color: var(--clr-text-light);
  transition-duration: 100ms;
}

.settings-button:hover {
  cursor: pointer;
  color: var(--clr-text);
  transition-duration: 150ms;
}

.settings-button:active {
  top: 4px;
}

.settings-button.active {
  color: var(--clr-text);
}
</style>