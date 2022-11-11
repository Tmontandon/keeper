<template>
  <div class="con">
    <div class="grid">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" class="" />
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
  columns: 4;
}

@media screen and (max-width: 575px) {
  .grid {
    columns: 2
  }
}

// TODO How can I use multiple media queries
// @media screen and (max-width: 800px) {
//   .grid {
//     columns: 3
//   }
// }
</style>
