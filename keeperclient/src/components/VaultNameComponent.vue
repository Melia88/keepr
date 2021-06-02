<template>
  <div class="vault-name-component">
    <a class="dropdown-item action"
       href="#"
       title="Add to this Vault!"
       @click.prevent="moveToVault"
    >

      {{ vault.name }}
    </a>
  </div>
</template>

<script>
import { vaultKeepsService } from '../services/VaultKeepsService'
import { computed, reactive } from 'vue'
import { AppState } from '../AppState'
export default {
  name: 'VaultNameComponent',
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      vaults: computed(() => AppState.profileVaults),
      activeKeep: computed(() => AppState.activeKeep)
    })
    return {
      state,
      async moveToVault() {
        try {
          const newVaultKeep = {
            activeKeepId: state.activeKeep.id,
            vaultId: props.vault.id
          }
          await vaultKeepsService.moveToVault(newVaultKeep)
          Notification.toast('Successfully Added Keep to Vault!', 'success')
        } catch (error) {
          Notification.toast('Error: ' + error, 'error')
        }
      }
    }
  },
  components: {}
}
</script>

<style lang="scss" scoped>
// .vaultNameSeporation{
//   box-sizing: border-box;
//   border: 1px solid;
//   // border-radius: 20px ;
//   // outline-style: solid;
//   outline-color: grey;
// }
</style>
