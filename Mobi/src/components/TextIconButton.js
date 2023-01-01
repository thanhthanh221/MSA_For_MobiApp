import { StyleSheet, Text, View, TouchableOpacity, Image } from 'react-native'
import React from 'react'

import { COLORS, FONTS, SIZES, icons } from '../constants'

const TextIconButton = (
    { containerStyle, label, lableStyle, icon, iconStyle, onPress, childLabel, disabled = false, iconPosition = 'RIGHT' }) => {
    return (
        <TouchableOpacity
            style={{
                flexWrap: 'nowrap',
                flexDirection: 'row',
                justifyContent: 'center',
                alignItems: 'center',
                ...containerStyle,
            }}
            onPress={onPress}
            disabled={disabled}
        >
            <View
                style={{
                    flexDirection: 'column',
                    flexWrap: 'wrap'
                }}
            >
                {
                    (iconPosition === 'RIGHT' || !iconPosition) &&
                    <Text
                        style={{
                            ...lableStyle,
                            ...FONTS.body3,
                        }}
                    >
                        {label}
                    </Text>

                }
            </View>

            {/* image */}
            <Image
                source={icon}
                style={{
                    ...iconStyle
                }}
            />
            <View>
                {iconPosition === 'LEFT' &&
                    <Text
                        style={{
                            ...lableStyle,
                            flexWrap: 'nowrap',
                        }}
                    >
                        {label}
                    </Text>
                }
                {childLabel}
            </View>
        </TouchableOpacity>
    )
}

export default TextIconButton

const styles = StyleSheet.create({})