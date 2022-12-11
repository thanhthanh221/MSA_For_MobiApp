import { StyleSheet, Text, View, FlatList, Image } from 'react-native'
import React from 'react'

import { COLORS, constants, icons, SIZES } from '../../constants'
import { Header, IconButton, LineDivider } from '../../components'
import TextIconButton from '../../components/TextIconButton'

const Settings = ({ navigation }) => {
    const renderHeader = () => {
        return (
            <Header
                title="CÀI ĐẶT"
                containerStyle={{
                    height: 50,
                    marginHorizontal: SIZES.padding,
                    marginTop: 15,
                    marginBottom: 10
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
                        icon={icons.menu}
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
                    />
                }

            />
        )
    }

    const renderBody = () => {
        return (
            <View
                style={{
                    flex: 1,
                    paddingHorizontal: SIZES.padding,
                    borderRadius: SIZES.radius,
                    marginTop: SIZES.radius,
                }}
            >
                <FlatList
                    data={constants.Settings}
                    renderItem={({ item, index }) => {
                        return (
                            <View>
                                <TextIconButton
                                    icon={item.icon}
                                    iconPosition='LEFT'
                                    label={item.label}
                                    lableStyle={{
                                        color: COLORS.black,
                                        fontWeight: '400',
                                    }}
                                    iconStyle={{
                                        width: 25,
                                        height: 25,
                                        tintColor: COLORS.primary,
                                        marginRight: SIZES.base * 5,
                                        left: SIZES.base * 2
                                    }}
                                    containerStyle={{
                                        backgroundColor: COLORS.lightGray2,
                                        justifyContent: 'flex-start',
                                        height: 60,
                                        borderRadius: SIZES.radius
                                    }}
                                    onPress={() => navigation.navigate(item.onPress)}
                                />
                                <LineDivider
                                    lineStyle={{
                                        backgroundColor: COLORS.white,
                                        marginVertical: SIZES.radius / 2
                                    }}
                                />
                            </View>
                        )
                    }}
                />
            </View>
        )
    }
    return (
        <View
            style={{
                backgroundColor: COLORS.white,
                flex: 1
            }}
        >
            {/* Header */}
            {renderHeader()}

            {/* Render Body */}
            {renderBody()}

        </View>
    )
}

export default Settings

const styles = StyleSheet.create({
    x: {
        fontWeight: '400',
        justifyContent: 'flex-start',
    }
})