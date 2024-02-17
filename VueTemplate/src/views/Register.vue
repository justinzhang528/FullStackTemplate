<template>
    <div class="register">
        <div class="box">
            <h2>Register New User</h2>
            <el-form ref="formRef" :model="validateForm" :rules="inputRules" label-width="140px" class="demo-ruleForm">

                <el-form-item label="Email" prop="email">
                    <el-input type="text" v-model="validateForm.email" />
                </el-form-item>

                <el-form-item label="Password" prop="password">
                    <el-input type="password" v-model="validateForm.password" />
                </el-form-item>

                <el-form-item label="Confirm Password" prop="confirmPassword">
                    <el-input type="password" v-model="validateForm.confirmPassword" />
                </el-form-item>

                <el-form-item label="Phone" prop="phone">
                    <el-input type="phone" v-model="validateForm.phone" />
                </el-form-item>

                <el-form-item label="Address" prop="address">
                    <el-input type="address" v-model="validateForm.address" />
                </el-form-item>

                <el-form-item>
                    <el-button type="primary" @click="submitForm(formRef)">Submit</el-button>
                    <el-button @click="resetForm(formRef)">Reset</el-button>
                    <el-button type="danger" link @click="goToLoginPage">Already have account? Login now!</el-button>
                </el-form-item>

            </el-form>
        </div>
    </div>
</template>

<script lang="ts" setup>
    import { reactive, ref } from 'vue'
    import type { FormInstance } from 'element-plus'
    import { ElNotification } from 'element-plus'
    import { $post } from '@/utils/request';
    import router from '@/router';

    const formRef = ref<FormInstance>()

    const validateForm = reactive({
        email: '',
        password: '',
        confirmPassword: '',
        phone: '',
        address: '',
    })

    const validateConfirmPassword = (rule: any, value: string, callback: Function) => {
        if (value !== validateForm.password) {
            callback(new Error('The two passwords do not match'));
        } else {
            callback();
        }
    }

    const inputRules = {
        email: [
            {
                required: true,
                message: 'Please input email address',
                trigger: 'blur',
            },
            {
                type: 'email',
                message: 'Please input correct email address',
                trigger: ['blur', 'change'],
            },
        ],
        password: [
            {
                required: true,
                message: 'Please input password',
                trigger: 'blur',
            },
            {
                min: 6,
                message: 'Password length must be at least 6 characters',
                trigger: 'blur',
            }
        ],
        confirmPassword: [
            {
                required: true,
                message: 'Please input password',
                trigger: 'blur',
            },
            {
                validator: validateConfirmPassword,
                trigger: 'blur',
            }
        ],
        phone: [
            {
                required: true,
                message: 'Please input phone',
                trigger: 'blur',
            }
        ],
        address: [
            {
                required: true,
                message: 'Please input address',
                trigger: 'blur',
            }
        ],
    }

    const alert = (title:string,message:string,type:string) => {
        ElNotification({
            title: title,
            message: message,
            type: type,
        })
    }

    const submitForm = (formEl: FormInstance | undefined) => {
        if (!formEl) return
        formEl.validate((valid) => {
            if (valid) {
                $post('/Admin/Register', validateForm)
                .then((response) => {
                    if(response.data.errorCode === 0){
                        alert('Success','Register Success','success')
                        router.push('/login')
                    }else{
                        alert('Warning',response.data.errorMessage,'warning')
                    }
                })
            }
        })
    }

    const resetForm = (formEl: FormInstance | undefined) => {
        if (!formEl) return
        formEl.resetFields()
    }

    const goToLoginPage = () => {
        router.push('/login')
    }
</script>

<style scoped lang="scss">
.register{
    width: 100vw;
    height: 100vh;
    background: white;
    display: flex;
    justify-self: center;
    align-items: center;
    background-image: url(../images/background.png);
    background-size: cover;
    .box{
        width: 600px;
        margin: 0 auto;
        padding: 20px;
        border-radius: 5px;
        box-shadow: 0 0 10px rgba(0,0,0,.5);
        background: white;
        h2{
            font-size: 20px;
            text-align: center;
            margin-bottom: 20px;
        }
    }
}
</style>