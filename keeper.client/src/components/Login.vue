<template>
  <span class="navbar-text">
    <button class="btn bg-primary selectable text-shadow-dark text-primary lighten-30 text-uppercase my-2 my-lg-0"
      @click="login" v-if="!user.isAuthenticated">
      Login
    </button>
    <div v-else>
      <div class="dropdown dropstart my-2 my-lg-0">
        <div type="button" class="rounded-5 border-0 selectable no-select" data-bs-toggle="dropdown"
          aria-expanded="false" title="Options">
          <div v-if="account.picture || user.picture">
            <img :src="account.picture || user.picture" alt="account photo" height="" class="rounded-5 vh" />
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
import { AppState } from '../AppState'
import { AuthService } from '../services/AuthService'
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
}

// .selectable:hover {
//   border: solid, paleturquoise, 3rem;
// }
</style>
