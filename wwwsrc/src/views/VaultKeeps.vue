<template>
  <div>
    <router-link :to="{ path: '/' }">Home Page</router-link>


    <h4>Name of vault : {{vault.name}}</h4>
    <h4>Description : {{vault.description}}</h4>








    <keep></keep>
  </div>

</template>



<script>

  import Keep from '@/Components/Keeps.vue'

  export default {
    name: "vaultkeep",
    props: ["vaultId"],
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


      this.$store.dispatch("getVaultsById", this.vaultId);
      this.$store.dispatch("getKeepsByVaultId", this.vaultId);
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vault() {
        return this.$store.state.vault;
      }
    }

    ,

    methods: {



    },
    components: {

      Keep,


    }
  };
</script>