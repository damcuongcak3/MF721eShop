<template>
<div class="main-content">
    <ShopList/>
</div>
</template>
<script>
import ShopList from './views/dictionary/ShopList.vue'

export default {
  name: 'main-content',
  components: {
    ShopList
  }
}
</script>
<style scoped>
.main-content{
    position: absolute;
    width: calc(100% - 235px);
    height: 100vh;
    border-left: 1px solid #ccc;
    border-right: 1px solid #ccc;
    border-bottom: 1px solid #ccc;
    left: 235px;
    top: 49px;
}

</style>