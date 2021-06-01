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
              <div class="row">
                <div class="col-12 col-md-6 m-0 p-0">
                  <img src="https://images.unsplash.com/photo-1525538182201-02cd1909effb?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=667&q=80" alt="" class="w-100">
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
                      <p> <i class="fas fa-eye text-primary mr-4"></i> <i class="fab fa-kickstarter-k text-primary ml-4"></i> </p>
                    </div>
                    <div class="card-body">
                      <h5 class="card-title">
                        Special title treatment
                      </h5>
                      <!-- {{ keep.name }} -->
                      <p class="card-text">
                        With supporting text below as a natural lead-in to additional content.
                      </p>
                    </div>
                    <div class="card-footer footer-light text-muted">
                      <a href="#" class="btn btn-primary">Go somewhere</a>
                      <i class="far fa-trash-alt text-secondary ml-5 pl-5"></i>
                      <!-- Creator pic & name -->
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
export default {
  name: 'KeepDetailsModalComponent',
  props: {
    keep: {
      type: Object,
      required: true
    }
  },
  setup() {
    return {}
  },
  components: {}
}
</script>

<style lang="scss" scoped>
.modal-body{
  min-height: 50vh;
}
</style>
