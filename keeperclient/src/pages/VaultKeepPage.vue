<template>
  <div class="vault-keep-kage" v-if="state.activeVault">
    <div class="row">
      <div class="col-12 m-3">
        <div>
          <h1 class="m-3">
            {{ state.activeVault.name }}
          </h1>
          <i class="far fa-trash-alt text-secondary m-2 pl-2 action" title="Delete Keep" @click="deleteVault(state.activeVault)" v-if="state.activeVault.creator && state.activeVault.creator.id == state.account.id" aria-hidden="true"></i>
          <p class="m-3">
            {{ state.activeVault.description }}
          </p>
        </div>
      </div>
    </div>
    <div class="row">
      <div class="col">
        <div class="card-columns responsive">
          <KeepsComponent v-for="keep in state.vaultkeeps" :key="keep.id" :keep="keep" />
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { vaultsService } from '../services/VaultsService'
import { computed, watchEffect, reactive } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'
import Notification from '../utils/Notification'
import $ from 'jquery'
import { logger } from '../utils/Logger'
import KeepsComponent from '../components/KeepsComponent.vue'

export default {
  name: 'VaultKeepPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile),
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      user: computed(() => AppState.user),
      activeVault: computed(() => AppState.activeVault),
      vaultkeeps: computed(() => AppState.vaultKeeps)
    })
    watchEffect(async() => {
      try {
        await vaultsService.getVaultById(route.params.id)
        await vaultsService.GetVaultsKeeps(route.params.id)
      } catch (error) {
        Notification.toast('Error:' + error, 'error')
      }
    })
    return {
      route,
      state,
      async deleteVault(activeVault) {
        try {
          if (await Notification.confirmAction()) {
            await vaultsService.deleteVault(activeVault.id)
            Notification.toast('Successfully Deleted Vault', 'success')
          }
          $('#keepsDetailsModal').modal('hide')
        } catch (error) {
          logger.error(error)
          Notification.toast('Error: ' + error, 'error')
        }
      }
    }
  },
  components: { KeepsComponent }
}
</script>

<style lang="scss" scoped>
.action{
  cursor: pointer;
}
.card-columns{
  column-count:4;
}
</style>
