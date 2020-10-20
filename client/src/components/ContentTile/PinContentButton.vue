<template>
  <i
    v-on:click="toggleContentIsPinned(content)"
    class="las la-thumbtack pin-content-button"
    v-bind:class="{ active: pinnedContainsId(content.id) }"
  ></i>
</template>

<script lang="ts">
import Vue from "vue";
import { Content } from "@/models";
import { mapActions, mapGetters } from "vuex";
export default Vue.extend({
  name: "PinContentButton",
  props: {
    content: Object as () => Content,
  },
  computed: {
    ...mapGetters(["pinnedContainsId"]),
  },
  methods: {
    ...mapActions(["toggleContentIsPinned"]),
  },
});
</script>

<style scoped>
.pin-content-button {
  color: var(--clr-text-light);
}

.pin-content-button:hover {
  color: var(--clr-highlight);
  cursor: pointer;
}

.pin-content-button:active {
  margin-bottom: 8px;
}

.pin-content-button.active {
  color: var(--clr-highlight);
}

.pin-content-button.active:hover {
  color: var(--clr-text);
}
</style>