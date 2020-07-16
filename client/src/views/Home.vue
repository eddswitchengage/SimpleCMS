<template>
  <div class="home">
    <content-panel v-for="content in exampleContent" v-bind:content="content" :key="content.id"></content-panel>
  </div>
</template>

<script>
import ContentPanel from "@/components/ContentPanel.vue";

export default {
  name: "Home",
  data: function() {
    return {
      exampleContent: [
        {
          name: "Content A",
          id: 1,
          description: "This is a nice example of a content object",
          topicId: 1
        },
        {
          name: "Content B",
          id: 2,
          description:
            "This is anohter example of a content object, except this one contains a typo",
          topicId: 1
        },
        {
          name: "Content C",
          id: 3,
          description:
            "This content has quite a long description. Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
            "Sed finibus eleifend venenatis. Praesent non augue sit amet tortor mattis laoreet sed euismod ex. Integer vitae metus velit.",
          topicId: 2
        }
      ]
    };
  },
  components: {
    ContentPanel
  }
};
</script>
