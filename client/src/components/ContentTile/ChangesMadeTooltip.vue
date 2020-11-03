<template>
  <span
    class="tooltip changes-made-tooltip"
    v-if="editedContainsContentId(contentId)"
    >*<span class="tooltip-text">You have made changes to this item</span></span
  >
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters } from "vuex";
export default Vue.extend({
  name: "ChangesMadeTooltip",
  props: {
    contentId: Number,
  },
  computed: {
    ...mapGetters(["editedContainsContentId"]),
  },
});
</script>

<style scoped>
.changes-made-tooltip {
  transition-duration: 200ms;
  color: var(--clr-text) !important;
}

.changes-made-tooltip:hover {
  color: var(--clr-highlight) !important;
  transition-duration: 200ms;
}
</style>
