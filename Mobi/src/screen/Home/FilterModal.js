import {
    StyleSheet,
    Text,
    TouchableWithoutFeedback,
    View,
    Modal,
    ScrollView
} from 'react-native'
import React from 'react'
import Animated from 'react-native-reanimated';

import { FONTS, SIZES, COLORS, icons, constants } from '../../constants';
import IconButton from '../../components/IconButton';
import TwoPointSlider from '../../components/TwoPointSlider';
import TextButton from '../../components/TextButton'
import TextIconButton from '../../components/TextIconButton';
import { CategoryApi } from '../../services';


const Section = ({ containerStyle, title, children }) => {
    return (
        <View
            style={{
                marginTop: SIZES.padding,
                ...containerStyle
            }}
        >
            <Text
                style={{
                    ...FONTS.h3,
                    fontWeight: 'bold',
                    color: COLORS.black
                }}
            >
                {title}
            </Text>

            {/* Content */}
            {children}
        </View>
    )
}

const FilterModal = ({ navigation, isVisible, onClose }) => {
    const [showFilterModal, setShowFilterModal] = React.useState(isVisible);
    const modalAnimatedValue = React.useRef(new Animated.Value(0)).current;

    const [deliveryTime, setDeliveryTime] = React.useState("");
    const [rattings, setRattings] = React.useState("");

    const [listCategory, setListCategory] = React.useState([]);
    const [tags, setTags] = React.useState("");

    const [minPrice, setMinPrice] = React.useState(1);
    const [maxPrice, setMaxPrice] = React.useState(40);

    React.useState(() => {
        const CallApi = async () => {
            var res = await CategoryApi.GetAllCategory();
            if (res.status == 200 && res.data.success) {
                setListCategory(res.data.data);
            }
        }
        CallApi();
    }, [])

    React.useEffect(() => {
        if (showFilterModal) {
            Animated.timing(modalAnimatedValue, {
                toValue: 1,
                duration: 500,
                useNativeDriver: false
            }).start;
        }
        else {
            Animated.timing(modalAnimatedValue, {
                toValue: 0,
                duration: 500,
                useNativeDriver: false
            }).start;
            onClose();
        }
    }, [showFilterModal]);

    // Top Modal
    const modaY = modalAnimatedValue.interpolate({
        inputRange: [0, 1],
        outputRange: [SIZES.height * 0.15, 0]
    })

    // Update Price
    const updatePrice = (minPriceUpdate, maxPriceUpdate) => {
        setMinPrice(minPriceUpdate);
        setMaxPrice(maxPriceUpdate);
    }

    // Thời gian đặt hàng 

    const renderDeliveryTime = () => {
        return (
            <Section
                title="Thời gian đặt hàng"
                containerStyle={{ marginTop: 40 }}
            >
                <View
                    style={{
                        // dài hơn thì sẽ rơi xuống
                        flexWrap: 'wrap',
                        flexDirection: 'row'
                    }}
                >
                    {
                        constants.delivery_time.map((item, index) => {
                            return (
                                <TextButton
                                    key={`'time-${index}`}
                                    buttonContainerStyle={{
                                        ...styles.buttonContainerStyle,
                                        backgroundColor: item.value == deliveryTime
                                            ? COLORS.primary : COLORS.lightGray2
                                    }}
                                    lableStyle={{
                                        ...FONTS.h3,
                                        color: item.value === deliveryTime
                                            ? COLORS.white : COLORS.black
                                    }}
                                    lable={item.label}
                                    onPress={() => { setDeliveryTime(item.value) }}
                                />
                            )
                        })
                    }
                </View>

            </Section>
        )
    }

    // Khoảng đơn giá tiền

    const renderPricingRange = () => {
        return (
            <Section
                title={"Giá sản phẩm"}
            >
                <View style={{ alignItems: 'center' }}>
                    <TwoPointSlider
                        values={[minPrice, maxPrice]}
                        min={1}
                        max={200}
                        postfix={' k'}
                        onValuesChange={(value) => updatePrice(value[0], value[1])}
                    />

                </View>

            </Section>
        )
    }

    // Số Lượng sao
    const renderRatings = () => {
        return (
            <Section
                title='Đánh giá sản phẩm'
                containerStyle={{
                    marginTop: 40
                }}
            >
                <View
                    style={{
                        flexDirection: 'row',
                        flexWrap: 'wrap',
                        marginTop: 15
                    }}
                >
                    {
                        constants.ratings.map((item, index) => {
                            return (
                                <TextIconButton
                                    key={`R-${index}`}
                                    containerStyle={{
                                        ...styles.textIconButtonContainerStyle,
                                        backgroundColor: item.id == rattings
                                            ? COLORS.primary : COLORS.lightGray2
                                    }}
                                    label={item.label}
                                    lableStyle={{
                                        color: item.id == rattings ?
                                            COLORS.white : COLORS.gray
                                    }}
                                    icon={icons.star}
                                    iconStyle={{
                                        tintColor: item.id == rattings ?
                                            COLORS.white : COLORS.gray,
                                        width: 20,
                                        height: 20,
                                        marginLeft: SIZES.base
                                    }}
                                    onPress={() => setRattings(item.id)}
                                />
                            )
                        })
                    }
                </View>


            </Section>
        )
    }

    // Tags
    const renderTag = () => {
        return (
            <Section
                title={"Danh mục"}
            >
                <View
                    style={{
                        flexDirection: 'row',
                        // hết là xuống dòng
                        flexWrap: 'wrap'
                    }}
                >
                    {
                        listCategory?.map((item, index) => {
                            return (
                                <TextButton
                                    key={`T-${index}`}
                                    lable={item.name}
                                    lableStyle={{
                                        color: item === tags ?
                                            COLORS.white : COLORS.gray,
                                        ...FONTS.body3
                                    }}
                                    buttonContainerStyle={{
                                        ...styles.tagContainerStyle,
                                        backgroundColor: item === tags ?
                                            COLORS.primary : COLORS.lightGray2
                                    }}
                                    onPress={() => setTags(item)}
                                />
                            )
                        })
                    }

                </View>

            </Section>
        )
    }


    return (
        <Modal
            animationType='fade'
            transparent={true}
            visible={isVisible}
        >
            <View
                style={{
                    flex: 1,
                    backgroundColor: COLORS.transparentBlack7
                }}
            >
                <TouchableWithoutFeedback
                    onPress={() => setShowFilterModal(false)}
                >
                    <View
                        style={{
                            position: 'absolute',
                            left: 0,
                            right: 0,
                            top: 0,
                            bottom: 0,
                        }}
                    />

                </TouchableWithoutFeedback>

                {/* View Filter */}
                <Animated.View
                    style={{
                        flex: 1,
                        position: 'absolute',
                        left: 0,
                        top: modaY,
                        width: '100%',
                        height: '100%',
                        backgroundColor: COLORS.white,
                        padding: SIZES.padding,
                        borderTopLeftRadius: SIZES.padding,
                        borderTopRightRadius: SIZES.padding

                    }}
                >
                    {/* header */}
                    <View
                        style={{
                            flexDirection: 'row',
                            alignItems: 'center'
                        }}
                    >

                        {/* Text */}
                        <Text
                            style={{
                                flex: 1,
                                ...FONTS.h3,
                                fontSize: 20,
                                fontWeight: 'bold',
                                color: COLORS.black
                            }}
                        >
                            Tìm kiếm sản phẩm
                        </Text>

                        {/* icon buttons */}
                        <IconButton
                            containerStyle={styles.iconButton}
                            icon={icons.cross}
                            iconStyle={styles.iconStyle}
                            onPress={() => setShowFilterModal(false)}
                        />
                    </View>

                    {/* Check Up */}
                    <ScrollView
                        showsVerticalScrollIndicator={false}
                        contentContainerStyle={{
                            paddingBottom: 250
                        }}
                    >

                        {/* thời gian đặt hàng */}
                        {renderDeliveryTime()}

                        {/* khoảng giá chọn đặt hàng */}
                        {renderPricingRange()}

                        {/* Chọn Khoảng sao */}
                        {renderRatings()}

                        {/* tags */}
                        {renderTag()}
                        <View style={{ marginBottom: -40 }} />

                    </ScrollView>
                    {/* Apply Button */}
                    <View
                        style={{
                            position: 'absolute',
                            backgroundColor: COLORS.white,
                            left: 0,
                            right: 0,
                            bottom: 120,
                            height: 100,
                            paddingHorizontal: SIZES.padding,
                            paddingVertical: SIZES.base,
                            justifyContent: 'center'
                        }}
                    >
                        <TextButton
                            lable={"Tìm kiếm sản phẩm ..."}
                            buttonContainerStyle={{
                                ...styles.appLyButton,
                                backgroundColor: tags ? COLORS.primary : COLORS.transparentPrimray
                            }}
                            disabled={tags ? false : true}
                            onPress={() => navigation.navigate("SearchProduct", {
                                "CategoryId": tags.id,
                                "CategoryName": tags.name,
                                "Star": rattings,
                                "TimeOrder": deliveryTime,
                                "minPrice": minPrice,
                                "maxPrice": maxPrice
                            })}
                            lableStyle={styles.baseApply}
                        />
                    </View>
                </Animated.View>
            </View>
        </Modal>
    )
}

export default FilterModal

const styles = StyleSheet.create({
    iconButton: {
        borderRadius: 10,
        borderWidth: 2,
        borderColor: COLORS.gray2
    },
    iconStyle: {
        tintColor: COLORS.gray2
    },
    buttonContainerStyle: {
        width: '30%',
        height: 50,
        margin: 5,
        borderRadius: SIZES.base
    },
    textIconButtonContainerStyle: {
        flex: 1,
        height: 50,
        margin: 5,
        alignContent: 'center',
        borderRadius: SIZES.base
    },
    tagContainerStyle: {
        height: 50,
        margin: 5,
        paddingHorizontal: 8,
        alignItems: 'center',
        borderRadius: SIZES.base
    },
    appLyButton: {
        height: 50,
        borderRadius: SIZES.base
    },
    baseApply: {
        fontSize: 20,
        fontWeight: '600',
        alignSelf: 'center',
        color: COLORS.white
    }
})