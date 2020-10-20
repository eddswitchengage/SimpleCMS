<template>
  <div
    v-if="editModalShown"
    class="edit-content-modal hide-modal"
    v-on:click="hideOrCloseModal"
  >
    <div class="modal">
      <div class="header">
        <h2>
          <span v-if="content.id">{{ content.id }}:</span>
          {{ content.title }}
        </h2>

        <div class="action-buttons">
          <pin-content-button :content="content" v-if="content.id" />
          <i
            class="las la-window-minimize hide-modal"
            v-on:click="hideOrCloseModal"
          ></i>
          <i
            class="las la-window-close close-modal"
            v-on:click="hideOrCloseModal"
          ></i>
        </div>
      </div>

      <div class="tabs">
        <button
          v-on:click="showPreview(false)"
          v-bind:class="{ active: !showingPreview }"
        >
          Edit
        </button>
        <button
          v-on:click="showPreview(true)"
          v-bind:class="{ active: showingPreview }"
        >
          Preview
        </button>
      </div>

      <div class="body">
        <div class="edit" v-if="!showingPreview">
          <select>
            <optgroup label="Category 1">
              <option>Topic 1</option>
              <option>Topic 2</option>
              <option>Topic 3</option>
            </optgroup>
          </select>

          <input
            type="text"
            placeholder="Edit title..."
            v-model="content.title"
          />

          <textarea
            placeholder="Edit description..."
            rows="2"
            v-model="content.description"
          ></textarea>

          <textarea
            placeholder="Edit HTML..."
            rows="10"
            v-model="content.htmlBody"
          ></textarea>

          <input
            type="text"
            placeholder="Edit tags..."
            v-model="content.tags"
            maxlength="64"
          />
        </div>

        <div class="preview" v-if="showingPreview">
          <content-preview :content="content"></content-preview>
        </div>
      </div>

      <div class="footer">
        <button>Save changes</button>
        <label>Last updated: 2020/09/29 12:32</label>
        <label>Created at: 2020/09/29 12:32</label>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters, mapActions } from "vuex";
import PinContentButton from "@/components/ContentTile/PinContentButton.vue";
import ContentPreview from "./ContentPreview.vue";

export default Vue.extend({
  name: "EditContentModal",

  data: function () {
    return {
      showingPreview: false,
    };
  },
  computed: {
    ...mapGetters({
      editModalShown: "getEditModalShown",
      content: "getEditing",
      pinnedContainsId: "pinnedContainsId",
    }),
  },
  methods: {
    ...mapActions(["closeEditModal", "closeContent"]),
    hideOrCloseModal: function (event: any) {
      const classes = event.target.className.split(" ");
      if (classes.includes("close-modal") || classes.includes("hide-modal")) {
        this.closeEditModal();
        if (classes.includes("close-modal")) this.closeContent(this.content);
      }
    },
    showPreview: function (show: boolean) {
      this.showingPreview = show;
    },
  },
  components: {
    PinContentButton,
    ContentPreview,
  },
});
</script>

<style scoped>
.edit-content-modal {
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;

  z-index: 2;

  display: flex;
  justify-content: center;
  align-items: center;

  background-color: rgba(0, 0, 0, 0.5);
}

.edit-content-modal:hover {
  cursor: pointer;
}

.modal {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
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

/* Header section */

.header {
  display: flex;
  flex: 0.1;
  justify-content: space-between;
  align-items: flex-start;
  padding-bottom: 25px;
}

.header h2 {
  margin: 0;
  padding: 0;
  font-size: 20px;
}

.header h2 span {
  color: var(--clr-text-light);
}

.header i {
  font-size: 24px;
  margin-right: 5px;
}

.action-buttons {
  font-size: 26px;
}

.action-buttons i {
  position: relative;
  color: var(--clr-text-light);
  margin-left: 5px;
}

.action-buttons i:hover {
  cursor: pointer;
  color: var(--clr-text);
}

.action-buttons i:active {
  top: 2px;
}

/* Tab selection section */

.tabs {
  display: flex;
  flex: 0.1;
  flex-direction: row;
  justify-content: flex-start;
  border-bottom: 2px solid var(--clr-background);
  margin-bottom: 20px;
}

.tabs button {
  background-color: var(--clr-panel);
  border: 1px solid var(--clr-panel);
  border-radius: 5px;
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
  border-bottom: none;
  outline: none;
  color: var(--clr-text);
  padding: 5px 15px;
}

.tabs button:hover {
  cursor: pointer;
  background-color: var(--clr-text-light);
}

.tabs button.active {
  background-color: var(--clr-background);
}

/* Body section */

.body {
  display: flex;
  flex: 4;
  flex-direction: column;
  overflow-y: auto;
}

.preview {
  flex: 1;
}

.edit {
  display: flex;
  flex-direction: column;
  justify-content: flex-start;
  align-items: center;
  margin-bottom: 20px;
}

.edit input,
textarea,
select {
  width: 99%;
  background-color: var(--clr-background) !important;
  font-size: 20px;
  padding: 4px;
  border-radius: 5px;
  border: 1px solid transparent !important;
  transition-duration: 250ms;
  margin-bottom: 20px;
}

.edit input:focus,
textarea:focus {
  border: 1px solid var(--clr-highlight) !important;
  transition-duration: 250ms;
}

/* Footer section */
.footer {
  flex: 0.25;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
}

.footer button {
  margin-bottom: 5px;
  border: none;
  border-radius: 8px;
  font-size: 16px;
  color: white;
  background-color: var(--clr-highlight);
  padding: 4px 12px;
  outline: none;
}

.footer button:hover {
  cursor: pointer;
  opacity: 0.8;
}

.footer button:active {
  opacity: 0.6;
}

.footer label {
  font-size: 14px;
  color: var(--clr-text-light);
}
</style>