import { StyleSheet, Text, View, TouchableOpacity, Image } from 'react-native'
import React from 'react'

import { COLORS, FONTS, SIZES, icons } from '../constants'

const CardItem = ({ item, isSelected, onPress }) => {
    return (
        <TouchableOpacity
            style={{
                flexDirection: 'row',
                height: 100,
                alignItems: 'center',
                marginTop: SIZES.radius,
                paddingHorizontal: SIZES.padding,
                borderWidth: 2,
                borderRadius: SIZES.radius,
                borderColor: isSelected ? COLORS.primary : COLORS.lightGray2
            }}
            onPress={onPress}
        >
            {/* Card Images */}
            <View
                style={{
                    width: 60,
                    height: 45,
                    alignItems: 'center',
                    justifyContent: 'center',
                    borderWidth: 2,
                    borderRadius: COLORS.radius,
                    borderColor: COLORS.lightGray2
                }}
            >
                <Image
                    source={item.icon}
                    style={{
                        width: 35,
                        height: 35
                    }}
                    resizeMode='center'
                />
            </View>

            {/* Name */}
            <Text
                style={{
                    flex: 1,
                    marginLeft: SIZES.radius,
                    ...FONTS.h3,
                    color: COLORS.black,
                    fontWeight: 'bold'
                }}
            >
                {item.name}
            </Text>

            {/* Radio Button */}
            <Image
                source={isSelected ? icons.check_on : icons.check_off}
                style={{
                    width:25,
                    height:25
                }}
            />
        </TouchableOpacity>
    )
}

export default CardItem

const styles = StyleSheet.create({})