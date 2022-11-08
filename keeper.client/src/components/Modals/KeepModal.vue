<template>
  <div class="component">
    <div class="modal" id="keepModal" tabindex="-1" aria-labelledby="KeepModal" aria-hidden="true">
      <div class="modal-dialog modal-lg container">
        <div class="card bg-secondary row">
          <!-- Picture -->
          <div class="col-6" :style="{ backgroundImage: `url(${keep.img})` }">
          </div>
          <!-- Content -->
          <div class="col-6">
            {{ keep.name }}
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../../AppState.js';

export default {
  setup() {
    return {
      keep: computed(() => AppState.selectedKeep)
    }
  }
}
</script>


<style lang="scss" scoped>
// .col-6 {
//   height: 40vh;
//   width: 40vw;
//   background-position: center;
//   background-size: cover;
// }
</style>