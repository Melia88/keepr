<template>
  <div class="keeps-component">
    <div class="card text-white shadow">
      <img :src="keep.img"
           class="card-img"
           alt="..."
      >
      <div class="card-img-overlay d-flex align-items-end justify-content-between">
        <button title="View Details"
                type="button"
                class="btn btn-outline-transparent text-light"
                data-toggle="modal"
                data-target="#keepsDetailsModal"
                :id="keep.id"
        >
          <!-- v-if="state.user.isAuthenticated" -->
          <h5 class="card-title mb-2">
            {{ keep.name }}
          </h5>
        </button>
        <router-link :to="{name: 'ProfileDetailsPage', params: {id: keep.creator.id}}">
          <img class="creator-pic rounded-circle small-img" :src="keep.creator.picture" alt="Creator Photo">
        </router-link>
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
  max-height: 2rem;
  max-width: 2rem;
}
</style>
