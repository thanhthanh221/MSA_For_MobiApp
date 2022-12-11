import { Platform, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import LinearGradient from 'react-native-linear-gradient'

import { COLORS, FONTS, SIZES } from '../constants'
import LineDivider from './LineDivider'
import TextButton from './TextButton'

const FooterTotal = ({ subtotal, shippingFee, total, onPress }) => {
    return (
        <View>
            {/* Shadow */}
            <LinearGradient
                start={{ x: 0, y: 0 }}
                end={{ x: 0, y: 1 }}
                colors={[COLORS.transparent, COLORS.black]}
                style={{
                    position: 'absolute',
                    top: -15,
                    left: 0,
                    right: 0,
                    height: Platform.OS = 'ios' ? 200 : 50,
                    borderTopLeftRadius: 15,
                    borderTopRightRadius: 15

                }}
            />

            {/* Order */}
            <View
                style={{
                    padding: SIZES.padding,
                    borderTopLeftRadius: 20,
                    borderTopRightRadius: 20,
                    backgroundColor: COLORS.white
                }}
            >
                {/* subtotal */}
                <View
                    style={{
                        flexDirection: 'row',

                    }}
                >
                    <Text
                        style={{
                            flex: 1,
                            ...FONTS.body3,
                            color: COLORS.black,
                            fontWeight: 'bold'
                        }}
                    >
                        Sản phẩm
                    </Text>
                    <Text
                        style={{
                            ...FONTS.h3,
                            color: COLORS.black,
                            fontWeight: 'bold'
                        }}
                    >
                        {subtotal.toFixed(3)} VNĐ
                    </Text>

                </View>

                {/* Shipping Fee*/}
                <View
                    style={{
                        flexDirection: 'row',
                        marginTop: SIZES.base,
                        marginBottom: SIZES.padding
                    }}
                >
                    <Text
                        style={{
                            flex: 1,
                            ...FONTS.h3,
                            color: COLORS.black,
                            fontWeight: 'bold'
                        }}
                    >
                        Giao hàng
                    </Text>
                    <Text
                        style={{
                            ...FONTS.h3,
                            color: COLORS.black,
                            fontWeight: 'bold'
                        }}
                    >
                        {shippingFee ? shippingFee.toFixed(3) : 0} VNĐ
                    </Text>
                </View>
                {/* Line */}
                <LineDivider />

                {/* Total */}
                <View
                    style={{
                        flexDirection: 'row',
                        marginTop: SIZES.padding,
                        marginBottom:10
                    }}
                >
                    <Text
                        style={{
                            flex: 1,
                            ...FONTS.h2,
                            fontWeight: 'bold',
                            color: COLORS.black
                        }}
                    >
                        Giá:
                    </Text>
                    <Text
                        style={{
                            ...FONTS.h2,
                            fontWeight: 'bold',
                            color: COLORS.black
                        }}
                    >
                        {total.toFixed(3)} VNĐ

                    </Text>

                </View>

                {/* Button Order */}
                <TextButton
                    buttonContainerStyle={{
                        height: 55,
                        marginTop: SIZES.padding,
                        borderRadius: SIZES.radius,
                        backgroundColor: COLORS.primary
                    }}
                    lableStyle={{
                        ...FONTS.h2,
                        color: COLORS.white,
                        fontWeight:'bold'
                    }}
                    lable="Đặt hàng..."
                    onPress={onPress}
                />

            </View>
        </View>
    )
}

export default FooterTotal

const styles = StyleSheet.create({})