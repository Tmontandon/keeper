<template>
  <section v-if="account.name">
    <div class="about  d-flex flex-column align-items-center">
      <div class="cover-img my-4 rounded text-center"
        :style="account.coverImg ? { backgroundImage: `url(${account.coverImg})` } : { backgroundImage: `url(//thiscatdoesnotexist.com)` }">
        <img v-if="account.picture" :src="account?.picture" alt="Account Pfp" class="img-fluid pfp rounded-5" />
        <button class="edit btn btn-dark-outline bg-secondary" data-bs-toggle="modal" data-bs-target="#EditAcc"
          aria-label="Open Edit Account Form">Edit
          Details</button>
      </div>
      <h1 class="m-4">{{ account?.name }}</h1>
      <p>{{ vaults.length }} Vaults | {{ keeps.length }} Keeps</p>
      <div v-if="vaults[0] || keeps[0]">
        <h4 v-if="vaults[0]" class="ps-3">My Vaults</h4>
        <div v-if="vaults[0]" class="p-3 flex-wrap d-flex justify-content-between">
          <VaultCard v-for="v in vaults" :key="v.id" :vault="v" class="col-6" />
        </div>
        <h4 v-if="keeps[0]" class="ps-3">My Keeps</h4>
        <div class="grid">
          <KeepCard v-for="k in keeps" :key="k.id" :keep="k" class="" />
        </div>
      </div>
      <div v-else class="p-4">
        <h5 class="text-center mb-3">
          Hey you dont have any Vaults or Keeps! Try making some
        </h5>
        <div>
          <img src="https://miro.medium.com/max/1000/1*1LPBUmm5gjoDfet6AzMf1A.gif" alt="">
        </div>
      </div>
    </div>
  </section>
  <section v-else>
    Hey looks like your stuff isnt loading...
    Try refreshing!
  </section>

</template>

<script>
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import KeepCard from '../components/Cards/KeepCard.vue'
import VaultCard from '../components/Cards/VaultCard.vue'
import { accountService } from '../services/AccountService.js'
import Pop from '../utils/Pop.js'
export default {
  setup() {
    async function getAccount() {
      try {
        await accountService.getAccount();
      }
      catch (error) {
        Pop.error;
      }
    }
    async function getAccountVaults() {
      try {
        await accountService.getAccountVaults();
      }
      catch (error) {
        Pop.error(error);
      }
    }
    async function getUserKeeps() {
      try {
        await accountService.getUserKeeps(AppState?.account?.id);
      }
      catch (error) {
        Pop.error(error);
      }
    }
    onMounted(() => {
      // AppState.keeps = []
      // AppState.vaults = []
      // getAccount();
      getAccountVaults();
    });
    watchEffect(() => {
      getUserKeeps();

    })
    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.accountKeeps),
      vaults: computed(() => AppState.accountVaults),
    };
  },
  components: { KeepCard, VaultCard }
}
</script>

<style scoped>
.cover-img {
  width: 60vw;
  height: 35vh;
  background-position: center;
  background-size: cover;
  background-repeat: no-repeat;
}

.pfp {
  height: 9vh;
  max-width: 6vw;
  border: rgba(0, 0, 0, 0.588) solid 1px;
  position: absolute;
  top: 44%;
  left: 50%;
  margin-left: -4.5vh;

}

.edit {
  position: absolute;
  top: 49%;
  left: 74%;
}

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

@media screen and (max-width: 575px) {
  .pfp {
    height: 6vh;
    max-width: 10vh;
    border: rgba(0, 0, 0, 0.588) solid 1px;
    position: absolute;
    top: 34%;
    left: 50%;
    margin-left: -4.5vh;

  }
}
</style>
