<template>
  <div class="panel">
    <h3 class="title">{{this.content.name}}</h3>
    <p class="text-light">Id: {{this.content.id}} | Topic Id: {{this.content.topicId}}</p>
    <p>{{this.content.description}}</p>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
export default Vue.extend({
  name: "ContentPanel",
  props: {
    content: Object
  }
});
</script>

<style scoped>
.panel {
  height: 300px;
  width: 300px;
  text-align: start;
}
</style>