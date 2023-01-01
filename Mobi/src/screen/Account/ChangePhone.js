import { Image, StyleSheet, Text, TextInput, View } from 'react-native'
import React from 'react'
import AccountLayout from './AccountLayout'
import { COLORS, SIZES, icons } from '../../constants'

const ChangePhone = ({ navigation }) => {
    const [phone, setPhone] = React.useState('');

    const SendOtpToPhone = () => {
        navigation.navigate("Otp");
    }
    const disabled = () => {
        return phone.length == 9
    }
    return (
        <AccountLayout
            buttonTitle={"Tiếp theo"}
            title="Số điện thoại"
            navigation={navigation}
            disabled = {!disabled()}
            onPress={() => SendOtpToPhone()}
            
        >
            <Text
                style={{
                    paddingVertical: SIZES.radius,
                    fontWeight: "800",
                    color: COLORS.darkGray,
                    fontSize: 26
                }}
            >
                Nhập số điện thoại của bạn để tiếp tục
            </Text>

            <View
                style={{
                    width: '100%',
                    height: 100,
                    backgroundColor: COLORS.lightGray1,
                    borderRadius: SIZES.radius,
                    justifyContent: 'center',
                    alignItems: 'center',
                    borderColor: COLORS.transparentPrimray,
                    borderWidth: 1
                }}
            >
                <View
                    style={{
                        backgroundColor: COLORS.white2,
                        width: '94%',
                        height: 50,
                        alignItems: 'center',
                        borderRadius: 7,
                        borderColor: COLORS.primary,
                        borderWidth: 2,
                        flexDirection: 'row'
                    }}
                >
                    <View
                        style={{
                            flexDirection: 'row',
                            justifyContent: 'center',
                            alignItems: 'center',
                            width: '30%',
                            height: '70%',
                            borderRightWidth: 1,
                            borderColor: COLORS.lightGray1
                        }}
                    >
                        <Image
                            source={icons.vietnam}
                            style={{
                                width: 65,
                                height: 30
                            }}
                            resizeMode='center'
                        />
                        <Text
                            style={{
                                fontSize: 17
                            }}
                        >
                            +84
                        </Text>
                    </View>
                    {/* Form Input Phone */}
                    <TextInput
                        placeholder='Số điện thoại'
                        style={{
                            marginLeft: SIZES.base,
                            flex: 1,
                            fontSize: 18,
                            backgroundColor: COLORS.white2
                        }}
                        keyboardType='phone-pad'
                        onChangeText={(numberPhone) => setPhone('84' + numberPhone)}
                    />
                </View>
            </View>

        </AccountLayout>
    )
}

export default ChangePhone

const styles = StyleSheet.create({})