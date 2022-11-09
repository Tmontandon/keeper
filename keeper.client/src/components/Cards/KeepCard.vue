<template>
  <div @click="selectKeep()" class=" card elevation-3 m-3 text-dark selectable"
    :style="{ backgroundImage: `url(${keep?.img})` }">
    <i @click.self.stop="deleteKeep()" v-if="keep.creatorId == account.id"
      class="mdi mdi-delete-circle text-danger fs-4 text-shadow"></i>
    <div data-bs-toggle="modal" data-bs-target="#keepModal" class="wacky d-flex justify-content-between flex-column ">
      <div class="text-end pe-2"></div>
      <div class="d-flex flex-wrap justify-content-between align-items-center">
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
import { computed } from '@vue/reactivity';
import { AppState } from '../../AppState.js';
import { Keep } from '../../models/Keep.js';
import { keepsService } from '../../services/KeepsService.js';
import Pop from '../../utils/Pop.js';

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup(props) {
    async function viewKeep(id) {
      try {
        keepsService.viewKeep(id)
      } catch (error) {
        console.error(error);
        Pop.error("Your view was likely not counted")
      }
    }

    return {
      account: computed(() => AppState.account),
      props,
      async deleteKeep() {
        try {
          if (await Pop.confirm()) {
            keepsService.deleteKeep(props.keep.id)
          }
        } catch (error) {
          Pop.error(error, "[DeleteKeep]");
        }
      },
      selectKeep() {
        try {
          props.keep.views++
          AppState.selectedKeep = props.keep
          viewKeep(AppState.selectedKeep.id)
        } catch (error) {
          // AppState.selectedKeep = {}
          Pop.error(error, "[SelectKeep]")
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

.wacky {
  height: 40vh;
  width: 40vw;
}

.pfp {
  height: 7vh;
  border: rgba(0, 0, 0, 0.588) solid 1px;
}

.card:hover {
  transform: scale(1.01);
  transition: 100ms;
}

span {
  overflow-x: scroll;
}

.mdi {
  position: absolute;
  right: 1%;
  top: -1%;
}
</style>