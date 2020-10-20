<template>
  <div class="home">
    <search-filter-toolbar id="search-filter-toolbar" />

    <div class="dashboard">
      <pinned-content-view v-if="getPinnedContentShown" />

      <div class="header noselect">
        <p class="id noselect">Id</p>
        <p class="title noselect">Title</p>
        <p class="hierarchy noselect">Topic/Category</p>
        <p class="actions noselect">Actions</p>
      </div>
      <p v-if="getSearchResults.length === 0">No results...</p>

      <content-tile
        v-for="content in getSearchResults"
        v-bind:content="content"
        :key="content.id"
      ></content-tile>
    </div>
  </div>
</template>

<script>
import ContentTile from "@/components/ContentTile/ContentTile.vue";
import PinnedContentView from "@/components/PinnedContentView/PinnedContentView.vue";
import SearchFilterToolbar from "@/components/SearchFilterToolbar/SearchFilterToolbar.vue";
import { mapGetters, mapActions } from "vuex";

export default {
  name: "Home",
  components: {
    ContentTile,
    PinnedContentView,
    SearchFilterToolbar,
  },
  methods: {
    ...mapActions(["performSearch"]),
  },
  created() {
    this.performSearch("");
  },
  computed: {
    ...mapGetters(["getSearchResults", "getPinnedContentShown"]),
  },
};
</script>

<style scoped>
.home {
  flex: 1;
  height: 100%;
  display: flex;
  overflow-y: scroll;
  flex-direction: row;
}

.dashboard {
  flex: 1;
  margin-right:10px;
}

.header {
  text-align: left;
  display: flex;
  font-size: 14px;
  flex-direction: row;
  padding: 0px 15px;
  color: var(--clr-text-light);
}

.header p {
  margin: 5px 0px;
}

.header .id {
  flex: 0.5;
}
.header .title {
  flex: 4;
}
.header .hierarchy {
  flex: 2;
}
.header .actions {
  text-align: right;
  flex: 0.75;
}
</style>
