<template>
  <div class="component oxy">
    <!-- BUTTON & DROPDOWN -->
    <div class="dropdown-center droptop m-0 p-0">
      <button class="btn bg-primary m-0 dropdown-toggle text-light m-2 fs-6 rounded-5 text-center"
        data-bs-toggle="dropdown" aria-expanded="false" title="Create Keep or Vault">
        <p class="mb-0 fs-3 px-1 text-shadow-dark">Create</p>
      </button>
      <ul class="dropdown-menu bg-secondary no-select text-center p-0 elevation-3">
        <div v-if="!account.id">Login To Create</div>
        <div v-else class="list-group">
          <li data-bs-toggle="modal" data-bs-target="#CreateKeep" aria-label="Open New Keep Form"
            class="selectable list-group-item dropdown-item list-group-item-action rounded-top no-select text-shadow-dark text-light">
            New Keep
          </li>
          <li data-bs-toggle="modal" data-bs-target="#CreateVault" aria-label="Open New Vault Form"
            class="selectable list-group-item dropdown-item list-group-item-action no-select text-shadow-dark text-light">
            New Vault
          </li>
        </div>
      </ul>
    </div>
  </div>
</template>


<script>
import { computed } from '@vue/reactivity';
import { AppState } from '../../AppState.js';
export default {
  setup() {

    return {
      account: computed(() => AppState.account),

    };
  },
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

.dropdown-toggle::after {
  display: none;
}
</style>