<template>
  <div class="component">
    <div class="about  d-flex flex-column align-items-center">
      <div class="cover-img my-4 rounded text-center"
        :style="profile.coverImg ? { backgroundImage: `url(profile.coverImg)` } : { backgroundImage: `url(//thiscatdoesnotexist.com)` }">
        <img v-if="profile.picture" :src="profile?.picture" alt="Profile Pfp" class="img-fluid pfp rounded-5" />
      </div>
      <h1 class="m-2">{{ profile?.name }}</h1>
      <p>{{ vaults.length }} Vaults | {{ keeps.length }} Keeps</p>
      <div v-if="vaults[0] || keeps[0]">
        <h4 v-if="vaults[0]">My Vaults</h4>
        <div v-if="vaults[0]" class="p-3 flex-wrap d-flex justify-content-between">
          <VaultCard v-for="v in vaults" :key="v.id" :vault="v" class="col-6" />
        </div>
        <h4 v-if="keeps[0]">My Keeps</h4>
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
import { computed, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import { AppState } from '../AppState.js';
import KeepCard from '../components/Cards/KeepCard.vue';
import VaultCard from '../components/Cards/VaultCard.vue';

export default {
  setup() {
    const route = useRoute();


    onMounted(() => {
      getProfile()
    })
    return {

      profile: computed(() => AppState.profile)
    };
  },
  components: { VaultCard, KeepCard }
}
</script>


<style lang="scss" scoped>

</style>