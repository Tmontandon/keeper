<template>
  <div class="component oxy">
    <!-- BUTTON & DROPDOWN -->
    <div class="dropdown dropend m-0 p-0">
      <button class="btn bg-primary m-0 dropdown-toggle text-light m-2 fs-6 py-3 px-2 rounded-5 text-shadow-dark"
        type="button" data-bs-toggle="dropdown" aria-expanded="false">Post</button>
      <ul class="dropdown-menu bg-secondary no-select text-center p-0 elevation-3">
        <div class="list-group">
          <li data-bs-toggle="modal" data-bs-target="#CreateKeep"
            class="selectable list-group-item dropdown-item list-group-item-action rounded-top no-select text-shadow-dark text-light">
            New Keep
          </li>
          <li data-bs-toggle="modal" data-bs-target="#CreateVault"
            class="selectable list-group-item dropdown-item list-group-item-action no-select text-shadow-dark text-light">
            New Vault
          </li>
        </div>
      </ul>
    </div>

    <!-- MODALS -->
    <CreateKeepModal />
    <CreateVaultModal />
  </div>
</template>


<script>
import CreateKeepModal from '../Modals/CreateKeepModal.vue';
import CreateVaultModal from '../Modals/CreateVaultModal.vue';

export default {
  setup() {

    return {

    };
  },
  components: { CreateKeepModal, CreateVaultModal }
}
</script>


<style lang="scss" scoped>
.dropdown-item {
  background-color: #ded5f7;
}

.m-0 {
  margin: 0 !important;
}

.rounded-5 {
  border: rgba(0, 0, 0, 0.588) solid 1px;

  .rounded-5:hover {
    background-color: #916ef3 !important;
    border: rgba(0, 0, 0, 0.588) solid 1px !important;
  }
}
</style>