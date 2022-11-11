<template>
  <span class="navbar-text p-0 oxy">
    <button class="btn bg-primary border-dark border-3 selectable text-light text-uppercase my-2 my-lg-0" @click="login"
      v-if="!user.isAuthenticated" aria-label="Login">
      Login
    </button>
    <div v-else>
      <div class="dropdown dropstart my-2 my-lg-0">
        <div type="button" class="rounded-5 border-0  no-select" data-bs-toggle="dropdown" title="Options">
          <div v-if="account.picture || user.picture">
            <img :src="account.picture || user.picture" alt="account photo" height=""
              class="rounded-5 vh bg-light text-light" />
          </div>
        </div>
        <div class="dropdown-menu dropdown-menu-lg-left p-0 elevation-3" aria-labelledby="authDropdown">
          <div class="list-group ">
            <router-link :to="{ name: 'Account' }">
              <div
                class="list-group-item dropdown-item list-group-item-action rounded-top no-select text-shadow-dark text-light">
                Account Details
              </div>
            </router-link>
            <div class="list-group-item dropdown-item list-group-item-action text-danger no-select text-shadow-light"
              @click="logout">
              <i class="mdi mdi-logout"></i>
              Logout
            </div>
          </div>
        </div>
      </div>
    </div>
  </span>
</template>

<script>
import { computed } from 'vue'
import { AppState } from '../../AppState'
import { AuthService } from '../../services/AuthService'
export default {
  setup() {
    return {
      user: computed(() => AppState.user),
      account: computed(() => AppState.account),
      async login() {
        AuthService.loginWithPopup()
      },
      async logout() {
        AuthService.logout({ returnTo: window.location.origin })
      }
    }
  }
}
</script>

<style lang="scss" scoped>
.dropdown-item {
  background-color: #d0c1f6;
}

.vh {
  height: 8vh;
  border: rgba(0, 0, 0, 0.588) solid 1px;
}

.rounded-5 {
  border: rgba(0, 0, 0, 0.588) solid 1px;

  .rounded-5:hover {

    border: rgba(0, 0, 0, 0) solid 1px !important;
  }
}
</style>
