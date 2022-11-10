<template>
  <div class="component">
    <!-- NOTE Router link to page -->
    <!-- <router-link :to="{ name: 'Profile', params: { id: vault.creatorId } }"> -->
    <router-link :to="{ name: 'Profile', params: { id: vault.creatorId } }">
      <div class="card elevation-3 m-3 text-dark selectable" :style="{ backgroundImage: `url(${vault?.img})` }">
        <div class="wacky d-flex justify-content-between flex-column ">
          <div></div>
          <div class="d-flex flex-wrap justify-content-between align-items-center">
            <span class="m-2 text-light text-shadow-dark marko">
              {{ vault?.name }}
            </span>
          </div>
        </div>
      </div>
    </router-link>
  </div>
</template>


<script>
// import { RouterLink } from 'vue-router';
import { Vault } from '../../models/Vault.js';

export default {
  props: {
    vault: { type: Vault, required: true }
  },
  setup() {
    return {};
  },
  // components: { RouterLink }
}
</script>


<style lang="scss" scoped>
.card {
  // height: 40vh;
  // width: 40vw;
  background-position: center;
  background-size: cover;
}

.wacky {
  height: 20vh;
  width: 40vw;
}

.card:hover {
  transform: scale(1.01);
  transition: 100ms;
}

span {
  overflow-x: scroll;
}
</style>