<template>
  <div v-if="getEditModalShown" class="edit-content-modal hide-modal">
    <div class="modal">
      <div class="header">
        <h2>
          <span v-if="content.id">{{ content.id }}:</span>
          {{ content.title }}
          <changes-made-toltip :contentId="content.id" />
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

      <div v-if="loading" class="loading">
        <activity-indicator />
      </div>

      <div v-if="!loading" class="tabs">
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

      <div v-if="!loading" class="body">
        <div class="edit" v-if="!showingPreview">
          <select-topic-dropdown
            :initialTopicId="content.topicId"
            v-on:valueChanged="(newVal) => (content.topicId = newVal)"
            v-on:change="changesMade = true"
          />

          <input
            type="text"
            placeholder="Edit title..."
            v-model="content.title"
            v-on:change="changesMade = true"
          />

          <textarea
            placeholder="Edit description..."
            rows="2"
            v-model="content.description"
            v-on:change="changesMade = true"
          ></textarea>

          <textarea
            placeholder="Edit HTML..."
            rows="10"
            v-model="content.htmlBody"
            v-on:change="changesMade = true"
          ></textarea>

          <input
            type="text"
            placeholder="Edit tags..."
            v-model="content.tags"
            v-on:change="changesMade = true"
          />
        </div>

        <div class="preview" v-if="showingPreview">
          <content-preview :content="content"></content-preview>
        </div>
      </div>

      <div class="footer">
        <div class="labels">
          <label>Created: <span>2020/09/29 12:32</span></label>
          <label>Last updated: <span>2020/09/29 12:32</span></label>
        </div>
        <div class="buttons">
          <button
            v-bind:class="{
              disabled: loading || !changesMade,
            }"
            :disabled="loading || !changesMade"
            v-on:click="saveChanges"
          >
            Save changes
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { mapGetters, mapActions } from "vuex";
import { Content } from "@/models";
import PinContentButton from "@/components/ContentTile/PinContentButton.vue";
import SelectTopicDropdown from "./SelectTopicDropdown.vue";
import ContentPreview from "./ContentPreview.vue";
import ActivityIndicator from "@/components/LoadingOverlay/ActivityIndicator.vue";
import ChangesMadeToltip from "@/components/ContentTile/ChangesMadeTooltip.vue";
import APIClient from "@/API";

export default Vue.extend({
  name: "EditContentModal",

  data: function() {
    return {
      showingPreview: false,
      changesMade: false,
      content: {} as Content,
      loading: false,
    };
  },
  computed: {
    ...mapGetters([
      "getEditModalShown",
      "getEditing",
      "pinnedContainsId",
      "getOpenById",
      "editedContainsContentId",
    ]),
  },
  methods: {
    ...mapActions([
      "closeEditModal",
      "closeContent",
      "addContentIdToEdited",
      "removeContentIdFromEdited",
    ]),

    hideOrCloseModal: function(event: any) {
      const classes = event.target.className.split(" ");
      if (classes.includes("close-modal") || classes.includes("hide-modal")) {
        if (!this.changesMade) {
          this.closeEditModal();
          if (classes.includes("close-modal")) this.closeContent(this.content);
        } else if (!classes.includes("close-modal")) {
          this.closeEditModal();
        } else {
          this.closeModalWithChangesPrompt();
        }
      }
    },
    closeModalWithChangesPrompt: function() {
      const confirmClose = confirm(
        "You have unsaved changes, these changes will be lost if you close this content. Are you sure?"
      );
      if (confirmClose === true) {
        this.changesMade = false;
        this.closeEditModal();
        this.closeContent(this.content);
      }
    },
    showPreview: function(show: boolean) {
      this.showingPreview = show;
    },
    saveChanges: function() {
      this.loading = true;
      APIClient.content.upsert(this.content).then((success: boolean) => {
        if (success === true) {
          this.changesMade = false;
        } else {
          alert(
            "Sorry, something went wrong when trying to update this content"
          );
        }
        this.loading = false;
      });
    },
  },
  watch: {
    getEditModalShown: function(newVal) {
      if (newVal === true) {
        this.content = this.getEditing;
        const alreadyOpenContent = this.getOpenById(this.content.id);
        if (alreadyOpenContent != null) {
          this.content = alreadyOpenContent;
        }
        this.changesMade = this.editedContainsContentId(this.content.id);
      }
    },
    changesMade: function(newVal) {
      if (newVal === true) this.addContentIdToEdited(this.content.id);
      else this.removeContentIdFromEdited(this.content.id);
    },
  },
  components: {
    ChangesMadeToltip,
    PinContentButton,
    ContentPreview,
    SelectTopicDropdown,
    ActivityIndicator,
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

.loading {
  flex: 1;
  display: flex;
  justify-content: center;
  align-items: center;
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
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
}

.footer .buttons {
  display: flex;
  justify-content: flex-end;
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

.footer .buttons .disabled {
  opacity: 0.2;
}

.footer .buttons .disabled:hover {
  opacity: 0.2;
  cursor: default;
}

.footer .labels {
  display: flex;
  justify-content: flex-start;
}

.footer label {
  font-size: 14px;
  color: var(--clr-text-light);
  margin-right: 20px;
}

.footer label span {
  font-weight: bold;
}
</style>
