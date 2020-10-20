<template>
  <div class="pinned-content-view">
    <div class="header">
      <p class="noselect">Pinned ({{ getPinned.length }})</p>
      <i
        class="las la-window-close toggle-view"
        v-on:click="togglePinnedContentShown"
      ></i>
    </div>

    <div class="pinned-content">
      <content-tile
        v-for="content in getPinned"
        v-bind:content="content"
        :key="'pinned_' + content.id"
      ></content-tile>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import ContentTile from "@/components/ContentTile/ContentTile.vue";
import { mapGetters, mapActions } from "vuex";

export default Vue.extend({
  name: "PinnedContentView",

  components: {
    ContentTile,
  },
  methods: {
    ...mapActions(["togglePinnedContentShown"]),
  },
  computed: {
    ...mapGetters(["getPinned"]),
  },
});
</script>

<style scoped>
.pinned-content-view {
  text-align: left;
  margin-bottom: 25px;
}

.header {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  padding: 10px 4px;
}

.header p {
  font-size: 18px;
  color: var(--clr-highlight);
  margin: 0;
}

.header .toggle-view {
  font-size: 24px;
  color: var(--clr-text-light);
}

.header .toggle-view:hover {
  color: var(--clr-text);
  cursor: pointer;
}

.header .toggle-view:active {
  opacity: 0.8;
}

.pinned-content {
  border-left: 2px solid var(--clr-highlight);
  padding-left: 10px;
  flex: 1;
}

.pinned-section i {
  display: inline-block;
  color: var(--clr-highlight);
  font-weight: bold;
  font-size: 24px;
  margin: 0;
  margin-right: 8px;
}
</style>