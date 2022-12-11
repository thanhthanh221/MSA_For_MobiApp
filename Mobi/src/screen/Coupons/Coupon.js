import { FlatList, Image, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { Header, IconButton, TextButton, TextIconButton } from '../../components'
import { COLORS, icons, SIZES, theme } from '../../constants'

const Coupon = ({ navigation }) => {

    const [selectType, setSelectType] = React.useState();
    const [listCoupon, setListCoupon] = React.useState({});

    React.useEffect(() => {
        setSelectType('couponUser');

        setListCoupon(
            [
                {
                    "Id": 1,
                    'Value': "Giảm 10K cho đơn từ 70K ",
                    "Expiry": new Date(2022, 11, 17)
                },
                {
                    "Id": 2,
                    'Value': "Giảm 20K cho đơn từ 100K",
                    "Expiry": new Date(2022, 11, 17)
                },
                {
                    "Id": 3,
                    'Value': "Giảm 30K cho đơn từ 120K",
                    "Expiry": new Date(2022, 11, 17)
                },
                {
                    "Id": 4,
                    'Value': "Giảm 40K cho đơn từ 160K",
                    "Expiry": new Date(2022, 11, 12)
                },
                {
                    "Id": 5,
                    'Value': "Giảm 50K cho đơn từ 200K",
                    "Expiry": new Date(2022, 11, 17)
                },
                {
                    "Id": 6,
                    'Value': "Giảm 70K cho đơn từ 250K",
                    "Expiry": new Date(2022, 11, 17)
                }
            ])
    }, [])

    // Khoảng chênh thời gian
    const timeRemainingCoupon = (DatimeTime) => {
        const today = new Date();

        const SpanDay = (DatimeTime.getTime() - today.getTime()) / (1000 * 60 * 60 * 24);

        return Math.ceil(SpanDay)
    }

    // RenderView

    // Header
    const renderHeader = () => {
        return (
            <View
                style={{
                    flexDirection: 'column',
                    backgroundColor: COLORS.white
                }}
            >
                <Header
                    containerStyle={{
                        marginTop: 10
                    }}
                    leftComponent={
                        <IconButton
                            icon={icons.back}
                            iconStyle={{
                                tintColor: COLORS.black,
                                marginLeft: 10
                            }}
                            onPress={() => navigation.goBack()}
                        />
                    }
                    title={"MÃ GIẢM GIÁ"}
                />

                <View
                    style={{
                        marginTop: 20,
                        marginBottom: 10,
                        flexDirection: 'row',
                        justifyContent: 'space-around'
                    }}
                >
                    <TextButton
                        lable={"Mã cá nhân"}
                        buttonContainerStyle={{
                            backgroundColor: selectType === 'couponUser'
                                ? COLORS.primary : COLORS.lightOrange2,
                            width: 180,
                            height: 45,
                            borderRadius: SIZES.radius,
                        }}
                        lableStyle={{
                            color: selectType === 'couponUser'
                                ? COLORS.white : COLORS.primary
                        }}
                        onPress={() => setSelectType('couponUser')}
                    />
                    <TextButton
                        lable={"Khuyến mại hot"}
                        buttonContainerStyle={{
                            backgroundColor: selectType === 'couponHot'
                                ? COLORS.primary : COLORS.lightOrange2,
                            width: 180,
                            height: 45,
                            borderRadius: SIZES.radius
                        }}
                        lableStyle={{
                            color: selectType === 'couponHot'
                                ? COLORS.white : COLORS.primary
                        }}
                        onPress={() => setSelectType('couponHot')}

                    />
                </View>

                {/* Light */}
                <View
                    style={{
                        flexDirection: 'row'
                    }}
                >
                    <View
                        style={{
                            width: theme.SIZES.width * 0.5,
                            height: selectType === 'couponUser' ? 1 : 0,
                            backgroundColor: COLORS.primary
                        }}>

                    </View>

                    <View
                        style={{
                            width: theme.SIZES.width * 0.5,
                            height: selectType === 'couponHot' ? 1 : 0,
                            backgroundColor: COLORS.primary
                        }}>

                    </View>
                </View>
            </View>
        )
    }

    const renderCoupon = () => {
        return (
            <FlatList
                showsVerticalScrollIndicator={false}
                data={listCoupon}
                keyExtractor={item => `CP--${item.Id}`}
                renderItem={({ item, index }) => {
                    return (
                        <View
                            style={{
                                marginTop: 20,
                                flexDirection: 'row',
                                alignItems: 'center'
                            }}
                        >
                            <View
                                style={{
                                    width: 10,
                                    height: 90,
                                    backgroundColor: COLORS.primary,
                                    borderTopLeftRadius: 2,
                                    borderBottomLeftRadius: 2,
                                }}
                            />

                            {/* Text Icon */}
                            <TextIconButton
                                containerStyle={{
                                    width: 280,
                                    height: 90,
                                    backgroundColor: COLORS.white,
                                    borderTopRightRadius: SIZES.padding,
                                    borderBottomRightRadius: SIZES.padding,
                                    justifyContent: 'center',
                                    alignItems:'center'
                                }}
                                icon={icons.couponsUser}
                                iconStyle={{
                                    height: 40,
                                    width: 40,
                                    marginRight: 5
                                }}
                                label={item.Value}
                                iconPosition="LEFT"
                                lableStyle={{
                                    color: COLORS.black,
                                    width: 200
                                }}
                                childLabel={
                                    <View
                                        style={{
                                            flexDirection: 'row',
                                            marginTop: 5,
                                            height: 30,
                                            alignItems: 'center',
                                        }}
                                    >
                                        {
                                            timeRemainingCoupon(item.Expiry) <= 5 ?
                                                <View
                                                    style={{

                                                        borderColor: COLORS.primary,
                                                        borderRadius: 7,
                                                        justifyContent: 'center',
                                                        alignItems: 'center',
                                                        borderWidth: 1,
                                                        borderColor: COLORS.primary,
                                                        height: 30,
                                                        width: 90
                                                    }}>
                                                    <Text
                                                        style={{
                                                            color: COLORS.red,
                                                        }}
                                                    >
                                                        Sắp hết hạn:
                                                    </Text>
                                                </View>
                                                :
                                                <Text
                                                    style={{
                                                        color: COLORS.darkGray
                                                    }}
                                                >
                                                    HSD:
                                                </Text>
                                        }

                                        <Text> {item.Expiry.getDate()}.
                                            {item.Expiry.getMonth() + 1}.
                                            {item.Expiry.getFullYear()}
                                        </Text>
                                    </View>
                                }
                            />

                            <View
                                style={{
                                    flexDirection: 'row',
                                    backgroundColor: COLORS.white,
                                    height: 40,
                                    justifyContent: 'center',
                                    alignItems: 'center'
                                }}
                            >
                                <Image
                                    source={icons.dotted_line}
                                    style={{
                                        width: 2,
                                        height: 30,
                                        justifyContent: 'center',
                                        tintColor: COLORS.black
                                    }}
                                />
                            </View>

                            {/* Text Button */}
                            <TextButton
                                buttonContainerStyle={{
                                    height: 90,
                                    width: 70,
                                    backgroundColor: COLORS.white,
                                    borderTopLeftRadius: SIZES.padding,
                                    borderBottomLeftRadius: SIZES.padding,
                                    borderTopRightRadius: 2,
                                    borderBottomRightRadius: 2,
                                }}
                                lable={"Chọn"}
                                lableStyle={{
                                    color: COLORS.primary
                                }}
                            />
                        </View>
                    )
                }}

            />
        )
    }
    return (
        <View
            style={{
                flex: 1,
                paddingBottom: 120
            }}
        >
            {renderHeader()}

            <View
                style={{
                    paddingHorizontal: SIZES.padding,
                    marginTop: 5
                }}
            >
                {/* Coupon */}
                {renderCoupon()}
            </View>
        </View>
    )
}

export default Coupon

const styles = StyleSheet.create({})