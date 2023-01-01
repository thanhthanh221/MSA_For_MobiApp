import { StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { useFocusEffect } from '@react-navigation/native';

import AccountLayout from './AccountLayout'
import { COLORS, SIZES, icons } from '../../constants'
import { TextIconButton } from '../../components'
import DatePicker from 'react-native-date-picker'
import IdentityApi from '../../services/IdentityApi';

const ChangeDateOfBirth = ({ navigation, route }) => {
  const [date, setDate] = React.useState('');
  const [open, setOpen] = React.useState(false);

  useFocusEffect(
    React.useCallback(() => {
      if(route.params?.dateOfBirth) {
        setDate(new Date(route.params?.dateOfBirth))
      }
    }, [])
  );
  const CallApi = () => {
    IdentityApi.EditExtraProfileUser({ DateOfBirth: date })
  }

  return (
    <AccountLayout
      title={"Ngày sinh"}
      buttonTitle={"Lưu"}
      navigation={navigation}
      disabled={!date}
      onPress={() => CallApi()}
    >
      <Text
        style={{
          fontSize: 21,
          marginVertical: SIZES.radius
        }}
      >
        Lưu ngày sinh nhật của bạn nè
      </Text>

      {/* Date Time */}
      <View
        style={{
          width: '100%',
          height: 85,
          backgroundColor: COLORS.lightGray1,
          borderRadius: SIZES.radius,
          justifyContent: 'center',
          alignItems: 'flex-start',
        }}
      >
        <TextIconButton
          label={date ? date.getDate() + "/" + `${date.getMonth() + 1}` + "/" + date.getFullYear()
            : "Nhập ngày sinh của bạn !"}
          onPress={() => setOpen(true)}
          containerStyle={{
            marginLeft: SIZES.radius,
            height: 55,
            width: '92.5%',
            backgroundColor: COLORS.white2,
            borderRadius: SIZES.radius,
            borderColor: COLORS.transparentPrimray,
            borderWidth: 1
          }}
          lableStyle={{
            width: SIZES.width * 0.7
          }}
          icon={icons.check_update}
          iconStyle={{
            width: 25,
            height: 25,
            tintColor: COLORS.primary,
          }}
        />
      </View>
      <DatePicker
        modal
        open={open}
        date={date ? date : new Date()}
        mode='date'
        onConfirm={(date) => {
          setOpen(false)
          setDate(date)
        }}
        dividerHeight={10}
        textColor={COLORS.primary}
        maximumDate={new Date()}
        confirmText="Nhập"
        cancelText='Hủy'
        title="Ngày sinh của bạn"
        onCancel={() => {
          setOpen(false)
        }}
        locale={"vi-VN"}
      />
    </AccountLayout>
  )
}

export default ChangeDateOfBirth

const styles = StyleSheet.create({})