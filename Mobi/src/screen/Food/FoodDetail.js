import {
    StyleSheet,
    Text,
    View,
    Image,
    ScrollView
} from 'react-native';
import axios from 'axios';
import React from 'react'

import { FONTS, COLORS, SIZES, icons, images } from '../../constants'
import CartQuatityButton from '../../components/CartQuatityButton'
import dummyData from '../../constants/dummyData';
import {
    Header,
    IconButton,
    IconLable,
    LineDivider,
    Ratting,
    StepperInput,
    TextButton
} from '../../components'


const FoodDetail = ({ navigation }) => {
    const [foodItem, setFoodItem] = React.useState(dummyData.vegBiryani);
    const [selectSize, setSelectSize] = React.useState("");
    const [qty, setQty] = React.useState(1);

    React.useEffect(() => {
        axios.get("https://e2f5-2402-9d80-26d-1954-25cb-3061-ba59-60ec.ap.ngrok.io/MarketService/Product/ProductById/cea20f55-0286-4419-a822-f3dcf13a0aab",)
            .then((responseJson) => {
                console.log('getting data from fetch', responseJson.data)
            })
            .catch(error => {
                console.log(error)
            })
    }, [])

    function renderHeader() {
        return (
            <Header
                title="Chi tiết"
                containerStyle={{
                    height: 50,
                    marginHorizontal: SIZES.padding,
                    marginTop: 15
                }}
                leftComponent={
                    <IconButton
                        icon={icons.back}
                        containerStyle={{
                            width: 40,
                            height: 40,
                            color: COLORS.black,
                            justifyContent: 'center',
                            alignItems: 'center',
                            borderWidth: 1,
                            borderRadius: SIZES.radius,
                            borderColor: COLORS.gray2

                        }}
                        iconStyle={{
                            tintColor: COLORS.darkGray2,
                        }}
                        onPress={() => console.log("Back")}
                    />
                }
                RightComponent={
                    <CartQuatityButton
                        quantity={3}
                    />
                }

            />
        )
    }

    const renderDetails = () => {
        return (
            <View
                style={{
                    marginTop: SIZES.radius * 2,
                    marginBottom: SIZES.padding,
                    paddingHorizontal: SIZES.padding
                }}
            >
                {/* food Card */}
                <View
                    style={{
                        height: 190,
                        borderRadius: 15,
                        backgroundColor: COLORS.lightGray2
                    }}
                >
                    {/* Calories & Favourite */}
                    <View
                        style={{
                            flexDirection: 'row',
                            justifyContent: 'space-between',
                            marginTop: SIZES.base,
                            paddingHorizontal: SIZES.radius
                        }}
                    >
                        {/* Calo */}
                        <View
                            style={{
                                flexDirection: 'row'
                            }}
                        >
                            <Image
                                source={icons.calories}
                                style={{
                                    width: 30,
                                    height: 30
                                }}
                            />

                            <Text
                                style={{
                                    color: COLORS.darkGray2,
                                    ...FONTS.body4

                                }}
                            >
                                {foodItem?.calories} Calo
                            </Text>
                        </View>


                        {/* Favourite */}
                        <Image
                            source={icons.love}
                            style={{
                                width: 20,
                                height: 20,
                                tintColor: foodItem?.isFavourite
                                    ? COLORS.primary : COLORS.gray
                            }}
                        />
                    </View>

                    {/* Food Images */}
                    <Image
                        source={foodItem?.image}
                        resizeMode='contain'
                        style={{
                            height: 190,
                            width: '100%'
                        }}
                    />
                </View>

                {/* Food Info */}
                <View
                    style={{
                        marginTop: SIZES.padding
                    }}
                >
                    <Text
                        style={{
                            ...FONTS.h1,
                            fontWeight: 'bold',
                            color: COLORS.black
                        }}
                    >
                        {foodItem?.name}
                    </Text>

                    <Text
                        style={{
                            marginTop: SIZES.base,
                            color: COLORS.darkGray,
                            textAlign: 'justify',
                            ...FONTS.body3
                        }}
                    >
                        {foodItem?.description}
                    </Text>

                    {/* Đánh giá sao - thời gian giao hàng */}
                    <View
                        style={{
                            marginVertical: SIZES.padding,
                            flexDirection: 'row',
                            justifyContent: 'space-between'
                        }}
                    >
                        {/* Sao đánh giá */}
                        <IconLable
                            icon={icons.star}
                            containerStyle={{
                                backgroundColor: COLORS.primary,
                            }}
                            lable='4.5'
                            lableStyle={{
                                color: COLORS.white
                            }}
                        />

                        {/* Thời gian giao hàng */}
                        <IconLable
                            icon={icons.clock}
                            containerStyle={{
                                marginLeft: SIZES.radius
                            }}
                            iconStyle={{
                                tintColor: COLORS.black
                            }}
                            lable={"30 Phút"}
                        />

                        {/* Ship Product */}
                        <IconLable
                            icon={icons.dollar}
                            containerStyle={{
                                marginLeft: SIZES.radius
                            }}
                            iconStyle={{
                                tintColor: COLORS.black
                            }}
                            lable={"Free Ship"}
                        />
                    </View>

                    {/* Chọn kích cỡ của sản phẩm */}
                    <View
                        style={{
                            flexDirection: 'row',
                            alignItems: 'center'
                        }}
                    >
                        <Text
                            style={{
                                ...FONTS.h3,
                                color: COLORS.black,
                                fontWeight: 'bold'
                            }}
                        >
                            Sizes:
                        </Text>

                        {/* Các kích thước sản phẩm */}
                        <View
                            style={{
                                flexDirection: 'row',
                                flexWrap: 'wrap',
                                marginLeft: SIZES.padding / 2
                            }}
                        >
                            {
                                dummyData.sizes.map((item, index) => {
                                    return (
                                        <TextButton
                                            key={`Size-${index}`}
                                            buttonContainerStyle={{
                                                width: 70,
                                                height: 45,
                                                margin: SIZES.base,
                                                borderWidth: 1,
                                                borderRadius: SIZES.radius,
                                                borderColor: selectSize == item.id
                                                    ? COLORS.primary : COLORS.gray2,
                                                backgroundColor: selectSize == item.id
                                                    ? COLORS.primary : null
                                            }}
                                            lable={item.label}
                                            lableStyle={{
                                                color: selectSize == item.id
                                                    ? COLORS.white : COLORS.gray,
                                                ...FONTS.body4
                                            }}
                                            onPress={() => setSelectSize(item.id)}
                                        />

                                    )
                                })
                            }
                        </View>
                    </View>
                </View>
            </View>
        )
    }

    // Render cửa hàng
    const renderRestaurant = () => {
        return (
            <View
                style={{
                    flexDirection: 'row',
                    marginVertical: SIZES.padding,
                    paddingHorizontal: SIZES.padding,
                    alignItems: 'center'
                }}
            >
                <Image
                    source={images.userfake}
                    style={{
                        width: 50,
                        height: 50,
                        borderRadius: SIZES.radius
                    }}
                />

                {/* Icons */}
                <View
                    style={{
                        flex: 1,
                        marginLeft: SIZES.radius,
                        justifyContent: 'center'
                    }}
                >
                    <Text
                        style={{
                            ...FONTS.h3,
                            fontWeight: '400',
                            color: COLORS.black
                        }}
                    >
                        Bùi Quang
                    </Text>

                    {/* Km */}
                    <Text
                        style={{
                            color: COLORS.gray,
                            ...FONTS.body4
                        }}
                    >
                        Khoảng cách 1.2 Km
                    </Text>
                </View>

                {/* Sao cho người bán hàng */}
                <Ratting
                    ratting={4}
                    iconStyle={{
                        marginLeft: 3
                    }}
                />
            </View>
        )
    }

    // Footer
    const renderFooter = () => {
        return (
            <View
                style={{
                    flexDirection: 'row',
                    height: 120,
                    alignItems: 'center',
                    paddingHorizontal: SIZES.padding,
                    paddingBottom: SIZES.radius
                }}
            >
                {/* Tăng giảm sản phẩm */}
                <StepperInput
                    value={qty}
                    onAdd={() => setQty(qty + 1)}
                    onMinus={() => {
                        if (qty > 1) {
                            setQty(qty - 1)
                        }
                    }}
                />
                <TextButton
                    buttonContainerStyle={{
                        flexDirection: 'row',
                        backgroundColor: COLORS.primary,
                        marginLeft: SIZES.padding,
                        height: 60,
                        width: 230,
                        justifyContent: 'space-between',
                        borderRadius: SIZES.radius,
                    }}
                    lableStyle={{
                        color: COLORS.white,
                        marginLeft: 30,
                        marginRight: 25
                    }}
                    lable='Buy Now'
                    lable2='150.000 VNĐ'
                    onPress={() => navigation.navigate('MyCart')}
                />

            </View>
        )
    }

    return (
        <View
            style={{
                flex: 1,
                backgroundColor: COLORS.white
            }}
        >
            {/* Header */}
            {renderHeader()}


            {/* Body */}
            <ScrollView
                showsVerticalScrollIndicator={false}
            >
                {/* Render Food */}
                {renderDetails()}

                <LineDivider />

                {/* Nhà hàng */}
                {renderRestaurant()}

            </ScrollView>

            {/* Footer */}
            <LineDivider />

            {renderFooter()}
        </View>
    )
}

export default FoodDetail

const styles = StyleSheet.create({
    headerStyle: {
        width: 40,
        height: 40,
        color: COLORS.black,
        justifyContent: 'space-between',
        alignItems: 'center',
    }
})