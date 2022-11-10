<template>
  <div class="component">


  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js';
import { vaultsService } from '../services/VaultsService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const route = useRoute();
    vault: computed(() => AppState.selectedVault)

    async function getSelectedVault() {
      try {
        await vaultsService.getSelectedVault(route.params.id)
      } catch (error) {
        Pop.error(error)
      }
    }
    onMounted(() => {
      getSelectedVault()

    })
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>