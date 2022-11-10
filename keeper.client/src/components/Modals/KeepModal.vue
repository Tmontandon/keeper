<template>
  <div class="component">
    <div class="modal bg-glass" id="keepModal" tabindex="-1" aria-labelledby="KeepModal" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-fullscreen-sm-down modal-xl">
        <div class="modal-content bg-secondary">
          <div class="row">
            <!-- Picture -->
            <div class="fit pic-card rounded-start col-md-6 " :style="{ backgroundImage: `url(${keep?.img})` }">
              <button type="button" class="btn m-3 text-light text-shadow-dark bg-t" data-bs-dismiss="modal"
                aria-label="Close" title="Go Back">
                &lt Go Back</button>
            </div>
            <!-- Content -->
            <div class="content bg-secondary col-md-6 rounded-end">
              <div class="d-flex flex-column justify-content-between content">
                <!-- STUB Stats -->
                <div class="d-flex justify-content-center m-2 gre">
                  <span class="d-flex me-2 "><i class="mdi mdi-eye-outline me-1 fs-3 "></i>
                    <p class="my-auto">{{ keep.views }}</p>
                  </span>
                  <span class="d-flex ms-2">
                    <p class="border border-dark border-1 rounded px-1 marko me-1 my-auto">k</p>
                    <p class="my-auto">{{ keep.kept }}</p>
                  </span>
                </div>
                <!-- STUB Content -->
                <div class="px-4">
                  <h2 class="marko text-center ">{{ keep?.name }}</h2>
                  <p class="inter gre">{{ keep?.description }}</p>
                </div>
                <!-- STUB Intractable -->
                <div v-if="keep.creatorId" class="d-flex justify-content-between mb-1 ">
                  <span class="ms-2"></span>
                  <span class="me-2 d-flex align-items-center">
                    <router-link :to="{ name: 'Profile', params: { id: keep?.creatorId } }">
                      <img :src="keep?.creator?.picture" alt="CreatorImg" class="rounded-5 pfp selectable">
                    </router-link>
                    <p class="my-auto ms-1">{{ keep?.creator?.name }}</p>
                  </span>
                </div>
              </div>
            </div>
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
.bg-glass {
  background-color: rgba(0, 0, 0, 0.25);
  backdrop-filter: blur(7px);
}

.pfp {
  height: 7vh;
  border: rgba(0, 0, 0, 0.588) solid 1px;
}

.pfp:hover {
  transform: 1.1 !important;
  transition: 100ms !important;
}

h2 {
  overflow-x: scroll;
}

.content {
  height: 65vh;
}

.bg-t {
  background-color: rgba(0, 0, 0, 0.321);
}

.gre {
  color: #636E72;
  max-height: 32vh;
  overflow-y: scroll;
  margin-bottom: 0;
}

.pic-card {
  height: 65vh;
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;
}
</style>