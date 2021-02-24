<template>
    <div  class="dialog-detail" title="Thông tin nhân viên">
        <div class="dialog-modal"></div>
        <div class="content-dialog">
            <div class="dialog-header">
                <div class="dialog-header-title">Thêm mới cửa hàng</div>
                <div class="dialog-header-icon">
                    <button tabindex="14" id="btnCancel" v-on:click="close">X</button>
                </div>
            </div>
            <div class="dialog-body">
                <div class="shopDetails">
                    <div class="label" for="">Mã cửa hàng <Span>*</Span></div>
                    <input id="txtShopCode" name="ShopCode" ref="shopCode" tabindex="1" type="text" required
                    @blur="validateData('shopCode')"
                    :class="{required: isActiveClassRequired.shopCode}"
                    v-model="shopData.shopCode">
                </div>
                <div class="shopDetails">
                    <div class="label" for="">Tên cửa hàng <Span>*</Span></div>
                    <input id="txtShopName"  name="ShopName" ref="shopName" tabindex="2" type="text" required
                    @blur="validateData('shopName')"
                    :class="{required :isActiveClassRequired.shopName}"
                    v-model="shopData.shopName">
                </div>
                <div class="shopDetails">
                    <div class="label" for="">Địa chỉ <Span>*</Span></div>
                    <textarea id="txtAddress" name="Address" ref="address" tabindex="3" rows="8" required
                    style="resize:none"
                    @blur="validateData('address')"
                    :class="{required :isActiveClassRequired.address}"
                    v-model="shopData.address"></textarea>
                </div>
                <div class="shopDetails">
                    <div class="shopDetailsColumn">
                    <div class="label" for="">Số điện thoại</div>
                    <input tabindex="4" type="text"
                    v-model="shopData.phoneNumber">
                    </div>
                     <div class="shopDetailsColumn">
                    <div class="label" for="">Mã số thuế</div>
                    <input tabindex="5" class="columnRight"  type="text"
                    v-model="shopData.shopTaxCode">
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
                <button tabindex="11" id="btnSave" class="btnDialog btnSave" v-on:click="editConfirm()"><div class="icon icon-save"></div>Lưu</button>
                </div>
                <div class="btn-footer" style="width: 145px"> 
                <button tabindex="12" id="btnSaveNew" class="btnDialog btnSaveNew" v-on:click="Confirm()"><div class="icon icon-savenew"></div>Lưu và thêm mới</button>
                </div>
                <div class="btn-footer"> 
                <button tabindex="13" id="btnCancel" class="btnDialog btnCancel" v-on:click="close"><div class="icon icon-cancel"></div>Hủy bỏ</button>
                </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
import * as axios from "axios";        
export default {
    
    data() {

        return {
            shopData: {
                shopCode: "",
                shopName: "",
                address: "",
                phoneNumber: "",
                shopTaxCode: "",
            },
            isActiveClassRequired: {
                shopCode: false,
                shopName: false,
                address: false
            },            
        }
    }, 
    props: {
        mode: String,
        shopParentData: Object
    },
    mounted() {
        if (this.mode === "EDIT") {
            this.shopData = this.shopParentData;
        }else{
            this.focusInput();
        }
    },

    methods: {
        /* Đóng dialog */
    close() {
            this.$emit('close');
        },
    focusInput(){
        this.$refs.shopCode.focus();
    },
    btnAddOnClick() {
        /** 
      this.isHide = false;
      */
    },
    btnCancelOnClick() {
      this.$emit('closePopup',true)
    },
    /**
     * Hàm kiểm tra dữ liệu bắt buộc nhập!
     * key: trường thông tin cần validate
     * isActiveClassRequired: trạng thái để bật tắt class required. True: bật, false: tắt
     * <Return>False: trống
     * true: Ok</Return>
     * CreatedBy: DvCuong (20/02/2021)
     */
    validateData(key) {
        if (this.shopData[key] === null || this.shopData[key] === "") {
            console.log(key)
            console.log(this.shopData[key])
            this.isActiveClassRequired[key] = true;
            return false;
        } else {
            this.isActiveClassRequired[key] = false;
            return true;
        }
    },
  

/**
 * Function thêm mới dữ liệu
 * CreatedBy: DvCuong (20/02/2021)
 */
    Confirm : async function(){   
      console.log(this.shopData);

          var self = this;
          //Validate dữ liệu Ok thì mới thực hiện thêm dữ liệu
          if((self.validateData('shopCode') && self.validateData('shopName') && self.validateData('address'))==true){

              try {
                  await axios.post('https://localhost:44333/api/v1/Shop', this.shopData)
                    .then(function (res) {
                        console.log(res);
                        alert("Thêm mới thành công");
                        self.$emit("close"); 
                        })
                    .catch(function (error) {   
                        console.log(error);
                        alert("Thêm mới không thành công");
                        });
                  
              } catch (error) {
                  console.log(error);
              }
          }else{
              alert("Kiểm tra lại định dạng!");
          }



    },
    /**
     * Function thực hiện chỉnh sửa dữ liệu
     * CreatedBy: DvCuong(20/02/2021)
     */
    editConfirm : async function(){
        /* Nếu chưa có shop được chọn đưa ra cảnh báo! */
        if(!this.shopData.shopId){
                alert("Bạn chưa chọn shop chỉnh sửa!")
                this.$emit("close");
                /* Validate các trường dữ liệu bắt buộc, Nếu không trống thì cho phép sửa, trống:đưa ra câu cảnh báo */
        }else if((this.validateData('shopCode') && this.validateData('shopName') && this.validateData('address'))==true){
            try {
                await axios.put('https://localhost:44333/api/v1/Shop', this.shopData)
                .then(function(res){
                    console.log(res);
                    alert("Cập nhật thành công!");
                })
                .catch(function(error){
                    console.log(error);
                    alert("Cập nhật thất bại!");
                })
                this.$emit("update");
                
            } catch (error) {
                console.log (error);
            }
        }else{
            alert("Vui lòng kiểm tra lại định dạng");
        }
    },


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
width: calc(100% - 110px);
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
    width: 85%;
}
</style>