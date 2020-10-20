<template>
  <button v-on:click="createNewContent" class="create-content-button">
    <i class="las la-plus"></i>
  </button>
</template>

<script lang="ts">
import Vue from "vue";
import { Content } from "@/models";
import { mapActions } from "vuex";
export default Vue.extend({
  name: "CreateContentButton",

  methods: {
    ...mapActions(["openEditModal"]),
    createNewContent: function() {
      const emptyContent: Content = {
        id: 0,
        topicId: 0,
        title: "New content",
        description: "",
        htmlBody: "",
        tags: "",
      };
      this.openEditModal(emptyContent);
    },
  },
});
</script>

<style scoped>
.create-content-button {
  position: relative;
  height: 36px;
  font-size: 24px;
  outline: none;
  border: none;
  background-color: var(--clr-background);
  border-radius: 24px;
  color: var(--clr-text);
  transition-duration: 100ms;
}

.create-content-button:hover {
  cursor: pointer;
  color: var(--clr-text);
  background-color: var(--clr-highlight);
  transition-duration: 150ms;
}
</style>
