import {
    StyleSheet,
    Text,
    View,
    Image,
    ImageBackground
} from 'react-native'
import { Animated } from 'react-native'
import React from 'react'
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view'

import {
    COLORS,
    SIZES,
    images,
    constants,
    FONTS
} from '../../constants'
import { TextButton } from '../../components'

const AuthLayout = ({ title, subtitle, titleContainerStyle, children }) => {
    return (
        <View
            style={{
                flex: 1,
                paddingVertical: SIZES.radius,
                backgroundColor: COLORS.white
            }}
        >
            <KeyboardAwareScrollView
                keyboardDismissMode='on-drag'
                contentContainerStyle={{
                    flex: 1,
                    paddingHorizontal: SIZES.padding
                }}
            >
                {/* App icon */}
                <View
                    style={{
                        alignItems: 'center',
                    }}
                >
                    <Image
                        source={images.logo_02}
                        resizeMode='contain'
                        style={{
                            height: 100,
                            width: 200,

                        }}
                    />

                </View>

                {/* Tiêu đề -- Phụ đề */}
                <View
                    style={{
                        marginTop: SIZES.padding / 2,
                        ...titleContainerStyle
                    }}
                >
                    <Text
                        style={{
                            textAlign: 'center',
                            ...FONTS.h2,
                            fontWeight: 'bold',
                            color: COLORS.black
                        }}
                    >
                        {title}
                    </Text>

                    {/* Phụ đề */}
                    <Text
                        style={{
                            textAlign: "center",
                            color: COLORS.darkGray,
                            marginTop: SIZES.base,
                            ...FONTS.body3
                        }}
                    >
                        {subtitle}
                    </Text>
                </View>
                {/* Children */}
                {children}
            </KeyboardAwareScrollView>

        </View>
    )
}

export default AuthLayout

const styles = StyleSheet.create({})