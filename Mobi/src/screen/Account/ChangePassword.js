import { StyleSheet, Text, View, TouchableOpacity, Image, Alert } from 'react-native'
import React from 'react'
import { FormInput, Header, IconButton, TextIconButton } from '../../components'
import { COLORS, FONTS, SIZES, icons } from '../../constants'
import { RequestAxios, utils } from '../../utils'
import AsyncStorage from '@react-native-async-storage/async-storage'

const ChangePassword = ({ navigation }) => {
    const [oldPassword, setOldPassword] = React.useState('');
    const [newPassword, setNewPassword] = React.useState('');
    const [confirmPassword, setConfirmPassword] = React.useState('');

    // Error
    const [oldPassWordError, setOldPasswordError] = React.useState('');
    const [newPassWordError, setNewPasswordError] = React.useState('');
    const [confirmPassWordError, setConfirmPasswordError] = React.useState('');

    // showPass
    const [showPassOld, setShowPassOld] = React.useState(false);
    const [showPassNew, setShowPassNew] = React.useState(false);
    const [showPassConfirm, setShowPassConfirm] = React.useState(false);

    const isEnableChangePassword = () => {
        return oldPassword != '' && newPassword != '' && confirmPassword != ''
            && oldPassWordError == '' && newPassWordError == '' && confirmPassWordError == ''
    };

    const CallApiChangePass = async () => {
        try {
            const token = await AsyncStorage.getItem('Token');
            const userId = await AsyncStorage.getItem('userId');
            // Call Api
            const response = await RequestAxios.put('/IdentityService/Account/ChangePassword',
                {
                    userId: userId,
                    oldPassword: oldPassword,
                    password: newPassword,
                    confirmPassword: confirmPassword
                },
                {
                    headers: {
                        "Authorization": `Bearer ${token}`
                    }
                });
            Alert.alert(response.data.message);
        } catch (error) {
            console.log(error);
        }
    }


    const renderHeader = () => {
        return (
            <Header
                title={'ĐỔI MẬT KHẨU'}
                leftComponent={
                    <IconButton
                        icon={icons.back}
                        containerStyle={{
                            width: 40,
                            height: 40,
                            color: COLORS.black,
                            justifyContent: 'center',
                            alignItems: 'center',
                            borderWidth: 1,
                            borderRadius: SIZES.radius,
                            borderColor: COLORS.gray2,

                        }}
                        iconStyle={{
                            tintColor: COLORS.darkGray2,
                        }}
                        onPress={() => navigation.goBack()}
                    />
                }
            />
        )
    }

    const renderBody = () => {
        return (
            <View
                style={{
                    flex: 1
                }}
            >
                <View
                    style={{
                        width: '100%',
                        height: 310,
                        backgroundColor: COLORS.lightGray1,
                        marginVertical: SIZES.radius,
                        borderRadius: SIZES.radius
                    }}
                >
                    {/* Mật khẩu */}
                    <FormInput
                        lable='Mật khẩu cũ'
                        secureTextEntry={!showPassOld}
                        autoCompleteType='password'
                        onChange={(value) => {
                            setOldPassword(value);
                            utils.validatePassword(value, setOldPasswordError);
                        }}
                        errorMsg={oldPassWordError}
                        containerStyle={{
                            marginTop: SIZES.radius,
                            marginHorizontal: SIZES.radius
                        }}
                        appendComponent={
                            <TouchableOpacity
                                style={{
                                    width: 40,
                                    alignItems: 'flex-end',
                                    justifyContent: 'center',
                                }}
                                onPress={() => setShowPassOld(!showPassOld)}
                            >
                                <Image
                                    source={!showPassOld ? icons.eye : icons.eye_close}
                                    style={{
                                        height: 20,
                                        width: 20,
                                        tintColor: COLORS.gray
                                    }}
                                />

                            </TouchableOpacity>
                        }
                    />
                    {/* Mật khẩu */}
                    <FormInput
                        lable='Mật khẩu mới'
                        autoCompleteType='password'
                        secureTextEntry={!showPassNew}
                        onChange={(value) => {
                            setNewPassword(value);
                            utils.validatePassword(value, setNewPasswordError);
                        }}
                        errorMsg={newPassWordError}
                        containerStyle={{
                            marginTop: SIZES.radius,
                            marginHorizontal: SIZES.radius
                        }}
                        appendComponent={
                            <TouchableOpacity
                                style={{
                                    width: 40,
                                    alignItems: 'flex-end',
                                    justifyContent: 'center',
                                }}
                                onPress={() => setShowPassNew(!showPassNew)}
                            >
                                <Image
                                    source={!showPassNew ? icons.eye : icons.eye_close}
                                    style={{
                                        height: 20,
                                        width: 20,
                                        tintColor: COLORS.gray
                                    }}
                                />

                            </TouchableOpacity>
                        }
                    />
                    {/* Mật khẩu */}
                    <FormInput
                        lable='Xác nhận mật khẩu'
                        autoCompleteType='password'
                        secureTextEntry={!showPassConfirm}
                        onChange={(value) => {
                            setConfirmPassword(value);
                            utils.validatePassword(value, setConfirmPasswordError, newPassword);
                        }}
                        errorMsg={confirmPassWordError}
                        containerStyle={{
                            marginTop: SIZES.radius,
                            marginHorizontal: SIZES.radius
                        }}
                        appendComponent={
                            <TouchableOpacity
                                style={{
                                    width: 40,
                                    alignItems: 'flex-end',
                                    justifyContent: 'center',
                                }}
                                onPress={() => setShowPassConfirm(!showPassConfirm)}
                            >
                                <Image
                                    source={!showPassConfirm ? icons.eye : icons.eye_close}
                                    style={{
                                        height: 20,
                                        width: 20,
                                        tintColor: COLORS.gray
                                    }}
                                />

                            </TouchableOpacity>
                        }
                    />

                </View>
            </View>
        )
    }
    return (
        <View
            style={{
                paddingTop: SIZES.base,
                paddingHorizontal: SIZES.padding,
                backgroundColor: COLORS.white,
                flex: 1,
                justifyContent: 'space-between'
            }}
        >
            {renderHeader()}

            {renderBody()}
            <View>
                {/* Button */}
                <TextIconButton
                    icon={icons.check_update}
                    disabled={!isEnableChangePassword()}

                    iconStyle={{
                        width: 25,
                        height: 25,
                        marginLeft: SIZES.radius,
                        tintColor: COLORS.white
                    }}
                    label="Lưu..."
                    lableStyle={{
                        color: COLORS.white,
                        ...FONTS.h2
                    }}
                    containerStyle={{
                        backgroundColor: isEnableChangePassword() ?
                            COLORS.primary : COLORS.transparentPrimray,
                        height: 55,
                        borderRadius: SIZES.radius,
                        marginBottom: SIZES.radius
                    }}
                    onPress={() => {
                        CallApiChangePass();
                    }}

                />

            </View>
        </View>
    )
}

export default ChangePassword

const styles = StyleSheet.create({})