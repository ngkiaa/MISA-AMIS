<template>
    <div ref="popup" class="pop-up" :class="{isHide:isHide}">
        <div class="modal"></div>
        <div class="pop-up-main">
            <div class="pop-up-content">
                <div class="icon-alert"></div>
                <div class="alert">{{this.alertMsg}}</div>
            </div>
            <div class="line"></div>
            <div class="pop-up-footer">
                <button class="btn-cancel" @click="btnCancelOnClick">Không</button>
                <button class="btn-accept" @click="btnAcceptOnClick">Có</button>
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
            employeeId: '',
            alertMsg: '',
        }
    },
    methods: {
        // đóng pop up
        btnCancelOnClick() {
            this.$emit('closePopUp',true);
        },

        // thực hiện nhân viên khỏi hệ thống khi nhấn nút đồng ý xóa
        async btnAcceptOnClick() {
            await axios.delete("http://localhost:56784/api/v1/Employees/" + this.employeeId);
            this.$emit('closePopUp',true);
        },
    },
}
</script>

<style scoped>
@import url("../../style/page/employee/employeepopup.css");
</style>