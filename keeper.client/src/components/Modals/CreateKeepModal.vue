<template>
  <div class="component">
    <div class="modal" id="CreateKeep" tabindex="-1" aria-labelledby="CreateVaultModal" aria-hidden="true">
      <div class="modal-dialog modal-lg ">
        <div class="modal-content bg-light">
          <div class="modal-header">
            <h5 class="modal-title">Create A Keep!</h5>
          </div>
          <div class="modal-body">
            <p>Keep Form goes here.</p>
          </div>
          <div class="modal-footer d-flex justify-content-between">
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            <button type="button" class="btn bg-secondary text-dark">Create Keep</button>
          </div>
        </div>
      </div>
    </div>

  </div>
</template>


<script>
export default {
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>

</style>