<template>
  <!-- NOTE d-sm-none look into it -->
  <nav class=" bg-light elevation-5 px-3 d-flex flex-wrap justify-content-between align-items-center">
    <!-- TODO Implement create component -->
    <div>
      <CreateKVButton />
    </div>
    <router-link class="navbar-brand d-flex" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center selectable rounded" title="Home">
        <img alt="logo" src="../assets/img/Keepr logoKeeprLogo.png" class="vh" />
      </div>
    </router-link>
    <Login />
  </nav>
</template>

<script>
import CreateKVButton from './CreateKVButton.vue';
import Login from './Login.vue'
export default {
  setup() {
    return {}
  },
  components: { Login, CreateKVButton }
}
</script>

<style scoped>
a:hover {
  text-decoration: none;
}

.nav-link {
  text-transform: uppercase;
}

.navbar-nav .router-link-exact-active {
  border-bottom: 2px solid var(--bs-success);
  border-bottom-left-radius: 0;
  border-bottom-right-radius: 0;
}

.vh {
  height: 8vh;
}

@media screen and (min-width: 768px) {
  nav {
    height: 12vh;
  }
}
</style>
