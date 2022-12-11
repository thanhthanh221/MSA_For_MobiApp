import { StyleSheet, Text, View, ScrollView } from 'react-native'
import React from 'react'

import { COLORS, SIZES, icons, FONTS } from '../../constants'
import { CardItem, FooterTotal, Header, IconButton, StepperInput, TextButton } from '../../components';
import CartQuatityButton from '../../components/CartQuatityButton'
import dummyData from '../../constants/dummyData';

const MyCard = ({ navigation }) => {
  const [selectedCard, setSelectedCard] = React.useState('');

  // Header
  function renderHeader() {
    return (
      <Header
        title={"Thanh toán"}
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
        RightComponent={
          <CartQuatityButton
            quantity={3}
          />
        }
      />
    )
  }

  function renderMyCards() {
    return (
      <View>
        {dummyData.myCards.map((item, index) => {
          return (
            <CardItem
              key={`MyCard-${item.id}`}
              item={{ ...item, key: "MyCard" }}
              isSelected={selectedCard.name === item.name && selectedCard.key === "MyCard"}
              onPress={() => setSelectedCard({ ...item, key: "MyCard" })}
            />
          )
        })
        }
      </View>
    )
  }

  // New Card
  function renderAddNewCard() {
    return (
      <View
        style={{
          marginTop: SIZES.padding
        }}
      >
        <Text
          style={{
            ...FONTS.h3,
            color: COLORS.black,
            fontWeight: 'bold'
          }}
        >
          Phương thức khác :
        </Text>
        {dummyData.allCards.map((item, index) => {
          return (
            <CardItem
              key={`newCard-${item.id}`}
              item={item}
              isSelected={selectedCard.name === item.name && selectedCard.key === 'NewCard'}
              onPress={() => setSelectedCard({ ...item, key: "NewCard" })}
            />
          )
        })}
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
          paddingHorizontal: SIZES.padding
        }}
      >
        <TextButton
          disabled={!selectedCard}
          buttonContainerStyle={{
            height: 60,
            backgroundColor: selectedCard ? COLORS.primary : COLORS.gray,
            borderRadius: SIZES.radius
          }}
          lable={selectedCard.key === 'MyCard' ? 'Thanh toán...' : 'Thêm...'}
          lableStyle={{
            color: COLORS.white,
            ...FONTS.h3
          }}
          onPress={() => {
            if (selectedCard?.key === 'NewCard') {
              navigation.navigate('AddCard', { selectedCard: selectedCard });
            }
            else {
              navigation.navigate('CheckOut', {selectedCard: selectedCard})
            }

          }}
        />

      </View>
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

      {/* Cards */}
      <ScrollView
        style={{
          // dãn cho đầy chiều
          flexGrow: 1,
          marginTop: SIZES.radius,
          paddingHorizontal: SIZES.padding,
          paddingBottom: SIZES.radius
        }}
      >
        {/* Card User */}
        {renderMyCards()}

        {/* Add new Card */}
        {renderAddNewCard()}
      </ScrollView>

      {/* Footer */}
      {renderFooter()}
    </View>
  )
}

export default MyCard

const styles = StyleSheet.create({})