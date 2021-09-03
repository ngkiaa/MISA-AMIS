<template>
    <div class="content">
        <Employees/>
    </div>
</template>

<script>
import Employees from '../../views/employee/EmployeeList.vue'

export default {
    name: 'Content',
    components: {
        Employees,
    }
}
</script>

<style scoped>
@import url("../../style/layout/content.css");
</style>