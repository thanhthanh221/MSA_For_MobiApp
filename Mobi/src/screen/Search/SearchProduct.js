import { FlatList, ScrollView, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { COLORS, FONTS, SIZES, constants, icons } from '../../constants'
import { Header, IconButton, TextIconButton } from '../../components'
import dummyData from '../../constants/dummyData'
import HorizontalFoodCard from '../../components/HorizontalFoodCard'

const SearchProduct = ({ navigation, route }) => {
  const [categoryName, setCategoryName] = React.useState('');
  const [listProduct, setListProduct] = React.useState([]);

  // Star
  const [rattings, setRattings] = React.useState('');

  // TimeOrder 
  const [timeOrder, setTimeOrder] = React.useState('');

  // Price
  const [minPrice, setMinPrice] = React.useState(0);
  const [maxPrice, setMaxPrice] = React.useState(0);
  React.useEffect(() => {
    setCategoryName(route?.params.CategoryName);
    setRattings(route.params.Star ? route.params.Star : '');
    setTimeOrder(route.params.TimeOrder ? route.params.TimeOrder : '');

    // SetPrice
    setMinPrice(route.params.minPrice);
    setMaxPrice(route.params.maxPrice);

    // setProduct 
    setListProduct(dummyData.listProduct)
  }, [])


  const renderHeader = () => {
    return (
      <View>
        <Header
          leftComponent={
            <IconButton
              icon={icons.back}
              iconStyle={{
                tintColor: COLORS.black
              }}
              onPress={() => navigation.pop()}
            />
          }
          title={categoryName}
        />
        <ScrollView
          horizontal={true}
          showsHorizontalScrollIndicator={false}
          style={{
            flexDirection: 'row',
            marginVertical: SIZES.radius,
          }}
        >
          {/* SS */}
          <TextIconButton
            containerStyle={{
              marginRight: SIZES.radius,
              paddingHorizontal: SIZES.radius,
              paddingVertical: 5,
              borderWidth: 1,
              borderColor: COLORS.lightGray1,
              borderRadius: 16
            }}
            icon={icons.arrowDown}
            iconStyle={{
              width: 15,
              height: 15,
              marginLeft: 3
            }}
            label={"Sắp xếp"}
            lableStyle={{
              color: COLORS.darkGray,
              fontSize: 16,
              textAlignVertical: 'center',
              fontWeight: '700',
            }}
          />

          {/* Lọc */}
          <Text
            style={{
              marginHorizontal: SIZES.radius,
              textAlignVertical: 'center',
              fontSize: 17,
              color: COLORS.primary,
              fontWeight: '600'
            }}
          >
            Lọc:
          </Text>
          <TextIconButton
            containerStyle={{
              paddingHorizontal: SIZES.radius,
              paddingVertical: 5,
              borderWidth: rattings ? 0 : 1,
              borderColor: COLORS.lightGray1,
              borderRadius: 16,
              backgroundColor: rattings ? COLORS.primary : COLORS.white
            }}
            icon={icons.star}
            iconStyle={{
              tintColor: COLORS.lightOrange,
              width: 17,
              height: 17,
              marginRight: 5,
              marginLeft: 2,
              marginBottom: 2

            }}
            label={`Đánh giá  ${rattings}`}
            lableStyle={{
              color: rattings ? COLORS.white : COLORS.darkGray,
              fontSize: 15,
              fontWeight: rattings ? '700' : '500'
            }}
          />
          {/* Khoảng tiền của sản phẩm */}
          <TextIconButton
            containerStyle={{
              marginHorizontal: SIZES.radius,
              paddingHorizontal: SIZES.base,
              paddingVertical: 5,
              borderWidth: minPrice && maxPrice ? 0 : 1,
              borderColor: COLORS.lightGray1,
              borderRadius: 16,
              backgroundColor: minPrice && maxPrice ? COLORS.primary : COLORS.white
            }}
            icon={icons.dollar}
            iconStyle={{
              width: 20,
              height: 20,
              marginLeft: 3,
              tintColor: minPrice && maxPrice ? COLORS.white : COLORS.darkGray
            }}
            label={minPrice && maxPrice ? `Giá: ${minPrice} K -> ${maxPrice} K ` : 'Giá'}
            lableStyle={{
              color: minPrice && maxPrice ? COLORS.white : COLORS.darkGray,
              fontSize: 15,
              fontWeight: minPrice && maxPrice ? '800' : '500'
            }}
          />

          {/* Thời gian đặt hàng */}
          <TextIconButton
            containerStyle={{
              paddingHorizontal: SIZES.radius,
              paddingVertical: 5,
              borderWidth: timeOrder ? 0 : 1,
              borderColor: COLORS.lightGray1,
              borderRadius: 16,
              backgroundColor: timeOrder ? COLORS.primary : COLORS.white
            }}
            icon={icons.clock}
            iconStyle={{
              tintColor: timeOrder ? COLORS.white : COLORS.darkBlue,
              width: 23,
              height: 23,
              marginLeft: 3
            }}
            label={timeOrder ? ` Thời gian chờ: ${timeOrder}'` : 'Thời gian chờ'}
            lableStyle={{
              color: timeOrder ? COLORS.white : COLORS.darkGray,
              fontSize: 15,
              fontWeight: timeOrder ? '800' : '500'
            }}
          />

          {/* Khuyến mãi */}
          <TextIconButton
            containerStyle={{
              marginHorizontal: SIZES.radius,
              paddingHorizontal: SIZES.radius,
              paddingVertical: 5,
              borderWidth: 1,
              borderColor: COLORS.lightGray1,
              borderRadius: 16
            }}
            icon={icons.discount}
            iconStyle={{
              tintColor: COLORS.primary,
              width: 22,
              height: 22,
              marginHorizontal: 5
            }}
            label={"Khuyến mãi: 15%"}
            lableStyle={{
              color: COLORS.darkGray,
              fontSize: 15,
              fontWeight: '500',
            }}
          />
        </ScrollView>
      </View>
    )
  }

  // Render Product Call Api BackEnd
  const renderProduct = () => {
    return (
      <FlatList
        data={listProduct}
        keyExtractor={item => `EE-${item.id}`}
        contentContainerStyle={{
          backgroundColor: COLORS.white,
          justifyContent: 'center',
          alignItems: 'center'
        }}
        showsVerticalScrollIndicator={false}
        renderItem={({ item, index }) => {
          return (
            <HorizontalFoodCard
              containerStyle={{
                ...styles.productStyle
              }}
              imageStyle={{
                ...styles.productImageStyle
              }}
              item={item}
              onPress={() => navigation.navigate('FoodDetail')}
            />
          )
        }}
      />
    )
  }
  return (
    <View
      style={{
        flex: 1,
        backgroundColor: COLORS.white,
        paddingVertical: SIZES.radius,
        paddingHorizontal: SIZES.radius
      }}
    >
      {renderHeader()}
      {renderProduct()}
    </View>
  )
}

export default SearchProduct

const styles = StyleSheet.create({
  productStyle: {
    height: 140,
    width: SIZES.width * 0.95,
    paddingRight: SIZES.radius,
    alignItems: 'center',
    marginVertical: SIZES.radius
  },
  productImageStyle: {
    marginTop: 35,
    height: 150,
    width: 150
  }
})