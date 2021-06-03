<template>
  <div class="modal"
       v-if="state.newKeep"
       id="new-keeps-form"
       tabindex="-1"
       role="dialog"
       aria-labelledby="exampleModalLabel"
       aria-hidden="true"
  >
    <div class="modal-dialog" role="document">
      <div class="modal-content">
        <div class="modal-header">
          <h5 class="modal-title" id="exampleModalLabel">
            Create a Keep
          </h5>
          <button type="button" class="close text-danger" data-dismiss="modal" aria-label="Close">
            <span aria-hidden="true">&times;</span>
          </button>
        </div>
        <form @submit.prevent="createKeep">
          <div class="modal-body">
            <div class="form-group">
              <label for="title">Title</label>
              <input type="text"
                     class="form-control"
                     id="title"
                     placeholder="Title..."
                     min="1"
                     v-model="state.newKeep.name"
                     required
              >
            </div>
            <div class="form-group">
              <label for="title">Image Url</label>
              <input type="text"
                     class="form-control"
                     id="imgUrl"
                     placeholder="URL..."
                     min="1"
                     v-model="state.newKeep.img"
                     required
              >
            </div>
          </div>

          <div class="form-group p-3">
            <label for="description">Description</label>
            <textarea type="text"
                      class="form-control"
                      id="description"
                      placeholder="Description..."
                      minlength="3"
                      v-model="state.newKeep.description"
                      required
            >
              </textarea>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-link text-secondary" data-dismiss="modal">
              Close
            </button>
            <button type="submit" class="btn btn-success text-light">
              Create
            </button>
          </div>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import { computed, reactive } from 'vue'
import { keepsService } from '../services/KeepsService'
import { AppState } from '../AppState'
import Notification from '../utils/Notification'
import $ from 'jquery'
export default {
  name: 'CreateKeepModal',
  setup() {
    const state = reactive({
      newKeep: {},
      keeps: computed(() => AppState.keeps),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account)
    })
    return {
      state,
      async createKeep() {
        try {
          await keepsService.createKeep(state.newKeep)
          state.newKeep = {}
          $('#new-keeps-form').modal('hide')
          Notification.toast('Successfully Created Keep', 'success')
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
