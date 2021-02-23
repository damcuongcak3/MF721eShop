<template>

    <div class="body-content">
        <div class="filter-bar">
            <div class="form-add">   
              <button class="btn btn-add" id="btnAdd" @click="btnAddOnClick"><div class="icon icon-add"></div>Thêm mới</button>                 
                </div>
                <div class="form-copy">
                    <button class="btn btn-copy" id="btnCopy" @click="focusInput"><div class="icon icon-copy"></div>Nhân bản</button>
                </div>
                <div class="form-edit">
                    <button class="btn btn-edit" id="btnEdit" @click="btnEditOnclick"><div class="icon icon-edit"></div>Sửa</button>
                </div>
                <div class="form-delete">
                  <button class="btn btn-delete" id="btnDelete" @click="show = !show"><div class="icon icon-delete"></div>Xóa</button>
                </div>
                <div class="form-reload">
                  <button class="btn btn-reload" id="btnReload"><div class="icon icon-reload"></div>Nạp</button>
                </div>
        </div>
            <table>
                <thead>
                    <tr class="trTitle">
                            <th style="width: 170px">Mã cửa hàng</th>
                            <th style="width: 240px">Tên cửa hàng</th>
                            <th style="width: 500px">Địa chỉ</th>
                            <th style="width: 140px">Số điện thoại</th>
                            <th style="width: 120px">Trạng thái</th>
                        </tr>
                     <tr class="trFilter">
                       <th class="row">
                         <button class="btnOption"><div>*</div></button>
                         <input ref="shopCode" type="text" class="filter filterShopCode" id="filterShopCode">
                       </th>
                       <th class="row">

                        <button class="btnOption"><div>*</div></button>
                         <input type="text" class="filter filterShopName" id="filterShopName">
                       </th>
                      <th class="row">
                         <button class="btnOption"><div>*</div></button>
                         <input type="text" class="filter filterAddress" id="filterAddress">
                       </th>
                       <th class="row">
                         <button class="btnOption"><div>*</div></button>
                         <input type="text" class="filter filterPhoneNumber" id="filterPhoneNumber">
                       </th>
                       <th class="row">
                         <select name="" id="">
                           <option value="1">Đang hoạt động</option>
                         </select>
                       </th>
                       </tr>   
                </thead>
            </table>
        <div class="table-content">
                <table>
                <tbody>
                    <tr ref="tableShop"
                    v-for="shp in shops"
                    :key="shp.shopId" 
                    :row="shp"
                    @click="rowSelected(shp.shopId); shopParentData = shp" 
                    v-bind:class="{trSelected : rowSelected_el === shp.shopId}"
                    :id-selected="shp.shopId"
                    >
                    <td style="width: 170px">{{shp.shopCode}}</td>
                    <td style="width: 240px">{{shp.shopName}}</td>
                    <td style="width: 500px">{{shp.address}}</td>
                    <td style="width: 140px">{{shp.phoneNumber}}</td>
                    <td style="width: 108px">{{shp.status}}</td>
                    </tr>
                    </tbody>
            </table>
        </div>
        <div class="footer-content">
            <button class="btnFooter btnFirst"></button>
            <button class="btnFooter btnPrevious"></button>
            <div class="page">Trang<input type="text" value="1" class="pageCurrent">trên 1</div>
            
            <button class="btnFooter btnNext"></button>
            <button class="btnFooter btnLast"></button>
            <button class="btnFooter btnReload"></button>
            <select class="totalPage">
              <option>50</option>
            </select>
            </div>
  <ShopDetails ref="ShopDetails"
    v-if="showDialogDetail"
    :shopParentData="shopParentData"
    @close="closeDialog"
    @closePopup ="closePopup"
    @update="getData" 
    :mode="dialogMode"/>
  <DeleteDialog ref="DeleteDialog"
    :active.sync="show" 
    :shopParentData="shopParentData"
    @deleted="deleteConfirm"
   />
</div>
</template>
<script>
import * as axios from "axios";
import ShopDetails from './ShopDetails';
import DeleteDialog from '../dialogcofirm/DeleteDialog.vue'
export default {
  name: "Shops",
  components: {
    ShopDetails,
       DeleteDialog
  },
  props: {
    success: Boolean,
    shopId: String,
  },
    data() {
      return {
        shopParentData: null,
        show: false,
        rowSelected_el: 0,
        isHideParent: true,  
        shops: [],
        shop:{},
        trSelected: {},
        showDialogDetail: false,
        dialogMode: null
      };
    },
  methods: {
    async getData(){
      const response = await axios.get("https://localhost:44333/api/v1/Shop");     
      this.shops = response.data;
    },
    closeDialog(){
      this.showDialogDetail = false;
      this.dialogMode = null;
      this.getData();
    },
      btnAddOnClick(){
        this.showDialogDetail = true;
        this.dialogMode = 'ADD';
      },
      btnEditOnclick(){
        this.showDialogDetail = true;
        this.dialogMode = 'EDIT'; 
        var rowSelected = this.$el.querySelector('.trSelected')
        if(!rowSelected){
            alert("Bạn chưa chọn shop chỉnh sửa!")
            this.showDialogDetail = false;
        }
      },
      btnDeleteOnClick(){
        this.$refs.DeleteDialog.show();
        var rowSelected = this.$el.querySelector('.trSelected')
        if(!rowSelected){
        alert("Bạn chưa chọn shop cần xóa!")
        this.$refs.DeleteDialog.hide();
        }
      },
      closePopup(value){
        this.isHideParent = value;
      },
      focusInput(){
        this.$refs.shopCode.focus();
      },
      rowSelected(shopId){
        this.rowSelected_el = shopId;
      },
      deleteConfirm: async function(){
        this.show = false;
        this.getData();
      },
      updateShop : async function(){
        var rowSelected = this.$el.querySelector('.trSelected')
        if(!rowSelected){
            alert("Bạn chưa chọn shop chỉnh sửa!")
            return
        }
        var shopId = rowSelected.getAttribute('id-selected')
        try {
          var res = await axios.get(`https://localhost:44333/api/v1/Shop/${shopId}`)
          console.log(res.data)
        } catch (error) {
          console.log(error)
        }
        this.showDialogDetail = true;
    }

      
     }, 
     async created() {
        this.getData();
  },

};
</script>
<style scoped>
.trSelected{
  background-color: #3d7daf !important;
  color: #fff;
}


</style>