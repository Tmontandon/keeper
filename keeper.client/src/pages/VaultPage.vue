<template>
  <div v-if="vault.name" class="component container ">
    <div class="row justify-content-center mt-2 marko">
      <div class="p-4 cover-img d-flex flex-column justify-content-center align-items-center rounded elevation-2"
        :style="vault.img ? { backgroundImage: `url(${vault.img})` } : { backgroundImage: `url(//thiscatdoesnotexist.com)` }">
        <h2 class="text-light text-shadow-dark">{{ vault.name }}</h2>
        <h5 class="text-light text-shadow-dark">{{ vault.creator.name }}</h5>
      </div>
      <span class="text-center p-2  lighten-10" v-if="keeps.length == 1">
        <h4>{{ keeps.length }} keep</h4>
      </span>
      <span class="text-center p-2  lighten-10" v-else>
        <h4>{{ keeps.length }} keeps</h4>
      </span>
    </div>
    <div class="grid">
      <VaultKeepCard v-for="k in keeps" :key="k.id" :keep="k" class="" />
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { onMounted, watchEffect } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js';
// import KeepCard from '../components/Cards/KeepCard.vue';
import VaultKeepCard from '../components/Cards/VaultKeepCard.vue';
import { vaultsService } from '../services/VaultsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const route = useRoute();
    async function getSelectedVault() {
      try {
        await vaultsService.getSelectedVault(route.params.id);
      }
      catch (error) {
        Pop.error(error);
      }
    }
    async function getVaultKeeps() {
      try {
        await vaultsService.getVaultKeeps(route.params.id);
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      AppState.keeps = []
      AppState.selectedVault = {}

    });

    // TODO I dont know how to make account load before these go through
    watchEffect(() => {
      getSelectedVault();
      getVaultKeeps();
    })
    return {
      vault: computed(() => AppState.selectedVault),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { VaultKeepCard }
}
</script>


<style lang="scss" scoped>
.cover-img {
  width: 60vw;
  height: 35vh;
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;
}

.grid {
  columns: 4;
}

@media screen and (max-width: 575px) {
  .grid {
    columns: 2
  }
}
</style>