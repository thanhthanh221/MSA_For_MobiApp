import { StyleSheet, Text, View, Image, TouchableOpacity } from 'react-native'
import React from 'react'


import AuthLayout from './AuthLayout'
import { COLORS, FONTS, icons, images, SIZES } from '../../constants'
import FormInput from '../../components/FormInput'
import { utils } from '../../utils/index'
import CustomSwitch from '../../components/CustomSwitch'
import TextButton from '../../components/TextButton'

const ForgotPassword = ({navigation}) => {
    const [email, setEmail] = React.useState("");
    const [emailError, setEmailError] = React.useState("");

    const isEnableForgotPassword = () => {
        return email != '' && emailError == ''
    }

    return (
        <AuthLayout
            title='Lấy lại mật khẩu'
            subtitle='Nhập Email - Số điện thoại của bạn'
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
                {/* Footer */}
                <View
                    style={{
                        marginTop: 400
                    }}
                >
                    <TextButton
                        lable={'Lấy lại mật khẩu...'}
                        buttonContainerStyle={{
                            height: 50,
                            alignItem: 'center',
                            backgroundColor: COLORS.primary,
                            borderRadius: SIZES.radius
                        }}
                        lableStyle={{
                            color: COLORS.white,
                            ...FONTS.h3
                        }}
                        onPress={() => navigation.navigate('Otp')}
                    />
                </View>
            </View>
        </AuthLayout>
    )
}

export default ForgotPassword

const styles = StyleSheet.create({})