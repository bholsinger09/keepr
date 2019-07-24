<template>
  <div class="home">
    <header class="welcome">
      <h1>Welcome Home {{user.username}}</h1>
      <button v-if="user.id" @click="logout">logout</button>
      <router-link v-else :to="{name: 'login'}">Login</router-link>
    </header>
    <main>

      <keep></keep>

    </main>



  </div>
</template>

<script>
  export default {
    name: "home",
    computed: {
      user() {
        return this.$store.state.user;
      }
    },

    methods: {
      logout() {
        this.$store.dispatch("logout");
      }
    },
    components: {
      Keep
    }
  };
</script>