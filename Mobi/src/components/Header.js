import { StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { COLORS, FONTS } from '../constants/index'

const Header = (
    { containerStyle, title, leftComponent, RightComponent }) => {
    return (
        <View style={{
            flexDirection: 'row',
            ...containerStyle
        }}>
            {/* left */}
            {leftComponent}

            {/* title */}
            <View
                style={{
                    flex: 1,
                    alignItems: 'center',
                    justifyContent: 'center'
                }}>
                <Text
                    style={{
                        color: COLORS.darkBlue,
                        ...FONTS.h3
                    }}
                >{title}</Text>
            </View>

            {/* right */}
            {RightComponent}
        </View>
    )
}

export default Header

const styles = StyleSheet.create({})