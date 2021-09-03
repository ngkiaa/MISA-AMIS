<template>
    <div class="employee-content">
        <div class="content-header">
            <div class="title">
                <div class="title-name">Nhân viên</div>
                <a href="" class="category-link">Tất cả danh mục</a>
            </div>
            <button class="btn-add" @click="btnAddOnClick">Thêm</button>
        </div>
        <div class="main-content">
            <div class="filter">
                <input type="text" class="text-box" placeholder="Tìm theo mã, tên nhân viên" @keyup.enter="searchEmployee" v-model="searchKey">
                <div class="icon-search"></div>
            </div>
            <div class="employee-grid">
                <table cellspacing="0">
                    <thead>
                        <th style="border-left: none; max-width: 150px">MÃ NHÂN VIÊN</th>
                        <th style="max-width:150px">TÊN NHÂN VIÊN</th>
                        <th style="max-width:200px">CHỨC DANH</th>
                        <th style="max-width:200px">TÊN ĐƠN VỊ</th>
                        <th style="max-width:200px">SỐ TÀI KHOẢN</th>
                        <th style="max-width:150px">TÊN NGÂN HÀNG</th>
                        <th style="max-width:150px">TRẠNG THÁI</th>
                        <th style="max-width:150px">CHI NHÁNH</th>
                        <th style="max-width:100px">CHỨC NĂNG</th>
                    </thead>
                    <tbody>
                        <tr
                            v-for="(employee, index) in employees" :key="index"
                        >
                            <td style="border-left: none; max-width:150px">{{employee.employeeCode}}</td>
                            <td style="max-width:150px">{{employee.fullName}}</td>
                            <td style="max-width:200px">{{employee.position}}</td>
                            <td style="max-width:200px">{{employee.departmentName}}</td>
                            <td style="max-width:200px">{{employee.bankAccountNumber}}</td>
                            <td style="max-width:150px">{{employee.bankName}}</td>
                            <td style="max-width:150px">Đang sử dụng</td>
                            <td style="max-width:150px">{{employee.bankBranch}}</td>
                            <td style="max-width:100px; display:flex; align-items: center; justify-content:center; overflow: visible">
                                <button class="btn-fix" :id="employee.employeeId" @click="btnUpdateOnClick(employee.employeeId)">Sửa</button>
                                <div class="dropdown">
                                    <button class="btn-drop"></button>
                                    <div class="dropdown-content">
                                        <button class="dropdown-option" disabled>Nhân bản</button>
                                        <br>
                                        <button class="dropdown-option delete-option" @click="btnDeleteOnClick(employee.employeeId, employee.employeeCode)">Xoá</button>
                                        <br>
                                        <button class="dropdown-option" disabled>Ngừng sử dụng</button>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="paging-bar">
                <div class="left-bar">Tổng số: <b>200</b> bản ghi</div>
                <div class="right-bar">
                    <select class="selector">
                        <option value="">15 bản ghi trên 1 trang</option>
                    </select>
                    <button class="btn-number">Trước</button>
                    <button class="btn-number">1</button>
                    <button class="btn-number">2</button>
                    <button class="btn-number">3</button>
                    <button class="btn-number">4</button>
                    <button class="btn-number">Sau</button>
                </div>
            </div>
        </div>
        <Dialog @closeDialog="closeDialog" :value="this.dialogValue" :id="this.dialogId" :isHide="isHideDialog"/>
        <PopUp @closePopUp="closePopUp" :isHide="isHidePopUp"/>
    </div>
</template>

<script>
import * as axios from "axios";
import Dialog from './EmployeeDialog.vue';
import PopUp from './EmployeePopUp.vue';

export default {
    name: "Employees",
    components: {
        Dialog,
        PopUp
    },
    data() {
        return {
            employees: [],
            isHideDialog: true,
            isHidePopUp: true,
            searchKey: '',
            dialogValue: '',
            dialogId: '',
        }
    },
    methods: {
        // hiển thị form để thêm thông tin nhân viên khi nhấn nút thêm
        async btnAddOnClick() {
            this.dialogId = 'add';
            await this.getMaxEmployeeCode();
            this.$children[0].resetData();
            await this.openDialog();
            this.$children[0].getFocus();
        },

        // hiển thị form thông tin nhân viên khi nhấn nút sửa
        async btnUpdateOnClick(value) {
            this.dialogId = 'update';
            await this.getUpdateId(value);
            await this.$children[0].getData();
            await this.openDialog();
            this.$children[0].getFocus();
        },

        // hiển thị pop up thông báo khi nhấn nút xóa
        btnDeleteOnClick(id, code) {
            this.isHidePopUp = false;
            this.$children[1].alertMsg = "Bạn có muốn xóa nhân viên " + code + " không?";
            this.$children[1].employeeId = id;
        },

        openDialog() {
            this.isHideDialog = false;
        },

        // đóng pop up thông báo nếu value = true
        closePopUp(value) {
            this.isHidePopUp = value;
            this.loadData();
        },

        // đóng form nhân viên nếu value=true
        closeDialog(value) {
            this.isHideDialog = value;
            this.loadData();
        },

        // lấy dữ liệu
        async loadData() {
            const response = await axios.get("http://localhost:56784/api/v1/Employees");
            this.employees = response.data;
        },

        // tìm kiếm nhân viên theo tên hoặc mã
        async searchEmployee() {
            if (this.searchKey != null && this.searchKey != "")
            {
                const response = await axios.get("http://localhost:56784/api/v1/Employees/search?searchKey=" + this.searchKey);
                this.employees = response.data;
            }
            else
            {
                this.loadData();
            }
        },

        // lấy mã nhân viên lớn nhất để hiển thị lên form khi thêm
        async getMaxEmployeeCode() {
            var response = await axios.get("http://localhost:56784/api/v1/Employees");
            var codes = [];
            var maxCode = 0;
            response.data.forEach(element => {
                codes.push(element.employeeCode);
            });
            codes.forEach(element => {
                var num = element.substring(2);
                if (num >= maxCode) {
                    maxCode = Number(num) + 1;
                }
            });
            this.dialogValue = 'NV' + maxCode;
        },

        // lấy id nhân viên cần update rồi lưu vào value của dialog
        getUpdateId(value) {
            this.dialogValue = value;
        }
    },

    async created() {
        this.loadData();
    }
}
</script>

<style scoped>
@import url("../../style/page/employee/employeelist.css");
</style>