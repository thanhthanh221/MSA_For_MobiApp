import {
    Image,
    StyleSheet,
    Text,
    TouchableOpacity,
    View
} from 'react-native'
import React from 'react'

import { COLORS } from '../constants'

const IconButton = ({ containerStyle, icon, iconStyle, onPress }) => {
    return (
        <TouchableOpacity
            style={containerStyle}
            onPress={onPress}
        >
            <Image
                style={{
                    height: 30,
                    width: 30,
                    ...iconStyle
                }}
                source={icon}
            />

        </TouchableOpacity>
    )
}

export default IconButton

const styles = StyleSheet.create({})