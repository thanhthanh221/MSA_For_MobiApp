import { StyleSheet, Text, View, FlatList } from 'react-native'
import React from 'react'

import { COLORS, icons, SIZES } from '../../constants'
import { Header, IconButton, LineDivider, TextButton } from '../../components'
import dummyData from '../../constants/dummyData'

const MyAccount = () => {
    const renderHeader = () => {
        return (
            <Header
                title={"Thông tin cá nhân"}
                containerStyle={{
                    height: 50,
                    marginHorizontal: SIZES.padding,
                    marginTop: 15,
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
                        onPress={() => navigation.goBack()}
                    />
                }
                RightComponent={
                    <IconButton
                        icon={icons.userInfomation}
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
                        onPress={() => navigation.goBack()}
                    />

                }
            />
        )
    }
    // User Infomation 

    const userInfomation = ({lable, userInfo}) => {
        return (
            <View
                style={{
                    paddingHorizontal: SIZES.padding,
                    justifyContent: 'space-between',
                    alignItems: 'center',
                    flexDirection: 'row',
                    flex: 1
                }}
            >
                <Text
                    style={{
                        fontWeight: '400',
                        fontSize: 17,
                        color: COLORS.black
                    }}
                >
                    {lable}
                </Text>

                <Text
                    style={{
                        fontWeight: '400',
                        fontSize: 17,
                        color: COLORS.black,
                        marginLeft: 45,


                    }}
                >
                    {userInfo}
                </Text>
            </View>
        )
    }

    // Render Body

    const renderUserBody = () => {
        return (
            <View
                style={{
                    paddingHorizontal: SIZES.padding,
                    borderRadius: SIZES.radius,
                    marginTop: SIZES.radius,
                }}
            >
                <View
                    style={{
                        backgroundColor: COLORS.lightGray1,
                        height: 200,
                        borderRadius: SIZES.radius
                    }}
                >
                    {/* User Name */}

                    {/* Line For Check */}
                    <LineDivider
                        lineStyle={{
                            backgroundColor: COLORS.lightGray2,
                            paddingHorizontal: 10

                        }}
                    />

                    <View
                        style={{
                            paddingHorizontal: SIZES.padding,
                            justifyContent: 'space-between',
                            alignItems: 'center',
                            flexDirection: 'row',
                            flex: 1
                        }}
                    >
                        <Text
                            style={{
                                fontWeight: '400',
                                fontSize: 17,
                                color: COLORS.black
                            }}
                        >
                            Số điện thoại
                        </Text>

                        <Text
                            style={{
                                fontWeight: '400',
                                fontSize: 17,
                                color: COLORS.black,
                                marginLeft: 45,


                            }}
                        >
                            {dummyData.myProfile.phone}
                        </Text>
                    </View>

                    {/* Line For Check */}
                    <LineDivider
                        lineStyle={{
                            backgroundColor: COLORS.lightGray2,
                            paddingHorizontal: 10

                        }}
                    />

                    <View
                        style={{
                            paddingHorizontal: SIZES.padding,
                            justifyContent: 'flex-start',
                            alignItems: 'center',
                            flexDirection: 'row',
                            flex: 1
                        }}
                    >
                        <Text
                            style={{
                                fontWeight: '400',
                                fontSize: 17,
                                color: COLORS.black
                            }}
                        >
                            Email
                        </Text>

                        <Text
                            style={{
                                fontWeight: '400',
                                fontSize: 17,
                                color: COLORS.black,
                                marginLeft: 45,
                            }}
                        >
                            {dummyData.myProfile.email}
                        </Text>
                    </View>
                </View>
            </View>
        )
    }

    const renderInfoUserBody = () => {
        return (
            <View
                style={{
                    paddingHorizontal: SIZES.padding,
                    borderRadius: SIZES.radius,
                    marginTop: SIZES.radius,
                }}
            >
                <View
                    style={{
                        backgroundColor: COLORS.lightGray1,
                        height: 450,
                        borderRadius: SIZES.radius
                    }}
                ></View>

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
            {/* header */}
            {renderHeader()}

            {/* Body */}
            {renderUserBody()}

            {renderInfoUserBody()}
        </View>
    )
}

export default MyAccount

const styles = StyleSheet.create({
    x: {

    }
})