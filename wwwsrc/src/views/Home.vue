<template>
  <div class="home">
    <header class="welcome">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </header>
    <main>
      <div class="vaults">
        <vault></vault>

    </main>

  </div>

  </div>
</template>

<script>
  import Vault from '@/Components/Vaults.vue'
  export default {
    name: "home",
    data() {
      return {}
    },
    computed: {
      user() {
        return this.$store.state.user;
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
</style>