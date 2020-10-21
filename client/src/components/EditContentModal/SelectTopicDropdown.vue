<template>
  <select v-model="selected" class="select-topic-dropdown">
    <optgroup
      v-for="category in getCategories"
      :key="category.id"
      :label="category.title"
    >
      <option
        v-for="topic in getTopicsByCategory(category.id)"
        :label="topic.title"
        :key="topic.id"
        :value="topic.id"
      />
    </optgroup>
  </select>
</template>

<script lang="ts">
import { Topic } from "@/models";
import Vue from "vue";
import { mapGetters } from "vuex";
export default Vue.extend({
  name: "SelectTopicDropdown",

  props: {
    initialTopicId: Number,
  },
  data: function() {
    return {
      selected: this.initialTopicId,
    };
  },
  methods: {
    getTopicsByCategory(categoryId: number) {
      return this.getTopics.filter((topic: Topic) => {
        return topic.categoryId === categoryId;
      });
    },
  },
  computed: {
    ...mapGetters(["getTopics", "getCategories"]),
  },
  watch: {
    selected: function(newVal: number) {
      this.$emit("topicUpdated", newVal);
    },
  },
});
</script>

<style scoped>
.select-topic-dropdown {
  width: 99%;
  background-color: var(--clr-background) !important;
  font-size: 20px;
  padding: 4px;
  border-radius: 5px;
  border: 1px solid transparent !important;
  transition-duration: 250ms;
  margin-bottom: 20px;
}
</style>
