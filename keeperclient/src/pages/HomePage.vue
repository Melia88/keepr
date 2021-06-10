<template>
  <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center">
    <div class="container-fluid">
      <div class="row  masonryholder">
        <div class="col-md-12 col-md-3 my-5">
          <div class="card-columns responsive">
            <KeepsComponent v-for="keep in state.keeps" :key="keep.id" :keep="keep" />
          </div>
        </div>
        <!-- <KeepDetailsModalComponent :keep="keep" /> -->
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
// Will need to bring in
</script>

<style scoped lang="scss">
.home{
  text-align: center;
  user-select: none;
  > img{
    height: 200px;
    width: 200px;
  }

//   body {
//   margin: 0;
//   padding: 1rem;
// }
//   .masonryholder {
//   margin: 0;
//   padding: 1rem;
// }

// .masonry-with-columns {
//   columns: 4 200px;
//   column-gap: 1rem;
//   div {
//     width: 150px;
//     margin: 0 1rem 1rem 0;
//     display: inline-block;
//     width: 100%;
//     text-align: center;
//     font-family: system-ui;
//     font-weight: 900;
//     font-size: 2rem;
//   }
//   @for $i from 1 through 36 {
//     div:nth-child(#{$i}) {
//       $h: (random(400) + 100) + px;
//       height: $h;
//       line-height: $h;
//     }
//   }
// }
// .testing{
//   position: relative;
// }

// .masonryholder{
//   column-count: 4;
//   column-gap: 1rem;
//   border: 1px solid red
// }
// .masonryblocks{
//   display: inline-block;
//   padding: 1rem;
//   margin: 0 0 15px;
//   width: 100%;
//   box-sizing: border-box;
// }

// @media screen and (max-width:768px){
//   .masonryholder{
//     column-count: 1;
//   }
// }
// @media screen and (min-width:769px){
//   .masonryholder{
//     column-count: 2;
//   }
// }
// @media screen and (min-width:1080px){
//   .masonryholder{
//     column-count: 3;
//   }
// }
// @media screen and (min-width:1200px){
//   .masonryholder{
//     column-count: 4;
//   }
// }
// .card-columns {
//   @include media-breakpoint-only(lg) {
//     column-count: 4;
//   }
//   @include media-breakpoint-only(xl) {
//     column-count: 5;
//   }
// }

.card-columns{
  column-count:4;
}
}
</style>
