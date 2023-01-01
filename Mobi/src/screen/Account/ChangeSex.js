import { Alert, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import AccountLayout from './AccountLayout'
import { COLORS, SIZES, icons } from '../../constants';
import { TextIconButton } from '../../components';
import { IdentityApi } from '../../services';

const ChangeSex = ({ navigation, route }) => {
  const [sex, setSex] = React.useState('');
  React.useState(() => {
    setSex(route.params?.sex);
  }, []);

  const CallApiToSever = async () => {
    if (route.params?.sex !== sex) {
      await IdentityApi.EditExtraProfileUser({ sex: sex })
      setSex(sex);
    }
  }
  return (
    <AccountLayout
      buttonTitle={"Lưu"}
      title={"Giới tính"}
      navigation={navigation}
      onPress={() => CallApiToSever()}
    >
      <View
        style={{
          width: '100%',
          height: 180,
          backgroundColor: COLORS.lightGray1,
          marginVertical: SIZES.radius,
          borderRadius: SIZES.radius,

        }}
      >
        <Text
          style={{
            fontSize: 17,
            fontWeight: '500',
            marginLeft: SIZES.padding,
            marginVertical: SIZES.radius
          }}
        >
          Giúp chúng mình dễ xưng hô hơn với bạn nha
        </Text>
        <View
          style={{
            width: '100%',
            height: 1,
            backgroundColor: COLORS.darkGray2
          }}
        />
        <View
          style={{
            height: 100,
            justifyContent: 'space-evenly',
            alignItems: 'flex-start',
            marginLeft: SIZES.padding,
            marginTop: SIZES.radius
          }}
        >
          <TextIconButton
            icon={sex == false ? icons.correct : null}
            iconStyle={{
              tintColor: COLORS.green,
              width: 25,
              height: 25,
            }}
            lableStyle={{
              width: 300,
              height: 35,
            }}
            label={"Nam"}
            onPress={() => setSex(false)}
          />
          <TextIconButton
            icon={sex == true ? icons.correct : null}
            iconStyle={{
              tintColor: COLORS.green,
              width: 25,
              height: 25,
            }}
            lableStyle={{
              width: 300,
              height: 35
            }}
            label={"Nữ"}
            onPress={() => setSex(true)}
          />
        </View>
      </View>
    </AccountLayout>
  )
}

export default ChangeSex

const styles = StyleSheet.create({})