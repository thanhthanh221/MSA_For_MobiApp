import {
    StyleSheet,
    Text,
    View,
    Alert
} from 'react-native'
import React from 'react'
import OTPInputView from '@twotalltotems/react-native-otp-input'

import AuthLayout from './AuthLayout'
import { COLORS, FONTS, icons, images, SIZES } from '../../constants'
import TextButton from '../../components/TextButton'
import { IdentityApi } from '../../services'

const Otp = ({ navigation, route }) => {
    const [time, setTime] = React.useState(60);
    const [phone, setPhone] = React.useState('');
    const [codeOtp, setCodeOtp] = React.useState('');

    const VerifyOtp = async () => {
        var responseApi = await IdentityApi.VerifyPhoneNumber(codeOtp, phone);
        if (responseApi.status === 200) {
            console.log(responseApi.data.message);
            if(!responseApi.data.verify) {
                Alert.alert(responseApi.data.message);
                return;
            }
            else {
                navigation.navigate("MyAccount");
                return;
            }
        }
    }
    // Gửi lại
    const SendOtp = async () => {
        await IdentityApi.AddPhoneNumber(phone);
    }
    const checkCode = () => {
        return codeOtp.length == 4;
    }

    React.useEffect(() => {
        setPhone(route.params.PhoneNumber)
        let interval = setInterval(() => {
            setTime(prev => {
                if (prev > 0) {
                    return prev - 1
                }
                else {
                    return prev
                }
            })
        }, 1000)
        return () => clearInterval(interval);
    }, [])

    return (
        <AuthLayout
            title='Mã xác thực'
            subtitle={'Nhập mã vừa gửi về số điện thoại của bạn'}
            titleContainerStyle={{
                marginTop: 30
            }}
        >
            <View
                style={{
                    flex: 1
                }}
            >
                <OTPInputView
                    pinCount={4}
                    style={{
                        width: '100%',
                        height: 50,
                        marginTop: 60
                    }}
                    onCodeChanged={(code) => {
                        setCodeOtp(code)
                    }}
                    codeInputFieldStyle={{
                        width: 65,
                        height: 65,
                        borderRadius: SIZES.radius,
                        backgroundColor: COLORS.lightGray2,
                        ...FONTS.h3,
                        color: COLORS.black

                    }}
                />

                {/* Đếm ngược thời gian */}
                <View
                    style={{
                        flexDirection: 'row',
                        justifyContent: 'center',
                        marginTop: SIZES.padding
                    }}
                >
                    <Text
                        style={{
                            color: COLORS.darkGray,
                            ...FONTS.body3,
                            marginTop: 14,
                            fontSize: 20
                        }}
                    >
                        Không nhận được mã ?
                    </Text>
                    <TextButton
                        buttonContainerStyle={{
                            marginLeft: 10,
                            marginTop: 10
                        }}
                        lableStyle={{
                            fontSize: 20,
                            color: COLORS.primary
                        }}
                        lable={`Gửi lại (${time}s)`}
                        onPress={() => {
                            setTime(60);
                            SendOtp();
                        }}
                    />
                </View>
            </View>

            {/* Footer */}
            <TextButton
                lable={'Xác nhận'}
                buttonContainerStyle={{
                    height: 50,
                    alignItem: 'center',
                    backgroundColor: checkCode() ? COLORS.primary : COLORS.transparentPrimray,
                    borderRadius: SIZES.radius,
                    marginBottom: 10
                }}
                disabled={!checkCode()}
                lableStyle={{
                    color: COLORS.white,
                    ...FONTS.h3
                }}
                onPress={() => VerifyOtp()}
            />
        </AuthLayout>
    )
}

export default Otp

const styles = StyleSheet.create({})