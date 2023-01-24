import { Image, StyleSheet, Text, TouchableOpacity, View } from 'react-native'
import React from 'react'
import { FONTS, SIZES } from '../constants'

const VerticalTextIconButton = (
    { containerStyle, label, lableStyle, icon, iconStyle, onPress, disabled = false }) => {
    return (
        <TouchableOpacity
            onPress={onPress}
            disabled={disabled}
            style={{
                flexDirection: 'column',
                justifyContent: 'center',
                alignItems: 'center',
                ...containerStyle
            }}
        >
            <Image
                source={icon}
                style={iconStyle}
            />
            <Text
                style={{
                    marginTop: SIZES.base,
                    ...FONTS.body3,
                    ...lableStyle
                }}
            >
                {label}
            </Text>

        </TouchableOpacity>
    )
}

export default VerticalTextIconButton

const styles = StyleSheet.create({})