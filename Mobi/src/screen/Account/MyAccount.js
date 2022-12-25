import { StyleSheet, Text, View, Image, ScrollView } from 'react-native'
import React from 'react'

import { COLORS, FONTS, icons, images, SIZES } from '../../constants'
import { Header, IconButton, LineDivider, MyAccountInfomation, TextButton, TextIconButton } from '../../components'
import dummyData from '../../constants/dummyData'
import AsyncStorage from '@react-native-async-storage/async-storage'


const MyAccount = ({ navigation }) => {
    const [userInfomation, setUserInfomation] = React.useState({});
    const [userId, setUserId] = React.useState('');

    React.useEffect(() => {
        async function GetItem() {
            const Id = await AsyncStorage.getItem('userId');
            setUserId(Id);
            console.log(Id);
            setUserInfomation(dummyData?.myProfile);
        }
        GetItem();
    }, [])

    const LogOut = async () => {
        await AsyncStorage.removeItem('Token');
        await AsyncStorage.removeItem('userId');
        await AsyncStorage.removeItem('userName');

        navigation.navigate('SignIn');

    }

    const renderHeader = () => {
        return (
            <Header
                title={"Thông tin tài khoản"}
                containerStyle={{
                    height: 50,
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
            />
        )
    }

    const renderUserInfomation = () => {
        return (
            <View
                style={{
                    alignItems: 'center'
                }}
            >
                <Image
                    source={userInfomation.image}
                    style={{
                        marginTop: SIZES.radius,
                        marginBottom: SIZES.radius,
                        width: 120,
                        height: 120,
                        borderRadius: 60,
                        borderWidth: 2,
                        borderColor: COLORS.transparentPrimray
                    }}
                />
                <View
                    style={{
                        justifyContent: 'center',
                        alignItems: 'center',
                        borderWidth: 2,
                        borderColor: COLORS.primary,
                        backgroundColor: COLORS.transparentPrimray,
                        width: SIZES.width - 2 * SIZES.base,
                        height: 60,
                        marginBottom: 15,
                        borderRadius: SIZES.radius
                    }}
                >
                    <Text
                        style={{
                            fontWeight: '700',
                            fontSize: 17,
                            color: COLORS.white
                        }}
                    >
                        Mã Id: {userId}
                    </Text>
                </View>
                <MyAccountInfomation
                    label="Tên"
                    text={userInfomation.name}
                    textType="Text"
                    check={true}
                    onPress={() => navigation.navigate('ChangeEmail')}
                />
                <MyAccountInfomation
                    label="Số điện thoại"
                    text={userInfomation.phone}
                    textType="Text"
                    check={true}
                />
                <MyAccountInfomation
                    label="Địa chỉ Email"
                    text={userInfomation.email}
                    textType="Text"
                    check={true}
                    onPress={() => navigation.navigate('ChangeEmail')}
                />
                <MyAccountInfomation
                    label="Giới tính"
                    textType="Text"
                />
                <MyAccountInfomation
                    label="Ngày sinh"
                    textType="DD/MM/YYYY"
                />
                <MyAccountInfomation
                    label="Nghề nghiệp"
                    textType="DD/MM/YYYY"
                />


                <Text
                    style={{
                        width: '100%',
                        marginLeft: SIZES.radius,
                        color: COLORS.red,
                        fontWeight: '600',
                        ...FONTS.h3
                    }}
                >
                    * Không chia sẻ những thông tin này cho ai ngoài bạn
                </Text>
            </View>
        )
    }

    return (
        <View
            style={{
                flex: 1,
                backgroundColor: COLORS.white,
                paddingHorizontal: SIZES.base,
                marginBottom: SIZES.base
            }}
        >
            <Image
                source={images.noen}
                style={{
                    position: 'absolute',
                    width: SIZES.width,
                    marginTop: 55
                }}
            />
            {/* header */}
            {renderHeader()}

            <ScrollView
                showsVerticalScrollIndicator={false}
            >
                {renderUserInfomation()}

                <TextIconButton
                    icon={icons.changePassword}
                    iconStyle={{
                        width: 25,
                        height: 25,
                        marginLeft: SIZES.base,
                        tintColor: COLORS.white
                    }}
                    label="Đổi mật khẩu..."
                    lableStyle={{
                        color: COLORS.white,
                        ...FONTS.h2
                    }}
                    containerStyle={{
                        backgroundColor: COLORS.primary,
                        height: 50,
                        borderRadius: SIZES.radius,
                        marginVertical: SIZES.radius
                    }}
                    onPress={() => navigation.navigate('ChangePassword')}
                />

                <TextIconButton
                    icon={icons.logout}
                    iconStyle={{
                        width: 25,
                        height: 25,
                        marginLeft: SIZES.radius
                    }}
                    label="Đăng xuất..."
                    lableStyle={{
                        color: COLORS.white,
                        ...FONTS.h2
                    }}
                    containerStyle={{
                        backgroundColor: COLORS.primary,
                        height: 50,
                        borderRadius: SIZES.radius,
                        marginBottom: SIZES.radius
                    }}
                    onPress={() => LogOut()}

                />
            </ScrollView>
        </View>
    )
}

export default MyAccount

const styles = StyleSheet.create({})