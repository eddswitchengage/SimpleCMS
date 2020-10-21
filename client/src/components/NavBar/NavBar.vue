<template>
  <div id="nav-bar">
    <h1 class="title noselect">simplecms</h1>

    <div class="search-create">
      <search-bar />
      <create-content-button style="margin-left: 12px" />
    </div>

    <div class="action-buttons">
      <pinned-content-button />
      <edit-hierarchy-button />
      <settings-button />
    </div>
  </div>

  <!-- Settings bar component, toggled with the settings icon -->
</template>

<script lang="ts">
import Vue from "vue";
import SearchBar from "./SearchBar.vue";
import SettingsButton from "./SettingsButton.vue";
import PinnedContentButton from "./PinnedContentButton.vue";
import CreateContentButton from "./CreateContentButton.vue";
import EditHierarchyButton from "./EditHierarchyButton.vue";

export default Vue.extend({
  name: "NavBar",

  components: {
    SearchBar,
    SettingsButton,
    CreateContentButton,
    PinnedContentButton,
    EditHierarchyButton,
  },
});
</script>

<style scoped>
#nav-bar {
  padding: 10px;
  padding-left: 20px;
  padding-right: 20px;

  align-items: center;

  background-color: var(--clr-panel);
  border-bottom: 2px solid #27313e;

  display: flex;
  justify-content: space-between;
}

.title {
  margin: 0;
  font-weight: normal;
  color: var(--clr-text);
  font-family: "Montserrat", sans-serif;
}

.search-create {
  display: flex;
  justify-content: space-between;
  align-items: center;
}

.action-buttons {
  display: flex;
  justify-content: space-between;
  width: 120px;
}
</style>
