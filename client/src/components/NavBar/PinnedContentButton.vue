<template>
  <button
    class="pinned-content-button"
    v-on:click="togglePinnedContentShown"
    v-bind:class="{ active: isActive }"
  >
    <i class="las la-thumbtack"></i>
  </button>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters, mapActions } from "vuex";

export default Vue.extend({
  name: "PinnedContentButton",

  computed: {
    ...mapGetters({
      isActive: "getPinnedContentShown",
    }),
  },
  methods: {
    ...mapActions(["togglePinnedContentShown"]),
  },
});
</script>

<style scoped>
.pinned-content-button {
  position: relative;
  font-size: 32px;
  padding: 0;
  outline: none;
  border: none;
  background: none;
  color: var(--clr-text-light);
  transition-duration: 100ms;
}

.pinned-content-button:hover {
  cursor: pointer;
  color: var(--clr-text);
  transition-duration: 150ms;
}

.pinned-content-button:active {
  top: 4px;
}

.pinned-content-button.active {
  color: var(--clr-text);
}
</style>