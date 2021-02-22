<template>
    <div id="menu" class="menu">
        <a href='#' class="menu-item">
            <div class="menu-item-icon"></div>
            <div class="menu-item-text">Tổng quan</div>
        </a>
        <a href='#' class="menu-item">
            <div class="menu-item-icon icon-report"></div>
            <div class="menu-item-text">Báo cáo</div>
        </a>
        <a href='#' class="menu-item">
            <div class="menu-item-icon icon-cart"></div>
            <div class="menu-item-text">Đơn hàng</div>
        </a>
        <a href='#' class="menu-item">
            <div class="menu-item-icon icon-sales"></div>
            <div class="menu-item-text">Khuyến mại</div>
        </a>
        <a href='#' class="menu-item">
            <div class="menu-item-icon icon-manage"></div>
            <div class="menu-item-text">Quản lý cửa hàng</div>
        </a>
                <a href='#' class="menu-item">
            <div class="menu-item-icon icon-item"></div>
            <div class="menu-item-text">Hàng hóa</div>
        </a>
    </div>
</template>
<script>


export default {
    name: "LeftSideBar",
    data() {
        return {
            listMenu: [
                 {
        title:"Tổng quan",
        img: require('../assets/content/icon/dashboard.png')
    },
    {
        title:"Báo cáo",
        img: require('../assets/content/icon/report.png')
    },
    {
        title:"Mua hàng",
        img: require('../assets/content/icon/dashboard.png')
    },
    {
        title:"Đơn hàng",
        img: require('../assets/content/icon/dic-employee.png')
    },
    {
        title:"Quản lý cửa hàng",
        img: require('../assets/content/icon/setting.png')
    },
    {
        "title":"Hàng hóa",
        "img": require('../assets/content/icon/dic-employee.png')
    }
            ]
        }
    },
}
</script>
<style scoped>
a{
  text-decoration: none;
  color: #fff;
  align-items: center;
}
a:hover{
  background-color: #0088c1;
  cursor: pointer;
}

</style>