<template>
  <div class="component oxy">
    <div class="modal" id="CreateKeep" tabindex="-1" aria-labelledby="CreateVaultModal" aria-hidden="true">
      <div class="modal-dialog modal-md">
        <div class="modal-content bg-secondary ">
          <div class="modal-body">
            <h5 class="modal-title fs-3">Create A Keep!</h5>
            <div class="">
              <form class="row g-2" @submit.prevent="postKeep()">
                <div class="form-floating my-3 col-4">
                  <input type="text" class="form-control" required v-model="editable.name" name="name"
                    placeholder="Name:" maxlength="25" />
                  <label for="name">Name:</label>
                </div>
                <div class="form-floating mb-3 col-12">
                  <input type="url" class="form-control" name="img" v-model="editable.img" required placeholder="Image:"
                    maxlength="5000" />
                  <label for="img">Image Url:</label>
                </div>
                <div class="form-floating mb-3 col-12">
                  <textarea type="text" class="form-control desc" v-model="editable.description" name="description"
                    placeholder="Description:" maxlength="500"></textarea>
                  <label for="name">Description:</label>
                </div>
                <div class="text-end">
                  <span>{{ editable.description ? editable.description.length : 0 }}</span>
                  <span>/ 500</span>
                </div>
                <div class="modal-footer d-flex justify-content-between">
                  <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                  <button type="submit" class="btn bg-primary lighten-10 text-dark" data-bs-dismiss="modal"
                    aria-label="Submit">Post
                    <span class="mdi mdi-send"></span></button>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
import { ref } from 'vue';
import { keepsService } from '../../services/KeepsService.js';
import Pop from '../../utils/Pop.js';

export default {
  setup() {
    const editable = ref({})

    return {
      editable,
      async postKeep() {
        try {
          await keepsService.postKeep(editable.value)
          Pop.success(`${editable.value.name} was posted!`)
          editable.value = {}
        } catch (error) {
          Pop.error(error, "[postKeep]")
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.desc {
  height: 43vh !important;
}
</style>