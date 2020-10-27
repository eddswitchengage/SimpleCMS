<template>
  <div class="search-bar">
    <i class="las la-search"></i>
    <input
      type="text"
      v-model="searchString"
      placeholder="Search..."
      v-on:keyup.enter="search"
    />

    <i class="las la-question-circle tooltip" v-if="searchString === ''">
      <span class="tooltip-text">Add # prefix to search by id.</span>
    </i>
    <i class="las la-times" v-if="searchString !== ''" v-on:click="clear" />
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { mapActions } from "vuex";

export default Vue.extend({
  name: "SearchBar",

  data: function() {
    return {
      searchString: "",
    };
  },

  methods: {
    ...mapActions(["performSearch", "setSearchTerm"]),
    search: async function() {
      this.setSearchTerm(this.searchString);
      this.performSearch();
    },
    clear: function() {
      this.searchString = "";
      this.search();
    },
  },
});
</script>

<style scoped>
.search-bar {
  background-color: var(--clr-background);
  padding: 5px 10px;
  border-radius: 6px;
  height: 24px;
  width: 400px;
  display: flex;
  align-items: center;

  position: relative;

  border: 2px solid transparent;
  transition-duration: 100ms;
}

.search-bar:focus-within {
  border: 2px solid var(--clr-highlight);
  transition-duration: 150ms;
}

.search-bar input {
  width: 100%;
  font-size: 18px;
}

.search-bar i:first-of-type {
  color: var(--clr-text);
  margin-right: 5px;
  width: 16px;
  height: 16px;
}

.search-bar i:last-of-type {
  color: var(--clr-text-light);
}
.search-bar i:last-of-type:hover {
  color: var(--clr-text);
}
</style>
