import {
    Image,
    StyleSheet,
    Text,
    TouchableOpacity,
    View
} from 'react-native'
import React from 'react'

const IconButton = ({ containerStyle, icon, iconStyle, onPress, disabled, network }) => {
    return (
        <TouchableOpacity
            style={containerStyle}
            onPress={onPress}
            disabled={disabled}
        >
            <Image
                style={{
                    height: 30,
                    width: 30,
                    ...iconStyle
                }}
                source={!network ? icon : { uri: icon }}
            />
        </TouchableOpacity>
    )
}

export default IconButton

const styles = StyleSheet.create({})