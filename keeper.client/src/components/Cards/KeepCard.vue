<template>
  <div class="component">
    <div class="card text-dark">



      <div class="justify-content-between">
        {{ keep.name }}
        <span>
          {{ keep.creator.name }}
        </span>
      </div>
    </div>

  </div>
</template>


<script>
import { Keep } from '../../models/Keep.js';

export default {
  props: {
    keep: { type: Keep, required: true }
  },
  setup() {
    return {}
  }
}
</script>


<style lang="scss" scoped>
.card {
  height: 20vh;
}
</style>