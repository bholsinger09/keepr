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

      <div class="keeps-content" v-for="Keep in Keeps" :key="Keep._id">
        <div class="keep">
          <p>keep name: {{Keep.name}}</p>
          <p>keep description: {{Keep.description}}</p>
          <!-- <img src="{{keep.image}}" alt="keep" height="10vh" width="10vw"> -->
          <button @click="deleteKeep(Keep.id)">delete keep</button>
          <button @click="addViewed">view</button>
          <!-- <p> Number viewed : {{keep.viewed}}</p> -->
          <button @click="addKeeped">keep</button>
          <!-- <p> Number keeped : {{keep.keeped}}</p> -->
          <button @click="addShared">share</button>
          <!-- <p> Number Shared: {{keep.shared}}</p> -->
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
    mounted() {
      this.$store.dispatch("getKeeps");
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
      deleteKeep(keepId) {

        this.$store.dispatch("deleteKeep", keepId);
      },
      addViewed() {

      },
      addKeeped() {

      },
      addShared() {

      }

    }


  }



</script>

<style>
  .keep {
    border-color: blue;
    border-style: solid
  }
</style>