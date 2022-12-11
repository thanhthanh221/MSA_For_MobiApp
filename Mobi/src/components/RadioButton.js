import { StyleSheet, Text, View, TouchableOpacity, Image } from 'react-native'
import React from 'react'

import { COLORS, FONTS, icons, SIZES } from '../constants'

const RadioButton = (
    { containerStyle, lable, lableStyle, iconStyle, isSelected, onPress }
) => {
    return (
        <TouchableOpacity
            style={{
                flexDirection: 'row',
                alignItems: 'center',
                justifyContent: 'center',
                ...containerStyle
            }}
            onPress={onPress}
        >
            <Image
                source={isSelected ? icons.check_on : icons.check_off}
                style={{
                    marginLeft: 5,
                    width: 20,
                    height: 20,
                    ...iconStyle
                }}
            />

            <Text
                style={{
                    marginLeft: SIZES.radius,
                    color: COLORS.gray,
                    ...FONTS.body3,
                    ...lableStyle
                }}
            >
                {lable}
            </Text>

        </TouchableOpacity>
    )
}

export default RadioButton

const styles = StyleSheet.create({})