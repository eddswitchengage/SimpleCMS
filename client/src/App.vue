<template>
  <div id="app">
    <nav-bar />
    <router-view />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import NavBar from "@/components/NavBar.vue";

export default Vue.extend({
  components: {
    NavBar
  }
});
</script>

<style>
:root {
  --clr-background: #15212c;
  --clr-panel: #1f2935;
  --clr-text: #e1e2e4;
  --clr-text-light: #4c525d;
  --clr-highlight: #0037fa;
}

body {
  background-color: var(--clr-background);
  margin: 0;
}

/* Default App Styling */

#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: var(--clr-text);
}

#app input[type="text"] {
  background: none;
  outline: none;
  border: none;
  color: var(--clr-text-light);
}

#app input[type="text"]:focus {
  color: var(--clr-text);
}

#app .panel {
  background-color: var(--clr-panel);
  border-radius: 10px;
  display: inline-block;
  padding: 10px 35px;
  margin: 15px;
  box-shadow: 0px 10px 25px -15px #000;
}

#app .text-light {
  color: var(--clr-text-light);
}

/* CSS components */
/* A collection of useful CSS components that are used throughout the app */

/* ---- TOOLTIP ----- */
.tooltip .tooltip-text {
  visibility: hidden;
  background-color: var(--clr-panel);
  text-align: center;
  border-radius: 2px;
  min-width: 100px;
  padding: 10px;
  border-top: 1px solid var(--clr-highlight);

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
