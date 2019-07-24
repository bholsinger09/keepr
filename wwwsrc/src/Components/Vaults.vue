<template>
  <div>
    <h1> Here are the Keeps for you Vault</h1>
    <div class="keep-Container" <keep></div>
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
    computer: {

    },
    methods: {

    },
    components: {
      Keep

    }


  }



</script>