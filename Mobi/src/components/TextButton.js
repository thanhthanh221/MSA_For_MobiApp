import {
  StyleSheet,
  Text,
  TouchableOpacity,
  View,
} from 'react-native'
import React from 'react'

import { COLORS, FONTS, SIZES, icons } from '../constants'

const TextButton = (
  { lable, buttonContainerStyle, onPress, lableStyle, lable2, disabled }
) => {
  return (
    <TouchableOpacity
      disabled={disabled}
      style={{
        ...buttonContainerStyle,
        alignItems: 'center',
        justifyContent: "center",
      }}
      onPress={onPress}
    >
      <Text
        style={{
          ...lableStyle,
          fontWeight: '700',
          ...FONTS.h3
        }}
      >
        {lable}
      </Text>

      {
        lable2 &&
        <View>
          {/* Lable 2 */}
          <Text
            style={{
              ...lableStyle,
              fontWeight: '700'
            }}
          >
            {lable2}
          </Text>
        </View>
      }

    </TouchableOpacity>
  )
}

export default TextButton

const styles = StyleSheet.create({})