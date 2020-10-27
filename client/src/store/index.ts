import Vue from "vue";
import Vuex from "vuex";
import VuexPersist from "vuex-persist";
import { Content, Category, Topic, SearchFilters } from "@/models";
import APIClient from "@/API";
import { SearchQuery } from "../models";

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
    pageIndex: 1,
    pageSize: 20,

    //Cache of each topic and category, populated when app is launched.
    topics: [] as Topic[],
    categories: [] as Category[],

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

    setTopics(state, topics: Topic[]) {
      state.topics = topics;
    },
    setCategories(state, categories: Category[]) {
      state.categories = categories;
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

    setSearchTerm({ commit }, searchTerm: string) {
      commit("setSearchTerm", searchTerm);
    },
    setSearchFilters({ commit }, filters: SearchFilters) {
      commit("setSearchFilters", filters);
    },

    performSearch({ state, commit }) {
      const searchQuery: SearchQuery = {
        searchTerm: state.searchTerm,
        filters: state.searchFilters,
        pageIndex: state.pageIndex,
        pageSize: state.pageSize,
      };
      APIClient.content.getAll(searchQuery).then((results: Content[]) => {
        commit("setSearchResults", results);
      });
    },

    fetchTopicAndCategories({ commit }) {
      APIClient.categories.getAll().then((categories: Category[]) => {
        commit("setCategories", categories);

        let topics: Topic[] = [];
        for (let c = 0; c < categories.length; c++) {
          categories[c].topics.forEach(function(topic) {
            topic.categoryId = categories[c].id;
          });
          topics = [...topics, ...categories[c].topics];
        }
        commit("setTopics", topics);
      });
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
    getPinned: (state) => state.pinned,
    pinnedContainsId: (state) => (id: number) => {
      return state.pinned.some((item) => item.id === id);
    },

    getEditing: (state) => state.editing,
    getOpen: (state) => state.open,
    getSearchFilters: (state) => state.searchFilters,
    getSearchResults: (state) => state.searchResults,

    getTopics: (state) => state.topics,
    getTopicById: (state) => (id: number) => {
      return state.topics.find((topic: Topic) => topic.id === id);
    },
    getCategories: (state) => state.categories,
    getCategoryById: (state) => (id: number) => {
      return state.categories.find((category: Category) => category.id === id);
    },

    // ---- Settings ---- //
    getSettingsBarShown: (state) => state.settingsBarShown,
    getPinnedContentShown: (state) => state.pinnedContentShown,
    getEditModalShown: (state) => state.editModalShown,
    getEditHierarchyModalShown: (state) => state.editHierarchyModalShown,
  },
});
