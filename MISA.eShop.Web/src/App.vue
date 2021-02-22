<template>
  <div id="app">
      <Header/>
    <LeftSideBar/>
    <Content/>
  </div>
</template>

<script>
import Header from './components/Header.vue'
import LeftSideBar from './components/LeftSideBar.vue'
import Content from './components/Content.vue'
export default {
  name: 'App',
  components: {
    Header,
    LeftSideBar,
    Content,
  }
}
</script>

<style lang="scss">
@import './styles/index.scss';


#app {
  box-sizing: border-box;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100vh;
  margin: 0px;
  padding: 0px;
}



</style>
