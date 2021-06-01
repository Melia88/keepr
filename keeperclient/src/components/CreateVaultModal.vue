<template>
  <div class="create-vault-modal">
    <div class="modal"
         id="new-vault-form"
         tabindex="-1"
         role="dialog"
         aria-labelledby="exampleModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog" role="document">
        <div class="modal-content">
          <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLabel">
              Create a Vault
            </h5>
            <button type="button" class="close text-danger" data-dismiss="modal" aria-label="Close">
              <span aria-hidden="true">&times;</span>
            </button>
          </div>
          <form @submit.prevent="createVault">
            <div class="modal-body">
              <div class="form-group">
                <label for="name">Title</label>
                <input type="text"
                       class="form-control"
                       id="name"
                       placeholder="Title..."
                       min="1"
                       v-model="state.newVault.name"
                       required
                >
              </div>
              <!-- <div class="form-group">
                <label for="title">Image Url</label>
                <input type="text"
                       class="form-control"
                       id="imgUrl"
                       placeholder="URL..."
                       min="1"
                       v-model="state.newVault.img"
                       required
                >
              </div> -->
            </div>

            <div class="form-group p-3">
              <label for="description">Description</label>
              <textarea type="text"
                        class="form-control"
                        id="description"
                        placeholder="Description..."
                        minlength="3"
                        v-model="state.newVault.description"
                        required
              >
              </textarea>
            </div>
            <!-- ---------------------------------------------------------------------------------- -->
            <p class="ml-3">
              Set to Private?
            </p>
            <div class="SetToPrivateCheckbox text-left mr-5">
              <input class="action ml-3"
                     type="checkbox"
                     id="isPrivate"
                     name="isPrivate"
                     title="Click to Set This Vault as Private"
                     @click="state.setToPrivate.isPrivate = !state.setToPrivate.isPrivate"
              >
            </div>
            <!-- step1 this state.setToAutoAdd.autoAdd is the global variable called autoAdd that is set in appState -->
            <div class="modal-footer">
              <button type="button" class="btn btn-link text-secondary" data-dismiss="modal">
                Close
              </button>
              <button type="submit" class="btn btn-success text-light" @click="createVault()">
                Create
              </button>
            </div>
          </form>

          <!-- ---------------------------------------------------------------------------------- -->
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { vaultsService } from '../services/VaultsService'
import { AppState } from '../AppState'
import Notification from '../utils/Notification'
import { useRoute } from 'vue-router'
import $ from 'jquery'
export default {
  name: 'CreateVaultModal',
  setup() {
    const route = useRoute()
    const state = reactive({
      newVault: { },
      activeProfile: computed(() => AppState.activeProfile),
      vaults: computed(() => AppState.vaults),
      // this is bringing in the entire appstate and saving it to setToAutoAdd so we can drill into it and get the global variable autoAdd
      setToPrivate: computed(() => AppState)
    })
    return {
      state,
      route,
      async createVault() {
        try {
          state.newVault.creatorId = route.params.id
          // step3 if they clicked the checkbox above then flip the server model to true
          if (state.setToPrivate.isPrivate) {
            state.newVault.isPrivate = true
            await vaultsService.createVault(state.newVault)
          } else {
            state.newVault.isPrivate = false
            await vaultsService.createVault(state.newVault)
          }
          // if (!state.setToPrivate.isPrivate)
          state.newVault = {}
          $('#new-vault-form').modal('hide')
          await Notification.toast('Vault Successfully Created!', 'success')
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

</style>
