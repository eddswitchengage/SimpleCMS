<template>
  <loading-overlay v-if="initialising" />

  <div v-else id="app">
    <nav-bar class="nav-view" />
    <div class="app-view">
      <router-view />
    </div>
    <settings-toolbar />
    <edit-content-modal />
    <edit-hierarchy-modal />
    <currently-open-toolbar />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import NavBar from "@/components/NavBar/NavBar.vue";
import SettingsToolbar from "@/components/SettingsToolbar/SettingsToolbar.vue";
import EditContentModal from "@/components/EditContentModal/EditContentModal.vue";
import EditHierarchyModal from "@/components/EditHierarchyModal/EditHierarchyModal.vue";
import CurrentlyOpenToolbar from "@/components/CurrentlyOpenToolbar/CurrentlyOpenToolbar.vue";
import LoadingOverlay from "@/components/LoadingOverlay/LoadingOverlay.vue";

export default Vue.extend({
  data: function() {
    return {
      initialising: true,
    };
  },

  mounted() {
    //Cache topics and categories
    this.$store.dispatch("fetchTopicAndCategories").then(() => {
      this.initialising = false;
    });
  },

  components: {
    NavBar,
    SettingsToolbar,
    EditContentModal,
    EditHierarchyModal,
    CurrentlyOpenToolbar,
    LoadingOverlay,
  },
});
</script>

<style>
:root {
  --clr-background: #15212c;
  --clr-panel: #1f2935;
  --clr-text: #e1e2e4;
  --clr-text-light: #4c525d;
  --clr-highlight: #204be6;
  --clr-danger: #be0029;
  --dim-navbar: 62px;
}

html,
body {
  height: 100%;
  margin: 0;
  background-color: var(--clr-background);
  overflow: hidden;
}

/* Default App Styling */

#app {
  height: 100%;
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: var(--clr-text);
}

#app .nav-view {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  height: 40px;
}

#app .app-view {
  position: absolute;
  top: var(--dim-navbar);
  left: 0;
  right: 0;
  bottom: 0;
  margin: 10px;
}

#app input[type="text"],
textarea,
select {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  background: none;
  outline: none;
  border: none;
  color: var(--clr-text-light);
}

#app select {
  color: var(--clr-text);
}

#app input[type="text"]:focus,
textarea:focus {
  color: var(--clr-text);
}

#app .text-light {
  color: var(--clr-text-light);
}

#app .noselect {
  -webkit-touch-callout: none; /* iOS Safari */
  -webkit-user-select: none; /* Safari */
  -khtml-user-select: none; /* Konqueror HTML */
  -moz-user-select: none; /* Old versions of Firefox */
  -ms-user-select: none; /* Internet Explorer/Edge */
  user-select: none; /* Non-prefixed version, currently supported by Chrome, Edge, Opera and Firefox */
}

/* Scrollbar Styling */

/* width */
::-webkit-scrollbar {
  width: 10px;
}

/* Track */
::-webkit-scrollbar-track {
  background: transparent;
}

/* Handle */
::-webkit-scrollbar-thumb {
  background: var(--clr-text-light);
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: var(--clr-text);
}

/* CSS components */
/* A collection of useful CSS components that are used for the app */

/* ---- TOOLTIP ----- */
.tooltip .tooltip-text {
  visibility: hidden;
  background-color: rgba(0, 0, 0, 1);
  text-align: center;
  border-radius: 2px;
  min-width: 100px;
  padding: 10px;
  border-top: 2px solid var(--clr-highlight);

  color: var(--clr-text);

  font-size: 12px;
  font-family: Avenir, Helvetica, Arial, sans-serif;
  font-weight: normal;

  position: absolute;
  z-index: 1;
}

.tooltip:hover .tooltip-text {
  visibility: visible;
  transition: visibility 500ms ease-in;
  transition-delay: 200ms;
}

.tooltip-text .title {
  font-weight: bold;
  color: var(--clr-text-light);
  margin: 0;
  margin-bottom: 5px;
}
/* ---- /TOOLTIP ----- */
</style>
