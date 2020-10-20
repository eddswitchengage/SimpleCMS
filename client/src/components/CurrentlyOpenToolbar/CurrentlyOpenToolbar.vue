<template>
  <div class="currently-open-toolbar">
    <short-content-tile
      v-for="content in getOpen"
      v-bind:content="content"
      :key="content.id"
    />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters } from "vuex";
import ShortContentTile from "./ShortContentTile.vue";
export default Vue.extend({
  name: "CurrentlyOpenToolbar",

  computed: {
    ...mapGetters(["getOpen"]),
  },
  components: {
    ShortContentTile,
  },
});
</script>

<style scoped>
.currently-open-toolbar {
  position: absolute;
  bottom: 0;
  left: 0;
  z-index: 2;
}
</style>