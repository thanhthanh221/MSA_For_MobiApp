import { Image, StyleSheet, Text, View, TouchableOpacity, TouchableWithoutFeedback } from 'react-native'
import React from 'react'
import Animated, { useAnimatedStyle, useSharedValue, withTiming } from 'react-native-reanimated';

import { Coupon, Home, Search } from '../screen';
import { COLORS, SIZES, constants, icons, FONTS } from '../constants';


const TabButton = ({ lable, icon, isFocused,
    onPress, innerContainerStyle, outerContainerStyle }) => {

    return (
        <TouchableWithoutFeedback
            onPress={onPress}
        >
            <Animated.View
                style={[
                    {
                        flex: 1,
                        alignItems: "center",
                        justifyContent: 'center'
                    },
                    outerContainerStyle
                ]}
            >
                <Animated.View
                    style={[
                        {
                            flexDirection: 'row',
                            width: '90%',
                            height: 40,
                            borderRadius: 25,
                            alignItems: 'center',
                            justifyContent: 'center'
                        },
                        innerContainerStyle
                    ]}
                >
                    <Image
                        style={{
                            width: 30,
                            height: 30,
                            tintColor: isFocused ? COLORS.white : COLORS.darkGray
                        }}
                        source={icon} />

                    {isFocused &&
                        <Text
                            numberOfLines={1}
                            style={{
                                marginLeft: SIZES.base,
                                color: COLORS.white,
                                width: 85,
                                ...FONTS.h3
                            }}>
                            {lable}
                        </Text>
                    }
                </Animated.View>
            </Animated.View>
        </TouchableWithoutFeedback>
    )
}

