<template>
  <div class="keeps-component">
    <div class="card text-white shadow">
      <img :src="keep.img" class="card-img" alt="...">
      <div class="card-img-overlay align-items-end justify-content-between">
        <h5 class="card-title">
          {{ keep.name }}
        </h5>
        <p class="card-text">
          {{ keep.description }}
        </p>

        <p class="card-text">
          {{ keep.views }}
        </p>
        <img :src="keep.creator.picture" class="creator-pic rounded-circle" alt="...">
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
.creator-pic{
  max-height: 1.5rem;
  max-width: 1.5rem;
}
</style>
