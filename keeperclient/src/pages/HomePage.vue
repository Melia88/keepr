<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container-fluid">
      <div class="row  masonryholder">
        <div class="col-md-12 col-md-3 my-5">
          <div class="card-columns responsive">
            <KeepsComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { AppState } from '../AppState'
import { computed, onMounted, reactive } from 'vue'
import Notification from '../utils/Notification'
import { keepsService } from '../services/KeepsService'
export default {
  name: 'Home',

  setup() {
    const state = reactive({
      account: computed(() => AppState.account),
      keeps: computed(() => AppState.keeps)
    })
    onMounted(async() => {
      try {
        await keepsService.getAll()
      } catch (error) {
        Notification.toast('Error:' + error, 'error')
      }
    })
    return {
      state
    }
  },
  components: {}
}
// Will need a v-if on keeps and shares incrementer
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }

.card-columns{
  column-count:4;
}
}
</style>
