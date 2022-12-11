import {
  StyleSheet,
  Text,
  View,
  TouchableOpacity,
  TouchableWithoutFeedback,
  Image,
  FlatList
} from 'react-native'
import React from 'react'
import LinearGradient from 'react-native-linear-gradient';
import Animated, {
  useAnimatedStyle,
  useSharedValue,
  withTiming
} from 'react-native-reanimated';
import { connect } from 'react-redux';

import { setSelectedTab } from '../stores/tab/TabActions';
import {
  COLORS,
  FONTS,
  SIZES,
  images,
  icons,
  constants
} from '../constants/index'
import { Header } from '../components';
import Home from './Home/Home';
import Search from './Search/Search';
import MyCart from './Cart/MyCart';
import Favourite from './Favourite/Favourite';
import Notification from './Notification/Notification';


// leftComponents

const leftComponent = (navigation) => {
  return (
    <TouchableOpacity
      style={{
        width: 40,
        height: 40,
        alignItems: 'center',
        justifyContent: 'center',
        borderWidth: 1,
        borderRadius: SIZES.radius,
        borderColor: COLORS.gray2
      }}
      onPress={() => navigation.toggleDrawer()}
    >
      <Image source={icons.menu} style={{ tintColor: COLORS.black }} />

    </TouchableOpacity>
  )
}

//RightComponents

const rightComponent = () => {
  return (
    <TouchableOpacity style={{
      width: 40,
      height: 40,
      alignItems: 'center',
      justifyContent: 'center'
    }}>
      <Image
        style={{
          width: 30,
          height: 30
        }}
        source={images.userfake} />

    </TouchableOpacity>
  )
}

// tabButton

const TabButton = ({ lable, icon, isFocused,
  onPress, innerContainerStyle, outerContainerStyle }) => {

  return (
    <TouchableWithoutFeedback
      onPress={onPress}
    >
      <Animated.View
        style={[
          {
            flex: 1,
            alignItems: "center",
            justifyContent: 'center'
          },
          outerContainerStyle
        ]}
      >
        <Animated.View
          style={[
            {
              flexDirection: 'row',
              width: '80%',
              height: 40,
              borderRadius: 25,
              alignItems: 'center',
              justifyContent: 'center'
            },
            innerContainerStyle
          ]}
        >
          <Image
            style={{
              width: 25,
              height: 25,
              tintColor: isFocused ? COLORS.white : COLORS.darkGray
            }}
            source={icon} />

          {isFocused &&
            <Text
              numberOfLines={1}
              style={{
                marginLeft: SIZES.base,
                color: COLORS.white,
                width: 76,
                ...FONTS.h3
              }}>
              {lable}
            </Text>
          }
        </Animated.View>
      </Animated.View>
    </TouchableWithoutFeedback>
  )
}



