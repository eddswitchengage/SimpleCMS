<template>
  <div
    class="edit-hierarchy-row"
    v-bind:class="{ active: selected }"
    v-on:click="$emit('selected')"
  >
    <input
      v-bind:class="{ editable: editing }"
      type="text"
      v-model="title"
      :readonly="item.id === 0 || !editing"
      ref="input"
      v-on:blur="onInputBlur"
      placeholder="Title"
    />
    <div class="action-buttons" v-if="selected">
      <i class="las la-check" v-if="changesMade" v-on:click="updateTitle"></i>
      <i
        class="las la-edit"
        v-else-if="item.id !== 0"
        v-on:click="selectInput"
      ></i>
      <i class="las la-trash" v-if="item.id > 0"></i>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "HierarchyItemRow",

  props: {
    item: Object,
    selected: Boolean,
    initiallyEditing: Boolean,
  },
  data: function () {
    return {
      editing: this.initiallyEditing,
      title: this.item.title,
      changesMade: false,
    };
  },
  methods: {
    selectInput: function () {
      this.editing = true;
      this.$refs.input.select();
    },
    onInputBlur: function () {
      if (this.changesMade) return;
      this.editing = false;
      this.title = this.item.title;
      this.$emit("blurred");
    },
    updateTitle: function () {
      this.$emit("titleUpdated", this.item.id, this.title);
      this.editing = false;
      this.changesMade = false;
    },
  },
  mounted: function () {
    if (this.initiallyEditing === true) this.selectInput();
  },
  watch: {
    title: function (newVal) {
      this.changesMade = newVal !== this.item.title;
    },
  },
});
</script>

<style scoped>
.edit-hierarchy-row {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  border-top: 3px solid var(--clr-background);
  padding: 10px 5px;
}

.edit-hierarchy-row:hover {
  cursor: pointer;
}

.active {
  background-color: var(--clr-text-light);
}

input {
  flex: 4;
  font-size: 18px;
  color: var(--clr-text) !important;
  padding: 2px 5px;
  border: 1px solid transparent !important;
  transition-duration: 100ms;
}

input:hover {
  cursor: pointer;
}

.editable {
  border: 1px solid var(--clr-text) !important;
  border-radius: 5px;
  transition-duration: 150ms;
}

.editable:hover {
  cursor: text;
}

.action-buttons {
  flex: 1;
  margin-right: 10px;
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  font-size: 22px;
  color: var(--clr-text-light);
}

.action-buttons i {
  margin-left: 12px;
}

.active .action-buttons i {
  color: var(--clr-text);
}

.action-buttons i:hover {
  opacity: 0.8;
}
.action-buttons i:active {
  opacity: 0.6;
}

.action-buttons :last-child:hover {
  color: var(--clr-danger);
}
</style>
