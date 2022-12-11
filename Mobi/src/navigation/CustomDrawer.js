import {
  Image,
  StyleSheet,
  Text,
  TouchableOpacity,
  View
} from 'react-native';
import React from 'react';
import Animated from 'react-native-reanimated';
import {
  createDrawerNavigator,
  DrawerContentScrollView,
  useDrawerStatus
} from '@react-navigation/drawer';
import { connect } from 'react-redux';

import { setSelectedTab } from '../stores/tab/TabActions';
import MainLayout from '../screen/MainLayout';
import { COLORS, SIZES, FONTS } from '../constants/theme';
import icons from '../constants/icons';
import images from '../constants/images'
import constants from '../constants/constants';


const Drawer = createDrawerNavigator();

const CustomDrawerItem = ({ lable, icon, isFocused, onPress }) => {

  return (
    <TouchableOpacity
      style={{
        flexDirection: 'row',
        height: 40,
        marginBottom: SIZES.base,
        alignItems: 'center',
        marginLeft: SIZES.radius,
        borderRadius: SIZES.base,
        backgroundColor: isFocused ? COLORS.transparentBlack1 : null
      }}
      onPress={onPress}
    >
      <Image source={icon}
        style={{
          width: 20,
          height: 20,
          tintColor: COLORS.white
        }} />
      <Text
        style={{
          marginLeft: 15,
          color: COLORS.white,
          ...FONTS.h3
        }}>{lable}</Text>

    </TouchableOpacity>
  )

}

const CustomDrawerContent = ({ navigation,
  setProgress,
  selectedTab,
  setSelectedTab }) => {

  const isDrawerOpen = useDrawerStatus();

  React.useEffect(() => {
    console.log(isDrawerOpen);
    if (isDrawerOpen === 'open') {
      setProgress(1)
    }
    else {
      setProgress(0)
    }
  }, [isDrawerOpen]);

  const navigationHandle = () => {
    navigation.closeDrawer();
  }


  return (
    <DrawerContentScrollView
      scrollEnabled={true} // có thể cuộn hay không
      contentContainerStyle={{ flex: 1 }}
      style={{ flex: 1 }}>
      {/* paddingHorizontal : padding trái phải */}
      <View
        style={{
          flex: 1,
          paddingHorizontal: SIZES.radius
        }}>

        {/* close */}
        <View
          style={{
            alignItems: 'flex-start', // căn ngang
            justifyContent: 'center', // căn dọc
          }}>
          <TouchableOpacity
            style={{
              alignItems: 'center',
              justifyContent: 'center',
            }}
            // ấn vào thì đóng drawer
            onPress={navigationHandle}>
            <Image
              source={icons.cross}
              style={{
                width: 35,
                height: 35,
                tintColor: COLORS.white
              }}
            />
          </TouchableOpacity>
        </View>

        {/* profile */}

        <TouchableOpacity
          style={{
            flexDirection: 'row',
            marginTop: SIZES.radius,
            alignItems: 'center',
          }}
          onPress={() => console.log('profile')}>
          <Image
            style={{
              width: 50,
              height: 50
            }}
            source={images.userfake} />
          <View
            style={{
              marginLeft: SIZES.radius
            }}>
            <Text
              style={{
                color: COLORS.white,
                ...FONTS.h3
              }}>Bùi Quang</Text>
            <Text
              style={{
                color: COLORS.white,
                ...FONTS.body4
              }}>Thông tin cá nhân</Text>
          </View>
        </TouchableOpacity>

        {/* Drawer Items */}

        <View style={{ flex: 1, marginTop: SIZES.padding }}>
          <CustomDrawerItem
            lable={constants.screens.home}
            icon={icons.home}
            isFocused={selectedTab == constants.screens.home}
            onPress={() => {
              setSelectedTab(constants.screens.home)
              navigation.navigate('mainLayout')
            }}

          />
          <CustomDrawerItem
            lable={constants.screens.my_wallet}
            icon={icons.wallet}
            isFocused={selectedTab == constants.screens.my_wallet}
            onPress={() => {
              setSelectedTab(constants.screens.my_wallet)
              navigation.navigate('mainLayout')
            }}
          />
          <CustomDrawerItem
            lable={constants.screens.notification}
            icon={icons.notification}
            isFocused={selectedTab == constants.screens.notification}
            onPress={() => {
              setSelectedTab(constants.screens.notification)
              navigation.navigate('mainLayout')
            }}
          />
          <CustomDrawerItem
            lable={constants.screens.favourite}
            icon={icons.favourite}
            isFocused={selectedTab == constants.screens.favourite}
            onPress={() => {
              setSelectedTab(constants.screens.favourite)
              navigation.navigate('mainLayout')
            }}
          />

          {/* Phân cách ----------*/}

          <View
            style={{
              height: 2,
              marginVertical: SIZES.radius,
              backgroundColor: COLORS.lightGray1,
              marginLeft: SIZES.base
            }} />

          <CustomDrawerItem
            lable={constants.screens.track_Your_Order}
            icon={icons.location}
            isFocused={selectedTab == constants.screens.cart}
            onPress={() => {
              setSelectedTab(constants.screens.cart)
              navigation.navigate('mainLayout')
            }}
          />
          <CustomDrawerItem
            lable={constants.screens.coupons}
            icon={icons.coupon}
            isFocused={selectedTab == constants.screens.coupons}
            onPress={() => {
              setSelectedTab(constants.screens.coupons)
              navigation.navigate('mainLayout')
            }}
          />
          <CustomDrawerItem
            lable={constants.screens.settings}
            icon={icons.setting}
            isFocused={selectedTab == constants.screens.settings}
            onPress={() => {
              navigation.navigate('Settings')
            }}
          />
          <CustomDrawerItem
            lable={constants.screens.invite_a_friend}
            icon={icons.profile}
            isFocused={selectedTab == constants.screens.profile}
            onPress={() => {
              setSelectedTab(constants.screens.profile)
              navigation.navigate('mainLayout')
            }}
          />
          <CustomDrawerItem
            lable={constants.screens.help_center}
            icon={icons.help}
            isFocused={selectedTab == constants.screens.help_center}
            onPress={() => {
              setSelectedTab(constants.screens.help_center)
              navigation.navigate('mainLayout')
            }}
          />
        </View>
        {/* đăng xuất */}

        <View style={{
          marginBottom: SIZES.padding
        }}>
          <CustomDrawerItem
            lable={constants.screens.logout}
            icon={icons.logout}
          />

        </View>

      </View>
    </DrawerContentScrollView>
  );
};

