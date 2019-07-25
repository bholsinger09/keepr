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
        <div class="devider">
        </div>
        <div class="vaults-content" v-for="vault in vaults" :key="vault._id">
          <div class="vault">
            <p>{{vault.name}}</p>
            <p>{{vault.description}}</p>
          </div>
        </div>

        <vault></vault>
      </div>
    </main>

  </div>

  </div>
</template>

<script>
  import Vault from '@/Components/Vaults.vue'
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
      }
    },
    components: {
      Vault
    }
  };
</script>

<style>
  .vault {
    border-color: blue;
    border-style: solid
  }
</style>