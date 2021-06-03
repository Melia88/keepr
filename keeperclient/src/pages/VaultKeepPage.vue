<template>
  <div class="vault-keep-kage" v-if="state.activeVault">
    {{ activeVault.name }}
  </div>
</template>

<script>
import { vaultsService } from '../services/VaultsService'
import { computed, watchEffect, reactive } from 'vue'
import { AppState } from '../AppState'
import { useRoute } from 'vue-router'

export default {
  name: 'VaultKeepPage',
  setup() {
    const route = useRoute()
    const state = reactive({
      activeProfile: computed(() => AppState.activeProfile),
      account: computed(() => AppState.account),
      profile: computed(() => AppState.profile),
      user: computed(() => AppState.user),
      activeVault: computed(() => AppState.activeVault)
    })
    // onMounted(async() => {
    //   try {
    //     await profileService.getAll()
    //   } catch (error) {
    //     logger.log(error)
    //   }
    // })
    // onMounted(async() => {
    //   })
    // If I change the onMounted in this specific instance to watchEffect
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
      state
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
