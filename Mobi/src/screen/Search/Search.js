import {
  StyleSheet,
  Text,
  View,
  Image,
  ScrollView,
  TouchableOpacity,
  TextInput
} from 'react-native';
import React from 'react';

import { FONTS, COLORS, SIZES, icons, images, theme, constants } from '../../constants'
import dummyData from '../../constants/dummyData';
import {
  Header,
  IconButton,
  TextIconButton
} from '../../components'
import FilterModal from '../Home/FilterModal';
import CategoryApi from '../../services/CategoryApi';
import { RequestLocationPermission } from '../../services';

const Search = ({ navigation, setSelectedTab }) => {

  const [showFilterModal, setShowFilterModal] = React.useState(false);
  const [Category, SetCategory] = React.useState([]);
  const [Location, setLocation] = React.useState('');

  React.useEffect(() => {
    RequestLocationPermission();
    const GetAllCategory = async () => {
      const response = await CategoryApi.GetAllCategory();
      SetCategory(response.data.data);
    }
    setLocation("Vĩnh Bảo - Hải Phòng")
    GetAllCategory();
  }, []);


  const renderSearch = () => {
    return (
      <View>
        <View
          style={{
            marginVertical: 10,
            flexDirection: 'row',
            justifyContent: 'space-between'
          }}
        >
          <TextIconButton
            icon={icons.location_pin}
            iconStyle={{
              width: 30,
              height: 30
            }}
            iconPosition='LEFT'
            label={Location}
            lableStyle={{
              fontSize: 18,
              fontWeight: '700',
              color: COLORS.primary,
              marginLeft: 5,
              width: SIZES.width * 0.7,
              ...SIZES.h3
            }}
          />
          <View
            style={{
              flexDirection: 'row'
            }}
          >
            <IconButton
              icon={icons.message}
              containerStyle={{
                justifyContent: 'center',
                alignItems: 'center'
              }}
              iconStyle={{
                tintColor: COLORS.darkBlue,
                width: 23,
                height: 23,
                marginRight: 15
              }}
            />
            <IconButton
              icon={icons.menu}
              containerStyle={{
                justifyContent: 'center',
                alignItems: 'center'
              }}
              iconStyle={{
                tintColor: COLORS.darkBlue,
                width: 23,
                height: 23,
                marginRight: 5,
              }}
              onPress={() => navigation.navigate("ViewAccount")}
            />
          </View>
        </View>
        <View
          style={{
            flexDirection: 'row',
            height: 40,
            backgroundColor: COLORS.lightGray2,
            marginVertical: SIZES.base,
            marginHorizontal: SIZES.padding,
            paddingHorizontal: SIZES.radius,
            borderRadius: SIZES.radius,
            alignItems: 'center',
            borderColor: COLORS.primary,
            borderWidth: 2
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
              height: 60,
              justifyContent: 'center',
              alignContent: 'center',
              ...FONTS.h3
            }}
            placeholder='Tìm kiếm sản phẩm'
          />

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
      </View>
    )
  }

  const SearchCategory = () => {
    return (
      <View>
        <View
          style={{
            width: 180,
            height: 50,
            borderWidth: 2,
            borderColor: COLORS.transparentPrimray,
            borderRadius: SIZES.padding,
            alignItems: 'center',
            justifyContent: 'flex-start',
            marginVertical: 20,
            flexDirection: 'row'
          }}
        >
          <Image
            source={icons.category}
            style={{
              marginLeft: SIZES.radius,
              width: 40,
              height: 40
            }}
          />

          {/* Text */}
          <Text
            style={{
              marginLeft: SIZES.radius,
              fontSize: 21,
              color: COLORS.black
            }}
          >
            Danh mục
          </Text>
        </View>

        <View
          style={{
            flexDirection: 'row',
            // hết là xuống dòng
            flexWrap: 'wrap',
            justifyContent: 'flex-end',

          }}
        >
          {
            Category.map((item, index) => {
              return (
                <View
                  key={"SX" + item.id + index}
                  style={{
                    flexDirection: 'column',
                    alignItems: 'center',
                    justifyContent: 'center',
                    marginBottom: 20,
                  }}
                >
                  <IconButton
                    network={true}
                    icon={`http://10.0.2.2:5027/CategoryService/Category/CategoryIcon/${item.id}`}
                    containerStyle={{
                      width: SIZES.width * 0.23,
                      height: 60,
                      alignItems: 'center'
                    }}
                    iconStyle={{
                      height: 45,
                      width: 45
                    }}
                    onPress={() => navigation.navigate("SearchProduct",
                      {
                        "CategoryId": item.id,
                        "CategoryName": item.name
                      }
                    )}
                  />

                  <Text
                    style={{
                      fontWeight: '600',
                      color: COLORS.black,
                      fontSize: 16,
                    }}
                  >
                    {item.name}
                  </Text>
                </View>
              )
            })
          }
        </View>

      </View>
    )
  }

  const muchSoughtAfter = () => {
    return (
      <View>
        <Text
          style={{
            fontSize: 20,
            fontWeight: 'bold',
            color: COLORS.black,
          }}
        >
          Được Tìm kiếm nhiều nhất
        </Text>

      </View>
    )
  }

  const lineBack = () => {
    return (
      <View
        style={{
          height: 2,
          marginVertical: SIZES.radius,
          backgroundColor: COLORS.lightGray1,
        }} />
    )
  }

  const CouponsSearch = () => {
    return (
      <View
        style={{
          height: 46,
          width: theme.SIZES.width - 2 * SIZES.radius,
          borderColor: COLORS.transparentPrimray,
          borderWidth: 2,
          justifyContent: 'space-between',
          alignItems: 'center',
          borderRadius: SIZES.radius,
          marginVertical: 15,
          flexDirection: 'row',
          backgroundColor: COLORS.white
        }}>
        <TextIconButton
          icon={icons.couponsUser}
          iconStyle={{
            width: 40,
            height: 40,
            marginRight: 15
          }}
          containerStyle={{
            height: 45,
            width: theme.SIZES.width * 0.7,
            justifyContent: 'flex-start',
            borderRadius: SIZES.radius,
            marginLeft: 15
          }}
          label={"Lấy mã giảm giá nè bạn !"}
          lableStyle={{
            marginLeft: 3,
            fontWeight: '400',
            color: COLORS.primary,
            marginVertical: 10,
            ...FONTS.h3

          }}
          iconPosition="LEFT"
          onPress={() => setSelectedTab(constants.screens.coupons)}
        />
        <Image
          source={icons.backRight}
          style={{
            width: 30,
            height: 30,
            tintColor: COLORS.primary,
            marginRight: 15
          }}
        />
      </View>
    )
  }
  return (
    <View
      style={{
        flex: 1,
        paddingHorizontal: SIZES.radius,
        paddingTop: SIZES.base
      }}
    >
      <Image
        source={images.noen}
        style={{
          position: 'absolute',
          width: SIZES.width,
        }}
      />
      {renderSearch()}

      {/* Filter */}
      {
        showFilterModal &&
        <FilterModal
          navigation={navigation}
          isVisible={showFilterModal}
          onClose={() => setShowFilterModal(false)}
        />
      }

      <ScrollView>
        {lineBack()}

        {/* much sought after */}
        {muchSoughtAfter()}

        {SearchCategory()}

        {CouponsSearch()}
      </ScrollView>

    </View>
  )
}

export default Search

const styles = StyleSheet.create({})