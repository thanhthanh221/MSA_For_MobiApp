import { Alert, Image, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { useFocusEffect } from '@react-navigation/native';

import AccountLayout from './AccountLayout'
import { COLORS, SIZES, icons } from '../../constants';
import { FormInput } from '../../components';
import { utils } from '../../utils';
import { IdentityApi } from '../../services';

const ChangeName = ({ navigation, route }) => {
  const [userName, setUserName] = React.useState('');
  const [userNameError, setUserNameError] = React.useState('');

  useFocusEffect(
    React.useCallback(() => {
      setUserName(route.params?.userName)
    }, [])
  );
  const CallApi = async () => {
    const response = await IdentityApi.EditExtraProfileUser({ UserName: userName })

    if (!response) { Alert.alert("Không đổi được tên!") }
  }
  const checkDis = () => {
    return userName != '' && userNameError == '';
  }
  return (
    <AccountLayout
      title={"Đổi tên"}
      buttonTitle={"Lưu"}
      navigation={navigation}
      disabled={!checkDis()}
      onPress={() => CallApi()}
    >
      <View
        style={{
          width: '100%',
          height: 135,
          backgroundColor: COLORS.lightGray1,
          marginVertical: SIZES.padding,
          borderRadius: SIZES.radius
        }}
      >
        {/* Infomation */}
        <FormInput
          lable='Tên'
          value={userName}
          placeholder={"Nhập tên của bạn"}
          onChange={(value) => {
            setUserName(value)
            utils.validateInput(value, 4, setUserNameError)
          }}
          errorMsg={userNameError}
          containerStyle={{
            marginTop: SIZES.radius,
            marginHorizontal: SIZES.radius
          }}
          appendComponent={
            <View
              style={{
                justifyContent: 'center',
              }}
            >
              <Image
                source={
                  userName == "" || (userName != "" && userNameError == '')
                    ? icons.correct : icons.cross
                }
                style={{
                  height: 20,
                  width: 20,
                  tintColor: userName == "" || (userName != "" && userNameError == '')
                    ? COLORS.green : COLORS.red
                }}
              />
            </View>
          }
        />

      </View>
    </AccountLayout>
  )
}

export default ChangeName

const styles = StyleSheet.create({})