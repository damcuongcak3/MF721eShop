<template>

    <div class="body-content">
        <div class="header-content">
            <div class="title">
                <h2>Danh sách nhân viên</h2>
            </div>
            <div class="addnew">
                <button id="btnAdd" v-on:click="btnAddOnClick" style="border:none">
                <div class="addnew-icon"><img src="@/assets/content/icon/add.png" alt=""></div>
                <div class="addnew-text">Thêm nhân viên</div>
                </button>
            </div>
            <Details @closePopup ="closePopup" :isHide ="isHideParent" />
        </div>
        <div class="filter-bar">
            <div class="form-search">
                    <input class="txt-search" id="txt-search" type="search" placeholder="Tìm kiếm theo Mã, Tên khác" name="gsearch"  />
                    
                </div>
                <div class="form-filter">
                    <select class="dropdown-filter" id="slcDepartment-filter">
                        <option value="1">Phòng ban</option>
                    </select>
                </div>
                <div class="form-filter">
                    <select class="dropdown-filter" id="slcTitle-filter">
                       <option value="1">Vị trí</option>
                    </select>
                </div>
                <div class="form-reload">
                    <button class="btn-reload" id="btnReload" style="border:1px solid #ccc"><img src="@/assets/content/icon/refresh.png" alt=""></button>
                </div>
        </div>
        <div class="table-content">
            <table>
                <thead>
                    <tr style=" height: 50px">
                            <th>Mã nhân viên</th>
                            <th style="width: 160px">Họ và tên</th>
                            <th style="width: 80px">Giới tính</th>
                            <th style="width: 120px">Ngày sinh</th>
                            <th style="width: 120px">Điện thoại</th>
                            <th style="width: 260px">Email</th>
                            <th style="width: 120px">Chức vụ</th>
                            <th style=" width: 110px">Phòng ban</th>
                            <th style="width: 130px">Mức lương cơ bản</th>
                            <th style=" width: 119px">Tình trạng công việc</th>
                        </tr>
                </thead>
                <tbody>
                    <tr v-for="emp in employees"
                    :key="emp.EmployeeId"
                    @click="selectedEmployee = emp">

                    <td v-for="item in emp" v-bind:key="item">{{item}} </td>
                    </tr>
                    </tbody>
            </table>
        </div>
        <div class="footer-content">
            <div>Hiển thị 1-10/1000 Khách hàng</div>
                <div class="page-navigation">

                        <div class="icon_page icon_firstpage"><img src="@/assets/content/icon/btn-firstpage.svg" alt=""></div>
                        <div class="icon_page icon_prevpage"><img src="@/assets/content/icon/btn-prev-page.svg" alt=""></div>

                        <div class="page-number" style="background-color: #019160">1</div>
                        <div class="page-number">2</div>
                        <div class="page-number">3</div>
                        <div class="page-number">4</div>

                        <div class="icon_page icon_nextpage"><img src="@/assets/content/icon/btn-lastpage.svg" alt=""></div>
                        <div class="icon_page icon_lastpage"><img src="@/assets/content/icon/btn-next-page.svg" alt=""></div>
                </div>
                <div class="page-number2">10 khách hàng/trang</div>
            </div>
</div>
</template>
<script>
import Details from './EmployeeDetails'
export default {
  name: "Employees",
  components: {
      Details
  },
  methods: {
      btnAddOnClick(){
        this.isHideParent = false;
        console.log(this);
      },
      closePopup(value){
          this.isHideParent = value;
      }
  },
  data() {
    return {
      isHideParent: true,  
      selectedEmployee: {
        EmployeeId: 1,
        FullName: "Nguyễn Văn Mạnh",
      },
      employees: [
        {
          EmployeeId: 1,
          FullName: "Nguyễn Văn Mạnh",
        },
        {
          EmployeeId: 2,
          FullName: "Nguyễn Văn Mạnh2",
        },
        {
          EmployeeId: 3,
          FullName: "Nguyễn Văn Mạnh3",
        },
      ],
    };
  },

};
</script>
<style scoped>

.body-content{
    padding: 15px 0px 0px 15px;

}
.header-content{
    width: 100%;
    height: 50px;
    display: flex;
    position: relative;
}
.addnew{
    position: absolute;
    right: 10px;
    top: 10px;
}
#btnAdd{
    display: flex;
    width: 150px;
    height: 40px;
    align-items: center;
    background-color: #019160;
    color: #fff;
    border-color: #019160;
    border-radius: 4px;
}
.addnew-icon{
    margin-left: 5px;
}
.addnew-text{
    margin-left: 5px;
    width: auto;
}
.paging-bar{
    height: 50px;
}
.filter-bar{
    width: 100%;
    height: 50px;
    display: flex;
    align-items: center;
    margin-bottom: 10px;
}
.form-search{
    margin-right: 10px;
}
.form-filter{
    height: 35px;
    width: 170px;
    margin-right: 10px;
}
.form-filter .dropdown-filter{
    border-radius: 5px;
    height: 100%;
    border: 1px solid #ccc;
    width: 100%;
}
.form-reload{
    position: absolute;
    right: 10px;
    width: 40px;
    height: 35px;

}

</style>