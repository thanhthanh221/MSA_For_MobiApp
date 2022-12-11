import { BackHandler, Image, StyleSheet, Text, View } from 'react-native'
import React from 'react'

import { COLORS, FONTS, images, SIZES } from '../../constants'
import { TextButton } from '../../components'

const Success = ({ navigation }) => {
  React.useEffect(() => {
    const backHandler = BackHandler.addEventListener(
      'hardwareBackPress', () => { return true }
    )
    return () => backHandler.remove();
  }, [])
  return (
    <View
      style={{
        flex: 1,
        backgroundColor: COLORS.white,
        paddingHorizontal: SIZES.padding
      }}
    >
      <View
        style={{
          flex: 1,
          alignItems: 'center',
          justifyContent: 'center'
        }}
      >
        <Image
          source={images.success}
          resizeMode='contain'
          style={{
            width: 150,
            height: 150
          }}
        />

        <Text
          style={{
            marginTop: SIZES.padding,
            ...FONTS.h1,
            fontWeight: 'bold',
            color: COLORS.black
          }}
        >
          Chúc mừng !
        </Text>

        <Text
          style={{
            textAlign: 'center',
            marginTop: SIZES.base,
            color: COLORS.darkGray,
            ...FONTS.body3,
            fontWeight: '400'
          }}
        >
          Thanh toán thành công cho đơn hàng
        </Text>
      </View>

      <TextButton
        lable={"Xong!"}
        buttonContainerStyle={{
          height: 55,
          marginBottom: SIZES.padding,
          backgroundColor: COLORS.primary,
          borderRadius: SIZES.radius
        }}
        lableStyle={{
          color: COLORS.white,
          ...FONTS.h3,
          fontWeight: 'bold'
        }}
        onPress={() => navigation.navigate("DeliveryStatus")}
      />
    </View>
  )
}

export default Success

const styles = StyleSheet.create({})