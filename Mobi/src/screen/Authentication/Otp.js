import {
    StyleSheet,
    Text,
    View,
    Image,
    TouchableOpacity
} from 'react-native'
import React from 'react'
import OTPInputView from '@twotalltotems/react-native-otp-input'


import AuthLayout from './AuthLayout'
import { COLORS, FONTS, icons, images, SIZES } from '../../constants'
import FormInput from '../../components/FormInput'
import { utils } from '../../utils/index'
import CustomSwitch from '../../components/CustomSwitch'
import TextButton from '../../components/TextButton'
import TextIconButton from '../../components/TextIconButton'

const Otp = ({ navigation }) => {
    const [time, setTime] = React.useState(60);

    React.useEffect(() => {
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
            subtitle={'Nhập mã vừa gửi về Email - Số điện thoại của bạn'}
            titleContainerStyle={{
                marginTop: 30
            }}
        >
            <OTPInputView
                pinCount={4}
                style={{
                    width: '100%',
                    height: 50,
                    marginTop: 60
                }}
                onCodeFilled={(code) => {
                    console.log(code)
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
                        marginLeft: 10
                    }}
                    lableStyle={{
                        fontSize: 20,
                        color: COLORS.primary
                    }}
                    lable={`Gửi lại (${time}s)`}
                    onPress={() => setTime(60)}
                />
            </View>

            {/* Footer */}
            <View
                style={{
                    marginTop: 250
                }}
            >
                <TextButton
                    lable={'Xác thực ....'}
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
                    onPress={() => navigation.navigate('Home')}
                />

                <View
                    style={{
                        marginTop: SIZES.padding / 2,
                        alignItems: 'center'
                    }}
                >
                    <TextButton
                        lable={'Xem về chúng tôi'}
                        buttonContainerStyle={{
                            backgroundColor: null
                        }}
                        lableStyle={{
                            color: COLORS.primary,
                            ...FONTS.body3
                        }}
                        onPress={() => console.log("Bùi Quang - Tạ Yến")}

                    />

                </View>
            </View>
        </AuthLayout>
    )
}

export default Otp

const styles = StyleSheet.create({})