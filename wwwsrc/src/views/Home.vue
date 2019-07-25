<template>
  <div class="home">
    <header class="welcome">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </header>
    <main>
      <div class="vaults">
        <form @submit.prevent="addVault">
          <input type="text" placeholder="name" v-model="newVault.name" required>
          <input type="text" placeholder="description" v-model="newVault.description">
          <button type="submit">Create Your Vault</button>
        </form>
        <div class="divider">
        </div>
        <div class="vaults-content" v-for="vault in vaults" :key="vault._id">
          <div class="vault">
            <h2>This is your Vault</h2>
            <p>name: {{vault.name}}</p>
            <p>description: {{vault.description}}</p>
            <button @click="deleteVault(vault.id)">Delete vault</button>

            <h3>Below here is your keeps</h3>
            <keep></keep>
          </div>
        </div>



      </div>
    </main>

  </div>

  </div>
</template>

<script>
  import Vault from '@/Components/Vaults.vue'
  import Keep from '@/Components/Keeps.vue'
  export default {
    name: "home",
    data() {
      return {
        newVault: {
          name: "",
          description: ""
        }
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
      vaults() {
        return this.$store.state.vault;
      }
    },

    methods: {
      logout() {
        this.$store.dispatch("logout");
      },
      addVault() {
        this.$store.dispatch("addVault", this.newVault);
        this.newVault = { name: "", description: "" }
      },
      deleteVault(vaultId) {

        this.$store.dispatch("deleteVault", vaultId);
      }
    },
    components: {
      Vault,
      Keep
    }
  };
</script>

<style>
  .vault {
    border-color: blue;
    border-style: solid
  }
</style>