import { StyleSheet, Text, View, Image, ScrollView } from 'react-native'
import React from 'react';
import { useFocusEffect } from '@react-navigation/native';

import { COLORS, FONTS, icons, images, SIZES } from '../../constants'
import { Header, IconButton, MyAccountInfomation, TextButton, TextIconButton } from '../../components'
import AsyncStorage from '@react-native-async-storage/async-storage'
import IdentityApi from '../../services/IdentityApi'
import { LoginManager } from 'react-native-fbsdk-next';
import { GoogleSignin } from '@react-native-google-signin/google-signin';


const MyAccount = ({ navigation }) => {
    const [userInfomation, setUserInfomation] = React.useState({});

    useFocusEffect(
        React.useCallback(() => {
            async function GetItem() {
                const response = await IdentityApi.UserInfomation();
                if (response.status == 200) {
                    setUserInfomation(response.data);
                }
            }
            GetItem();
        }, [])
    );


    const LogOut = async () => {
        await AsyncStorage.removeItem('Token');
        await AsyncStorage.removeItem('userId');
        await AsyncStorage.removeItem('userName');
        LoginManager.logOut();
        GoogleSignin.configure();
        await GoogleSignin.signOut();
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
                    source={images.userfake}
                    style={{
                        marginTop: SIZES.radius,
                        marginBottom: SIZES.padding,
                        width: 120,
                        height: 120,
                        borderRadius: 60,
                        borderWidth: 2,
                        borderColor: COLORS.transparentPrimray,
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
                        Mã Id: {userInfomation?.id}
                    </Text>
                </View>
                <MyAccountInfomation
                    label="Tên Tài khoản"
                    text={userInfomation?.userName}
                    textNull="-Chọn-"
                    onPress={() => navigation.navigate('ChangeName', {
                        userName: userInfomation?.userName
                    })}
                />
                <MyAccountInfomation
                    label="Số điện thoại"
                    text={userInfomation.phoneInfomation?.phone}
                    textNull="-Chọn-"
                    check={userInfomation.phoneInfomation?.phoneConfirmed}
                    onPress={() => navigation.navigate('ChangePhone')}
                />
                <MyAccountInfomation
                    label="Địa chỉ Email"
                    text={userInfomation.emailInfomation?.email}
                    textNull="-Chọn-"
                    check={userInfomation.emailInfomation?.emailConfirmed}
                    onPress={() => navigation.navigate('ChangeEmail', {
                        email: userInfomation.emailInfomation?.email,
                        emailConfirmed: userInfomation.emailInfomation?.emailConfirmed,
                    })}
                />
                <MyAccountInfomation
                    text={userInfomation?.sex == null ? null : (userInfomation?.sex ? "Nữ" : "Nam")}
                    label="Giới tính"
                    textNull={"-Chọn-"}
                    onPress={() => navigation.navigate('ChangeSex', {
                        sex: userInfomation?.sex
                    })}
                />
                <MyAccountInfomation
                    text={userInfomation?.dateOfBirth ? userInfomation?.dateOfBirth?.slice(8, 10)
                        + "/ " + userInfomation?.dateOfBirth?.slice(5, 7)
                        + "/ " + userInfomation?.dateOfBirth?.slice(0, 4) : null}
                    label="Ngày sinh"
                    textNull="DD/MM/YYYY"
                    onPress={() => navigation.navigate("ChangeDateOfBirth", {
                        dateOfBirth: userInfomation?.dateOfBirth
                    })}
                />
                <MyAccountInfomation
                    label="Nghề nghiệp"
                    textNull="-Chọn-"
                    text={userInfomation?.job}
                    onPress={() => navigation.navigate("ChangeJob", {
                        job: userInfomation?.job
                    })}
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