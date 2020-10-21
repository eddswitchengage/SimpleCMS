import Vue from "vue";
import Vuex from "vuex";
import VuexPersist from "vuex-persist";
import { Content, Category, Topic, SearchFilters } from "@/models";

/*
    ------ SimpleCMS Store ------

    This store holds data to be persisted between components/screens (as well as data to be persisted between sessions).
    The store is a single entity that holds all necessary data for the app.
    
    Note: in a larger scale application this store would have been split into multiple modules (SettingsStore module, ContentStore module, etc...)
*/

Vue.use(Vuex);
//Create and configure persistence plugin
const vuexLocalStorage = new VuexPersist({
  key: "simplecms_storage",
  storage: window.localStorage,
  reducer: (state: any) => ({
    pinned: state.pinned,
    searchFilters: state.searchFilters,
  }),
});

// ------ Root Store ------ //

export default new Vuex.Store({
  plugins: [vuexLocalStorage.plugin],

  state: {
    // ---- Content ---- //
    pinned: [] as Content[],
    open: [] as Content[],
    editing: {} as Content,

    searchTerm: "",
    searchFilters: {} as SearchFilters,
    searchResults: [] as Content[],

    topics: [
      { id: 1, title: "Topic One", categoryId: 1 },
      { id: 2, title: "Topic Two", categoryId: 1 },
      { id: 3, title: "Topic Three", categoryId: 2 },
      { id: 4, title: "Topic Four", categoryId: 2 },
      { id: 5, title: "Topic Five", categoryId: 2 },
    ],
    categories: [
      { id: 1, title: "Category 1" },
      { id: 2, title: "Category 2" },
    ],
    /*
      Cache of each topic and category, populated when app is launched.
    */

    // ---- Settings ---- //
    settingsBarShown: false,
    editModalShown: false,
    editHierarchyModalShown: false,
    pinnedContentShown: false,
  },
  mutations: {
    // ---- Content ---- //
    addToPinned(state, content: Content) {
      state.pinned.push(content);
    },
    removeFromPinned(state, content: Content) {
      state.pinned = state.pinned.filter(function(item) {
        return item.id !== content.id;
      });
    },

    addToOpen(state, content: Content) {
      state.open.push(content);
    },
    removeFromOpen(state, content: Content) {
      state.open = state.open.filter(function(item) {
        return item.id !== content.id;
      });
    },

    setEditing(state, content: Content) {
      state.editing = content;
    },

    setSearchTerm(state, term: string) {
      state.searchTerm = term;
    },
    setSearchFilters(state, filters: SearchFilters) {
      state.searchFilters = filters;
    },
    setSearchResults(state, results: Content[]) {
      state.searchResults = results;
    },

    // ---- Settings ---- //
    setSettingsBarShown(state, isShown: boolean) {
      state.settingsBarShown = isShown;
    },
    setPinnedContentShown(state, isShown: boolean) {
      state.pinnedContentShown = isShown;
    },
    setEditModalShown(state, isShown: boolean) {
      state.editModalShown = isShown;
    },
    setEditHierarchyModalShown(state, isShown: boolean) {
      state.editHierarchyModalShown = isShown;
    },
  },
  actions: {
    // ---- Content ---- //
    toggleContentIsPinned({ commit, getters }, content: Content) {
      if (getters.pinnedContainsId(content.id)) {
        commit("removeFromPinned", content);
      } else {
        commit("addToPinned", content);
      }
    },

    openContent({ state, commit }, content: Content) {
      if (!state.open.some((item) => item.id === content.id)) {
        commit("addToOpen", content);
      }
    },
    closeContent({ commit }, content: Content) {
      commit("removeFromOpen", content);
    },

    setSearchFilters({ commit }, filters: SearchFilters) {
      commit("setSearchFilters", filters);
    },
    performSearch({ state, commit }, searchTerm: string) {
      commit("setSearchTerm", searchTerm);

      //search
      if (searchTerm !== "" && searchTerm !== "empty") {
        commit("setSearchResults", [
          {
            title: "Topical content based on true fact",
            id: 113,
            description: "This is a nice example of a content object",
            htmlBody:
              "<p>This is an example of the HTML body of a piece of content</p>",
            topic: {
              title: "Topic 1",
              id: 1,
            },
            category: {
              title: "Category 1",
              id: 1,
            },
            tags: "tagnumberone, topicalcontent,somestuff, engineer",
          },
          {
            title: "Inter-railing for dummies: the long road",
            id: 221,
            description:
              "This is anodther example of a content object, except this one contains a typo",
            topic: {
              title: "Topic 1",
              id: 1,
            },
            category: {
              title: "Category 1",
              id: 1,
            },
          },
        ]);
      } else if (searchTerm === "") {
        commit("setSearchResults", [
          {
            title: "Topical content based on true fact",
            id: 113,
            description: "This is a nice example of a content object",
            htmlBody:
              "<p>This is an example of the HTML body of a piece of content</p>",
            topicId: 1,
            categoryId: 1,
            tags: "tagnumberone, topicalcontent,somestuff, engineer",
          },
          {
            title: "Inter-railing for dummies: the long road",
            id: 221,
            description:
              "This is anodther example of a content object, except this one contains a typo",
            topicId: 1,
            categoryId: 1,
          },
          {
            title: "Batman begins again and again",
            id: 305,
            description:
              "This content has quite a long description. Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
              "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit." +
              "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit.",
            topicId: 1,
            categoryId: 1,
          },
          {
            title:
              "Truly, the longest title anyone has ever seen! Truly! Really really long!",
            id: 432,
            description:
              "This content has quite a long description. Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
              "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit." +
              "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit.",
            topicId: 1,
            categoryId: 1,
          },
          {
            title:
              "Texas city's professional roller blading team loses to south dakota amateurs",
            id: 512,
            description:
              "This content has quite a long description. Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
              "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit." +
              "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit.",
            topicId: 1,
            categoryId: 1,
          },
          {
            title:
              "How many times must the wind blow down the road for the cannonball to fly?",
            id: 62,
            description:
              "This content has quite a long description. Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
              "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit." +
              "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit.",
            topicId: 1,
            categoryId: 1,
          },
        ]);
      } else if (searchTerm === "empty") {
        commit("setSearchResults", []);
      }
    },

    // ---- Settings ---- //
    toggleSettingsBarShown({ state, commit }) {
      commit("setSettingsBarShown", !state.settingsBarShown);
    },
    togglePinnedContentShown({ state, commit }) {
      commit("setPinnedContentShown", !state.pinnedContentShown);
    },
    openEditModal({ commit }, content: Content) {
      commit("setEditModalShown", true);
      commit("setEditing", content, { root: true });
    },
    closeEditModal({ commit }) {
      commit("setEditModalShown", false);
    },
    toggleEditHierarchyModalShown({ state, commit }) {
      commit("setEditHierarchyModalShown", !state.editHierarchyModalShown);
    },
  },
  getters: {
    // ---- Content ---- //
    pinnedContainsId: (state) => (id: number) => {
      return state.pinned.some((item) => item.id === id);
    },
    getPinned: (state) => {
      return state.pinned;
    },
    getEditing: (state) => {
      return state.editing;
    },
    getOpen: (state) => {
      return state.open;
    },
    getSearchFilters: (state) => {
      return state.searchFilters;
    },
    getSearchResults: (state) => {
      return state.searchResults;
    },

    getTopics: (state) => {
      return state.topics;
    },
    getTopicById: (state) => (id: number) => {
      return state.topics.find((topic: Topic) => topic.id === id);
    },
    getCategories: (state) => {
      return state.categories;
    },
    getCategoryById: (state) => (id: number) => {
      return state.categories.find((category: Category) => category.id === id);
    },

    // ---- Settings ---- //
    getSettingsBarShown: (state) => {
      return state.settingsBarShown;
    },
    getPinnedContentShown: (state) => {
      return state.pinnedContentShown;
    },
    getEditModalShown: (state) => {
      return state.editModalShown;
    },
    getEditHierarchyModalShown: (state) => {
      return state.editHierarchyModalShown;
    },
  },
});
