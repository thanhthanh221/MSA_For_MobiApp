import {
    StyleSheet,
    Text,
    View,
    Image,
    ImageBackground
} from 'react-native'
import { Animated } from 'react-native'
import React from 'react'

import {
    COLORS,
    SIZES,
    images,
    constants,
    FONTS
} from '../../constants'
import TextButton from '../../components/TextButton'


const OnBoarding = ({ navigation }) => {
    const scrollX = React.useRef(new Animated.Value(0)).current;
    const flatListRef = React.useRef();

    const [currentIndex, setCurrentIndex] = React.useState(0);

    const onViewChangeRef = React.useRef(({ viewableItems, changed }) => {
        setCurrentIndex(viewableItems[0].index)
    })

    const Dots = () => {
        const dotPosition = Animated.divide(scrollX, SIZES.width);

        return (
            <View
                style={{
                    flexDirection: 'row',
                    alignItems: 'center',
                    justifyContent: 'center'
                }}
            >
                {
                    constants.onboarding_screens.map((item, index) => {
                        const dotColor = dotPosition.interpolate({
                            inputRange: [index - 1, index, index + 1],
                            outputRange: [COLORS.lightOrange, COLORS.primary, COLORS.lightOrange],
                            extrapolate: 'clamp'
                        })

                        const dotWidth = dotPosition.interpolate({
                            inputRange: [index - 1, index, index + 1],
                            outputRange: [10, 40, 10],
                            extrapolate: 'clamp'
                        })

                        return (
                            <Animated.View
                                key={`dot-${index}`}
                                style={{
                                    borderRadius: 5,
                                    marginHorizontal: 6,
                                    width: dotWidth,
                                    height: 10,
                                    backgroundColor: dotColor
                                }}
                            />
                        )
                    })
                }
            </View>
        )
    }

    const renderHeaderLogo = () => {
        return (
            <View
                style={{
                    position: 'absolute',
                    top: SIZES.height > 800 ? 50 : 25,
                    left: 0,
                    right: 0,
                    alignItems: 'center',
                    justifyContent: 'center'

                }}
            >
                <Image
                    source={images.logo_02}
                    resizeMode='contain'
                    style={{
                        width: SIZES.width * 0.5,
                        height: 100
                    }}
                />
            </View>
        )
    }

    // fooder

    const renderFooder = () => {
        return (
            <View
                style={{
                    height: 160,

                }}
            >
                {/* Pagination / Dots */}
                <View
                    style={{
                        flex: 1,
                        justifyContent: 'center'
                    }}
                >
                    <Dots />
                </View>

                {/* Button */}
                {
                    currentIndex < constants.onboarding_screens.length - 1 && <View
                        style={{
                            flexDirection: 'row',
                            justifyContent: 'space-between',
                            paddingHorizontal: SIZES.padding,
                            marginVertical: SIZES.padding
                        }}
                    >
                        <TextButton
                            lableStyle={{ ...FONTS.h3 }}
                            lable='Bỏ qua'
                            onPress={() => navigation.navigate('SignIn')}

                        />
                        <TextButton
                            lable='Tiếp tục'
                            buttonContainerStyle={styles.buttonNext}
                            lableStyle={{ ...FONTS.h3, ...styles.buttonLable }}
                            onPress={() => {
                                // Math.ceil: làm tròn trả về số nhỏ hơn
                                flatListRef.current?.scrollToIndex({
                                    index: currentIndex + 1,
                                    animated: true
                                })
                            }}
                        />
                    </View>
                }

                {/* Button khi bằng Length */}
                {
                    currentIndex === constants.onboarding_screens.length - 1 &&
                    <View
                        style={{
                            paddingHorizontal: SIZES.padding,
                            marginVertical: SIZES.padding
                        }}
                    >
                        <TextButton
                            lable='Bắt đầu với chúng tôi'
                            buttonContainerStyle={styles.buttonLength}
                            onPress={() => navigation.replace('SignIn')}
                            lableStyle={{ ...styles.buttonLable, ...FONTS.h3 }}
                        />
                    </View>
                }
            </View>
        )
    }
    return (
        <View
            style={{
                backgroundColor: COLORS.white,
                flex: 1
            }}
        >
            {/* header Logo */}
            {renderHeaderLogo()}

            <Animated.FlatList
                horizontal
                ref={flatListRef}
                onViewableItemsChanged={onViewChangeRef.current}
                data={constants.onboarding_screens}
                showsHorizontalScrollIndicator={false}
                keyExtractor={(item) => `${item.id}-AF`}
                onScroll={Animated.event(
                    [
                        {
                            nativeEvent: {
                                contentOffset: { x: scrollX }
                            }
                        }
                    ],
                    { useNativeDriver: false }
                )}
                renderItem={({ item, index }) => {
                    return (
                        <View
                            style={{
                                flex: 1, width: SIZES.width
                            }}
                        >
                            {/* header */}
                            <View
                                style={{
                                    flex: 3
                                }}
                            >
                                <ImageBackground
                                    source={item.backgroundImage}
                                    style={{
                                        flex: 4,
                                        width: '100%',
                                        height: index == 1 ? '86.5%' : '100%',
                                        alignItems: 'center',
                                        justifyContent: "flex-end"
                                    }}
                                >
                                    <Image
                                        source={item.bannerImage}
                                        resizeMode='contain'
                                        style={{
                                            marginBottom: - SIZES.padding * 4,
                                            height: SIZES.height * 0.5,
                                            width: SIZES.width * 0.5
                                        }}
                                    />
                                </ImageBackground>

                                {/* Thông tin sản phẩm */}
                                <View
                                    style={{
                                        flex: 1,
                                        marginTop: 30,
                                        paddingHorizontal: SIZES.radius,
                                        alignItems: 'center',
                                        justifyContent: "center"

                                    }}
                                >
                                    <Text
                                        style={{
                                            ...FONTS.h1,
                                            fontWeight: 'bold',
                                            color: COLORS.black,
                                            fontSize: 25
                                        }}
                                    >
                                        {item.title}
                                    </Text>

                                    {/* mô tả sản phẩm */}
                                    <Text
                                        style={{
                                            textAlign: 'center',
                                            marginTop: SIZES.radius,
                                            paddingHorizontal: SIZES.padding,
                                            ...FONTS.body3,
                                            color: COLORS.darkGray
                                        }}
                                    >
                                        {item.description}
                                    </Text>
                                </View>
                            </View>
                        </View>
                    )
                }}
            />

            {/* fooder */}
            {renderFooder()}
        </View>

    )
}

export default OnBoarding

const styles = StyleSheet.create({
    buttonNext: {
        height: 50,
        width: 200,
        borderRadius: SIZES.radius,
        backgroundColor: COLORS.primary,
    },
    buttonLable: {
        color: COLORS.white
    },
    buttonLength: {
        height: 50,
        alignItems: 'center',
        justifyContent: 'center',
        borderRadius: SIZES.radius,
        backgroundColor: COLORS.primary
    }
})