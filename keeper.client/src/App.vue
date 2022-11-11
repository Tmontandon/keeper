<template>
  <!-- NOTE d-sm-none look into it -->
  <header class="d-none d-sm-block sticky-top">
    <Navbar />
  </header>
  <main>
    <router-view />
    <KeepModal />
    <CreateKeepModal />
    <CreateVaultModal />
    <EditAccModal />
  </main>
  <!-- NOTE maybe I can go here to put in component for thing -->
  <footer class="d-sm-none sticky-bottom bg-light">
    <FootBar />
  </footer>

</template>

<script>
import { computed } from 'vue'
import { AppState } from './AppState'
import FootBar from './components/FootBar.vue'
import CreateKeepModal from './components/Modals/CreateKeepModal.vue'
import CreateVaultModal from './components/Modals/CreateVaultModal.vue'
import EditAccModal from './components/Modals/EditAccModal.vue'
import KeepModal from './components/Modals/KeepModal.vue'
import Navbar from './components/Navbar.vue'

export default {
  setup() {
    return {
      appState: computed(() => AppState)
    }
  },
  components: { Navbar, FootBar, KeepModal, CreateKeepModal, CreateVaultModal, EditAccModal }
}
</script>
<style lang="scss">
@import "./assets/scss/main.scss";

:root {
  --main-height: calc(100vh - 32px - 64px);
}
</style>
