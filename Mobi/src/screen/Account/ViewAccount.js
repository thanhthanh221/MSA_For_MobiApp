import { FlatList, Image, StyleSheet, Text, TouchableOpacity, View } from 'react-native'
import React from 'react'
import { useFocusEffect } from '@react-navigation/native';

import { COLORS, FONTS, SIZES, constants, icons, images } from '../../constants'
import { Header, IconButton, LineDivider, TextIconButton, VerticalTextIconButton } from '../../components'
import AsyncStorage from '@react-native-async-storage/async-storage';

const ViewAccount = ({ navigation }) => {
    const [userName, setUserName] = React.useState('');

    useFocusEffect(
        React.useCallback(() => {
            async function GetUserName() {
                const nameUserInStorage = await AsyncStorage.getItem('userName');
                setUserName(nameUserInStorage);
            }
            GetUserName();
        }, [])
    );
    const renderHeader = () => {
        return (
            <Header
                title={"Thông tin tài khoản"}
                containerStyle={{
                    paddingVertical: SIZES.radius,
                    paddingHorizontal: SIZES.base,
                    backgroundColor: COLORS.white
                }}
                leftComponent={
                    <IconButton
                        icon={icons.back}
                        iconStyle={{
                            tintColor: COLORS.darkGray
                        }}
                        onPress={() => navigation.goBack()}
                    />
                }
            />
        )
    }
    const renderUserInfomation = () => {
        return (
            <View>
                <TouchableOpacity
                    style={{
                        marginVertical: 1,
                        flexDirection: 'row',
                        backgroundColor: COLORS.white,
                        height: 90,
                        alignItems: 'center',
                        justifyContent: 'space-between'
                    }}
                    onPress={() => navigation.navigate('MyAccount')}
                >
                    <View
                        style={{
                            alignItems: 'center',
                            flexDirection: 'row'
                        }}
                    >
                        <Image
                            source={images.userfake}
                            style={{
                                width: 70,
                                height: 70,
                                marginHorizontal: SIZES.radius
                            }}
                        />

                        {/* User Name */}
                        <Text
                            style={{
                                fontSize: 18,
                                fontWeight: '700',
                                color: COLORS.black
                            }}
                        >
                            {userName}
                        </Text>

                    </View>
                    <Image
                        source={icons.backRight}
                        style={{
                            width: 20,
                            height: 20,
                            marginRight: SIZES.padding
                        }}
                    />
                </TouchableOpacity>
                <View
                    style={{
                        flexDirection: 'row',
                        height: 70
                    }}
                >
                    {/* Favourite */}
                    <VerticalTextIconButton
                        icon={icons.order}
                        iconStyle={{
                            width: 35,
                            height: 35
                        }}
                        containerStyle={{
                            flex: 1,
                            borderRightWidth: 1,
                            borderColor: COLORS.lightGray1,
                            backgroundColor: COLORS.white
                        }}
                        label={"Đơn hàng"}
                    />
                    <VerticalTextIconButton
                        icon={icons.favourite}
                        iconStyle={{
                            tintColor: COLORS.red,
                            width: 30,
                            height: 30
                        }}
                        containerStyle={{
                            flex: 1,
                            borderRightWidth: 1,
                            borderColor: COLORS.lightGray1,
                            backgroundColor: COLORS.white
                        }}
                        label={"Yêu thích"}
                    />
                    <VerticalTextIconButton
                        icon={icons.location}
                        iconStyle={{
                            tintColor: COLORS.green,
                            width: 35,
                            height: 35
                        }}
                        containerStyle={{
                            flex: 1,
                            backgroundColor: COLORS.white
                        }}
                        label={"Địa chỉ"}
                    />
                </View>

            </View>
        )
    }
    const renderButton = () => {
        return (
            <View>
                <FlatList
                    keyExtractor={item => `MM-${item.id}`}
                    contentContainerStyle={{
                        marginVertical: SIZES.padding,
                        backgroundColor: COLORS.white
                    }}
                    showsVerticalScrollIndicator={false}
                    data={constants.labelViewAccount01}
                    renderItem={({ item, index }) => {
                        return (
                            <View>
                                <TextIconButton
                                    icon={item.icon}
                                    iconStyle={{
                                        tintColor: COLORS.black,
                                        width: 30,
                                        height: 30,
                                        marginHorizontal: SIZES.radius
                                    }}
                                    label={item.label}
                                    lableStyle={{
                                        fontWeight: '300',
                                        fontSize: 18,
                                        ...FONTS.h3
                                    }}
                                    iconPosition='LEFT'
                                    containerStyle={{
                                        backgroundColor: COLORS.white,
                                        height: 50,
                                        justifyContent: 'flex-start',
                                    }}
                                />
                                {index !== 2 &&
                                    <LineDivider
                                        lineStyle={{
                                            width: '90%',
                                            justifyContent: 'center',
                                            alignSelf: 'center',
                                            backgroundColor: COLORS.transparentPrimray
                                        }}
                                    />
                                }
                            </View>
                        )
                    }}
                />

                <FlatList
                    keyExtractor={item => `MM-${item.id}`}
                    contentContainerStyle={{
                        backgroundColor: COLORS.white
                    }}
                    showsVerticalScrollIndicator={false}
                    data={constants.labelViewAccount02}
                    renderItem={({ item, index }) => {
                        return (
                            <View>
                                <TextIconButton
                                    icon={item.icon}
                                    iconStyle={{
                                        tintColor: COLORS.black,
                                        width: 30,
                                        height: 30,
                                        marginHorizontal: SIZES.radius
                                    }}
                                    label={item.label}
                                    lableStyle={{
                                        fontWeight: '300',
                                        fontSize: 18,
                                        ...FONTS.h3
                                    }}
                                    iconPosition='LEFT'
                                    containerStyle={{
                                        backgroundColor: COLORS.white,
                                        height: 50,
                                        justifyContent: 'flex-start',
                                    }}
                                />
                                {index !== 3 &&
                                    <LineDivider
                                        lineStyle={{
                                            width: '90%',
                                            justifyContent: 'center',
                                            alignSelf: 'center',
                                            backgroundColor: COLORS.transparentPrimray
                                        }}
                                    />
                                }
                            </View>
                        )
                    }}
                />


                <TextIconButton
                    containerStyle={{
                        marginVertical: SIZES.padding,
                        height: 50,
                        width: SIZES.width,
                        justifyContent: 'space-between',
                        width: SIZES.width,
                        backgroundColor: COLORS.white
                    }}
                    label={"Phiên bản hiện tại 16.4.3"}
                    lableStyle={{
                        marginHorizontal: SIZES.radius
                    }}
                    icon={icons.backRight}
                    iconStyle={{
                        marginLeft: 150,
                        width: 20,
                        height: 20
                    }}
                />
            </View>
        )
    }
    return (
        <View
            style={{
                flex: 1,
                backgroundColor: COLORS.transparentPrimray

            }}
        >
            {renderHeader()}
            {renderUserInfomation()}

            {/* Render Button */}
            {renderButton()}

        </View>
    )
}

export default ViewAccount

const styles = StyleSheet.create({})