const CustomTabBottom = ({ navigation }) => {
    const [selectedTab, setSelectedTab] = React.useState(constants.screens.home);

    const flatListRef = React.useRef(null);

    const homeTabFlex = useSharedValue(1);
    const homeTabColor = useSharedValue(COLORS.black);

    const searchTabColor = useSharedValue(COLORS.white);
    const searchTabFlex = useSharedValue(1);

    const couponTabFlex = useSharedValue(1);
    const couponTabColor = useSharedValue(COLORS.white);

    const evaluateTabFlex = useSharedValue(1);
    const evaluateTabColor = useSharedValue(COLORS.white);

    const notificationTabFlex = useSharedValue(1);
    const notificationTabColor = useSharedValue(COLORS.white);

    const homeFlexStyle = useAnimatedStyle(() => {
        return {
            flex: homeTabFlex.value
        }
    });

    const homeColorStyle = useAnimatedStyle(() => {
        return {
            backgroundColor: homeTabColor.value
        }
    })

    const searchFlexStyle = useAnimatedStyle(() => {
        return {
            flex: searchTabFlex.value
        }
    });

    const searchColorStyle = useAnimatedStyle(() => {
        return {
            backgroundColor: searchTabColor.value
        }
    })

    const couponFlexStyle = useAnimatedStyle(() => {
        return {
            flex: couponTabFlex.value
        }
    });

    const couponColorStyle = useAnimatedStyle(() => {
        return {
            backgroundColor: couponTabColor.value
        }
    })

    const evaluateFlexStyle = useAnimatedStyle(() => {
        return {
            flex: evaluateTabFlex.value
        }
    });

    const evaluateColorStyle = useAnimatedStyle(() => {
        return {
            backgroundColor: evaluateTabColor.value
        }
    })

    React.useEffect(() => {
        setSelectedTab(constants.screens.home);
    }, [])


    React.useEffect(() => {
        if (selectedTab === constants.screens.home) {
            flatListRef?.current?.scrollToIndex({
                index: 0,
                animated: false
            })
            // duration: khoảng thời gian chuyển đổi (1/2 giây)
            homeTabFlex.value = withTiming(3, { duration: 500 })
            homeTabColor.value = withTiming(COLORS.primary, { duration: 500 });
        }
        else {
            homeTabFlex.value = withTiming(1, { duration: 500 })
            homeTabColor.value = withTiming(COLORS.white, { duration: 500 });
        }

        if (selectedTab === constants.screens.search) {
            flatListRef?.current?.scrollToIndex({
                index: 1,
                animated: false
            })
            // duration: khoảng thời gian chuyển đổi (1/2 giây)
            searchTabFlex.value = withTiming(4, { duration: 500 })
            searchTabColor.value = withTiming(COLORS.primary, { duration: 500 });
        }
        else {
            searchTabFlex.value = withTiming(1, { duration: 500 })
            searchTabColor.value = withTiming(COLORS.white, { duration: 500 });
        }

        if (selectedTab === constants.screens.coupons) {
            flatListRef?.current?.scrollToIndex({
                index: 2,
                animated: false
            })
            // duration: khoảng thời gian chuyển đổi (1/2 giây)
            couponTabFlex.value = withTiming(4, { duration: 500 })
            couponTabColor.value = withTiming(COLORS.primary, { duration: 500 });
        }
        else {
            couponTabFlex.value = withTiming(1, { duration: 500 })
            couponTabColor.value = withTiming(COLORS.white, { duration: 500 });
        }

        if (selectedTab === constants.screens.evaluate) {
            flatListRef?.current?.scrollToIndex({
                index: 3,
                animated: false
            })
            // duration: khoảng thời gian chuyển đổi (1/2 giây)
            evaluateTabFlex.value = withTiming(4, { duration: 500 })
            evaluateTabColor.value = withTiming(COLORS.primary, { duration: 500 });
        }
        else {
            evaluateTabFlex.value = withTiming(1, { duration: 500 })
            evaluateTabColor.value = withTiming(COLORS.white, { duration: 500 });
        }

        if (selectedTab === constants.screens.notification) {
            flatListRef?.current?.scrollToIndex({
                index: 4,
                animated: false
            })
            // duration: khoảng thời gian chuyển đổi (1/2 giây)
            notificationTabFlex.value = withTiming(4, { duration: 500 })
            notificationTabColor.value = withTiming(COLORS.primary, { duration: 500 });
        }
        else {
            notificationTabFlex.value = withTiming(1, { duration: 500 })
            notificationTabColor.value = withTiming(COLORS.white, { duration: 500 });
        }

    }, [selectedTab])


    return (
        <Animated.View
            style={{
                flex: 1
            }}
        >
            <View style={{ flex: 1 }}>
                {selectedTab === constants.screens.home &&
                    <Home navigation={navigation} setSelectedTab={setSelectedTab} />}
                {selectedTab === constants.screens.search &&
                    <Search navigation={navigation} setSelectedTab={setSelectedTab} />}
                {selectedTab === constants.screens.coupons &&
                    <Coupon navigation={navigation} setSelectedTab={setSelectedTab} />}

            </View>

            <View
                style={{
                    justifyContent: 'flex-end',
                    height: 85,

                }}>

                <View
                    style={{
                        flex: 1,
                        flexDirection: 'row',
                        paddingBottom: 10,
                        paddingHorizontal: 5,
                        borderTopRightRadius: 20,
                        borderTopLeftRadius: 20,
                        backgroundColor: COLORS.white
                    }}>
                    <TabButton
                        lable={constants.screens.home}
                        icon={icons.home}
                        outerContainerStyle={homeFlexStyle}
                        innerContainerStyle={homeColorStyle}
                        isFocused={selectedTab === constants.screens.home}
                        onPress={() => setSelectedTab(constants.screens.home)}
                    />
                    <TabButton
                        lable={constants.screens.search}
                        icon={icons.search}
                        outerContainerStyle={searchFlexStyle}
                        innerContainerStyle={searchColorStyle}
                        isFocused={selectedTab === constants.screens.search}
                        onPress={() => setSelectedTab(constants.screens.search)}
                    />
                    <TabButton
                        lable={constants.screens.coupons}
                        icon={icons.coupon}
                        outerContainerStyle={couponFlexStyle}
                        innerContainerStyle={couponColorStyle}
                        isFocused={selectedTab === constants.screens.coupons}
                        onPress={() => setSelectedTab(constants.screens.coupons)}
                    />
                    <TabButton
                        lable={constants.screens.evaluate}
                        icon={icons.evaluate}
                        outerContainerStyle={evaluateFlexStyle}
                        innerContainerStyle={evaluateColorStyle}
                        isFocused={selectedTab === constants.screens.evaluate}
                        onPress={() => setSelectedTab(constants.screens.evaluate)}
                    />
                </View>
            </View>

        </Animated.View>
    )
}

export default CustomTabBottom

const styles = StyleSheet.create({})