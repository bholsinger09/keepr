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
      //let vaultId = this.$router.
      // this.$store.dispatch("getVaultsById", vaultId);
      // this.$store.dispatch("getKeepsByVaultId", vaultId);
    },
    computed: {
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.vault.find(vault => vault.id == this.vaultId) || {
          title: "Loading...",
        }
      }

    },

    methods: {



    },
    components: {

      Keep,
      Vaults

    }
  };
</script>