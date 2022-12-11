import { StyleSheet, Text, View, Platform, TouchableOpacity, Image } from 'react-native'
import React from 'react'
import MapView, { Marker, PROVIDER_GOOGLE } from 'react-native-maps';
import MapViewDirections from 'react-native-maps-directions';

import { COLORS, constants, FONTS, icons, images, SIZES } from '../../constants'
import dummyData from '../../constants/dummyData';
import { IconButton } from '../../components';
import LinearGradient from 'react-native-linear-gradient';

const Map = ({ navigation }) => {
  const mapView = React.useRef(null);
  const [region, setRegion] = React.useState(null);
  const [toLoc, setToLoc] = React.useState(null);
  const [fromLoc, setFromLoc] = React.useState(null);
  const [angle, setAngle] = React.useState(null);

  const [isReady, setIsReady] = React.useState()

  React.useEffect(() => {
    let initalRegion = {
      latitude: 20.7185927,
      longitude: 105.8891058,
      latitudeDelta: 0.02,
      longitudeDelta: 0.02
    }
    var destination = {
      latitude: 20.7185927,
      longitude: 105.8891058,
    }
    setToLoc(destination);
    setFromLoc(dummyData.fromLocs[0])


    setRegion(initalRegion);
  }, [])
  function renderMap() {
    return (
      <MapView
        ref={mapView}
        style={{
          flex: 1
        }}
        initialRegion={region}
      >
        {
          fromLoc &&
          <Marker
            key={'FromLoc'}
            coordinate={fromLoc}
            tracksViewChanges={false}
            rotation={angle}
          >
            <Image
              style={{
                width: 30,
                height: 30
              }}
              source={icons.navigator1}
              anchor={{ x: 0.5, y: 0.5 }}
              rotation={70}
            />
          </Marker>
        }

        {/* ToLoc */}
        {
          toLoc &&
          <Marker
            key={'ToLoc'}
            coordinate={toLoc}
            tracksViewChanges={false}
          >
            <Image
              style={{
                width: 40,
                height: 40
              }}
              source={icons.location_pin}
              anchor={{ x: 0.5, y: 0.5 }}
            />
          </Marker>
        }

        <MapViewDirections
          origin={fromLoc}
          destination={toLoc}
          apikey={constants.GOOGLE_MAP_API_KEY}
          strokeWidth={5}
          strokeColor={COLORS.primary}
          optimizeWaypoints={true}

        />
      </MapView>
    )
  }

  // Header Button
  const renderHeaderButtons = () => {
    return (
      <>
        <IconButton
          icon={icons.back}
          containerStyle={{
            position: 'absolute',
            top: SIZES.padding,
            left: SIZES.padding,
            ...styles.buttonStyle

          }}
          iconStyle={{
            width: 25,
            height: 25,
            tintColor: COLORS.gray2
          }}
          onPress={() => navigation.goBack()}
        />

        <View
          style={{
            position: 'absolute',
            top: SIZES.padding,
            right: SIZES.padding,
          }}
        >
          <IconButton
            icon={icons.globe}
            containerStyle={{
              ...styles.buttonStyle,
              marginBottom: SIZES.padding

            }}
            iconStyle={{
              width: 25,
              height: 25,
              tintColor: COLORS.gray2
            }}

          />
          <IconButton
            icon={icons.focus}
            containerStyle={{
              ...styles.buttonStyle,

            }}
            iconStyle={{
              width: 25,
              height: 25,
              tintColor: COLORS.gray2
            }}

          />
        </View>
      </>
    )
  }

  //Footer/Info
  function renderInfo() {
    return (
      <View
        style={{
          position: 'absolute',
          bottom: 0,
          width: '100%'
        }}
      >
        {/* Linear Gradient */}
        <LinearGradient
          start={{ x: 0, y: 0 }}
          end={{ x: 0, y: 1 }}
          colors={[
            COLORS.transparent,
            COLORS.lightGray1
          ]}
          style={{
            position: 'absolute',
            top: -20,
            left: 0,
            right: 0,
            height: Platform.OS === 'ios' ? 200 : 50
          }}
        />

        {/* Info Container */}
        <View
          style={{
            paddingHorizontal: SIZES.padding,
            paddingTop: SIZES.padding,
            paddingBottom: SIZES.radius * 2,
            borderTopLeftRadius: 30,
            borderTopRightRadius: 30,
            backgroundColor: COLORS.white
          }}
        >
          {/* Delivery Time */}
          <View
            style={{
              flexDirection: 'row',
              alignItems: 'center'
            }}
          >
            <Image
              source={icons.clock}
              style={{
                width: 40,
                height: 40,
                tintColor: COLORS.black
              }}
            />

            <View
              style={{
                marginLeft: SIZES.padding
              }}
            >
              <Text
                style={{
                  color: COLORS.gray,
                  ...FONTS.body4
                }}
              >
                Thời gian đặt hàng
              </Text>
              <Text
                style={{
                  ...FONTS.h3,
                  color: COLORS.black,
                  fontWeight: 'bold'
                }}
              >
                30 Phút
              </Text>
            </View>
          </View>

          {/* Address */}
          <View
            style={{
              flexDirection: "row",
              alignItems: 'center',
              marginTop: SIZES.padding
            }}
          >
            <Image
              source={icons.focus}
              style={{
                width: 40,
                height: 40,
                tintColor: COLORS.black
              }}
            />

            <View
              style={{
                marginLeft: SIZES.padding
              }}
            >
              <Text
                style={{
                  color: COLORS.gray,
                  ...FONTS.body4
                }}
              >
                Địa chỉ của bạn
              </Text>
              <Text
                style={{
                  ...FONTS.h3,
                  color: COLORS.black,
                  fontWeight: 'bold'
                }}
              >
                Thôn vực - Vân từ - Phú Xuyên - Hà nội
              </Text>
            </View>
          </View>
          {/* Người giao hàng */}
          <TouchableOpacity
            style={{
              flexDirection: 'row',
              height: 70,
              marginTop: SIZES.padding,
              borderRadius: SIZES.radius,
              paddingHorizontal: SIZES.radius,
              alignItems: 'center',
              justifyContent: 'center',
              backgroundColor: COLORS.primary
            }}
          >
            <Image
              source={images.userfake}
              style={{
                width: 40,
                height: 40,
                borderRadius: 5
              }}
            />

            <View
              style={{
                marginLeft: SIZES.radius,
                flex: 1
              }}
            >
              <Text
                style={{
                  ...FONTS.h3,
                  color: COLORS.white,
                  fontWeight: 'bold'
                }}
              >
                Bùi Quang
              </Text>
              <Text
                style={{
                  color: COLORS.white,
                  ...FONTS.body4
                }}
              >
                Người giao hàng
              </Text>
            </View>

            <View
              style={{
                height: 40,
                width: 40,
                alignItems: 'center',
                justifyContent: 'center',
                borderWidth: 1,
                borderRadius: 7,
                borderColor: COLORS.white,
                backgroundColor: COLORS.transparent
              }}
            >
              <Image
                source={icons.call}
                style={{
                  width: 30,
                  height: 30
                }}
              />

            </View>

          </TouchableOpacity>
        </View>
      </View>
    )
  }

  return (
    <View
      style={{
        flex: 1
      }}
    >
      {/* Map */}
      {renderMap()}

      {/* Header Button */}
      {renderHeaderButtons()}

      {/* Footer/ Info */}
      {renderInfo()}
    </View>
  )
}

export default Map

const styles = StyleSheet.create({
  buttonStyle: {
    borderRadius: SIZES.radius,
    backgroundColor: COLORS.white,
    justifyContent: 'center',
    alignItems: 'center',
    width: 40,
    height: 40,
  }
})