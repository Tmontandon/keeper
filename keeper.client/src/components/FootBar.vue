<template>
  <div class="component">
    <section class=" bg-light elevation-5 px-3 d-flex flex-wrap justify-content-between align-items-center">
      <div class="order-2 order-sm-1">
        <!-- NEW CREATE BUTTON -->
        <CreateKVMobileButton />
      </div>
      <router-link class="navbar-brand d-flex order-1 order-sm-2" :to="{ name: 'Home' }">
        <div class="d-flex flex-column align-items-center selectable rounded" title="Home">
          <img alt="logo" src="../assets/img/Keepr logoKeeprLogo.png" class="vh" />
        </div>
      </router-link>
      <div class="order-3 d-flex align-items-center">
        <Login />
      </div>
    </section>
  </div>
</template>


<script>
import CreateKVMobileButton from './Buttons/CreateKVMobileButton.vue';
import Login from './Buttons/Login.vue';

export default {
  setup() {
    return {};
  },
  components: { Login, CreateKVMobileButton }
}
</script>


<style lang="scss" scoped>
.vh {
  height: 7vh;
}
</style>