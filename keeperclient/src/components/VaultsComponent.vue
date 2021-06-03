<template>
  <div class=" vaults-component my-1" v-if="vault.id">
    <div class="card bg-dark text-white">
      <img :src="vault.img" class="card-img w-100" alt="...">
      <div class="card-img-overlay">
        <router-link :to="{name: 'VaultKeepPage', params: {id: vault.id}}" class="goToVaultKeepLink">
          <h5 class="card-title">
            <!-- v-if="state.activeVault.id" -->
            <!-- @click.prevent="setToActiveVault()" -->
            {{ vault.name }}
          </h5>
        </router-link>
        <!-- <p class="card-text">
          This is a wider card with supporting text below as a natural lead-in to additional content. This content is a little bit longer.
        </p>
        <p class="card-text">
          Last updated 3 mins ago
        </p> -->
      </div>
    </div>
  </div>
</template>

<script>
// import { computed, reactive } from 'vue'
// import { AppState } from '../AppState'
export default {
  name: 'VaultsComponent',
  props: {
    vault: {
      type: Object,
      required: true
    }
  },
  // setup(props) {
  //   const state = reactive({
  //     activeVault: computed(() => AppState.activeVault)
  //   })
  //   return {
  //     state,
  //     activeKeepDetails() {
  //       AppState.activeVault = props.vault
  //     }
  //   }
  // },
  components: {}
}
</script>

<style lang="scss" scoped>
.goToVaultKeepLink{
  color: white;
    text-shadow: 1.5px 1.5px 1.5px #000;
}
</style>
