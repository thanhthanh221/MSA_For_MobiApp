import { Button, Image, ScrollView, StyleSheet, Text, View } from 'react-native'
import React from 'react'

import { COLORS, FONTS, icons, images, SIZES, theme } from '../../constants'
import { IconButton } from '../../components'

const ViewCoupon = ({ navigation, route }) => {
    const [coupon, setCoupon] = React.useState({});

    React.useEffect(() => {
        setCoupon({
            "Id": route.params.CouponId,
            "Name": "VNX1003K",
            "Value": "Giảm 10K cho đơn từ 70K ",
            "Expiry": new Date(2022, 11, 18),
            Description: [
                "Mã giảm giá có giá trị giảm 10.000đ cho đơn từ 70.000đ (Không bao gồm phí giao hàng). ",
                "Mã giảm giá có giá trị giảm 10.000đ cho đơn từ 70.000đ (Không bao gồm phí giao hàng). ",
                "Mã giảm giá có giá trị giảm 10.000đ cho đơn từ 70.000đ (Không bao gồm phí giao hàng). ",
                "Mã giảm giá có giá trị giảm 10.000đ cho đơn từ 70.000đ (Không bao gồm phí giao hàng). ",
                "Mã giảm giá có giá trị giảm 10.000đ cho đơn từ 70.000đ (Không bao gồm phí giao hàng). ",
                "Mã áp dụng cho một số sản phẩm. ",
                "Để biết thêm chi tiết vui lòng liên hệ bộ phận chăm sóc khách hàng Email: zzzquangzzzthuzzz@gmail.com."
            ]
        })

    }, [])
    const ShowImageHeader = () => {
        return (
            <View
                style={{
                    position: 'relative'
                }}
            >
                <IconButton
                    icon={icons.back}
                    containerStyle={{
                        zIndex: 3,
                        marginLeft: 10,
                        marginTop: SIZES.radius
                    }}
                    iconStyle={{
                        tintColor: COLORS.black
                    }}
                    onPress={() => navigation.goBack()}

                />
                <Image
                    source={images.couponBackground}
                    style={{
                        width: theme.SIZES.width,
                        height: 240,
                        position: 'absolute',
                        zIndex: 2,
                    }}
                />
                <View
                    style={{
                        height: 300,
                        width: SIZES.width,
                        position: 'absolute',
                        marginTop: 500,
                        backgroundColor: COLORS.lightGray2,
                        zIndex: 3
                    }}
                />

            </View>
        )
    }

    const ShowInfomationCoupon = () => {
        return (
            <ScrollView
                style={{
                    zIndex: 1000,

                }}
            >
                <View
                    style={{
                        position: 'relative',
                        justifyContent: 'center',
                        alignItems: 'center',
                    }}
                >
                    {/* Name */}
                    <View
                        style={{
                            width: SIZES.width * 0.93,
                            backgroundColor: COLORS.white2,
                            marginTop: 160,
                            alignItems: 'center',
                            borderRadius: 7,
                            paddingBottom: SIZES.radius,
                            borderWidth: 1,
                            borderColor: COLORS.lightGray1
                        }}
                    >
                        <Text
                            style={{
                                marginTop: SIZES.radius,
                                backgroundColor: COLORS.primary,
                                color: COLORS.white,
                                width: 130,
                                height: 30,
                                textAlign: 'center',
                                textAlignVertical: 'center',
                                borderRadius: SIZES.radius,
                                fontWeight: '700'
                            }}
                        >
                            {coupon.Name}
                        </Text>

                        {/* Value */}
                        <Text
                            style={{
                                color: COLORS.black,
                                marginTop: SIZES.base,
                                fontSize: 30,
                                width: SIZES.width * 0.82,
                                textAlign: 'center',
                                fontWeight: '800'

                            }}
                        >
                            {coupon.Value}
                        </Text>

                        {/* HSD */}
                        <View
                            style={{
                                flexDirection: 'row',
                                marginTop: 10

                            }}
                        >
                            <Text
                                style={{
                                    fontSize: 15,
                                    ...FONTS.h4
                                }}
                            >
                                Sử dụng đến:
                            </Text>
                            {
                                console.log(coupon)
                            }

                            <Text
                                style={{
                                    fontSize: 15,
                                    color: COLORS.darkGray,
                                    ...FONTS.h4
                                }}
                            > {coupon.Expiry &&
                                `${coupon.Expiry.getDate()}.${coupon.Expiry.getMonth() + 1}.${coupon.Expiry.getFullYear()}`}
                            </Text>
                        </View>
                    </View>


                    {/* light */}
                    <View
                        style={{
                            marginTop: 25,
                            height: 2,
                            width: SIZES.width * 0.97,
                            backgroundColor: COLORS.gray3
                        }}
                    />

                    {/* Description */}
                    <View
                        style={{
                            paddingHorizontal: 25,
                            paddingTop: 25
                        }}
                    >
                        {
                            coupon.Description && coupon.Description.map((item, index) => {
                                return (
                                    <View
                                        key={`Cd - ${index}`}
                                        style={{
                                            justifyContent: 'flex-start',
                                            alignItems: 'stretch',
                                            marginBottom: 20,
                                            flexDirection: 'row'
                                        }}
                                    >
                                        <View
                                            style={{
                                                width: 6,
                                                height: 6,
                                                backgroundColor: COLORS.primary,
                                                borderRadius: 3,
                                                marginRight: SIZES.radius
                                            }}
                                        />
                                        <Text
                                            style={{
                                                ...FONTS.h4
                                            }}
                                        >
                                            {item}
                                        </Text>

                                    </View>
                                )
                            })
                        }
                    </View>
                </View>

            </ScrollView>

        )
    }
    return (
        <View
            style={{
                flex: 1,
                backgroundColor: COLORS.lightGray2,
            }}
        >
            {ShowImageHeader()}

            {/* Infomation Coupon */}
            {ShowInfomationCoupon()}
        </View>
    )
}

export default ViewCoupon

const styles = StyleSheet.create({})