const CustomDrawer = ({ selectedTab, setSelectedTab }) => {

  const [progress, setProgress] = React.useState(new Animated.Value(0));

  const scale = Animated.interpolateNode(progress, {
    inputRange: [0, 1],
    outputRange: [1, 0.8]
  });

  const borderRadius = Animated.interpolateNode(progress, {
    inputRange: [0, 1],
    outputRange: [1, 26]
  });

  return (
    <View
      style={{
        flex: 1,
        backgroundColor: COLORS.primary,
      }}>
      <Drawer.Navigator
        initialRouteName="mainLayout"
        screenOptions={{
          overlayColor: 'transparent',
          drawerType: 'slide',
          headerShown: false,
          drawerStyle: {
            flex: 1,
            width: '60%',
            paddingRight: 20,
            // trong suốt
            backgroundColor: 'transparent',
          },
          // nội dung screen
          sceneContainerStyle: {
            backgroundColor: 'transparent',
          },
        }}
        drawerContent={props => {

          return <CustomDrawerContent
            {...props}
            navigation={props.navigation}
            setProgress={input => setProgress(input)}
            selectedTab={selectedTab}
            setSelectedTab={setSelectedTab}
          />;
        }}>
        <Drawer.Screen name="mainLayout">
          {props => <MainLayout
            {...props}
            scale={scale}
            borderRadius={borderRadius}
          />}
        </Drawer.Screen>
      </Drawer.Navigator>
    </View>
  );
};

const styles = StyleSheet.create({});

const mapStateToProps = (state) => {
  return {
    selectedTab: state.tabReducer.selectedTab
  }
}
const mapDispatchToProps = (dispatch) => {
  return {
    setSelectedTab: (selectedTab) => {
      return dispatch(setSelectedTab(selectedTab))
    }
  }
}
export default connect(mapStateToProps, mapDispatchToProps)(CustomDrawer)
