<template>
  <div id="nav">
    <h1 class="title">simplecms</h1>
    <search-bar />
    <div class="nav-links">
      <router-link to="/">
        <i class="las la-home"></i>
      </router-link>
      <router-link to="/settings">
        <i class="las la-cog"></i>
      </router-link>
    </div>
  </div>
</template>

<script lang="ts">
import Vue from "vue";
import SearchBar from "@/components/SearchBar.vue";

export default Vue.extend({
  name: "NavBar",

  components: {
    SearchBar
  }
});
</script>

<style scoped>
#nav {
  height: 40px;

  padding: 10px;
  padding-left: 20px;
  padding-right: 20px;

  align-items: center;

  background-color: var(--clr-panel);
  border-bottom: 2px solid #27313e;

  display: flex;
  justify-content: space-between;
}

#nav .title {
  margin: 0;
  font-weight: normal;
  color: var(--clr-brand);
  font-family: "Montserrat", sans-serif;
}

#nav .nav-links {
  text-align: end;
}

#nav a {
  color: var(--clr-text-light);
  font-weight: bold;
  text-decoration: none;
  margin-left: 20px;
}

#nav a i {
  font-size: 32px;
}

#nav a.router-link-exact-active i {
  color: var(--clr-text);
}
</style>