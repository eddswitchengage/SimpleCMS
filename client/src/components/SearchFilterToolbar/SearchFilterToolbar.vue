<template>
  <div class="search-filter-toolbar" v-bind:class="{ active: expanded }">
    <div class="settings" v-if="expanded">
      <div class="setting-input">
        <label>Category</label>
        <filter-dropdown
          v-on:updated="updateCategoryId(parseInt($event))"
          :initial="filters.categoryId"
          :labelProperty="'title'"
          :valueProperty="'id'"
          :options="getCategories"
        />
      </div>

      <div class="setting-input">
        <label>Topic</label>
        <filter-dropdown
          v-on:updated="filters.topicId = parseInt($event)"
          :initial="filters.topicId"
          :labelProperty="'title'"
          :valueProperty="'id'"
          :options="topics"
        />
      </div>

      <div class="setting-input">
        <label>Created within</label>
        <filter-dropdown
          :options="dateRanges"
          v-on:updated="filters.createdWithinDays = parseInt($event)"
          :initial="filters.createdWithinDays"
        />
      </div>

      <div class="setting-input">
        <label>Last updated within</label>
        <filter-dropdown
          :options="dateRanges"
          v-on:updated="filters.updatedWithinDays = parseInt($event)"
          :initial="filters.updatedWithinDays"
        />
      </div>

      <button class="apply-button" v-on:click="applyFilters">Apply</button>
    </div>
    <div class="toggle-expand" v-on:click="toggleExpanded">
      <i class="las la-angle-right"></i>
    </div>
  </div>
</template>

<script lang="ts">
import { SearchFilters, Topic, Category } from "@/models";
import Vue from "vue";
import { mapGetters, mapActions } from "vuex";
import FilterDropdown from "./FilterDropdown.vue";

export default Vue.extend({
  name: "SearchFilterToolbar",

  data: function() {
    return {
      expanded: true,
      filters: {} as SearchFilters,

      dateRanges: [
        { label: "Last 7 days", value: 7 },
        { label: "Last 14 days", value: 14 },
        { label: "Last 1 month", value: 30 },
        { label: "Last 3 month", value: 90 },
        { label: "Last 6 month", value: 180 },
        { label: "Last 12 month", value: 365 },
      ],
    };
  },
  created: function() {
    this.filters = this.$store.getters.getSearchFilters;
  },
  methods: {
    toggleExpanded: function() {
      this.expanded = !this.expanded;
    },

    ...mapActions(["setSearchFilters"]),

    applyFilters: function() {
      this.setSearchFilters(this.filters);
    },
    updateCategoryId: function(id: number) {
      this.filters.categoryId = id;

      //If the new topics array doesn't contain the already selected topicId, reset it to 0
      if (
        !this.topics.some((topic: Topic) => topic.id === this.filters.topicId)
      ) {
        this.filters.topicId = 0;
      }
    },
  },
  components: { FilterDropdown },
  computed: {
    ...mapGetters(["getCategories", "getTopics"]),

    topics(): Topic[] {
      let topics = this.getTopics;
      if (this.filters.categoryId !== 0) {
        topics = topics.filter((topic: Topic) => {
          return topic.categoryId === this.filters.categoryId;
        });
      }
      return topics;
    },
  },
});
</script>

<style scoped>
.search-filter-toolbar {
  background-color: transparent;
  background-color: var(--clr-panel);

  width: 30px;
  height: 100%;
  margin-right: 15px;
  padding: 0;

  border-radius: 5px;

  display: flex;
  flex-direction: row;

  transition-duration: 150ms;
}

.search-filter-toolbar.active {
  width: 250px;
  background-color: var(--clr-panel);
  transition-duration: 150ms;
}

.search-filter-toolbar.active .toggle-expand {
  border-top-left-radius: 0px;
  border-bottom-left-radius: 0px;
  flex: 0.35;
}

.search-filter-toolbar.active .toggle-expand i {
  transform: rotate(-180deg);
  transition-duration: 300ms;
}

.toggle-expand i {
  transition-duration: 300ms;
}

.toggle-expand {
  height: 100%;
  font-size: 25px;
  flex: 1;
  border-radius: 5px;
  display: flex;
  justify-content: center;
  align-items: center;
}
.toggle-expand:hover {
  cursor: pointer;
  background-color: var(--clr-text-light);
  transition-duration: 200ms;
}

.toggle-expand:active {
  opacity: 0.75;
}

.settings {
  flex: 5;
  padding: 25px 10px;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;
}

.setting-input {
  width: 100%;
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: flex-start;
  margin-bottom: 20px;
}

.apply-button {
  width: 100%;
  margin-top: 51px;
  border: none;
  border-radius: 8px;
  font-size: 14px;
  color: white;
  background-color: var(--clr-highlight);
  padding: 4px 12px;
  outline: none;
}

.apply-button:hover {
  cursor: pointer;
  opacity: 0.8;
}

.apply-button:active {
  opacity: 0.6;
}
</style>
