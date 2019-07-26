<template>
  <div>
    <router-link :to="{ path: '/' }">Home Page</router-link>
    <vaults></vaults>





    <keep></keep>
  </div>

</template>



<script>

  import Keep from '@/Components/Keeps.vue'
  import Vaults from '@/Components/Vaults.vue'
  export default {
    name: "vaultkeep",
    data() {
      return {

      }
    },
    created() {
      if (!this.$store.state.user.id) {
        this.$router.push({ name: "login" })
      }
    },
    mounted() {
      this.$store.dispatch("getVaults");
    },
    computed: {
      user() {
        return this.$store.state.user;
      },

    },

    methods: {



    },
    components: {

      Keep,
      Vaults

    }
  };
</script>