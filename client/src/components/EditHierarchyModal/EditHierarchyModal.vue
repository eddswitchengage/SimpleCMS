<template>
  <div
    v-if="getEditHierarchyModalShown"
    class="edit-hierarchy-modal close-modal"
  >
    <div class="modal">
      <div class="header">
        <h2>Edit Categories & Topics</h2>
        <i class="las la-window-close close-modal" v-on:click="closeModal"></i>
      </div>

      <div class="body">
        <div class="categories">
          <hierarchy-item-row-list
            :items="categories"
            v-on:selected="selectCategory"
            v-on:itemUpdated="updateCategory"
            v-on:itemDeleted="deleteCategory"
            :showAllOption="true"
            :initialSelectedItemId="selectedCategoryId"
          />
        </div>
        <div class="topics">
          <hierarchy-item-row-list
            v-if="selectedCategoryId !== -1"
            :items="filterTopics"
            :showAllOption="false"
            v-on:itemUpdated="updateTopic"
            v-on:itemDeleted="deleteTopic"
          />
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { mapActions, mapGetters } from "vuex";
import { Topic, Category } from "@/models";
import HierarchyItemRowList from "./HierarchyItemRowList.vue";

export default Vue.extend({
  name: "EditHierarchyModal",

  data: function() {
    return {
      selectedCategoryId: 0,
      categories: [] as Category[],
      topics: [] as Topic[],
    };
  },
  methods: {
    ...mapActions(["toggleEditHierarchyModalShown"]),
    closeModal: function(event: any) {
      const classes = event.target.className.split(" ");
      if (classes.includes("close-modal")) {
        this.toggleEditHierarchyModalShown();
      }
    },

    selectCategory: function(categoryId: number) {
      this.selectedCategoryId = categoryId;
    },
    updateCategory: function(categoryId: number, newTitle: string) {
      if (categoryId === -1) {
        if (newTitle.length > 0) this.addCategory(newTitle);
      } else {
        const category = this.categories.find((c) => c.id === categoryId);
        if (category != null) {
          category.title = newTitle;
          this.selectedCategoryId = categoryId;
          this.categories = [...this.categories];
        }
      }
    },
    addCategory: function(title: string) {
      const id = Math.random() * 1000;
      const newCategory: Category = {
        id,
        title,
      };
      this.categories.push(newCategory);
      this.selectedCategoryId = id;
    },
    deleteCategory: function(categoryId: number) {
      console.log("Deleting category - ID: " + categoryId);
    },

    updateTopic: function(topicId: number, newTitle: string) {
      if (topicId === -1) {
        if (newTitle.length > 0) this.addTopic(newTitle);
      } else {
        const topic = this.topics.find((t) => t.id === topicId);
        if (topic != null) {
          topic.title = newTitle;
          this.topics = [...this.topics];
        }
      }
    },
    addTopic: function(title: string) {
      const id = Math.random() * 1000;
      const newTopic: Topic = {
        id,
        title,
        categoryId: this.selectedCategoryId,
      };
      this.topics.push(newTopic);
    },
    deleteTopic: function(topicId: number) {
      console.log("Deleting topic - ID: " + topicId);
    },
  },
  computed: {
    ...mapGetters(["getEditHierarchyModalShown", "getTopics", "getCategories"]),
    filterTopics(): Topic[] {
      if (this.selectedCategoryId === 0) return this.topics;
      return this.topics.filter((topic: Topic) => {
        return topic.categoryId === this.selectedCategoryId;
      });
    },
  },
  watch: {
    getEditHierarchyModalShown: function(val) {
      if (val === true) {
        this.topics = this.getTopics;
        this.categories = this.getCategories;
      }
    },
  },
  components: {
    HierarchyItemRowList,
  },
});
</script>

<style scoped>
.edit-hierarchy-modal {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;

  z-index: 2;

  height: 100%;

  display: flex;
  justify-content: center;
  align-items: center;

  background-color: rgba(0, 0, 0, 0.5);
}

.modal {
  overflow: hidden;

  width: 75%;
  height: 80%;
  border-radius: 25px;

  padding: 15px 20px;

  background-color: var(--clr-panel);
}

.modal:hover {
  cursor: default;
}

.header {
  display: flex;
  height: 25px;
  justify-content: space-between;
  align-items: flex-start;
  padding-bottom: 10px;
}

.header h2 {
  margin: 0;
  padding: 0;
  font-size: 20px;
}

.header i {
  color: var(--clr-text-light);
  font-size: 24px;
  margin-right: 5px;
}

.header i:hover {
  color: var(--clr-text);
  cursor: pointer;
}

.body {
  display: flex;
  flex-direction: row;
  height: calc(100% - 35px);
}

.body .categories,
.topics {
  display: flex;
  height: 100%;
  flex-direction: column;
  flex: 1;
  overflow-y: auto;
}

.body .categories {
  flex: 0.6;
  border-right: 2px solid var(--clr-background);
}
</style>
