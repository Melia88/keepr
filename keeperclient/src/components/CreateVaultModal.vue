<template>
  <div class="create-vault-modal">
    <div class="modal"
         id="new-vaults-form"
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
                <label for="title">Title</label>
                <input type="text"
                       class="form-control"
                       id="title"
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
            <div class="AutoAddCheckbox text-left mr-5">
              <input class="action m-2"
                     type="checkbox"
                     id="AutoAdd"
                     name="AutoAdd"
                     title="Click to Auto Add Item"
                     @click="state.setToAutoAdd.autoAdd = !state.setToAutoAdd.autoAdd"
              >
              <!-- step1 this state.setToAutoAdd.autoAdd is the global variable called autoAdd that is set in appState -->
            </div>
          </form>
        </div>
        <!-- ---------------------------------------------------------------------------------- -->
        <div class="modal-footer">
          <button type="button" class="btn btn-link text-secondary" data-dismiss="modal">
            Close
          </button>
          <button type="submit" class="btn btn-success text-light">
            Create
          </button>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'CreateVaultModal',
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>

</style>
