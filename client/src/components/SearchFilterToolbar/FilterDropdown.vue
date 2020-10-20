<template>
  <select
    class="filter-dropdown"
    v-model="selected"
    @change="$emit('updated', selected)"
  >
    <option label="All" value="0" />
    <option
      v-for="option in options"
      v-bind:key="valueProperty ? option[valueProperty] : option['value']"
      v-bind:label="labelProperty ? option[labelProperty] : option['label']"
      v-bind:value="valueProperty ? option[valueProperty] : option['value']"
    />
  </select>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "FilterDropdown",

  data: function () {
    return {
      selected: this.initial,
    };
  },
  props: {
    initial: Number,
    options: Array,
    labelProperty: String,
    valueProperty: String,
  },
  watch: {
    initial: function (newVal, oldVal) {
      this.selected = newVal;
    },
  },
});
</script>

<style scoped>
.filter-dropdown {
  width: 100%;
  background-color: var(--clr-background) !important;
  color: var(--clr-text);
  padding: 4px;
  border-radius: 5px;
  border: 1px solid transparent !important;
  transition-duration: 250ms;
  margin-top: 6px;
}
</style>