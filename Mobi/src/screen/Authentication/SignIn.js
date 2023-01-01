import { StyleSheet, Text, View, Image, TouchableOpacity, Alert } from 'react-native'
import React from 'react'


import AuthLayout from './AuthLayout'
import { COLORS, FONTS, icons, images, SIZES } from '../../constants'
import FormInput from '../../components/FormInput'
import { RequestAxios, utils } from '../../utils/index'
import CustomSwitch from '../../components/CustomSwitch'
import TextButton from '../../components/TextButton'
import TextIconButton from '../../components/TextIconButton'
import AsyncStorage from '@react-native-async-storage/async-storage'



const SignIn = ({ navigation }) => {

    const [email, setEmail] = React.useState("");
    const [password, setPassword] = React.useState("");

    // Error
    const [emailError, setEmailError] = React.useState("");
    const [passWordError, setPasswordError] = React.useState("")

    // showPass
    const [showPass, setShowPass] = React.useState(false)

    // save
    const [saveMe, setSaveMe] = React.useState(false);

    const isEnableSignIn = () => {
        return email != '' && password != '' && emailError == '' && passWordError == ''
    }

    const LoginAsync = async () => {
        try {
            const response = await RequestAxios.post('/IdentityService/Account/Login',
                {
                    email: email,
                    password: password
                })
            
            if (response.status == 200) {
                await AsyncStorage.setItem('Token', response.data.token);
                await AsyncStorage.setItem('userId', response.data.id);
                await AsyncStorage.setItem('userName', response.data.userName);
                navigation.navigate('MyAccount')
            }
        } catch (error) {
            console.log(error);
            Alert.alert("Tên tài khoản hoặc mật khẩu không chính xác!");
        }
    }

    return (
        <AuthLayout
            title={'Đăng nhập'}
            subtitle={'Chào mừng bạn đến với cửa hàng chúng tôi'}
        >
            <View
                style={{
                    marginTop: SIZES.padding,
                    flex: 1
                }}
            >
                {/* Font Input */}

                {/* Email */}
                <FormInput
                    lable='Email'
                    keyboardType='email-address'
                    autoCompleteType='email'
                    onChange={(value) => {
                        utils.validateEmail(value, setEmailError)
                        setEmail(value)
                    }}
                    errorMsg={emailError}
                    appendComponent={
                        <View
                            style={{
                                justifyContent: 'center',
                            }}
                        >
                            <Image
                                source={
                                    email == "" || (email != "" && emailError == '')
                                        ? icons.correct : icons.cross
                                }
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: email == "" || (email != "" && emailError == '')
                                        ? COLORS.green : COLORS.red
                                }}
                            />

                        </View>
                    }
                />

                {/* Mật khẩu */}
                <FormInput
                    lable='Mật khẩu'
                    secureTextEntry={!showPass}
                    autoCompleteType='password'
                    onChange={(value) => {
                        setPassword(value)
                        utils.validatePassword(value, setPasswordError)
                    }}
                    errorMsg={passWordError}
                    containerStyle={{
                        marginTop: SIZES.base
                    }}
                    appendComponent={
                        <TouchableOpacity
                            style={{
                                width: 40,
                                alignItems: 'flex-end',
                                justifyContent: 'center',
                            }}
                            onPress={() => setShowPass(!showPass)}
                        >
                            <Image
                                source={!showPass ? icons.eye : icons.eye_close}
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: COLORS.gray
                                }}
                            />

                        </TouchableOpacity>
                    }
                />


                {/* Lưu tài khoản và mật khẩu */}
                <View
                    style={{
                        flexDirection: 'row',
                        marginTop: SIZES.radius,
                        justifyContent: 'space-between',
                        marginBottom: 10
                    }}
                >
                    <CustomSwitch
                        value={saveMe}
                        onChange={(value) => setSaveMe(value)}
                    />

                    {/* Quên mật khẩu */}
                    <TextButton
                        lable='Quên mật khẩu ?'
                        buttonContainerStyle={{
                            backgroundColor: null
                        }}
                        lableStyle={{
                            ...FONTS.body4,
                            color: COLORS.gray
                        }}
                        onPress={() => navigation.navigate('ForgotPassword')}
                    />
                </View>

                {/* Đăng nhập */}
                <TextButton
                    lable='Đăng nhập ...'
                    disabled={!isEnableSignIn()}
                    buttonContainerStyle={{
                        height: 55,
                        alignItems: 'center',
                        marginTop: SIZES.padding,
                        backgroundColor: isEnableSignIn() ? COLORS.primary : COLORS.transparentPrimray,
                        borderRadius: SIZES.radius,
                    }}
                    lableStyle={{
                        color: COLORS.white,
                        ...FONTS.h3
                    }}
                    onPress={() => LoginAsync()}
                />

                {/* Sign Up */}
                <View
                    style={{
                        flexDirection: 'row',
                        marginTop: SIZES.radius,
                        justifyContent: 'center'
                    }}
                >
                    <Text
                        style={{
                            color: COLORS.darkGray,
                            ...FONTS.body3,
                            marginTop: 10,
                            marginRight: 5
                        }}
                    >
                        Không có tài khoản?
                    </Text>

                    {/* Tải nhập */}
                    <TextButton
                        lable='Tạo tài khoản'
                        buttonContainerStyle={{
                            backgroundColor: null,
                            marginTop: 10
                        }}
                        lableStyle={{
                            color: COLORS.primary,
                            ...FONTS.body3
                        }}
                        onPress={() => navigation.navigate('SignUp')}
                    />
                </View>

                {/* Footer */}
                <View
                    style={{
                        marginTop: 30
                    }}
                >
                    {/* FaceBook */}
                    <TextIconButton
                        containerStyle={{
                            height: 50,
                            backgroundColor: COLORS.blue,
                            alignItems: 'center',
                            borderRadius: SIZES.radius,
                        }}
                        iconPosition='LEFT'
                        icon={icons.fb}
                        iconStyle={{
                            width: 20,
                            height: 20
                        }}
                        label='Tiếp tục với Facebook'
                        lableStyle={{
                            color: COLORS.white,
                            ...FONTS.h3,
                            marginLeft: SIZES.base
                        }}
                        onPress={() => { console.log('Đăng nhập với facebook') }}
                    />

                    {/* Google */}
                    <TextIconButton
                        containerStyle={{
                            height: 50,
                            backgroundColor: COLORS.lightGray1,
                            alignItems: 'center',
                            borderRadius: SIZES.radius,
                            marginTop: SIZES.radius
                        }}
                        iconPosition='LEFT'
                        icon={icons.google}
                        iconStyle={{
                            width: 20,
                            height: 20
                        }}
                        label='Tiếp tục với Google'
                        lableStyle={{
                            color: COLORS.black,
                            ...FONTS.h3,
                            marginLeft: SIZES.base
                        }}
                        onPress={() => { console.log('Đăng nhập với Google') }}
                    />
                </View>
            </View>
        </AuthLayout>
    )
}

export default SignIn

const styles = StyleSheet.create({

})