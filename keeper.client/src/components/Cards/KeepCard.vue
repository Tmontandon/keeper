<template>
  <div class="component">
    <div @click="selectKeep()" data-bs-toggle="modal" data-bs-target="#keepModal"
      class=" card elevation-3 m-3 text-dark d-flex justify-content-between flex-column selectable"
      :style="{ backgroundImage: `url(${keep?.img})` }">
      <div></div>
      <div class="d-flex justify-content-between align-items-center">
        <span class="m-2 text-light text-shadow-dark marko">
          {{ keep?.name }}
        </span>
        <span class="m-2">
          <!-- NOTE Make router link to profile page of creator -->
          <!-- NOTE will have to position absolute or @click.prevent or sum idk -->
          <img :src="keep?.creator?.picture" alt="CreatorPfp" class="img-fluid pfp rounded-5 "
            :title="keep?.creator?.name">
        </span>
      </div>
    </div>
  </div>
</template>


<script>
import { AppState } from '../../AppState.js';
import { Keep } from '../../models/Keep.js';
import Pop from '../../utils/Pop.js';

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup(props) {
    return {
      props,
      async selectKeep() {
        try {
          AppState.selectedKeep = props.keep
        } catch (error) {
          AppState.selectedKeep = {}
          Pop.error(error)
        }
      }

    }
  }
}
</script>


<style lang="scss" scoped>
.card {
  height: 40vh;
  width: 40vw;
  background-position: center;
  background-size: cover;
}

.pfp {
  height: 7vh;
  border: rgba(0, 0, 0, 0.588) solid 1px;
}
</style>