const MainLayout = (
  {
    drawerAnimationStyle,
    scale,
    borderRadius,
    navigation,
    setSelectedTab,
    selectedTab
  }) => {

  const flatListRef = React.useRef(null);

  const homeTabFlex = useSharedValue(1);
  const homeTabColor = useSharedValue(COLORS.black);

  const searchTabColor = useSharedValue(COLORS.white);
  const searchTabFlex = useSharedValue(1);

  const cartTabFlex = useSharedValue(1);
  const cartTabColor = useSharedValue(COLORS.white);

  const favouriteTabFlex = useSharedValue(1);
  const favouriteTabColor = useSharedValue(COLORS.white);

  const notificationTabFlex = useSharedValue(1);
  const notificationTabColor = useSharedValue(COLORS.white);

  const homeFlexStyle = useAnimatedStyle(() => {
    return {
      flex: homeTabFlex.value
    }
  });

  const homeColorStyle = useAnimatedStyle(() => {
    return {
      backgroundColor: homeTabColor.value
    }
  })

  const searchFlexStyle = useAnimatedStyle(() => {
    return {
      flex: searchTabFlex.value
    }
  });

  const searchColorStyle = useAnimatedStyle(() => {
    return {
      backgroundColor: searchTabColor.value
    }
  })

  const cartFlexStyle = useAnimatedStyle(() => {
    return {
      flex: cartTabFlex.value
    }
  });

  const cartColorStyle = useAnimatedStyle(() => {
    return {
      backgroundColor: cartTabColor.value
    }
  })

  const favouriteFlexStyle = useAnimatedStyle(() => {
    return {
      flex: favouriteTabFlex.value
    }
  });

  const favouriteColorStyle = useAnimatedStyle(() => {
    return {
      backgroundColor: favouriteTabColor.value
    }
  })

  const notificationFlexStyle = useAnimatedStyle(() => {
    return {
      flex: notificationTabFlex.value
    }
  });

  const notificationColorStyle = useAnimatedStyle(() => {
    return {
      backgroundColor: notificationTabColor.value
    }
  })

  React.useEffect(() => {
    setSelectedTab(constants.screens.home);
  }, [])


  React.useEffect(() => {
    if (selectedTab === constants.screens.home) {
      flatListRef?.current?.scrollToIndex({
        index: 0,
        animated: false
      })
      // duration: khoảng thời gian chuyển đổi (1/2 giây)
      homeTabFlex.value = withTiming(4, { duration: 500 })
      homeTabColor.value = withTiming(COLORS.primary, { duration: 500 });
    }
    else {
      homeTabFlex.value = withTiming(1, { duration: 500 })
      homeTabColor.value = withTiming(COLORS.white, { duration: 500 });
    }

    if (selectedTab === constants.screens.search) {
      flatListRef?.current?.scrollToIndex({
        index: 1,
        animated: false
      })
      // duration: khoảng thời gian chuyển đổi (1/2 giây)
      searchTabFlex.value = withTiming(4, { duration: 500 })
      searchTabColor.value = withTiming(COLORS.primary, { duration: 500 });
    }
    else {
      searchTabFlex.value = withTiming(1, { duration: 500 })
      searchTabColor.value = withTiming(COLORS.white, { duration: 500 });
    }

    if (selectedTab === constants.screens.cart) {
      flatListRef?.current?.scrollToIndex({
        index: 2,
        animated: false
      })
      // duration: khoảng thời gian chuyển đổi (1/2 giây)
      cartTabFlex.value = withTiming(4, { duration: 500 })
      cartTabColor.value = withTiming(COLORS.primary, { duration: 500 });
    }
    else {
      cartTabFlex.value = withTiming(1, { duration: 500 })
      cartTabColor.value = withTiming(COLORS.white, { duration: 500 });
    }

    if (selectedTab === constants.screens.favourite) {
      flatListRef?.current?.scrollToIndex({
        index: 3,
        animated: false
      })
      // duration: khoảng thời gian chuyển đổi (1/2 giây)
      favouriteTabFlex.value = withTiming(4, { duration: 500 })
      favouriteTabColor.value = withTiming(COLORS.primary, { duration: 500 });
    }
    else {
      favouriteTabFlex.value = withTiming(1, { duration: 500 })
      favouriteTabColor.value = withTiming(COLORS.white, { duration: 500 });
    }

    if (selectedTab === constants.screens.notification) {
      flatListRef?.current?.scrollToIndex({
        index: 4,
        animated: false
      })
      // duration: khoảng thời gian chuyển đổi (1/2 giây)
      notificationTabFlex.value = withTiming(4, { duration: 500 })
      notificationTabColor.value = withTiming(COLORS.primary, { duration: 500 });
    }
    else {
      notificationTabFlex.value = withTiming(1, { duration: 500 })
      notificationTabColor.value = withTiming(COLORS.white, { duration: 500 });
    }

  }, [selectedTab])

  return (
    <Animated.View
      style={{
        backgroundColor: COLORS.white,
        flex: 1,
        transform: [{
          scale: scale
        }],
        borderRadius: borderRadius
      }}>
      {/* Header */}

      {/* <Header
        containerStyle={styles.styleHeader}
        title={selectedTab.toUpperCase()}
        leftComponent={leftComponent(navigation)}
        RightComponent={rightComponent(navigation)}
      /> */}


      {/* Content */}
      {/* <View
        style={{
          flex: 1
        }}>
        <FlatList
          ref={flatListRef}
          snapToAlignment='center'
          scrollEnabled={false}
          horizontal
          keyExtractor={item => `${item.id}`}
          data={constants.bottom_tabs}
          initialScrollIndex={0}
          style={{flex:1}}
          renderItem={({ item, index }) => {
            return (
              <View>
                {item.label === constants.screens.home && <Home />}
                {item.label === constants.screens.search && <Search />}
                {item.label === constants.screens.cart && <Cart />}
                {item.label === constants.screens.favourite && <Favourite />}
                {item.label === constants.screens.notification && <Notification />}
              </View>
            )
          }}

        />

      </View> */}
      <View style={{ flex: 1 }}>
        {selectedTab === constants.screens.home && <Home />}
        {selectedTab === constants.screens.search && <Search />}
        {selectedTab === constants.screens.cart && <MyCart />}
        {selectedTab === constants.screens.favourite && <Favourite />}
      </View>

      {
        (selectedTab === constants.screens.home)
        &&
        <View
          style={{
            justifyContent: 'flex-end',
            height: 85
          }}>

          <View
            style={{
              flex: 1,
              flexDirection: 'row',
              paddingBottom: 10,
              paddingHorizontal: 5,
              borderTopRightRadius: 20,
              borderTopLeftRadius: 20,
              backgroundColor: COLORS.white
            }}>
            <TabButton
              lable={constants.screens.home}
              icon={icons.home}
              isFocused={selectedTab === constants.screens.home}
              outerContainerStyle={homeFlexStyle}
              innerContainerStyle={homeColorStyle}
              onPress={() => setSelectedTab(constants.screens.home)}
            />

            <TabButton
              lable={constants.screens.search}
              icon={icons.search}
              isFocused={selectedTab === constants.screens.search}
              onPress={() => setSelectedTab(constants.screens.search)}
            />

            <TabButton
              lable={constants.screens.cart}
              icon={icons.cart}
              isFocused={selectedTab === constants.screens.cart}
              onPress={() => setSelectedTab(constants.screens.cart)}
            />

            <TabButton
              lable={constants.screens.favourite}
              icon={icons.favourite}
              isFocused={selectedTab === constants.screens.favourite}
              onPress={() => setSelectedTab(constants.screens.favourite)}
            />

            <TabButton
              lable={constants.screens.notification}
              icon={icons.notification}
              isFocused={selectedTab === constants.screens.notification}
              onPress={() => setSelectedTab(constants.screens.notification)}
            />
          </View>
        </View>
      }
    </Animated.View >
  )
}

const styles = StyleSheet.create({
  styleHeader: {
    height: 50,
    paddingHorizontal: SIZES.padding,
    marginTop: 15,
    alignItems: 'center'
  }
})

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
export default connect(mapStateToProps, mapDispatchToProps)(MainLayout)