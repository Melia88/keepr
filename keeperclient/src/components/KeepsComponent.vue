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
                @click="activeKeepDetails()"
        >
          <h5 class="card-title mb-2 keep-name">
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
import { computed, reactive } from 'vue'

import { AppState } from '../AppState'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'KeepsComponent',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep),
      activeVault: computed(() => AppState.activeVault),
      vaultkeeps: computed(() => AppState.vaultKeeps),
      keeps: computed(() => AppState.profileKeeps),
      vaults: computed(() => AppState.profileVaults)
    })
    return {
      state,
      activeKeepDetails() {
        AppState.activeKeep = props.keep
        keepsService.getById(AppState.activeKeep.id)
      }
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
.keep-name{
  color: white;
    text-shadow: 1.5px 1.5px 1.5px #000;
}
</style>
