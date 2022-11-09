<template>
  <nav class=" bg-light elevation-5 px-3 d-flex flex-wrap justify-content-between align-items-center">
    <div class="order-2 order-sm-1">
      <CreateKVButton />
    </div>
    <router-link class="navbar-brand d-flex order-1 order-sm-2" :to="{ name: 'Home' }">
      <div class="d-flex flex-column align-items-center selectable rounded" title="Home">
        <img alt="logo" src="../assets/img/Keepr logoKeeprLogo.png" class="vh" />
      </div>
    </router-link>
    <div class="order-3 d-flex align-items-center">
      <Login />
    </div>
  </nav>
</template>

<script>
import CreateKVButton from './Buttons/CreateKVButton.vue';
import Login from './Buttons/Login.vue'
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


@media screen and (min-width: 575px) {
  nav {
    height: 10vh;
  }
}
</style>
