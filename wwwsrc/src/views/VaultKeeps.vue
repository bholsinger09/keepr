<template>
  <div>






    <keep></keep>
  </div>

</template>



<script>

  import Keep from '@/Components/Keeps.vue'
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

      Keep
    }
  };
</script>