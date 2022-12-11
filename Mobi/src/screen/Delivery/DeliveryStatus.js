import { StyleSheet, Text, View } from 'react-native'
import React from 'react'

import { COLORS, constants, FONTS, icons, SIZES } from '../../constants'
import { Header, LineDivider, TextButton } from '../../components'
import { ScrollView } from 'react-native-gesture-handler'
import { Image } from 'react-native'
import TextIconButton from '../../components/TextIconButton'

const DeliveryStatus = ({ navigation }) => {

  const [current, setCurrent] = React.useState(2);
  const renderHeader = () => {
    return (
      <Header
        title="THÔNG TIN ĐƠN HÀNG"
        containerStyle={{
          height: 50,
          marginHorizontal: SIZES.padding,
          marginTop: 15

        }}
      />
    )
  }

  //Info
  const renderInfo = () => {
    return (
      <View
        style={{
          marginTop: SIZES.radius,
          paddingHorizontal: SIZES.padding
        }}
      >
        <Text
          style={{
            textAlign: 'center',
            color: COLORS.gray,
            ...FONTS.body4,
          }}
        >
          Thời gian
        </Text>

        <Text
          style={{
            textAlign: 'center',
            ...FONTS.h2,
            color: COLORS.black,
            fontWeight: 'bold'
          }}
        >
          16/04/2022 15:20 PM
        </Text>

      </View>
    )
  }

  //renderTrackOrder
  function renderTrackOrder() {
    return (
      <View
        style={{
          marginTop: SIZES.padding,
          paddingHorizontal: SIZES.padding,
          borderRadius: SIZES.radius,
          borderWidth: 2,
          borderColor: COLORS.lightGray2,
          backgroundColor: COLORS.white2,
          paddingBottom: SIZES.padding
        }}
      >
        {/* Track Order */}
        <View
          style={{
            flexDirection: 'row',
            alignItems: 'center',
            justifyContent: 'space-between',
            marginBottom: 20,
            paddingHorizontal: SIZES.padding
          }}
        >
          <Text
            style={{
              ...FONTS.h3,
              color: COLORS.black,
              fontWeight: 'bold'
            }}
          >
            Theo dõi đơn hàng
          </Text>

          <Text
            style={{
              color: COLORS.gray,
              ...FONTS.body3
            }}
          >
            NYF836
          </Text>
        </View>

        <LineDivider
          lineStyle={{
            backgroundColor: COLORS.lightGray2
          }}
        />

        {/* Status */}
        <View
          style={{
            marginTop: SIZES.padding,
            paddingHorizontalL: SIZES.padding
          }}
        >
          {constants.track_order_status.map((item, index) => {
            return (
              <View
                key={`StatusList-${index}`}
              >
                <View
                  style={{
                    flexDirection: 'row',
                    alignItems: 'center',
                    marginVertical: -5
                  }}
                >
                  <Image
                    source={icons.check_circle}
                    style={{
                      width: 40,
                      height: 40,
                      tintColor: index <= current
                        ? COLORS.primary : COLORS.lightGray1
                    }}
                  />

                  <View
                    style={{
                      marginLeft: SIZES.radius
                    }}
                  >
                    <Text
                      style={{
                        ...FONTS.h3,
                        color: COLORS.black,
                        fontWeight: 'bold'
                      }}
                    >
                      {item.title}
                    </Text>
                    <Text style={{ ...FONTS.body4 }}>
                      {item.sub_title}
                    </Text>
                  </View>
                </View>
                {
                  index < constants.track_order_status.length - 1
                  &&
                  <View>
                    {
                      index < current &&
                      <View
                        style={{
                          height: 50,
                          width: 3,
                          marginLeft: 18,
                          backgroundColor: COLORS.primary,
                          zIndex: -1
                        }}
                      >
                      </View>
                    }
                    {
                      index >= current &&
                      <Image
                        source={icons.dotted_line}
                        resizeMode='cover'
                        style={{
                          width: 4,
                          height: 50,
                          marginLeft: 17
                        }}
                      />
                    }
                  </View>
                }

              </View>
            )
          })}

        </View>

      </View>
    )
  }

  //Footer
  const renderFooter = () => {
    return (
      <View
        style={{
          marginTop: SIZES.radius,
          marginBottom: SIZES.padding
        }}
      >
        {
          current < constants.track_order_status.length - 1
          &&
          <View
            style={{
              flexDirection: 'row',
              height: 55
            }}
          >
            {/* Cancel */}
            <TextButton
              buttonContainerStyle={{
                width: '40%',
                borderRadius: SIZES.base,
                backgroundColor: COLORS.lightGray2
              }}
              lable='Hủy Bỏ'
              lableStyle={{
                color: COLORS.primary
              }}
              onPress={() => navigation.navigate("FoodDetail")}
            />

            {/* MapView */}
            <TextIconButton
              containerStyle={{
                flex: 1,
                marginLeft: SIZES.radius,
                borderRadius: SIZES.base,
                backgroundColor: COLORS.primary,
                fontWeight: "bold"
              }}
              label={"Vị trí đơn hàng"}
              lableStyle={{
                color: COLORS.white,
                ...FONTS.h3
              }}
              icon={icons.map}
              iconPosition={'LEFT'}
              iconStyle={{
                height: 30,
                width: 30,
                marginRight: SIZES.base * 2,
                tintColor: COLORS.white
              }}
              onPress={() => navigation.navigate("Map")}
            />
          </View>
        }
        {
          current == constants.track_order_status.length - 1
          && 
          <TextButton 
          buttonContainerStyle={{
            height:55,
            borderRadius: SIZES.base,
            backgroundColor: COLORS.primary
          }}
          lable="Hoàn thành"
          lableStyle={{
            color: COLORS.white
          }}
          onPress={() => navigation.navigate("FoodDetail")}
          /> 
        }
      </View>
    )
  }
  return (
    <View
      style={{
        flex: 1,
        paddingHorizontal: SIZES.padding,
        backgroundColor: COLORS.white
      }}
    >
      {/* Header */}
      {renderHeader()}

      {/* Info */}
      {renderInfo()}

      {/* Track Order */}
      <ScrollView
        showsVerticalScrollIndicator={false}
      >
        {renderTrackOrder()}
      </ScrollView>

      {/* Footer */}
      {renderFooter()}
    </View>
  )
}

export default DeliveryStatus

const styles = StyleSheet.create({})