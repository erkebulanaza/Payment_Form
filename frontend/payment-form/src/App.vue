<script setup>
</script>

<template>
  <nav>
    <router-link to="/" class="link">Create payment</router-link> |
    <router-link to="/history" class="link">History</router-link> |
    <router-link to="/stats" class="link">Stats</router-link>
  </nav>
  <router-view />
</template>

<style scoped>
.link{
  text-decoration: none;
  font-size: 24px;
  color: darkgreen;
}
</style>
