import {
    StyleSheet,
    Text,
    View,
    TouchableOpacity,
    Image,
} from 'react-native'
import React from 'react'

import { COLORS, FONTS, SIZES, icons } from '../constants'
import TextIconButton from './TextIconButton'
import Star from 'react-native-star-view';

const HorizontalFoodCard = (
    { containerStyle, imageStyle, item, onPress }) => {
    return (
        <TouchableOpacity
            style={{
                flexDirection: 'row',
                borderRadius: SIZES.radius,
                backgroundColor: COLORS.lightGray2,
                ...containerStyle
            }}
        >

            {/* Images */}
            <Image
                source={item.image}
                style={imageStyle}
            />

            {/* Info */}
            <View
                style={{
                    flex: 1
                }}
            >
                {/* name */}
                <Text
                    style={{
                        ...FONTS.h3,
                        fontSize: 17,
                        fontWeight: 'bold',
                        color: COLORS.black
                    }}
                >
                    {item.name}
                </Text>

                {/* Star */}
                <Star score={1} style={styles.starStyle} />


                {/* price */}
                <Text
                    style={{
                        marginTop: SIZES.base,
                        color: COLORS.black,
                        fontWeight: 'bold',
                        ...FONTS.h2
                    }}
                >
                    {item.price.toFixed(3)} VNĐ
                </Text>

            </View>

            {/* Calories */}
            <View
                style={{
                    // cố định theo thành phần View bên ngoài
                    position: 'absolute',
                    flexDirection: 'row',
                    top: 5,
                    right: SIZES.radius
                }}
            >
                <Image
                    style={{
                        width: 30,
                        height: 30
                    }}
                    source={icons.calories}
                />
                <Text
                    style={{
                        color: COLORS.darkGray2,
                        ...FONTS.body4
                    }}
                >
                    {item.calories} Calo
                </Text>
            </View>


        </TouchableOpacity>
    )
}

export default HorizontalFoodCard

const styles = StyleSheet.create({
    starStyle: {
        marginTop: SIZES.base
    }
})