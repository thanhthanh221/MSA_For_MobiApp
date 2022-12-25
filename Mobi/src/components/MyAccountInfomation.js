import { Image, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { COLORS, SIZES, icons } from '../constants'
import IconButton from './IconButton'

const MyAccountInfomation =
    ({label, text, textType = 'Text', check = false, onPress}) => {
        return (
            <View
                style={{
                    flexDirection: 'row',
                    justifyContent: 'space-between',
                    paddingLeft: 15,
                    borderWidth: 2,
                    borderColor: COLORS.transparentPrimray,
                    backgroundColor: COLORS.white,
                    width: SIZES.width - 2 * SIZES.base,
                    height: 60,
                    marginBottom: 15,
                    borderRadius: SIZES.radius
                }}
            >
                <View
                    style={{
                        flexDirection: 'column',
                        justifyContent: 'space-evenly'
                    }}
                >
                    <Text
                        style={{
                            color: COLORS.darkGray2,
                            fontWeight: '700',
                            fontSize: 17
                        }}
                    >
                        {label}
                    </Text>
                    <Text
                        style={{
                            fontWeight: '500',
                            fontSize: 18,
                            color: text ? COLORS.darkGray : COLORS.lightGray1
                        }}
                    >
                        {text && text}
                        {!text && (textType == 'Text' ? '-Chọn-' : 'DD/MM/YYY')}
                    </Text>
                </View>

                <View
                    style={{
                        justifyContent: 'space-evenly'
                    }}
                >
                    {
                        check &&
                        <Image
                            source={icons.correct}
                            style={{
                                width: 20,
                                height: 20,
                                tintColor: COLORS.green
                            }}
                        />
                    }
                    <IconButton
                        icon={icons.pen}
                        iconStyle={{
                            width: 20,
                            height: 20
                        }}
                        containerStyle={{
                            justifyContent: 'center',
                            alignItems: 'center',
                            marginRight: SIZES.radius
                        }}
                        onPress={onPress}
                    />
                </View>
            </View>
        )
    }

export default MyAccountInfomation

const styles = StyleSheet.create({})