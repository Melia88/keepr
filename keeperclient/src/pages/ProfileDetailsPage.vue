<template>
  <div class="container-fluid">
    <div class="row creators-info-row my-4" v-if="state.activeProfile">
      <div class="col-2 ">
        <img :src="state.activeProfile.picture" class="rounded-circle creator-pic" alt="">
      </div>
      <div class="col-5">
        <b class="profile-pic mb-4">
          {{ state.activeProfile.name }}
        </b>
        <p class="keeps mb-4">
          {{ state.keeps.keeps }}
        </p>

        <p class="vaults mb-4">
          Vaults: <span></span> {{ state.userVaults.length }}
        </p>
        <p class="vaults mb-4">
          Keeps: <span></span> {{ state.keeps.length }}
        </p>
      </div>
      <div class="col">
        <span>
        </span>
      </div>
    </div>

    <!-- -------------------------------------------------------------------------------------------------------- -->
    <!-- VAULTS START -->
    <div class="row mt-5">
      <div class="col">
        <h1>
          Vaults
          <!-- Button trigger modal -->
          <button title="Click To Create a Vault"
                  type="button"
                  class="btn btn-outline-transparent"
                  data-toggle="modal"
                  data-target="#new-vault-form"
                  v-if="state.activeProfile.id == state.account.id"
          >
            <i class="fas fa-plus text-success" aria-hidden="true" v-if="state.activeProfile.id == state.account.id"></i>
          </button>
        </h1>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="row vaults float-container" v-if="state.account.id != $route.params.id">
          <VaultsComponent v-for="vault in state.vaults" :key="vault.id" :vault="vault" />
        </div>
        <!-- Vaults that arent private -->
        <div class="row vaults float-container" v-else>
          <VaultsComponent v-for="vault in state.userVaults" :key="vault.id" :vault="vault" />
        </div>
      </div>
    </div>

    <!-- KEEPS STARTS -->

    <div class="row mt-5">
      <div class="col">
        <h1>
          Keeps
          <!-- Button trigger modal -->
          <button title="Click To Create a Keep"
                  type="button"
                  class="btn btn-outline-transparent"
                  data-toggle="modal"
                  data-target="#new-keeps-form"
          >
            <i class="fas fa-plus text-success" aria-hidden="true" v-if="state.activeProfile.id == state.account.id"></i>
          </button>
        </h1>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="row masonryholder" v-if="state.keeps">
          <div class="col">
            <div class="card-columns">
              <KeepsComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- -------------------------------------------------------------------------------------------------------- -->
  </div>
</template>

<script>
import { computed, reactive, onMounted } from 'vue'
// import { logger } from '../utils/Logger'
// import { profileService } from '../services/ProfileService'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import { profileDetailsService } from '../services/ProfileDetailsService'
import Notification from '../utils/Notification'

export default {
  name: 'ProfileDetailsPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      newPost: {},
      activeProfile: computed(() => AppState.activeProfile),
      keeps: computed(() => AppState.profileKeeps),
      vaults: computed(() => AppState.profileVaults),
      userVaults: computed(() => AppState.userVaults),
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      user: computed(() => AppState.user)
    })

    onMounted(async() => {
      try {
        await profileDetailsService.getActiveProfile(route.params.id)
        await profileDetailsService.getProfileKeeps(route.params.id)
        await profileDetailsService.getProfileVaults(route.params.id)
      } catch (error) {
        Notification.toast('Error:' + error, 'error')
      }
    })
    return {
      route,
      state
      // async createKeep() {
      //   try {
      //     await keepsService.createPost(state.newKeep)
      //     Notification.toast('Successfully Created Keep', 'success')
      //     state.newKeep = {}
      //   } catch (error) {
      //     Notification.toast('Error: ' + error, 'error')
      //   }
      // },
      // async createVault() {
      //   try {
      //     await vaultsService.createPost(state.newVault)
      //     Notification.toast('Successfully Created Vault', 'success')
      //     state.newVault = {}
      //   } catch (error) {
      //     Notification.toast('Error: ' + error, 'error')
      //   }
      // }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.creator-pic{
  max-height: 4rem;
  max-width: 4rem;
}
.creators-info-row{
  min-height: 10vh;
}
.card-columns{
  column-count:4;
}
// .float-container {
//     // border: 3px solid #fff;
//     padding: 1.5rem;
// }
</style>
