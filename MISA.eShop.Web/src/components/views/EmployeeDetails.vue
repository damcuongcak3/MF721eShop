<template>
    <div  class="dialog-detail" title="Thông tin nhân viên" :class="{ isHide: isHide }">
        <div class="dialog-modal"></div>
        <div class="content-dialog">
            <div class="dialog-header">
                <div class="dialog-header-title">THÔNG TIN NHÂN VIÊN</div>
                <div class="dialog-header-icon">
                    <button v-on:click="btnCancelOnClick">X</button>
                </div>
            </div>
            <div class="dialog-body">
                <div class="dialog-body-avatar">
                    <div class="avatarDiv">
                        <div class="caption">
                            <p>
                                <input type="button" class="btnAvatar" onclick="showImagePreview();" value="Choose Avatar" />
                            </p>
                        </div>
                        <img alt="Avatar" src="@/assets/content/img/default-avatar.jpg" class="img-rounded" width="128" height="128" id="imgAvatar" />
                        <input id="iUserAvatar" type="file" style="height:0; width:0; visibility:hidden" />
                        <div>Vui lòng chọn ảnh có định dạng (.jpg, .jpeg, .png)</div>

                    </div>
                </div>
                <div class="dialog-body-profile">
                    <form>
                        <div class="inforA">
                            <h3>A. THÔNG TIN CHUNG:</h3>
                            <div class="green-space"></div>
                            <label hidden id="txtemployeeID"></label>
                            <div class="infor-content">
                                <div class="infor-left-column">
                                    <div class="infor-text">
                                        <label>Mã nhân viên (<span>*</span>)</label>
                                        <input type="text" ref="EmployeeCode" id="txtEmployeeCode" placeholder="VD:NV0001" required tabindex="1" />
                                    </div>

                                    <div class="infor-text">
                                        <label>Ngày sinh </label>
                                        <input type="date" id="txtDateOfBirth"  tabindex="3" />
                                    </div>
                                    <div class="infor-text">
                                        <label>Số CMTND/Căn cước(<span>*</span>)</label>
                                        <input type="text" id="txtCmt" placeholder="9-12 chữ số. VD:095256119" required tabindex="5" />
                                    </div>
                                    <div class="infor-text">
                                        <label>Nơi cấp</label>
                                        <input type="text" id="txtSupplyAdd" placeholder="Tỉnh thành" tabindex="7" />
                                    </div>
                                    <div class="infor-text">
                                        <label>Email (<span>*</span>)</label>
                                        <input type="text" id="txtEmail" placeholder="VD: example@gmail.com" required tabindex="8" />
                                    </div>
                                </div>
                                <div class="infor-right-column">
                                    <div class="infor-text">
                                        <label>Họ và tên (<span>*</span>)</label>
                                        <input type="text" id="txtEmployeeName" placeholder="Bắt buộc (Tối đa 50 ký tự)"  required tabindex="2" />
                                    </div>

                                    <div class="infor-text">
                                        <label>Giới tính </label>
                                        <select tabindex="4" id="slcGender">
                                            <option value="">Giới Tính</option>
                                            <option value="1">Nam</option>
                                            <option value="0">Nữ</option>
                                            <option value="2">Khác</option>
                                        </select>
                                    </div>
                                    <div class="infor-text">
                                        <label>Ngày cấp</label>
                                        <input type="date"  id="txtSupplyDate" tabindex="6" />
                                    </div>
                                    <div class="infor-text">

                                    </div>
                                    <div class="infor-text">
                                        <label>Số điện thoại (<span>*</span>)</label>
                                        <input type="text"  id="txtPhoneNumber" placeholder="(+84) 123 456" required tabindex="9" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="inforB">
                            <h3>B. THÔNG TIN CÔNG VIỆC:</h3>
                            <div class="green-space"></div>
                            <div class="infor-content">
                                <div class="infor-left-column">
                                    <div class="infor-text">
                                        <label>Vị trí</label>
                                        <select tabindex="10"  id="slcTitle">
                                            <option></option>
                                            
                                        </select>
                                    </div>

                                    <div class="infor-text">
                                        <label>Mã số thuế cá nhân</label>
                                        <input type="text"  id="txtTaxCode" tabindex="12" />
                                    </div>
                                    <div class="infor-text">
                                        <label>Ngày gia nhập công ty</label>
                                        <input type="date"  id="txtApplyDate" tabindex="14" />
                                    </div>
                                </div>
                                <div class="infor-right-column">
                                    <div class="infor-text">
                                        <label>Phòng ban</label>
                                        <select tabindex="11"  id="slcDepartment">
                                            <option value=""></option>
                                        </select>
                                    </div>

                                    <div class="infor-text">
                                        <label>Mức lương cơ bản </label>
                                        <input type="text" id="txtSalary" tabindex="13" />
                                    </div>
                                    <div class="infor-text">
                                        <label>Tình trạng công việc</label>
                                        <select tabindex="15"  id="slcStatus">
                                            <option value=""></option>
                                            <option value=" Đang làm việc">Đang làm việc</option>
                                            <option value="Đã nghỉ việc">Đã nghỉ việc</option>
                                        </select>
                                    </div>

                                </div>
                            </div>
                        </div>

                    </form>
                </div>
            </div>
            <div class="dialog-footer">
                <div class="dialog-button">
                <div class="btn-footer"> 
                <button id="btnCancel" class="btnDefault" v-on:click="btnCancelOnClick">Hủy</button>
                </div>
                <div class="btn-footer">
                <button id="btnSave" class="btnGreen">Lưu</button>
                </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>
        
