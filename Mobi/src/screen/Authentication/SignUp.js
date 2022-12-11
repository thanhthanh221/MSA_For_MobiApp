import { StyleSheet, Text, View, Image, TouchableOpacity } from 'react-native'
import React from 'react'


import AuthLayout from './AuthLayout'
import { COLORS, FONTS, icons, images, SIZES } from '../../constants'
import FormInput from '../../components/FormInput'
import { utils } from '../../utils/index'
import CustomSwitch from '../../components/CustomSwitch'
import TextButton from '../../components/TextButton'
import TextIconButton from '../../components/TextIconButton'

const SignUp = ({ navigation }) => {
    const [email, setEmail] = React.useState("");
    const [emailError, setEmailError] = React.useState("");

    const [userName, setUserName] = React.useState("");
    const [userNameError, setUserNameError] = React.useState('')

    const [password, setPassword] = React.useState("");
    const [passWordError, setPasswordError] = React.useState("");
    const [showPass, setShowPass] = React.useState(false);

    const isEnableSignUp = () => {
        return email != '' && password != ''
            && emailError == '' && passWordError == ''
            && userName != '' && userNameError == ''
    }

    return (
        <AuthLayout
            title={'Đăng kí'}
            subtitle={'Chào mừng bạn đến với cửa hàng chúng tôi'}
        >
            <View
                style={{
                    marginTop: SIZES.padding,
                    flex: 1
                }}
            >

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

                {/* UserName */}
                <FormInput
                    lable='Tên tài khoản'
                    onChange={(value) => {
                        setUserName(value)
                    }}
                    appendComponent={
                        <View
                            style={{
                                justifyContent: 'center',
                            }}
                        >
                            <Image
                                source={
                                    userName == "" || (userName != "" && userNameError == '')
                                        ? icons.correct : icons.cross
                                }
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: userName == "" || (userName != "" && userNameError == '')
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

                {/* Đăng kí */}
                <TextButton
                    lable='Đăng Kí ...'
                    buttonContainerStyle={{
                        height: 55,
                        alignItems: 'center',
                        marginTop: SIZES.padding,
                        backgroundColor: isEnableSignUp() ? COLORS.primary : COLORS.transparentPrimray,
                        borderRadius: SIZES.radius,
                    }}
                    lableStyle={{
                        color: COLORS.white,
                        ...FONTS.h3
                    }}
                    onPress={() => navigation.navigate('Otp')}
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
                            marginRight: 5
                        }}
                    >
                        Bạn có tài khoản?
                    </Text>

                    {/* Tải nhập */}
                    <TextButton
                        lable='Đăng nhập'
                        buttonContainerStyle={{
                            backgroundColor: null,
                        }}
                        lableStyle={{
                            color: COLORS.primary,
                            ...FONTS.body3
                        }}
                        onPress={() => navigation.navigate('SignIn')}
                    />
                </View>

                {/* Footer */}
                <View
                    style={{
                        marginTop: 60

                    }}
                >
                    {/* FaceBook */}
                    <TextIconButton
                        containerStyle={{
                            height: 50,
                            backgroundColor: COLORS.blue,
                            alignItems: 'center',
                            borderRadius: SIZES.radius
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

export default SignUp

const styles = StyleSheet.create({})