<template>
  <div class="col-3 vaults-component my-1">
    <div class="card bg-dark text-white">
      <img src="https://images.unsplash.com/photo-1561065749-2a263ce7b379?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=375&q=80" class="card-img w-100" alt="...">
      <div class="card-img-overlay">
        <h5 class="card-title">
          {{ vault.name }}
        </h5>
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
export default {
  name: 'VaultsComponent',
  props: {
    vault: {
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

</style>
