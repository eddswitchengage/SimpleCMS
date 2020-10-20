<template>
  <div class="content-preview">
    <div class="route">
      <a href="#">{{
        content.topicId !== 0
          ? getCategoryById(topic.categoryId).title
          : "Category name"
      }}</a>
      <p>></p>
      <a href="#">{{ content.topicId !== 0 ? topic.title : "Topic name" }}</a>
      <p>> {{ content.title }}</p>
    </div>
    <h2 class="title">{{ content.title }}</h2>
    <p class="description">{{ content.description }}</p>
    <div class="preview" v-html="content.htmlBody"></div>
    <p class="tags">Tags: {{ content.tags }}</p>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import { Content, Topic } from "@/models";
import { mapGetters } from "vuex";
export default Vue.extend({
  name: "ContentPreview",
  props: {
    content: Object as () => Content,
  },
  created() {
    console.log(this.content);
  },
  computed: {
    ...mapGetters(["getTopicById", "getCategoryById"]),
    topic(): Topic {
      return this.getTopicById(this.content.topicId);
    },
  },
});
</script>

<style scoped>
.content-preview {
  text-align: left;
  background-color: white;
  border-radius: 10px;
  padding: 10px 15px;
}

.route p,
a {
  color: var(--clr-text-light);
  display: inline-block;
  text-decoration-style: none;
  opacity: 0.7;
}

.route p {
  margin: 0px 5px;
}

.route a {
  text-decoration: none;
}

.route a:hover {
  opacity: 1;
}

.title {
  color: #0070ef;
  font-size: 36px;
  margin-top: 40px;
  margin-bottom: 10px;
}

.description {
  font-size: 20px;
  margin-top: 10px;
  line-height: 1.5rem;
  color: rgb(96, 93, 94);
  margin-bottom: 35px;
}

.tags {
  color: rgba(96, 93, 94, 0.5);
  margin-top: 50px;
}

.preview {
  color: black;
}
</style>
