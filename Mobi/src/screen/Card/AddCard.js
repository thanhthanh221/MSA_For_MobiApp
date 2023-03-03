import { Image, ImageBackground, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import { KeyboardAwareScrollView } from 'react-native-keyboard-aware-scroll-view'

import { COLORS, FONTS, icons, images, SIZES } from '../../constants'
import { FormInput, FormInputCheck, Header, IconButton, RadioButton, TextButton } from '../../components'
import { utils } from '../../utils'

const AddCard = ({ navigation, route }) => {

  const [selectedCard, setSelectedCard] = React.useState('');

  const [cardNumber, setCardNumber] = React.useState('');
  const [cardNumberError, setCardNumberError] = React.useState('');

  const [cardName, setCardName] = React.useState('');
  const [cardNameError, setCardNameError] = React.useState('');

  const [expiryDate, setExpiryDate] = React.useState('');
  const [expiryDateError, setExpiryDateError] = React.useState('');

  const [cvv, setCvv] = React.useState('');
  const [cvvError, setCvvError] = React.useState('');
  const [isRemember, setIsRemenber] = React.useState(false);

  React.useEffect(() => {
    let { selectedCard } = route.params;

    setSelectedCard(selectedCard);
  }, [])
  function renderHeader() {
    return (
      <Header
        title={"Thêm thẻ mới"}
        containerStyle={{
          height: 50,
          marginHorizontal: SIZES.padding,
          marginTop: 15
        }}
        leftComponent={
          <IconButton
            icon={icons.back}
            containerStyle={{
              width: 40,
              height: 40,
              color: COLORS.black,
              justifyContent: 'center',
              alignItems: 'center',
              borderWidth: 1,
              borderRadius: SIZES.radius,
              borderColor: COLORS.gray2

            }}
            iconStyle={{
              tintColor: COLORS.darkGray2,
            }}
            onPress={() => navigation.goBack()}
          />
        }
      />
    )
  }

  //Card
  const renderCard = () => {
    return (
      <ImageBackground
        source={images.card}
        style={{
          height: 200,
          width: '100%',
          marginTop: SIZES.radius,
          borderRadius: SIZES.radius,
          overflow: 'hidden'
        }}
      >
        {/* Logo */}
        <Image
          source={selectedCard?.icon}
          resizeMode='contain'
          style={{
            position: 'absolute',
            top: 20,
            right: 20,
            height: 40,
            width: 80
          }}
        />

        {/* Details */}
        <View
          style={{
            position: 'absolute',
            bottom: 10,
            left: 0,
            right: 0,
            paddingHorizontal: SIZES.padding
          }}
        >
          <Text
            style={{
              color: COLORS.white,
              ...FONTS.h3,
              fontWeight: 'bold'
            }}
          >
            {cardName.toUpperCase()}
          </Text>

          <View
            style={{
              flexDirection: 'row'
            }}
          >
            <Text
              style={{
                flex: 1,
                color: COLORS.white,
                ...FONTS.body3
              }}
            >
              {cardNumber}
            </Text>

            <Text
              style={{
                color: COLORS.white,
                ...FONTS.body3

              }}
            >
              {expiryDate}
            </Text>
            <Text
              style={{
                color: COLORS.white,
                ...FONTS.body3,
                marginLeft: 20

              }}
            >
              {cvv}
            </Text>
          </View>
        </View>
      </ImageBackground>
    )
  }

  const renderForms = () => {
    return (
      <View
        style={{
          marginTop: SIZES.padding * 2,
          flex: 1
        }}
      >
        {/* Card Number */}
        <FormInput
          lable={'Mã thẻ'}
          maxLength={19}
          keyboardType='number-pad'
          autoCompleteType='cc-number'
          onChange={(value) => {
            setCardNumber(value.replace(/\s/g, '')
              .replace(/(\d{4})/g, '$1 ').trim());
            utils.validateInput(value, 19, setCardNumberError);
          }}
          errorMsg={cardNumberError}
          appendComponent={
            <FormInputCheck
              value={cardNumber}
              error={cardNumberError}
            />
          }
        />

        {/* Card Name */}
        <FormInput
          lable={'Chủ thẻ'}
          value={cardName}
          containerStyle={{
            marginTop: SIZES.radius
          }}
          onChange={(value) => {
            utils.validateInput(value, 0, setCardNameError);
            setCardName(value);
          }}
          errorMsg={cardNameError}
          appendComponent={
            <FormInputCheck
              value={cardName}
              error={cardNameError}
            />
          }
        />

        {/* Date / CVV */}
        <View
          style={{
            flexDirection: 'row',
            marginTop: SIZES.radius
          }}
        >
          <FormInput
            lable={'Ngày hết hạn'}
            value={expiryDate}
            placeholder={'MM/YY'}
            containerStyle={{
              flex: 1
            }}
            maxLength={5}
            onChange={(value) => {
              utils.validateInput(value, 5, setExpiryDateError);
              setExpiryDate(value);
            }}
            errorMsg={expiryDateError}
            appendComponent={
              <FormInputCheck
                value={expiryDate}
                error={expiryDateError}
              />
            }
          />


          {/* Cvv */}
          <FormInput
            lable={'CVV'}
            value={cvv}
            keyboardType='number-pad'
            placeholder={'CVV'}
            maxLength={3}
            containerStyle={{
              flex: 1,
              marginLeft: 20
            }}
            onChange={(value) => {
              utils.validateInput(value, 3, setCvvError);
              setCvv(value);
            }}
            errorMsg={cvvError}
            appendComponent={
              <FormInputCheck
                value={cardName}
                error={cardNameError}
              />
            }
          />
        </View>

        <View
          style={{
            alignItems: 'flex-start',
            marginTop: SIZES.padding
          }}
        >
          <RadioButton
            lable={'LƯU'}
            isSelected={isRemember}
            onPress={() => setIsRemenber(!isRemember)}
          />

        </View>
      </View>
    )
  }

  // Footer
  function renderFooter() {
    return (
      <View
        style={{
          paddingTop: SIZES.radius,
          paddingBottom: SIZES.padding,
          paddingHorizontal: SIZES.padding,
        }}
      >
        <TextButton
          lable={"Thêm thẻ..."}
          buttonContainerStyle={{
            backgroundColor: isEnableAddCard() ? COLORS.primary : COLORS.transparentPrimray,
            height: 60,
            borderRadius: SIZES.radius,
          }}
          disabled={!isEnableAddCard()}
          lableStyle={{
            color: COLORS.white,
          }}
          onPress={() => navigation.goBack()}
        />
      </View>
    )
  }

  //AddCard
  function isEnableAddCard() {
    return (
      cardName !="" && cardNumber != "" && expiryDate != "" && cvv != "" && 
      cardNumberError == "" && cardNameError == "" && expiryDateError == "" &&
      cvvError == "" 
    ) 
  }
  return (
    <View
      style={{
        flex: 1,
        backgroundColor: COLORS.white
      }}
    >
      {/* Header */}
      {renderHeader()}

      {/* Body */}
      <KeyboardAwareScrollView
        keyboardDismissMode='on-drag'
        contentContainerStyle={{
          flex: 1,
          paddingHorizontal: SIZES.padding
        }}
      >
        {/* Card */}
        {renderCard()}

        {/* Forms */}
        {renderForms()}

      </KeyboardAwareScrollView>

      {/* Footer */}
      {renderFooter()}
    </View>
  )
}

export default AddCard

const styles = StyleSheet.create({})