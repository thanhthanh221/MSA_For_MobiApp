import { Image, StyleSheet, Text, View } from 'react-native';
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view';
import React from 'react';

import { COLORS, FONTS, icons, SIZES } from '../../constants';
import { CardItem, FooterTotal, FormInput, Header, IconButton } from '../../components';
import dummyData from '../../constants/dummyData';
import { Keyboard } from 'react-native';

const Checkout = ({ navigation, route }) => {
  const [selectedCard, setSelectedCard] = React.useState('');
  const [coupon, setCoupon] = React.useState('637734h57');

  React.useState(() => {
    let { selectedCard } = route.params;
    setSelectedCard(selectedCard);
  }, [])

  function renderHeader() {
    return (
      <Header
        title={"CHECK THẺ"}
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
            onPress={() => navigation.goBack()}
          />
        }
      />
    )
  }

  function renderMyCard() {
    return (
      <View>
        {
          selectedCard && dummyData.myCards.map((item, index) => {
            return (
              <CardItem
                key={`MyCard-${item.id}`}
                item={item}
                isSelected={`${selectedCard?.key}-${selectedCard?.id}` == `MyCard-${item.id}`}
                onPress={() => setSelectedCard({ ...item, key: 'MyCard' })}
              />
            )
          })
        }
      </View>
    )
  }

  // Addres
  function renderDeliveryAddr() {
    return (
      <View
        style={{
          marginTop: SIZES.padding
        }}
      >
        <Text
          style={{
            ...FONTS.h3,
            fontWeight: 'bold',
            color: COLORS.black
          }}
        >
          Địa chỉ nhận...
        </Text>

        <View
          style={{
            flexDirection: 'row',
            alignItems: 'center',
            marginTop: SIZES.radius,
            paddingVertical: SIZES.radius,
            paddingHorizontal: SIZES.padding,
            borderWidth: 2,
            borderRadius: SIZES.radius,
            borderColor: COLORS.lightGray2
          }}
        >
          <Image
            source={icons.location1}
            style={{
              height: 40,
              width: 40
            }}
          />

          <Text
            style={{
              marginLeft: SIZES.radius,
              width: '85%',
              ...FONTS.body3,
              color: COLORS.black,
              fontWeight: 'bold'
            }}
          >
            Quyết Tiến - Bảo Hà - Đồng Minh - Vĩnh Bảo - Hải Phòng
          </Text>
        </View>

      </View>
    )
  }

  function renderCoupon() {
    return (
      <View
        style={{
          marginTop: SIZES.padding
        }}
      >
        <Text
          style={{
            ...FONTS.h3,
            color: COLORS.black,
            fontWeight: 'bold'
          }}
        >
          Mã giảm giá
        </Text>

        <FormInput
          value={coupon}
          inputStyle={{
            marginTop: 0,
            width: '100%',
            paddingLeft: SIZES.padding,
            paddingRight: 0,
            borderWidth: 2,
            borderColor: COLORS.lightGray2,
            backgroundColor: COLORS.white,
            borderRadius: SIZES.radius,
            overflow: 'hidden'
          }}
          onChange={setCoupon}
          appendComponent={
            <View
              style={{
                width: 70,
                alignItems: 'center',
                justifyContent: 'center',
                backgroundColor: COLORS.primary,
                borderTopRightRadius: SIZES.radius,
                borderBottomRightRadius: SIZES.radius
              }}
            >
              <Image
                source={icons.discount}
                style={{
                  width: 40,
                  height: 40,
                }}
              />
            </View>
          }
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
      {renderHeader()}

      <KeyboardAwareScrollView
        keyboardDismissMode='on-drag'
        extraScrollHeight={-200}
        keyboardShouldPersistTaps='handled'
        contentContainerStyle={{
          flexGrow: 1,
          paddingHorizontal: SIZES.padding,
          paddingBottom: 20
        }}
      >
        {/* My Cards */}
        {renderMyCard()}

        {/* Delivery Address */}
        {renderDeliveryAddr()}

        {/* Coupon */}
        {renderCoupon()}

      </KeyboardAwareScrollView>

      {/* Footer */}
      <FooterTotal
        subtotal={56}
        shippingFee={0}
        total={56}
        onPress={() => navigation.replace("Success")}
      />
    </View>
  )
}

export default Checkout

const styles = StyleSheet.create({})