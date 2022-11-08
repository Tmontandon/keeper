<template>
  <div class="about text-center d-flex flex-column align-items-center">
    <div class="cover-img my-4 rounded"
      :style="account.coverImg ? { backgroundImage: `url(account.coverImg)` } : { backgroundImage: `url(//thiscatdoesnotexist.com)` }">
      <img :src="account?.picture" alt="Account Pfp" class="img-fluid pfp rounded-5" />
    </div>
    <h1 class="m-2">{{ account?.name }}</h1>
    <!-- <p>{{ vaults.length }} Vaults | {{ keeps.length }} Keeps</p> -->
  </div>
</template>

<script>
import { computed, onMounted, watchEffect } from 'vue'
import { AppState } from '../AppState.js'
import { accountService } from '../services/AccountService.js'
import Pop from '../utils/Pop.js'
export default {
  setup() {
    async function getAccount() {
      try {
        await accountService.getAccount()
      } catch (error) {
        Pop.error
      }
    }

    async function getAccountVaults() {
      try {
        await accountService.getAccountVaults()
      } catch (error) {
        Pop.error(error)
      }
    }

    async function getUserKeeps() {
      try {
        await accountService.getUserKeeps(AppState.account.id)
      } catch (error) {
        Pop.error(error)
      }
    }

    onMounted(() => {
      getAccount();
      getAccountVaults();
      getUserKeeps();
    })

    // watchEffect(() => {
    //   getAccountVaults()
    //   getAccKeeps();
    // })
    return {
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps),
      vaults: computed(() => AppState.vaults),
    }
  }
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
  border: rgba(0, 0, 0, 0.588) solid 1px;
  position: absolute;
  top: 46%;
  left: 50%;
  margin-left: -4.5vh;

}
</style>
