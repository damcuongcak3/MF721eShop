<template>
    <div  class="dialog-detail" title="Thông tin nhân viên" :class="{ isHide: isHide }">
        <div class="dialog-modal"></div>
        <div class="content-dialog">
            <div class="dialog-header">
                <div class="dialog-header-title">Thêm mới cửa hàng</div>
                <div class="dialog-header-icon">
                    <button tabindex="14" id="btnCancel" v-on:click="btnCancelOnClick">X</button>
                </div>
            </div>
            <div class="dialog-body">
                <p v-for="error in errorMsg" :key="error.errorMsg">{{error}}</p>
                <div class="shopDetails">
                    <div class="label" for="">Mã cửa hàng <Span>*</Span></div>
                    <input id="txtShopCode" name="ShopCode" ref="shopCode" tabindex="1" type="text" required
                    v-model="newshop.ShopCode">
                </div>
                <div class="shopDetails">
                    <div class="label" for="">Tên cửa hàng <Span>*</Span></div>
                    <input id="txtShopName"  name="ShopName" tabindex="2" type="text" required
                    v-model="newshop.ShopName">
                </div>
                <div class="shopDetails">
                    <div class="label" for="">Địa chỉ <Span>*</Span></div>
                    <textarea id="txtAddress" name="Address" tabindex="3" rows="8"
                    v-model="newshop.Address"></textarea>
                </div>
                <div class="shopDetails">
                    <div class="shopDetailsColumn">
                    <div class="label" for="">Số điện thoại</div>
                    <input tabindex="4" type="text"
                    v-model="newshop.PhoneNumber">
                    </div>
                     <div class="shopDetailsColumn">
                    <div class="label" for="">Mã số thuế</div>
                    <input tabindex="5" class="columnRight"  type="text"
                    v-model="newshop.ShopTaxCode">
                    </div>
                </div>
                <div class="shopDetails">
                    <div class="shopDetailsColumn">
                    <div class="label" for="">Quốc gia</div>
                    <select tabindex="6" name="" id="">
                        <option value="">Việt Nam</option>
                    </select>
                    </div>
                    
                </div>
                <div class="shopDetails">
                    <div class="shopDetailsColumn">
                    <div class="label" for="">Tỉnh/Thành phố</div>
                    <select tabindex="7" name="" id="">
                        <option value="" aria-placeholder="Nhập để tìm kiếm"></option>
                    </select>
                    </div>
                    <div class="shopDetailsColumn">
                    <div class="label" for="">Quận/Huyện</div>
                    <select tabindex="8" name="" id="" class="columnRight">
                        <option value="" aria-placeholder="Nhập để tìm kiếm"></option>
                    </select>
                    </div>
                    
                </div>
                <div class="shopDetails">
                    <div class="shopDetailsColumn">
                    <div class="label" for="">Phường/Xã</div>
                    <select tabindex="9" name="" id="">
                        <option value="" aria-placeholder="Nhập để tìm kiếm"></option>
                    </select>
                    </div>
                    <div class="shopDetailsColumn">
                    <div class="label" for="">Đường phố</div>
                    <input tabindex="10" class="columnRight"  type="text">

                    </div>
                    
                </div>

            </div>
            <div class="dialog-footer">
                <div class="dialog-button">
                <div class="btn-footer">
                <button tabindex="11" id="btnSave" class="btnDialog btnSave" v-on:click="Confirm()"><div class="icon icon-save"></div>Lưu</button>
                </div>
                <div class="btn-footer" style="width: 145px"> 
                <button tabindex="12" id="btnSaveNew" class="btnDialog btnSaveNew" v-on:click="validateInput()"><div class="icon icon-savenew"></div>Lưu và thêm mới</button>
                </div>
                <div class="btn-footer"> 
                <button tabindex="13" id="btnCancel" class="btnDialog btnCancel" v-on:click="btnCancelOnClick"><div class="icon icon-cancel"></div>Hủy bỏ</button>
                </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import * as axios from "axios";        
export default {
    
    props: {
        isHide: Boolean,
        data: {
            type: Object,
            default: () => {},
        },
    },

    methods: {
    focusInput(){
        this.$refs.shopCode.focus();
        console.log(this);
    },
    btnAddOnClick() {
      //this.isHide = false;
    },
    btnCancelOnClick() {
      this.$emit('closePopup',true)
      // this.isHide = true;
    },
    validateInput: function(){
        if (this.txtShopCode && this.txtShopName && this.txtAddress) {
            this.errorMsg.push("");
            return true;
     }
        this.errorMsg =[];
        if (!this.txtShopCode){
            this.errorMsg.push("Mã cửa hàng không được phép trống!");
        }
        if(!this.txtShopName){
            this.errorMsg.push("Tên cửa hàng không được phép để trống");

        }
        if(!this.txtAddress){
            this.errorMsg.push("Địa chỉ cửa hàng không được phép để trống");
        }        


    },
    Confirm : async function(){      
      var confirm = false;
      console.log(this.newshop);

      await axios.post('https://localhost:44333/api/v1/Shop', this.newshop)
            .then(function (res) {
             confirm = true;
             console.log(res);
        alert("Thêm mới thành công");

            })
            .catch(function (error) {   
             confirm = false;
             console.log(error);
        alert("Thêm mới không thành công");

            });
           this.$emit("postNewShop", confirm); 
    },

},
data() {
    return {
        newshop: {
            ShopCode: "",
            ShopName: "",
            Address: "",
            PhoneNumber: "",
            ShopTaxCode: "",
        },
        errorMsg:"",
        
    }
}, 
computed: {
    shop(){
        return this.data
    }
}
}

</script>
<style scoped>
input[required]{
width: calc(100% - 100px);
    border-radius: 3px;

}
input{
    width: 200px;
    border-radius: 3px;
}
select{
    width: 200px;
}
.required{
    border-color: rgb(194, 1, 1);
}
</style>