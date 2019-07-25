<template>
  <div>
    <h1> Here are the Keeps for you Vault</h1>
    <div class="keep-Container" <keep>
      </keep>
    </div>

  </div>

</template>

<script>
  import Keep from '@/Components/Keeps.vue'
  export default {
    name: 'Vault',
    data() {
      return {
        newVault: {
          name: '',
          description: ''
          //userId: this.userId
        }
      }
    },

    computed: {

    },
    methods: {

    },
    components: {
      Keep

    }


  }



</script>