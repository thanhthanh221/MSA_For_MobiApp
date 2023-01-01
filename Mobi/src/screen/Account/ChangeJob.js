import { Alert, FlatList, Image, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { useFocusEffect } from '@react-navigation/native';

import AccountLayout from './AccountLayout'
import { COLORS, FONTS, SIZES, constants, icons } from '../../constants'
import { TextIconButton } from '../../components'
import { IdentityApi } from '../../services';

const ChangeJob = ({ navigation, route }) => {
  const [jobName, setJobName] = React.useState("");

  useFocusEffect(
    React.useCallback(() => {
      setJobName(route.params?.job);
    }, [])
  );
  const CallApi = async () => {
    const response = await IdentityApi.EditExtraProfileUser({Job: jobName})
    if(response.status == 202) {Alert.alert("Thay đổi không thành công")}
  }

  return (
    <AccountLayout
      title={"Nghề nghiệp"}
      buttonTitle={"Lưu"}
      navigation={navigation}
      onPress={() => CallApi()}
    >
      <Text
        style={{
          color: COLORS.darkGray2,
          fontSize: 20,
          marginVertical: SIZES.radius
        }}
      >
        Để chúng tôi có thể dễ dàng gợi ý món ăn cho bạn!
      </Text>

      {/* List */}
      <View
        style={{
          backgroundColor: COLORS.lightGray1,
          width: '100%',
          height: 420,
          borderRadius: SIZES.radius,
          paddingHorizontal: SIZES.radius * 1.3,
          alignItems: 'flex-start',
        }}
      >
        <FlatList
          showsVerticalScrollIndicator={false}
          data={constants.job_User}
          keyExtractor={item => `C--${item.id}`}
          contentContainerStyle={{
            marginVertical: SIZES.radius,
            alignItems: 'flex-start',
            width: '100%'
          }}
          renderItem={({ item, index }) => {
            return (
              <View
                style={{
                  flexDirection: 'row',
                  alignItems: 'center',
                  justifyContent: 'space-between',
                  width: '100%'
                }}
              >
                <TextIconButton
                  icon={item.icon}
                  iconStyle={{
                    width: 45,
                    height: 45,
                    marginRight: SIZES.radius,
                    marginBottom: SIZES.padding,
                  }}
                  label={item.job}
                  lableStyle={{
                    height: 35,
                    fontWeight: item.job == jobName ? "900" : "400",
                    ...FONTS.h3,
                  }}
                  iconPosition={"LEFT"}
                  onPress={() => setJobName(item.job)}
                />
                <Image
                  style={{
                    tintColor: COLORS.green,
                    width: 30,
                    height: 30,
                    marginBottom: 10,
                  }}
                  source={item.job == jobName ? icons.correct : null}
                />
              </View>
            )
          }}
        />
      </View>
    </AccountLayout>
  )
}

export default ChangeJob

const styles = StyleSheet.create({
  x: {
    fontWeight: "400"
  }
})