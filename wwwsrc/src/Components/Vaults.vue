<template>
  <div>
    <div class="vaults-content" v-for="vault in vaults" :key="vault._id">
      <div class="vault">
        <h2>This is your Vault</h2>
        <p>name: {{vault.name}}</p>
        <p>description: {{vault.description}}</p>
        <button @click="deleteVault(vault.id)">Delete vault</button>

        <h3>Below here is your keeps</h3>

      </div>
    </div>



  </div>

</template>

<script>

  export default {
    name: 'Vault',
    data() {
      return {


      }
    },

    computed: {
      user() {
        return this.$store.state.user;
      },
      vaults() {
        return this.$store.state.vault;
      }
    },
    mounted() {
      this.$store.dispatch("getVaults");
    },
    methods: {

      deleteVault(vaultId) {

        this.$store.dispatch("deleteVault", vaultId);
      }

    },
    components: {


    }


  }





</script>