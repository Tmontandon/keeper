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
                  <!-- NOTE IF YOURE NOT IN VAULT PAGE -->
                  <span class="ms-2">
                    <!-- <div class="dropdown">
                      <button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown"
                        aria-expanded="false">
                        Your Vaults
                      </button>
                      <ul class="dropdown-menu dropdown-menu-dark">
                        <li>
                          <h6 class="dropdown-header">Select A Vault</h6>
                        </li>
                        <div class="form-group p-1">
                          <select v-for="v in vaults" class="form-select form-select-sm bg-light" required
                            v-model="editable.id">
                            <option class="dropdown-item" :value="v.id">{{ v.name }}</option>
                          </select>
                        </div>
                      </ul>
                    </div>
                    <button class="btn bg-primary" @click="vaultKeep(editable.vault)">Vault</button> -->
                    <div class="dropdown" v-if="keep.name">
                      <button type="button" class="btn bg-t dropdown-toggle text-light text-shadow-dark"
                        data-bs-toggle="dropdown" aria-expanded="false" data-bs-auto-close="outside">
                        Vault This Keep
                      </button>
                      <form class="dropdown-menu p-4">
                        <div class="mb-3">
                          <select class="form-select form-select-sm bg-light" required v-model="editable">
                            <option v-for="v in vaults" :value="v.id">{{ v.name }}</option>
                          </select>
                        </div>
                        <button @click="vaultKeep()" class="btn bg-primary" data-bs-dismiss="modal">Vault</button>
                      </form>
                    </div>
                  </span>
                  <!-- NOTE IF YOURE IN VAULT PAGE -->
                  <span>
                    <div @click="unvaultKeep()" class="btn bg-t text-light text-shadow-dark" data-bs-dismiss="modal">
                      Unvault</div>
                  </span>
                  <span class="me-2 d-flex align-items-center" data-bs-dismiss="modal">
                    <router-link :to="{ name: 'Profile', params: { id: keep?.creatorId } }">
                      <img :src="keep?.creator?.picture" alt="CreatorImg" class="rounded-5 pfp selectable"
                        title="Go To Page">
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
import { ref } from 'vue';
import { computed } from '@vue/reactivity';
import { useRoute } from 'vue-router';
import { AppState } from '../../AppState.js';
import { keepsService } from '../../services/KeepsService.js';
import Pop from '../../utils/Pop.js';

export default {
  setup() {
    const route = useRoute();
    const editable = ref("")
    return {
      editable,
      keep: computed(() => AppState.selectedKeep),
      vaults: computed(() => AppState.accountVaults),
      async unvaultKeep() {
        try {
          // debugger
          await keepsService.unvaultKeep(AppState.selectedKeep.vaultKeepId, AppState.selectedKeep.id)
        } catch (error) {
          Pop.error(error)
        }
      },

      async vaultKeep() {
        try {
          await keepsService.vaultKeep(editable.value, AppState.selectedKeep.id)
        } catch (error) {
          Pop.error(error)
        }
      }
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

.dropdown-toggle::after {
  display: none;
}
</style>