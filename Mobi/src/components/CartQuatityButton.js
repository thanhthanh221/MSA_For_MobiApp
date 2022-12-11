import {
    Image,
    StyleSheet,
    Text,
    TouchableOpacity,
    View
}
    from 'react-native'
import React from 'react'

import { COLORS, FONTS, SIZES, icons } from '../constants'

const CartQuatityButton = (
    { containerStyle, iconStyle, quantity, Onpress }) => {
    return (
        <TouchableOpacity
            style={{
                width: 40,
                height: 40,
                alignItems: 'center',
                justifyContent: 'center',
                borderRadius: SIZES.radius,
                backgroundColor: COLORS.lightOrange2,
                ...containerStyle
            }}
            onPress={Onpress}
        >
            <Image
                source={icons.cart}
                style={{
                    width: 20,
                    height: 20,
                    tintColor: COLORS.black,
                    ...iconStyle
                }}
            />

            <View
                style={{
                    position: 'absolute',
                    top: 0,
                    right: -5,
                    height: 20,
                    width: 20,
                    alignItems: 'center',
                    justifyContent: "center",
                    borderRadius: SIZES.radius,
                    backgroundColor: COLORS.primary
                }}
            >
                <Text
                    style={{
                        color: COLORS.white,
                        fontSize: 12,
                        fontWeight:'500',
                    }}
                >
                    {quantity}
                </Text>

            </View>

        </TouchableOpacity>
    )
}

export default CartQuatityButton

const styles = StyleSheet.create({})