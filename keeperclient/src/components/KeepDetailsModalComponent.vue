<template>
  <div class="keep-details-modal-component">
    <div class="modal"
         id="keepsDetailsModal"
         tabindex="-1"
         role="dialog"
         aria-labelledby="exampleModalLabel"
         aria-hidden="true"
    >
      <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content">
          <div class="div modal-body p-1">
            <!-- ------------------------------------------------------------------------------------ -->
            <div class="div container-fluid">
              <div class="row" v-if="state.activeKeep">
                <div class="col-12 col-md-6 m-0 p-0">
                  <img :src="state.activeKeep.img" alt="" class="w-100">
                </div>
                <div class="col-12 col-md-6 p-1">
                  <!-- <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                  </button>
                  <p> icons </p>
                  <h1> HEllurrrr</h1>

                  <div> this is some crazy messs rn ksdfhiuhwfdschberghkdsh;kdhbxvjhdfmuvjhxmznbxcljs.,h    dixukhvbcidkhbvyhjdbzxk.hchbiuzskjdhbfuvjgmdfzbyxcjhhvxc </div>
                  <div> </div> -->
                  <div class="card border-light px-0 m-0">
                    <div class="card-header bg-light">
                      <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                      </button>
                      <p> <i class="fas fa-eye text-primary mr-4"><span class="mx-2">{{ state.activeKeep.views }}</span></i> <i class="fab fa-kickstarter-k text-primary ml-4"> <span class="mx-2">{{ state.activeKeep.keeps }}</span></i> </p>
                    </div>
                    <div class="card-body">
                      <h5 class="card-title">
                        {{ state.activeKeep.name }}
                      </h5>
                      <p class="card-text">
                        {{ state.activeKeep.description }}
                      </p>
                    </div>
                    <div class="card-footer footer-light text-muted">
                      <!-- <a href="#" class="btn btn-primary">Go somewhere</a> -->
                      <!-- This starts the move task dropdown -->
                      <div class="dropdown">
                        <button class="btn btn-primary dropdown-toggle"
                                type="button"
                                title="Add Keep to a Vault"
                                id="dropdownMenu2"
                                data-toggle="dropdown"
                                aria-haspopup="true"
                                aria-expanded="false"
                        >
                          <span class="text-dark">
                            Add to a Vault
                          </span>
                        </button>
                        <div class="dropdown-menu" aria-labelledby="dropdownMenu2">
                          <a class="dropdown-item action"
                             type="button"
                             title="Add to this Vault!"
                          >
                            <!-- v-for="list in state.list"
                             :key="list.id"
                             @click="moveTask(task, list.id)" -->
                            <p>
                              <!-- {{ list.title }} -->
                            </p>
                          </a>
                        </div>
                      </div>
                      <!------------------------- this ends the move task dropdown -->
                      <i class="far fa-trash-alt text-secondary mx-5 pl-5 action" title="Delete Keep" @click="deleteKeep(state.activeKeep)" v-if="state.activeKeep.creator.id == state.account.id" aria-hidden="true"></i>

                      <router-link :to="{name: 'ProfileDetailsPage', params: {id: state.activeKeep.creator.id}}" data-dismiss="modal">
                        {{ state.activeKeep.creator.name }}
                        <img class="creator-pic rounded-circle small-img action" title="Go to Keep Creator's Profile" :src="state.activeKeep.creator.picture" alt="Creator Photo">
                      </router-link>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>

          <!-- ---------------------------------------------------------------------------------------- -->
        </div>
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
  name: 'KeepDetailsModalComponent',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup(props) {
    const state = reactive({
      activeKeep: computed(() => AppState.activeKeep),
      user: computed(() => AppState.user),
      account: computed(() => AppState.account)

    })
    return {
      state,
      // activeKeepDetails() {
      //   AppState.activeKeep = props.keep
      // }
      // TODO write the delete keep
      async deleteKeep(activeKeep) {
        try {
          if (await Notification.confirmAction()) {
            await keepsService.deleteKeep(activeKeep.id)
            // Notification.toast('Successfully Deleted Note', 'success')
          }
          $('#keepsDetailsModal').modal('hide')
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
.modal-body{
  min-height: 50vh;
}
.card{
  min-height: 84vh;
}
.creator-pic{
  max-height: 2rem;
  max-width: 2rem;
}
.action{
  cursor: pointer;
}
</style>
