<template>
  <div v-if="profile" class="component">
    <div class="about  d-flex flex-column align-items-center">
      <div class="cover-img my-4 rounded text-center"
        :style="profile.coverImg ? { backgroundImage: `url(profile.coverImg)` } : { backgroundImage: `url(//thiscatdoesnotexist.com)` }">
        <img v-if="profile.picture" :src="profile?.picture" alt="Profile Pfp" class="img-fluid pfp rounded-5" />
      </div>
      <h1 class="m-2">{{ profile?.name }}</h1>
      <p>{{ vaults.length }} Vaults | {{ keeps.length }} Keeps</p>
      <div v-if="vaults[0] || keeps[0]">
        <h4 v-if="vaults[0]">{{ profile.name }}'s Vaults</h4>
        <div v-if="vaults[0]" class="p-3 flex-wrap d-flex justify-content-between">
          <VaultCard v-for="v in vaults" :key="v.id" :vault="v" class="col-6" />
        </div>
        <h4 v-if="keeps[0]">{{ profile.name }}'s Keeps</h4>
        <div class="p-3 flex-wrap d-flex justify-content-between">
          <KeepCard v-for="k in keeps" :key="k.id" :keep="k" class="col-3" />
        </div>
      </div>
      <div v-else class="p-4">
        <h5 class="text-center mb-3">
          This person doesn't have any vaults or keeps!
        </h5>
        <div>
          <img src="https://miro.medium.com/max/1000/1*1LPBUmm5gjoDfet6AzMf1A.gif" alt="">
        </div>
      </div>
    </div>
  </div>

</template>


<script>
import { computed, onMounted, watchEffect } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js';
import KeepCard from '../components/Cards/KeepCard.vue';
import VaultCard from '../components/Cards/VaultCard.vue';
import { Account } from '../models/Account.js';
import { router } from '../router.js';
import { accountService } from '../services/AccountService.js';
import Pop from '../utils/Pop.js';

export default {
  setup() {
    const route = useRoute();
    async function getProfile() {
      try {
        accountService.getUser(route.params.id)
      } catch (error) {
        Pop.error(error)
      }
    }
    async function getUserKeeps() {
      try {
        await accountService.getUserKeeps(route.params.id);
      }
      catch (error) {
        Pop.error(error);
      }
    }
    async function getUserVaults() {
      try {
        console.log("wtf")
        accountService.getUserVaults(route.params.id)
      } catch (error) {
        Pop.error(error)
      }
    }

    onMounted(() => {
      AppState.accountKeeps = []
      AppState.accountVaults = []
      // NOTE this fn you can implement a if statement to send to acc page
      getProfile()
      getUserKeeps();
      getUserVaults();
    })
    watchEffect(() => {
      if (route.params.id == AppState.account.id) {
        router.push({ name: 'Account' })
        AppState.profile = null
      }
    })
    return {
      profile: computed(() => AppState.profile),
      keeps: computed(() => AppState.accountKeeps),
      vaults: computed(() => AppState.accountVaults)
    };
  },
  components: { VaultCard, KeepCard }
}
</script>


<style lang="scss" scoped>
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
  top: 44%;
  left: 50%;
  margin-left: -4.5vh;

}

@media screen and (max-width: 575px) {
  .pfp {
    height: 9vh;
    border: rgba(0, 0, 0, 0.588) solid 1px;
    position: absolute;
    top: 34%;
    left: 50%;
    margin-left: -4.5vh;

  }
}
</style>