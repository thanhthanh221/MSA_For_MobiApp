import { StyleSheet, Text, View, Image } from 'react-native'
import React from 'react'

import { COLORS, icons } from '../constants'

const Ratting = (
    {
        ratting, iconStyle,
        activeColor = COLORS.orange,
        inactiveColor = COLORS.lightOrange3
    }
) => {
    return (
        <View
            style={{
                flexDirection: 'row'
            }}
        >
            <Image
                source={icons.star}
                style={{
                    tintColor: ratting >= 1 ? activeColor : inactiveColor,
                    ...styles.rateIcon,
                    ...iconStyle
                }}
            />

            <Image
                source={icons.star}
                style={{
                    tintColor: ratting >= 2 ? activeColor : inactiveColor,
                    ...styles.rateIcon,
                    ...iconStyle
                }}
            />

            <Image
                source={icons.star}
                style={{
                    tintColor: ratting >= 3 ? activeColor : inactiveColor,
                    ...styles.rateIcon,
                    ...iconStyle
                }}
            />

            <Image
                source={icons.star}
                style={{
                    tintColor: ratting >= 4 ? activeColor : inactiveColor,
                    ...styles.rateIcon,
                    ...iconStyle
                }}
            />

            <Image
                source={icons.star}
                style={{
                    tintColor: ratting >= 5 ? activeColor : inactiveColor,
                    ...styles.rateIcon,
                    ...iconStyle
                }}
            />
        </View>
    )
}

export default Ratting

const styles = StyleSheet.create({
    rateIcon: {
        height: 15,
        width: 15
    }
})