import {
  StyleSheet,
  Text,
  View,
  TouchableOpacity,
  Image,
  TextInput,
  FlatList
} from 'react-native'
import React from 'react'

import { FONTS, SIZES, COLORS, icons } from '../../constants';
import * as dummyData from '../../constants/dummyData'
import HorizontalFoodCard from '../../components/HorizontalFoodCard';
import VerticalFoodCard from '../../components/VerticalFoodCard';
import FilterModal from './FilterModal';

const Section = ({ title, onPress, children }) => {
  return (
    <View>

      {/* Header */}
      <View
        style={{
          flexDirection: 'row',
          marginHorizontal: SIZES.padding,
          marginTop: 30,
          marginBottom: 20
        }}
      >
        <Text
          style={{
            flex: 1,
            fontWeight: 'bold',
            ...FONTS.h3
          }}
        >
          {title}
        </Text>

        <TouchableOpacity
          onPress={onPress}
        >
          <Text
            style={{
              color: COLORS.primary,
              fontWeight: 'bold',
              ...FONTS.h3
            }}
          > Show All</Text>
        </TouchableOpacity>
      </View>

      {/* Content */}
      {children}

    </View>
  )

}


const Home = () => {
  const [selectedCategoryId, setSelectedCategoryId] = React.useState(1);
  const [selectedMenuType, setSelectedMenuType] = React.useState(1);

  const [recommends, setRecommends] = React.useState([]);
  const [menuList, setMenuList] = React.useState([]);

  const [popular, setPopular] = React.useState([]);

  const [showFilterModal, setShowFilterModal] = React.useState(false)

  React.useEffect(() => {
    handleChangeCategory(selectedCategoryId, selectedMenuType);
  }, [])

  // handler
  const handleChangeCategory = (categoryId, menuTypeId) => {
    //popular menu
    let selectedPopular = dummyData.default.menu
      .find(a => a.name == 'Popular')

    // tìm lấy menu đang hiện hành
    let selectedRecommend = dummyData.default.menu
      .find(a => a.name == 'Recommended')

    // tìm kiếm phần tử đầu tiên của mảng
    // tìm kiếm menu mà có id === id tìm kiếm
    let selectedMenu = dummyData.default.menu.
      find(value => value.id === menuTypeId);

    setRecommends(selectedRecommend.list.filter(a =>
      a.categories.includes(categoryId)));

    // tìm kiếm tất cả sản phẩm 
    // tất cả sản phẩm trong menu mà có danh mục có mã danh mục tìm kiếm
    setMenuList(selectedPopular?.list.filter(value =>
      value.categories.includes(categoryId)))

    //popular menu set
    setPopular(selectedMenu?.list.filter(a =>
      a.categories.includes(categoryId)));

  }

  const renderSearch = () => {
    return (
        <View
          style={{
            flexDirection: 'row',
            height: 40,
            backgroundColor: COLORS.lightGray2,
            marginVertical: SIZES.base,
            marginHorizontal: SIZES.padding,
            paddingHorizontal: SIZES.radius,
            borderRadius: SIZES.radius,
            alignItems: 'center'
          }}
        >
          {/* Icons */}

          <Image
            source={icons.search}
            style={{
              height: 20,
              width: 20,
              tintColor: COLORS.black
            }}
          />

          {/* Text button */}

          <TextInput
            style={{
              marginLeft: SIZES.radius,
              flex: 1,
              ...FONTS.h3
            }}
            placeholder='Search food' />

          {/* Filter Button */}

          <TouchableOpacity
            onPress={() => setShowFilterModal(true)}
          >
            <Image
              source={icons.filter}
              style={{
                width: 20,
                height: 20,
                tintColor: COLORS.black
              }} />
          </TouchableOpacity>
        </View>
    )
  }

  const renderMenuTypes = () => {
    return (
      <FlatList
        horizontal
        showsHorizontalScrollIndicator={false}
        data={dummyData.default.menu}
        keyExtractor={item => `C--${item.id}`}
        contentContainerStyle={{
          marginTop: 30,
          marginBottom: 20
        }}
        renderItem={({ item, index }) => {
          return (
            <TouchableOpacity
              style={{
                marginLeft: SIZES.padding,
                marginRight: index === dummyData.default.menu.length - 1 ?
                  SIZES.padding : 0
              }}
              onPress={() => {
                setSelectedMenuType(item.id)
                handleChangeCategory(selectedCategoryId, selectedMenuType)
              }}
            >
              <Text
                style={{
                  color: item.id === selectedMenuType ?
                    COLORS.primary : COLORS.black,
                  fontWeight: 'bold',
                  ...FONTS.h3
                }}
              >
                {item.name}
              </Text>

            </TouchableOpacity>
          )
        }}

      />
    )
  }
  // giới thiệu sản phẩm
  const renderRecommendedSections = () => {
    return (
      <Section
        title={'Giới thiệu sản phẩm'}
        onPress={() => {
          console.log("Tất cả sản phẩm")
        }}
      >
        <FlatList
          data={recommends}
          keyExtractor={item => `D -- ${item.id}`}
          horizontal
          showsHorizontalScrollIndicator={false}
          renderItem={({ item, index }) => (
            <HorizontalFoodCard
              containerStyle={{
                ...styles.recommends,
                marginLeft: index == 0 ? SIZES.padding : 18,
                marginRight: index == recommends.length - 1 ? SIZES.padding : 0
              }}
              imageStyle={styles.recommendsImage}
              item={item}
              onPress={() => console.log("Sản phẩm nổi trong bán hàng")}
            />
          )}
        />

      </Section>
    )
  }

  // sản phẩm nổi tiếng
  const renderPopularSection = () => {
    return (
      <Section
        title={"Sản phẩm nổi tiếng"}
        onPress={() => console.log('Show sản phẩm nổi tiếng')}
      >
        <FlatList
          data={popular}
          keyExtractor={item => `${item.id}`}
          horizontal
          showsHorizontalScrollIndicator={false}
          renderItem={({ item, index }) => {
            return (
              <VerticalFoodCard
                containerStyle={{
                  marginLeft: index === 0 ? SIZES.padding : 18,
                  marginRight: index === popular.length - 1 ? SIZES.padding : 0
                }}
                item={item}
                onPress={() => console.log('Quay ngang check')}
              />
            )
          }}

        />

      </Section>
    )
  }

  // danh mục sản phẩm
  const renderFoodCategories = () => {
    return (
      <FlatList
        data={dummyData.default.categories}
        keyExtractor={item => `${item.id}-C`}
        horizontal
        showsHorizontalScrollIndicator={false}
        renderItem={({ item, index }) => {
          return (
            <TouchableOpacity
              style={{
                flexDirection: 'row',
                height: 55,
                marginTop: SIZES.padding,
                marginLeft: index === 0 ? SIZES.padding : SIZES.radius,
                marginRight: index === dummyData.default.categories.length - 1
                  ? SIZES.padding : 0,
                paddingHorizontal: 8,
                borderRadius: SIZES.radius,
                backgroundColor: selectedCategoryId === item.id
                  ? COLORS.primary : COLORS.lightGray2
              }}
              onPress={() => {
                setSelectedCategoryId(item.id),
                  handleChangeCategory(item.id, selectedMenuType)
              }}>
              <Image
                source={item.icon}
                style={{
                  height: 50,
                  width: 50,
                  marginTop: 5
                }}
              />
              {/* name category */}
              <Text
                style={{
                  // căn giữa các phần tử mục bên trong
                  alignSelf: 'center',
                  marginRight: SIZES.base,
                  ...FONTS.h3,
                  color: selectedCategoryId === item.id
                    ? COLORS.white : COLORS.black,
                  fontWeight: 'bold'
                }}
              >
                {item.name}
              </Text>

            </TouchableOpacity>
          )
        }}
      />
    )
  }

  // vị trí vận chuyển
  const renderDeliveryTo = () => {
    return (
      <View
        style={{
          marginTop: SIZES.padding,
          marginHorizontal: SIZES.padding
        }}
      >
        <Text
          style={{
            color: COLORS.primary,
            ...FONTS.body3,
            fontWeight: '900'
          }}
        >
          Giao hàng tới
        </Text>

        {/* nút bấm */}
        <TouchableOpacity
          style={{
            flexDirection: 'row',
            marginTop: SIZES.base,
            alignItems: 'center'
          }}
        >

          {/* địa chỉ */}
          <Text
            style={{
              fontWeight: 'bold',
              ...FONTS.h3
            }}
          >
            {dummyData?.default.myProfile?.address}
          </Text>

          {/* image */}
          <Image
            source={icons.down_arrow}
            style={{
              width: 20,
              height: 20,
              marginLeft: SIZES.base
            }}
          />

        </TouchableOpacity>

      </View>
    )
  }

  return (
    <View
      style={{
        flex: 1
      }}>
      {/* Search */}
      {renderSearch()}

      {/* filer  */}
      {
        showFilterModal &&
        <FilterModal
          isVisible={showFilterModal}
          onClose={() => setShowFilterModal(false)}
        />
      }

      {/* List */}
      <FlatList
        data={menuList}
        ListHeaderComponent={
          <View>
            {/* vận chuyển tới */}
            {renderDeliveryTo()}

            {/* render danh mục sản phẩm */}
            {renderFoodCategories()}

            {/* sản phẩm yêu thích */}
            {renderPopularSection()}

            {/* giới thiệu sản phẩm */}
            {renderRecommendedSections()}

            {/* menuType */}
            {renderMenuTypes()}

          </View>
        }
        listKey={(item) => `K--${item.id}`}
        horizontal={false}
        keyExtractor={(item) => `F -- ${item.id.toString()}`}
        showsVerticalScrollIndicator={false}
        style={{ marginBottom: 10 }}
        renderItem={({ item, index }) => {
          return (
            <HorizontalFoodCard
              containerStyle={styles.flatListStyle}
              imageStyle={styles.flatListImageStyle}
              item={item}
              onPress={() => console.log("HorizontalFoodCard")}
            />
          )
        }}
      />
    </View>
  )
}

export default Home

const styles = StyleSheet.create({
  flatListStyle: {
    height: 130,
    alignItems: 'center',
    marginHorizontal: SIZES.padding,
    marginBottom: SIZES.radius,
  },
  flatListImageStyle: {
    marginTop: 20,
    height: 110,
    width: 110
  },
  recommends: {
    height: 180,
    width: SIZES.width * 0.85,
    paddingRight: SIZES.radius,
    alignItems: 'center',
  },
  recommendsImage: {
    marginTop: 35,
    height: 150,
    width: 150
  }
})