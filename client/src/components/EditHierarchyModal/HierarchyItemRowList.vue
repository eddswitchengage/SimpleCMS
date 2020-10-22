<template>
  <div class="hierarchy-item-row-list">
    <hierarchy-item-row
      v-if="showAllOption"
      :item="{ title: 'All', id: 0 }"
      :selected="selectedItemId === 0"
      v-on:selected="selectItem(0)"
    />

    <hierarchy-item-row
      v-for="item in items"
      :item="item"
      :selected="selectedItemId === item.id"
      v-bind:key="item.id"
      v-on:selected="selectItem(item.id)"
      v-on:titleUpdated="updateItem"
    />

    <hierarchy-item-row
      :initiallyEditing="true"
      :item="newItem"
      :selected="selectedItemId === -1"
      v-if="selectedItemId === -1"
      v-on:selected="selectItem(-1)"
      v-on:titleUpdated="updateItem"
      v-on:blurred="selectItem(0)"
    />

    <button
      class="add-button"
      v-on:click="selectItem(-1)"
    >
      <i class="las la-plus" />
    </button>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import HierarchyItemRow from "./HierarchyItemRow.vue";

export default Vue.extend({
  name: "HierarchyItemRowList",
  props: {
    items: Array,
    initialSelectedItemId: Number,
    showAllOption: Boolean,
  },
  data: function () {
    return {
      selectedItemId: this.initialSelectedItemId,
      newItem: { id: -1, title: "" },
    };
  },
  methods: {
    selectItem: function (itemId: number) {
      this.selectedItemId = itemId;
      this.$emit("selected", this.selectedItemId);
    },
    updateItem: function (itemId: number, newTitle: string) {
      this.$emit("itemUpdated", itemId, newTitle);
    },
  },
  components: {
    HierarchyItemRow,
  },
  watch: {
    items: function (newVal) {
      //When new items are passed, reset the current selection
      this.selectItem(this.initialSelectedItemId);
    },
  },
});
</script>

<style scoped>
.hierarchy-item-row-list {
  display: flex;
  flex: 1;
  flex-direction: column;
}

.add-button {
  border: none;
  outline: none;
  background-color: transparent;
  border-top: 3px solid var(--clr-background);
  padding: 12px 6px;
  color: var(--clr-text);
}

.add-button:hover {
  background-color: var(--clr-text-light);
  cursor: pointer;
}

.add-button:active {
  opacity: 0.6;
}
</style>
