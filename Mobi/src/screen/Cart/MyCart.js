import { StyleSheet, Text, View, Image } from 'react-native';
import React from 'react';
import { SwipeListView } from 'react-native-swipe-list-view';

import { COLORS, FONTS, icons, SIZES } from '../../constants';
import { FooterTotal, Header, IconButton, StepperInput } from '../../components';
import CartQuatityButton from '../../components/CartQuatityButton';
import dummyData from '../../constants/dummyData';

const MyCart = ({ navigation }) => {
  const [myCartList, setMyCartList] = React.useState(dummyData.myCart);


  //handler Quantity
  function updateQuantityHandler(newQty, id) {
    let newMyCartList = myCartList.map(cl => (
      cl.id === id ? { ...cl, qty: newQty } : cl
    ))
    setMyCartList(newMyCartList);
  }

  //handle Remove
  function removeMyCartHandler(id) {
    let newCartList = [...myCartList]

    const index = newCartList.findIndex(cart => cart.id === id);
    newCartList.splice(index, 1);

    setMyCartList(newCartList);

  }

  // Header 
  const renderHeader = () => {
    return (
      <Header
        title={"Đơn Hàng"}
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
        RightComponent={
          <CartQuatityButton
            quantity={3}
          />
        }
      />
    )
  }

  const renderCartList = () => {
    return (
      <SwipeListView
        data={myCartList}
        keyExtractor={item => `${item.id}`}
        contentContainerStyle={{
          marginTop: SIZES.radius,
          paddingHorizontal: SIZES.padding,
          paddingBottom: SIZES.padding * 2
        }}
        // tắt khả năng vuốt xang phải
        disableRightSwipe={true}
        rightOpenValue={-75}
        renderItem={(data, rowMap) => (
          <View
            style={{
              height: 100,
              backgroundColor: COLORS.lightGray2,
              ...styles.cartItemContainer
            }}
          >
            <View
              style={{
                width: 90,
                height: 100,
                marginLeft: -10
              }}
            >
              <Image
                source={data.item.image}
                resizeMode='contain'
                style={{
                  width: '100%',
                  height: '100%',
                  position: 'absolute',
                  top: 10
                }}
              />
            </View>

            {/* Food Info */}
            <View
              style={{
                flex: 1,
              }}
            >
              {/* Name */}
              <Text
                style={{
                  ...FONTS.body3,
                  color: COLORS.black,
                  fontWeight: 'bold'
                }}
              >
                {data.item.name}
              </Text>

              {/* Price */}
              <Text
                style={{
                  ...FONTS.h3,
                  color: COLORS.primary,
                  fontWeight: 'bold'
                }}
              >
                {data.item.price}.000 VNĐ
              </Text>
            </View>

            {/* Quantity */}
            <StepperInput
              containerStyle={{
                height: 50,
                width: 125,
                backgroundColor: COLORS.white
              }}
              value={data.item.qty}
              onAdd={() => updateQuantityHandler(data.item.qty + 1, data.item.id)}
              onMinus={() => {
                if (data.item.qty > 1) {
                  updateQuantityHandler(data.item.qty - 1, data.item.id)
                }
              }}
            />
          </View>
        )}
        renderHiddenItem={(data, rowMap) => (
          <IconButton
            containerStyle={{
              flex: 1,
              justifyContent: 'flex-end',
              backgroundColor: COLORS.primary,
              ...styles.cartItemContainer
            }}
            icon={icons.delete_icon}
            iconStyle={{
              marginRight: 10
            }}
            onPress={() => removeMyCartHandler(data.item.id)}
          />
        )}
      />
    )
  }
  return (
    <View
      style={{
        flex: 1,
        backgroundColor: COLORS.white
      }}
    >

      {/* Cart List */}
      {renderCartList()}

      {/* Footer */}
      <FooterTotal
        subtotal={46}
        shippingFee={0.00}
        total={46}
        onPress={() => navigation.navigate('MyCard')}
      />
    </View>
  )
}

export default MyCart

const styles = StyleSheet.create({
  cartItemContainer: {
    flexDirection: 'row',
    alignItems: 'center',
    marginTop: SIZES.radius,
    paddingHorizontal: SIZES.radius,
    borderRadius: SIZES.radius,
  }
})