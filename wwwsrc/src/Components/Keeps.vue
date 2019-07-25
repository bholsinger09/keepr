<template>
  <div>
    <h4> test keep component </h4>

    <div class="keeps">
      <form @submit.prevent="addKeep">
        <input type="text" placeholder="name" v-model="newKeep.name" required>
        <input type="text" placeholder="description" v-model="newKeep.description">
        <button type="submit">Create Your keep</button>
      </form>
      <div class="divider">
      </div>

      <div class="keeps-content" v-for="Keep in Keeps" :key="keep.id">
        <div class="keep">
          <p>{{keep.name}}</p>
          <p>{{keep.description}}</p>
          <!-- <img src="{{keep.image}}" alt="keep" height="10vh" width="10vw"> -->
        </div>
      </div>



    </div>
  </div>

</template>

<script>
  export default {
    name: 'Keep',
    data() {
      return {
        newKeep: {
          name: "",
          description: ""
        }
      }
    },
    computed: {
      Keeps() {
        return this.$store.state.keep;
      }

    },
    methods: {
      addKeep() {
        this.$store.dispatch("addKeep", this.newKeep);
        this.newKeep = { name: "", description: "" }
      },

    }


  }



</script>