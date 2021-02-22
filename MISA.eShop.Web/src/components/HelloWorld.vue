<template>
  <div class="hello">
    <h1>{{ msg }}</h1>
     <button v-on:click="counter += 1">Cộng 1</button>
     <p>{{counter}}</p>

     <table>
       <thead>
         <th>STT</th>
         <th>Name</th>
         <th>Age</th>
       </thead>
       <tbody>
         <td>1</td>
         <td>Cuong</td>
         <td>1</td>
       </tbody>
     </table>
  </div>
</template>

<script>
export default {
  name: 'HelloWorld',
  props: {
    msg: String
  },
  data() {
    return {
      counter: 0
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
