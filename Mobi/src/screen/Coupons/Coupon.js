import { Alert, FlatList, Image, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { Header, IconButton, TextButton, TextIconButton } from '../../components'
import { COLORS, icons, images, SIZES, theme } from '../../constants'

const Coupon = ({ navigation }) => {

    const [selectType, setSelectType] = React.useState('');
    const [listCoupon, setListCoupon] = React.useState([]);
    const [userCoupon, setUserCoupon] = React.useState([]);

    React.useEffect(() => {
        setSelectType('couponUser');

        setListCoupon(
            [
                {
                    "Id": 1,
                    'Value': "Giảm 10K cho đơn từ 70K ",
                    "Expiry": new Date(2022, 11, 17),
                    "Quantity": 3
                },
                {
                    "Id": 2,
                    'Value': "Giảm 20K cho đơn từ 100K",
                    "Expiry": new Date(2022, 11, 17),
                    "Quantity": 6
                },
                {
                    "Id": 3,
                    'Value': "Giảm 30K cho đơn từ 120K",
                    "Expiry": new Date(2022, 11, 29),
                    "Quantity": 0
                },
                {
                    "Id": 4,
                    'Value': "Giảm 40K cho đơn từ 160K",
                    "Expiry": new Date(2022, 11, 29),
                    "Quantity": 11
                },
                {
                    "Id": 5,
                    'Value': "Giảm 50K cho đơn từ 200K",
                    "Expiry": new Date(2022, 11, 17),
                    "Quantity": 15
                },
                {
                    "Id": 6,
                    'Value': "Giảm 70K cho đơn từ 250K",
                    "Expiry": new Date(2022, 11, 17),
                    "Quantity": 6
                }
            ])
        setUserCoupon(
            [
                {
                    "Id": 6,
                    'Value': "Giảm 70K cho đơn từ 250K",
                    "Expiry": new Date(2022, 11, 17)
                }
            ]
        )
    }, [])

    // Khoảng chênh thời gian
    const timeRemainingCoupon = (DatimeTime) => {
        const today = new Date();

        const SpanDay = (DatimeTime.getTime() - today.getTime()) / (1000 * 60 * 60 * 24);

        return Math.ceil(SpanDay)
    }

    // Show Alert
    const AlertRemoveCoupon = (coupon) => {
        Alert.alert(
            'Xóa mã giảm giá',
            'Bạn muốn xóa mã giảm giá ?', [
            {
                text: 'Hủy',
                onPress: () => console.log("Quang"),

            },
            {
                text: 'Xóa',
                onPress: () => setUserCoupon(userCoupon.filter((value, index) => {
                    return value.Id != coupon.Id;
                }))
            },
        ],
            {
                cancelable: true
            }
        )
    }
    const AddCouponForUser = (coupon) => {
        const filterCoupon = userCoupon.filter((value, index) => {
            return value.Id == coupon.Id;
        });
        if (filterCoupon.length == 0) {
            setUserCoupon([...userCoupon, coupon]);
            return;
        }

        Alert.alert("Bạn đã có mã này rồi ! ");
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
                data={selectType === 'couponUser' ? userCoupon : listCoupon}
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
                                    justifyContent: 'flex-start',
                                    alignItems: 'center'
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
                                onPress={() => navigation.navigate("DetailCoupon", { CouponId: item.Id })}
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
                                disabled={item.Quantity == 0 ? true : false}
                                buttonContainerStyle={{
                                    height: 90,
                                    width: 70,
                                    backgroundColor: item.Quantity == 0 && selectType === 'couponHot' ? COLORS.transparentPrimray : COLORS.white,
                                    borderTopLeftRadius: SIZES.padding,
                                    borderBottomLeftRadius: SIZES.padding,
                                    borderTopRightRadius: 2,
                                    borderBottomRightRadius: 2,
                                }}
                                lable={selectType === 'couponUser' ? "Xóa" : item.Quantity == 0 ? "Hết" : "Chọn"}
                                lableStyle={{
                                    color: COLORS.primary,
                                }}
                                onPress={() => selectType === 'couponUser'
                                    ? AlertRemoveCoupon(item)
                                    : AddCouponForUser(item)
                                }
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
            <Image
                source={images.noen}
                style={{
                    width: SIZES.width,
                    position: 'absolute',
                    marginTop: 120
                }}
            />
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