<template>
  <div class="con">
    <div class="grid">
      <KeepCard v-for="k in keeps" :key="k.id" :keep="k" class="item" />
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
  // column-gap: 1rem;
}

// .item {
//   width: 150px;
//   background: #EC985A;
//   color: white;
//   // margin: 0 1rem 1rem 0;
//   display: inline-block;
//   // width: 100%;
//   text-align: center;
//   font-family: system-ui;
//   font-weight: 900;
//   font-size: 2rem;
// }

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
