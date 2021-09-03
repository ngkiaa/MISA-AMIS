<template>
    <div 
        class="employee-dialog"
        title="Thông tin nhân viên"
        :class="{isHide:isHide}"
    >
        <div class="modal"></div>
        <div class="dialog">
            <div class="dialog-header">
                <div class="dialog-title">Thông tin nhân viên</div>
                <label class="checkbox-container">
                    <input type="checkbox" class="checkbox">
                    Là khách hàng
                </label>
                <label class="checkbox-container">
                    <input type="checkbox" class="checkbox">
                    Là nhà cung cấp
                </label>
                <button class="btn-close" @click="btnCancelOnClick"></button>
                <button class="btn-help"></button>
            </div>
            <div class="dialog-content">
                <div class="top-content">
                    <div class="topleft-content">
                        <div style="display:flex">
                            <div style="margin-right: 12px">
                                <label><b>Mã</b> <font color="red">*</font></label>
                                <br>
                                <input type="text" class="text-field" style="width:184px" 
                                    v-model="employee.employeeCode" required
                                    id="txtEmployeeCode"
                                    ref="focus"
                                >
                            </div>
                            <div>
                                <label><b>Tên</b> <font color="red">*</font></label>
                                <br>
                                <input type="text" class="text-field" style="width:242px" 
                                    v-model="employee.fullName" required
                                    id="txtFullName"
                                >
                            </div>
                        </div>
                        <div>
                            <label><b>Đơn vị</b> <font color="red">*</font></label>
                            <br>
                            <select class="select-field" v-model="employee.departmentId">
                                <option value="4e272fc4-7875-78d6-7d32-6a1673ffca7c" selected>PHÒNG NHÂN SỰ</option>
                                <option value="11452b0c-768e-5ff7-0d63-eeb1d8ed8cef">PHÒNG ĐÀO TẠO</option>
                                <option value="142cb08f-7c31-21fa-8e90-67245e8b283e">PHÒNG CÔNG NGHỆ</option>
                                <option value="17120d02-6ab5-3e43-18cb-66948daf6128">PHÒNG MARKETING</option>
                                <option value="469b3ece-744a-45d5-957d-e8c757976496">PHÒNG HÀNH CHÍNH</option>
                            </select>
                        </div>
                        <div>
                            <label><b>Chức danh</b></label>
                            <br>
                            <input type="text" class="text-field" v-model="employee.position">
                        </div>
                    </div>
                    <div class="topright-content">
                        <div style="display:flex">
                            <div style="margin-right: 16px;">
                                <label><b>Ngày sinh</b></label>
                                <br>
                                <input type="date" class="text-field" style="width:184px; height:36px" v-model="employee.dateOfBirth">
                            </div>
                            <div>
                                <label><b>Giới tính</b></label>
                                <br>
                                <div class="radio-field">
                                    <label class="radio-container">
                                        Nam
                                        <input type="radio" name="gender" value="0" v-model="employee.gender">
                                        <span class="checkmark"></span>
                                    </label>
                                    <label class="radio-container">
                                        Nữ
                                        <input type="radio" name="gender" value="1" v-model="employee.gender">
                                        <span class="checkmark"></span>
                                    </label>
                                    <label class="radio-container">
                                        Khác
                                        <input type="radio" name="gender" value="2" v-model="employee.gender">
                                        <span class="checkmark"></span>
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div style="display:flex">
                            <div style="margin-right: 12px">
                                <label><b>Số CMND</b></label>
                                <br>
                                <input type="text" class="text-field" style="width:242px" v-model="employee.identityNumber">
                            </div>
                            <div>
                                <label><b>Ngày cấp</b></label>
                                <br>
                                <input type="date" class="text-field" style="width:184px; height: 36px" v-model="employee.identityDate">
                            </div>
                        </div>
                        <div>
                            <label><b>Nơi cấp</b></label>
                            <br>
                            <input type="text" class="text-field" v-model="employee.identityPlace">
                        </div>
                    </div>
                </div>
                <div class="bottom-content">
                    <div class="navigator">
                        <button class="btn-navigate" :class="{isChosen:hideBankAccount}" @click="btnContactOnClick">Liên hệ</button>
                        <button class="btn-navigate" :class="{isChosen:hideContact}" @click="btnBankAccountOnClick">Tài khoản ngân hàng</button>
                    </div>
                    <div class="information-field">
                        <div class="contact" :class="{isHide:hideContact}">
                            <div>
                                <label><b>Địa chỉ</b></label>
                                <br>
                                <input type="text" class="text-field" style="width: 920px;" v-model="employee.address">
                            </div>
                            <div style="display: flex">
                                <div style="margin-right: 12px;">
                                    <label><b>ĐT di động</b></label>
                                    <br>
                                    <input type="text" class="text-field" style="width: 220px;" v-model="employee.phoneNumber">
                                </div>
                                <div style="margin-right: 12px;">
                                    <label><b>ĐT cố định</b></label>
                                    <br>
                                    <input type="text" class="text-field" style="width: 220px;" v-model="employee.homeNumber">
                                </div>
                                <div>
                                    <label><b>Email</b></label>
                                    <br>
                                    <input type="text" class="text-field" style="width: 220px;" v-model="employee.email">
                                </div>
                            </div>
                        </div>
                        <div class="bank-account" :class="{isHide:hideBankAccount}">
                            <table cellspacing="0">
                                <thead>
                                    <th style="border-left: none; width: 200px">SỐ TÀI KHOẢN</th>
                                    <th style="width: 250px">TÊN NGÂN HÀNG</th>
                                    <th style="width: 200px">CHI NHÁNH</th>
                                    <th style="width: 250px">TỈNH/TP CỦA NGÂN HÀNG</th>
                                    <th style="border-right: none; width: 34px"></th>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td style="border-left: none; width: 200px">
                                            <input type="text" class="table-input" v-model="employee.bankAccountNumber">
                                        </td>
                                        <td style="width: 250px">
                                            <input type="text" class="table-input" v-model="employee.bankName">
                                        </td>
                                        <td style="width: 200px">
                                            <input type="text" class="table-input" v-model="employee.bankBranch">
                                        </td>
                                        <td style="width: 250px">
                                            <input type="text" class="table-input" v-model="employee.bankPlace">
                                        </td>
                                        <td style="border-right: none; width: 34px">
                                            <button class="btn-recycle-bin"></button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <div style="display: flex; margin-top: 12px;">
                                <button class="btn-table" disabled>Thêm dòng</button>
                                <button class="btn-table" disabled>Xóa hết dòng</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="underline"></div>
            <div class="dialog-footer">
                <button class="btn-cancel" @click="btnCancelOnClick">Hủy</button>
                <button class="btn-save" @click="btnSaveOnClick">Cất và thêm</button>
            </div>
        </div>
    </div>
