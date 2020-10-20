<template>
  <div id="settings-toolbar" v-bind:class="{ active: getSettingsBarShown }">
    <div v-if="getSettingsBarShown">
      <h3>Settings</h3>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters } from "vuex";

export default Vue.extend({
  name: "SettingsToolbar",

  computed: {
    ...mapGetters(["getSettingsBarShown"]),
  },
});
</script>

<style scoped>
#settings-toolbar {
  position: absolute;

  top: var(--dim-navbar);
  right: 0;
  bottom: 0;
  width: 0;

  z-index: 1;
  transition: 100ms;
  background-color: var(--clr-panel);
}

#settings-toolbar.active {
  width: 25vw;
  transition: 100ms;
  border-left: 4px solid var(--clr-highlight);
}
</style>