export default {
    
    props: ['isHide'],
    methods: {
    setFocus(){
        this.$refs.EmployeeCode.focus();
    },
    btnAddOnClick() {
      // this.isHide = false;
    },
    btnCancelOnClick() {
      this.$emit('closePopup',true)
      // this.isHide = true;
    }  
},
data() {
    return {
        
    }
}, 
}

</script>
<style scoped>
.dialog-modal{
    position: fixed;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    background-color: black;
    opacity: 0.4;
}
.content-dialog{
    position: fixed;
    border-radius: 5px;
    width: 700px;
    height: 725px;
    background-color: #fff;
    left: calc(50% - 350px);
    top: calc(50% - 350px);
}
.dialog-header{
    border-top-left-radius: 5px;
    border-top-right-radius: 5px;
    width: 100%;
    position: relative;
    height: 27px;
    background-color: #ccc;
    padding-left: 16px;
    display: flex;
    font-size: 18px;
    align-items: center;
}
.dialog-header-icon{
    position: absolute;
    right: 5px;
}
.dialog-body{
    margin-top: 10px;
    display: flex;
    padding-left: 10px;
    padding-right: 10px;
}
.dialog-body-avatar{
    width: 30%;
}
.dialog-body-profile{
    width: 70%;
}
.green-space {
    margin-top: -10px;
    height: 6px;
    width: 110px;
    background-color: #019160;
    margin-bottom: 10px;
}
.infor-content {
    display: flex;
}
.infor-left-column{
    width: 50%;
}
.infor-right-column{
    width: 50%;
}
.infor-text {
    margin-bottom: 15px;
    height: 50px;
    display: grid;
    margin-right: 10px;
}
.dialog-footer{
    width: 100%;
    height: 50px;
    background-color: #ccc;
    position: absolute;
    bottom: 0;
    border-bottom-left-radius: 5px;
    border-bottom-right-radius: 5px;
    align-items: center;
    display: flex;

    float: right;
    right: 0px;
}
.dialog-button{
    position: absolute;
    display: flex;
    right: 10px;
}
.btn-footer{
    width: 80px;
    height: 30px;
    margin-right: 10px;
}
.isHide{
    display: none;
}
img{
    border: 1px solid #ccc;
    border-radius: 50%;
    width: 150px;
    height: 150px;
}
h3{
    text-align: left;
}
label{
    margin-bottom: 5px;
}
span{
    color: rgb(255, 0, 0);
}
.infor-content{
    text-align: left;
}

</style>