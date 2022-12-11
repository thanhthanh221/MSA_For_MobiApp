import {
    StyleSheet,
    Text,
    View,
    TouchableOpacity,
    Image,
    TextInput,
} from 'react-native'
import React from 'react'

import { COLORS, FONTS, SIZES } from '../constants'

const FormInput = (
    {
        containerStyle,
        lable,
        placeholder,
        inputStyle,
        value,
        prependComponent,
        appendComponent,
        onChange,
        secureTextEntry,
        keyboardType = 'default',
        autoCompleteType = 'off',
        autoCapitalize = 'none',
        errorMsg = "",
        maxLength = 100
    }

) => {
    return (
        <View style={{ ...containerStyle }}>

            {/* lable - error */}
            <View
                style={{
                    flexDirection: 'row',
                    justifyContent: 'space-between'
                }}
            >
                <Text
                    style={{
                        color: COLORS.gray,
                        ...FONTS.body4
                    }}
                >
                    {lable}
                </Text>

                <Text
                    style={{
                        color: COLORS.red,
                        ...FONTS.body4
                    }}
                >
                    {errorMsg}
                </Text>

            </View>
            {/* Text input */}
            <View
                style={{
                    flexDirection: 'row',
                    height: 55,
                    paddingHorizontal: SIZES.radius,
                    marginTop: SIZES.base,
                    borderRadius: SIZES.radius,
                    backgroundColor: COLORS.lightGray2,
                }}
            >
                {prependComponent}
                <TextInput
                    style={{
                        flex: 1,
                        ...inputStyle,
                    }}
                    value={value}
                    maxLength={maxLength}
                    placeholder={placeholder}
                    placeholderTextColor={COLORS.gray}
                    secureTextEntry={secureTextEntry}
                    keyboardType={keyboardType}
                    autoCapitalize={autoCapitalize}
                    autoComplete={autoCompleteType}
                    onChangeText={(text) => onChange(text)}
                />
                {appendComponent}

            </View>
        </View>
    )
}

export default FormInput

const styles = StyleSheet.create({})