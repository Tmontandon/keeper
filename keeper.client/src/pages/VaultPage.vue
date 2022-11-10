<template>
  <div v-if="vault.name" class="component container">
    <div class="row">
      <div class="p-4 cover-img text-center"
        :style="vault.img ? { backgroundImage: `url(${vault.img})` } : { backgroundImage: `url(//thiscatdoesnotexist.com)` }">
        <h3 class="text-light text-shadow-dark">{{ vault.name }}</h3>
      </div>
      <div class="row">
        <KeepCard v-for="k in keeps" :key="k.id" :keep="k" class="col-3" />
      </div>
    </div>

  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js';
import KeepCard from '../components/Cards/KeepCard.vue';
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
      AppState.keeps = [];
      getSelectedVault();
      getVaultKeeps();
    });
    return {
      vault: computed(() => AppState.selectedVault),
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard }
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
</style>