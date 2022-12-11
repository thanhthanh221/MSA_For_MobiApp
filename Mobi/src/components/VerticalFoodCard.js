import { Image, StyleSheet, Text, TouchableOpacity, View } from 'react-native'
import React from 'react'

import { COLORS, FONTS, SIZES, icons } from '../constants';
import Star from 'react-native-star-view';

const VerticalFoodCard = (
    { containerStyle, item, onPress }) => {
    return (
        <TouchableOpacity
            style={{
                width: 200,
                paddingVertical: SIZES.radius,
                alignItems: 'center',
                borderRadius: SIZES.radius,
                backgroundColor: COLORS.lightGray2,
                ...containerStyle
            }}
        >
            {/* calo và yêu thích */}
            <View
                style={{
                    flexDirection: 'row'
                }}
            >
                {/* calo */}
                <View style={{ flex: 1, flexDirection: 'row' }}>
                    <Image
                        source={icons.calories}
                        style={{
                            width: 30,
                            height: 30
                        }}
                    />
                    <Text
                        style=
                        {{
                            color: COLORS.darkGray2,
                            ...FONTS.body4
                        }}
                    >
                        {item.calories} Calo
                    </Text>
                </View>

                {/* favourite */}
                <Image
                    style={{
                        width: 20,
                        height: 20,
                        tintColor: item.isFavourite ?
                            COLORS.primary : COLORS.gray,
                        right: 20
                    }}
                    source={icons.love}
                />

            </View>

            {/* images */}
            <View
                style={{
                    height: 150,
                    width: 150,
                    alignItems: 'center',
                    justifyContent: 'center'
                }}
            >
                <Image
                    source={item.image}
                    style={{
                        width: '100%',
                        height: '100%'
                    }}
                />

            </View>

            {/* info */}
            <View
                style={{
                    marginTop: -20,
                    alignItems: 'center'
                }}
            >
                <Text
                    style={{
                        ...FONTS.h3,
                        fontWeight: 'bold',
                        color: COLORS.black,
                        marginBottom: SIZES.base
                    }}
                >{item.name}
                </Text>

                {/* Star */}
                <Star score={1} />

                {/* price */}
                <Text style={{
                    ...FONTS.h2,
                    color: COLORS.black,
                    fontWeight: 'bold',
                    marginTop: SIZES.base
                }}>
                    {item.price.toFixed(3)} VNĐ
                </Text>
            </View>


        </TouchableOpacity>
    )
}

export default VerticalFoodCard

const styles = StyleSheet.create({})