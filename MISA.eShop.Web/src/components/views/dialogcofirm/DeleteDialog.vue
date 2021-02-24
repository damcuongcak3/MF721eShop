<template>
        <div  class="dialog-detail" title="Xóa dữ liệu" v-if="active">
            <div class="dialog-modal"></div>
            <div class="content-dialog">
            <div class="dialog-header">
                <div class="dialog-header-title">Xóa dữ liệu</div>
                <div class="dialog-header-icon">
                    <button tabindex="3" id="btnCancel" @click="dialogDropClick">X</button>
                </div>
            </div>
            <div class="dialog-body">
                <div class="icon-dialog"><img style="height: 100%; width: 100%" src="@/assets/content/img/icon-question.png" alt=""></div>
                <div class="text-dialog">Bạn có chắc chắn muốn xóa {{shopParentData.shopCode}} khỏi danh sách cửa hàng.</div>
            </div>
            <div class="dialog-footer">
                <div class="dialog-button">
                 <div class="btn-footer">
                     <button tabindex=1 id="btnConfirmDelete" class="btnDialog btnConfirmDelete" @click="deleteData(shopParentData.shopId)"><div class="btnCfDelete"></div>Xóa</button>
                     </div>   
                <div class="btn-footer"> 
                <button tabindex="2" id="btnCancel" class="btnDialog btnCancel" @click="dialogDropClick"><div class="icon icon-cancel"></div>Hủy bỏ</button>
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
            visible:false,

        }
        
    },
props:{
    active:{type: Boolean, default: false},
    shopParentData: Object
},
    methods: {
        dialogDropClick(){
            this.$emit("update:active", false);
        },
        deleteData: async function(shopId){
            var self = this;
            console.log(shopId);
            try {
                await axios.delete('https://localhost:44333/api/v1/Shop?shopId='+shopId)
          .then(function(res){
              console.log(res);
              self.$emit("deleted")
          }).catch(function(error){
              console.log(error)
          });
                
            } catch (error) {
                console.log(error);
            }
        }
    },
    
}
</script>
<style lang="scss" scoped>
.content-dialog{
    width: 500px;
    height: 200px;
    text-align: left;
    position: fixed;
    border-radius: 5px;
    background-color: #fff;
    left: calc(50% - 250px);
    top: calc(50% - 100px);
}
.dialog-body{
    display: flex;
    align-items: center;
    padding-left: 40px;
    padding-right: 40px;
    margin-top: 30px;
}
.icon-dialog{
    height: 50px;
    width: 50px;
    background-color: #fff;
}

</style>