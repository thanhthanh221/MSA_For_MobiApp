import { StyleSheet, Text, View } from 'react-native'
import React from 'react';
import SplashScreen from 'react-native-splash-screen'
import { createStackNavigator } from '@react-navigation/stack';
import { NavigationContainer } from '@react-navigation/native';
import { applyMiddleware, createStore } from 'redux'
import { Provider } from 'react-redux'
import thunk from 'redux-thunk';

import RootReducer from './src/stores/RootReducer';
import OnBoarding from './src/screen/OnBoarding/OnBoarding';
import SignIn from './src/screen/Authentication/SignIn';
import SignUp from './src/screen/Authentication/SignUp';
import Otp from './src/screen/Authentication/Otp';
import ForgotPassword from './src/screen/Authentication/ForgotPassword';
import FoodDetail from './src/screen/Food/FoodDetail';
import { AddCard, ChangeDateOfBirth, ChangeEmail, ChangeJob, ChangeName, ChangePassword, ChangePhone, ChangeSex, Checkout, Coupon, DeliveryStatus, Home, Map, MyAccount, MyCard, MyCart, Settings, Success, ViewCoupon } from './src/screen';
import CustomTabBottom from './src/navigation/CustomTabBottom';

const store = createStore(RootReducer, applyMiddleware(thunk));

const Stack = createStackNavigator();

const App = () => {
  React.useEffect(() => {
    SplashScreen.hide();
  }, [])

  return (
    <Provider store={store}>
      <NavigationContainer>
        <Stack.Navigator
          initialRouteName='MyAccount'
          screenOptions={{ headerShown: false }}
        >
          <Stack.Screen
            name='Settings'
            component={Settings}
          />
          <Stack.Screen
            name='MyAccount'
            component={MyAccount}
          />
          <Stack.Screen
            name='FoodDetail'
            component={FoodDetail}
          />
          <Stack.Screen
            name='ChangePassword'
            component={ChangePassword}
          />
          <Stack.Screen
            name='Map'
            component={Map}
          />
          <Stack.Screen
            name='Success'
            component={Success}
          />
          <Stack.Screen
            name='DeliveryStatus'
            component={DeliveryStatus}
          />
          <Stack.Screen
            name='MyCart'
            component={MyCart}
          />
          <Stack.Screen
            name='MyCard'
            component={MyCard}
          />
          <Stack.Screen
            name='AddCard'
            component={AddCard}
          />
          <Stack.Screen
            name='CheckOut'
            component={Checkout}
          />
          <Stack.Screen
            name='OnBoarding'
            component={OnBoarding}
          />
          <Stack.Screen
            name='SignIn'
            component={SignIn}
          />
          <Stack.Screen
            name='Otp'
            component={Otp}
          />
          <Stack.Screen
            name='ForgotPassword'
            component={ForgotPassword}
          />
          <Stack.Screen
            name='Home'
            component={CustomTabBottom}
          />
          <Stack.Screen
            name='SignUp'
            component={SignUp}
          />
          <Stack.Screen
            name='CouponLayout'
            component={Coupon}
          />
          <Stack.Screen
            name='DetailCoupon'
            component={ViewCoupon}
          />
          <Stack.Screen
            name='ChangeEmail'
            component={ChangeEmail}
          />
          <Stack.Screen
            name='ChangeSex'
            component={ChangeSex}
          />
          <Stack.Screen
            name='ChangeDateOfBirth'
            component={ChangeDateOfBirth}
          />
          <Stack.Screen
            name='ChangeJob'
            component={ChangeJob}
          />
          <Stack.Screen
            name='ChangeName'
            component={ChangeName}
          />
          <Stack.Screen
            name='ChangePhone'
            component={ChangePhone}
          />
        </Stack.Navigator>
      </NavigationContainer>
    </Provider>
  )
}

export default App

const styles = StyleSheet.create({})