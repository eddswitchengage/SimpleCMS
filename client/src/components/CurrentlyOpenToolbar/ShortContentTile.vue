<template>
  <div class="short-content-tile">
    <p class="noselect" v-on:click="openEditModal(content)">
      <span>{{ content.id }}: </span>{{ truncateTitle(content.title) }}
    </p>
    <i
      v-on:click="closeContent(content)"
      class="las la-window-close close-modal"
    ></i>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Content } from "@/models";
import { mapActions } from "vuex";

export default Vue.extend({
  name: "ShortContentTile",
  props: {
    content: Object as () => Content,
  },
  methods: {
    ...mapActions(["openEditModal", "closeContent"]),
    truncateTitle: function (title: string) {
      if (title.length < 24) return title;
      return title.substring(0, 21) + "...";
    },
  },
});
</script>

<style scoped>
.short-content-tile {
  display: inline-block;
  background-color: var(--clr-panel);
  border-top-left-radius: 5px;
  border-top-right-radius: 5px;
  padding: 4px 10px;
  margin-left: 5px;
  font-size: 14px;
  box-shadow: 2px -2px rgba(0, 0, 0, 0.2);
}

p:hover {
  cursor: pointer;
  opacity: 0.75;
}
p:active {
  opacity: 0.5;
}

p {
  display: inline-block;
  margin: 0;
  color: var(--clr-text);
  font-weight: bold;
}

span {
  color: var(--clr-text-light);
}

i {
  display: inline-block;
  font-size: 18px;
  margin-left: 8px;
}

i:hover {
  opacity: 0.7;
  cursor: pointer;
}
</style>