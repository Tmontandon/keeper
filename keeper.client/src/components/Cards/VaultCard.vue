<template>
  <div class="component">
    <div class="card elevation-3 m-3 text-dark selectable" :style="{ backgroundImage: `url(${vault?.img})` }">
      <i @click.self.stop="deleteVault()" v-if="vault.creatorId == account.id"
        class="mdi mdi-delete-circle text-danger fs-4 text-shadow" title="Delete Keep"></i>
      <router-link :to="{ name: 'Vault', params: { id: vault.id } }">
        <div class="wacky d-flex justify-content-between flex-column ">
          <div></div>
          <div class="d-flex flex-wrap justify-content-between align-items-center">
            <span class="m-2 text-light text-shadow-dark marko">
              {{ vault?.name }}
            </span>
          </div>
        </div>
      </router-link>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../../AppState.js';
import { Vault } from '../../models/Vault.js';
import { vaultsService } from '../../services/VaultsService.js';
import Pop from '../../utils/Pop.js';

export default {
  props: {
    vault: { type: Vault, required: true }
  },
  setup(props) {
    return {
      props,
      account: computed(() => AppState.account),

      async deleteVault() {
        try {
          if (await Pop.confirm("Delete this vault?")) {
            vaultsService.deleteVault(props.vault.id)
          }
        } catch (error) {
          Pop.error(error, "[DeleteVault]");
        }
      }
    };
  },
}
</script>


<style lang="scss" scoped>
.card {
  // height: 40vh;
  // width: 40vw;
  background-position: center;
  background-size: cover;
}

.wacky {
  height: 20vh;
  width: 40vw;
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