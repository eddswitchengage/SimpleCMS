<template>
  <div class="content-tile" v-on:click="showEditModal">
    <div class="id">
      <p class="noselect">{{ content.id }}</p>
    </div>

    <div class="title">
      <p class="noselect">{{ content.title }}</p>
    </div>

    <div class="hierarchy">
      <p class="noselect dont-open-modal">
        {{ topic.title }}
      </p>
      <span class="noselect" style="color: var(--clr-text-light)"> | </span>
      <p class="noselect dont-open-modal">
        {{ getCategoryById(topic.categoryId).title }}
      </p>
    </div>

    <div class="actions">
      <pin-content-button :content="content" class="dont-open-modal" />
      <delete-content-button class="dont-open-modal" />
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Content, Topic } from "@/models";
import { mapGetters, mapActions } from "vuex";
import PinContentButton from "./PinContentButton.vue";
import DeleteContentButton from "./DeleteContentButton.vue";

export default Vue.extend({
  name: "ContentTile",
  props: {
    content: Object as () => Content,
  },
  methods: {
    ...mapActions(["openEditModal", "openContent"]),

    showEditModal: function(event: any) {
      if (!event.target.className.split(" ").includes("dont-open-modal")) {
        this.openEditModal(this.content);
        this.openContent(this.content);
      }
    },
  },
  computed: {
    ...mapGetters(["getTopicById", "getCategoryById"]),
    topic(): Topic {
      return this.getTopicById(this.content.topicId);
    },
  },
  components: {
    PinContentButton,
    DeleteContentButton,
  },
});
</script>

<style scoped>
.content-tile {
  display: flex;
  flex-direction: row;
  justify-content: flex-start;
  align-items: center;
  padding: 0px 10px;
  margin-bottom: 8px;

  border-radius: 5px;

  background-color: var(--clr-panel);
  border: 2px solid transparent;

  text-align: left;

  transition: 200ms;
}

.content-tile:hover {
  border: 2px solid var(--clr-highlight);
  cursor: pointer;
  transition: 200ms;
}

.content-tile:active {
  opacity: 0.8;
}

.content-tile p {
  margin: 8px 0px;
}

.id {
  flex: 0.25;
  color: var(--clr-text-light);
  width: 35px;
}

.title {
  flex: 4;
  font-weight: bold;
}

.hierarchy {
  flex: 3;
}

.actions {
  flex: 0.5;
  text-align: right;
}

.actions i {
  font-size: 24px;
  margin-right: 5px;
}

.hierarchy p {
  display: inline;
  color: var(--clr-text);
}

.hierarchy p:hover {
  color: var(--clr-highlight);
}
</style>
