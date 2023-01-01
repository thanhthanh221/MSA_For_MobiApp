import { StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { COLORS, FONTS, SIZES, icons } from '../../constants'
import { Header, IconButton, TextIconButton } from '../../components'

const AccountLayout = (
    { title, buttonTitle, titleContainerStyle, children, onPress, navigation, disabled}) => {
    return (
        <View
            style={{
                flex: 1,
                paddingVertical: SIZES.radius,
                backgroundColor: COLORS.white,
                paddingHorizontal: SIZES.radius
            }}
        >
            <Header
                title={title}
                containerStyle={titleContainerStyle}
                leftComponent={
                    <IconButton
                        icon={icons.back}
                        iconStyle={{
                            tintColor: COLORS.black
                        }}
                        onPress={() => navigation.navigate("MyAccount")}
                    />
                }
            />
            {/* Line */}
            <View
                style={{
                    width: '100%',
                    height: 1,
                    backgroundColor: COLORS.darkGray,
                    marginTop: SIZES.radius,
                }}
            />
            <View
                style={{
                    flex: 1,
                    backgroundColor: COLORS.white
                }}
            >
                {children}
            </View>
            <TextIconButton
                icon={icons.save}
                disabled={disabled}
                iconStyle={{
                    width: 20,
                    height: 20,
                    marginLeft: SIZES.radius,
                    tintColor: COLORS.white
                }}
                label={`${buttonTitle}...`}
                lableStyle={{
                    color: COLORS.white,
                    ...FONTS.h2
                }}
                containerStyle={{
                    backgroundColor: disabled ? COLORS.transparentPrimray : COLORS.primary,
                    height: 55,
                    borderRadius: SIZES.radius,
                    marginBottom: SIZES.radius
                }}
                onPress={onPress}
            />
        </View>
    )
}

export default AccountLayout

const styles = StyleSheet.create({})