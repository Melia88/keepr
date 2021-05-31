<template>
  <div class="keeps-component">
    <div class="card text-white shadow masonryblocks">
      <img :src="keep.img" class="card-img" alt="...">
      <div class="card-img-overlay">
        <h5 class="card-title">
          {{ keep.name }}
        </h5>
        <p class="card-text">
          {{ keep.description }}
        </p>
        <div class="">
          <p class="card-text">
            {{ keep.views }}
          </p>
          <p class="card-text">
            {{ keep.shares }}
          </p>
          <p class="card-text">
            {{ keep.keeps }}
          </p>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'KeepsComponent',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    // const state = reactive({
    //   account: computed(() => AppState.account)
    // })
    return {
      // state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
