<template>
  <div class="home">
    <nav class="dashboard">

      <div class="vaults-content" v-for="vault in vaults" :key="vault._id">
        <h4> Go to vault: </h4>
        <router-link :to="{ name: 'vaultkeep', params: {vaultId:vault.id} }">Name of vault {{vault.name}}</router-link>
      </div>
    </nav>
    <header class="welcome">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </header>

    <main>
      <div class="divider">
      </div>
      <div class="vaults">
        <h4>Add your vault to store your keeps : </h4>
        <form @submit.prevent="addVault">
          <input type="text" placeholder="name" v-model="newVault.name" required>
          <input type="text" placeholder="description" v-model="newVault.description">
          <button type="submit">Create Your Vault</button>
        </form>
        <div class="divider">
        </div>

        <keep>

        </keep>

      </div>
    </main>

  </div>

  </div>
</template>

<script>

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
        return this.$store.state.vaults;
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

    },
    components: {

      Keep
    }
  };
</script>

<style>
  .vault {
    border-color: blue;
    border-style: solid
  }

  .divider {
    padding-top: 2em;
  }
</style>