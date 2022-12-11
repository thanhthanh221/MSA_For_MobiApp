import {
    Image,
    StyleSheet,
    Text,
    View
}
    from 'react-native'
import React from 'react'
import { COLORS, FONTS, SIZES } from '../constants'

const IconLable = (
    { containerStyle, icon, iconStyle, lable, lableStyle }
) => {
    return (
        <View
            style={{
                flexDirection: 'row',
                paddingVertical: SIZES.base,
                paddingHorizontal: SIZES.radius,
                borderRadius: SIZES.radius,
                ...containerStyle
            }}
        >
            <Image
                source={icon}
                style={{
                    height: 20,
                    width: 20,
                    ...iconStyle
                }}
            />
            <Text
                style={{
                    marginLeft: SIZES.base,
                    ...FONTS.body3,
                    color: COLORS.black,
                    fontWeight:'bold',
                    ...lableStyle
                }}
            >
                {lable}
            </Text>
        </View>
    )
}

export default IconLable

const styles = StyleSheet.create({})