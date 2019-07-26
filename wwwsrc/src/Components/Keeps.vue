<template>
  <div>
    <h4> View keeps :</h4>

    <div class="keeps">
      <form @submit.prevent="addKeep">
        <input type="text" placeholder="name" v-model="newKeep.name" required>
        <input type="text" placeholder="description" v-model="newKeep.description">
        <input type="text" placeholder="add image url" v-model="newKeep.img">
        <button type="submit">Create Your keep</button>
      </form>
      <div class="divider">
      </div>

      <div class="keeps-content" v-for="Keep in Keeps" :key="Keep.id">
        <div class="keep">
          <img v-bind:src="Keep.img">
          <p>keep name: {{Keep.name}}</p>
          <p>keep description: {{Keep.description}}</p>
          <select v-model="selected" @change="moveKeepToVault(Keep)">
            <option disabled value>Select vault</option>
            <option v-for="vault in vaults" :key="vault.id" :value="vault.id">{{vault.name}}</option>
          </select>
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
          description: "",
          img: ""
        },
        selected: ""
      }
    },
    mounted() {
      this.$store.dispatch("getKeeps");
    },

    computed: {
      Keeps() {
        return this.$store.state.keep;
      },
      vaults() {
        return this.$store.state.vaults;
      }



    },
    methods: {
      addKeep() {

        this.$store.dispatch("addKeep", this.newKeep);
        this.newKeep = { name: "", description: "", img: "" }
      },
      deleteKeep(keepId) {

        this.$store.dispatch("deleteKeep", keepId);
      },
      addViewed() {

      },
      addKeeped() {
        // this.$store.dispatch("addKeepToVault", this.newKeep);

      },
      addShared() {

      },
      moveKeepToVault(Keep) {
        // let targetKeep = this.newKeep;
        // let keepId = targetKeep.id
        //targetVault.oldListId = this.newKeep


        let vaultId = this.selected;
        let keepId = Keep.id;


        this.selected = "";
        this.$store.dispatch("addKeepToVault", { vaultId, keepId });

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