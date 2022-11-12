<template>
  <div class="component">
    <div class="modal" id="EditAcc" tabindex="-1" aria-labelledby="EditAccModal" aria-hidden="true">
      <div class="modal-dialog modal-md">
        <div class="modal-content bg-secondary ">
          <div class="modal-body">
            <h5 class="modal-title fs-3 ">Edit Account</h5>
            <form class="row" @submit.prevent="editAccSubmit()">
              <div class="form-group  my-2">
                <input type="text" v-model="acc.name" placeholder="Name" min="1" required class="form-control">
              </div>
              <div class="form-group  my-2">
                <input type="url" v-model="acc.picture" placeholder="Profile Picture" min="1" required
                  class="form-control">
              </div>
              <div class="form-group  my-2">
                <input type="url" v-model="acc.coverImg" placeholder="Cover Image" min="1" required
                  class="form-control">
              </div>
              <div>
                <button type="submit" class="btn btn-primary" data-bs-dismiss="modal" aria-label="Save Changes">Save New
                  Info</button>
              </div>
            </form>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
import { ref, watchEffect } from 'vue';
import { AppState } from '../../AppState.js';
import { accountService } from '../../services/AccountService.js';
import Pop from '../../utils/Pop.js';

export default {
  setup() {
    const acc = ref({})
    watchEffect(() => {
      acc.value = { ...AppState.account }
    })


    return {
      acc,
      async editAccSubmit() {
        try {
          await accountService.editAccount(acc.value)
          acc.value = {}
        } catch (error) {
          Pop.error(error)
        }
      }

    }
  }
}
</script>


<style lang="scss" scoped>

</style>