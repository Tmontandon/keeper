<template>
  <div class="con">
    <div v-if="keeps[0]" class="grid mt-2 mx-3">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" class="item" />
    </div>
    <div v-else class="mdi-spin text-center">
      <i class="mdi-spin mdi mdi-loading fs-1"></i>
    </div>

  </div>

</template>



<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import KeepCard from '../components/Cards/KeepCard.vue';
import { keepsService } from '../services/KeepsService.js'
import Pop from '../utils/Pop.js';

export default {
  setup() {
    async function getAllKeeps() {
      try {
        await keepsService.getAllKeeps();
      }
      catch (error) {
        Pop.error(error, "[getAllKeeps]");
      }
    }
    onMounted(() => {
      AppState.keeps = []
      getAllKeeps();
    });
    return {
      keeps: computed(() => AppState.keeps)
    };
  },
  components: { KeepCard }
}
</script>

<style scoped lang="scss">
.grid {
  display: block;
  columns: 16rem;
  gap: 1rem;
}


@media screen and (max-width: 575px) {
  .grid {
    columns: 2;
    gap: .3rem;
  }
}

// TODO How can I use multiple media queries
// @media screen and (max-width: 800px) {
//   .grid {
//     columns: 3
//   }
// }
</style>