</template>

<script>
import * as axios from 'axios';

export default {
    props: ['isHide'],
    data() {
        return {
            isHidePopUp: true,
            hideContact: false,
            hideBankAccount: true,
            employee: {
                address: null,
                bankAccountNumber: null,
                bankBranch: null,
                bankName: null,
                bankPlace: null,
                dateOfBirth: null,
                departmentId: "4e272fc4-7875-78d6-7d32-6a1673ffca7c",
                departmentName: null,
                email: null,
                employeeCode: "",
                fullName: "",
                gender: null,
                homeNumber: null,
                idEmployee: null,
                identityDate: null,
                identityNumber: null,
                identityPlace: null,
                phoneNumber: null,
                position: null,
            }
        }
    },
    methods: {
        // đóng form khi nhấn nút hủy hoặc x
        btnCancelOnClick() {
            this.$emit('closeDialog',true);
        },

        // chuyển sang phần liên hệ khi nhấn nút liên hệ
        btnContactOnClick() {
            this.hideContact = false;
            this.hideBankAccount = true;
        },

        // chuyển sang phần tài khoản ngân hàng khi nhấn nút tài khoản ngân hàng
        btnBankAccountOnClick() {
            this.hideContact = true;
            this.hideBankAccount = false;
        },

        // đóng pop up thông báo
        closePopUp(value) {
            this.isHidePopUp = value;
        },

        // lấy dữ liệu khách hàng vào các trường khi nhấn nút sửa
        async getData() { 
            var response = await axios.get("http://localhost:56784/api/v1/Employees/" + this.$attrs.value);
            this.employee = response.data[0];
            this.employee.dateOfBirth = response.data[0].dateOfBirth.substring(0, 10);
            this.employee.identityDate = response.data[0].identityDate.substring(0,10);
        },

        getFocus() {
            this.$refs.focus.focus();
            console.log(this.isHide);
        },

        // đưa dữ liệu các trường về ban đầu khi nhấn nút thêm
        resetData() {
            this.employee.employeeCode = this.$attrs.value;
            this.employee.address = null;
            this.employee.bankAccountNumber = null;
            this.employee.bankBranch = null;
            this.employee.bankName = null;
            this.employee.bankPlace = null;
            this.employee.dateOfBirth = null;
            this.employee.departmentId = "4e272fc4-7875-78d6-7d32-6a1673ffca7c";
            this.employee.departmentName = null;
            this.employee.email = null;
            this.employee.fullName = "";
            this.employee.gender = null;
            this.employee.homeNumber = null;
            this.employee.idEmployee = null;
            this.employee.identityDate = null;
            this.employee.identityNumber = null;
            this.employee.identityPlace = null;
            this.employee.phoneNumber = null;
            this.employee.position = null;
        },

        // thực hiện thêm hoặc sửa dữ liệu tùy thuộc vào id của form đồng thời hiển thị thông báo thành công/lỗi
        async btnSaveOnClick() {
            if (this.$attrs.id == "add") {
                await axios.post("http://localhost:56784/api/v1/Employees", this.employee)
                .then((response) => {
                    this.$toast.success(response.data);
                    this.$emit('closeDialog', true);
                }, (error) => {
                    error.response.data.userMsg.forEach(element => {
                        this.$toast.error(element);
                    });
                });
            }
            else {
                await axios.put("http://localhost:56784/api/v1/Employees", this.employee)
                .then((response) => {
                    this.$toast.success(response.data);
                    this.$emit('closeDialog', true);
                }, (error) => {
                    error.response.data.userMsg.forEach(element => {
                        this.$toast.error(element);
                    });
                });
            }
        },
    },
}
</script>

<style scoped>
@import url("../../style/page/employee/employeedialog.css");
</style>