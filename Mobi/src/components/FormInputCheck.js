import { StyleSheet, Text, View, Image } from 'react-native'
import React from 'react'

import { icons, COLORS } from '../constants'

const FormInputCheck = ({ value, error }) => {
    return (
        <View
            style={{
                justifyContent: 'center',
            }}
        >
            <Image
                source={
                    value == '' || (value != "" && error == '')
                        ? icons.correct : icons.cross
                }
                style={{
                    height: 20,
                    width: 20,
                    tintColor: value == "" || (value != "" && error == '')
                        ? COLORS.green : COLORS.red
                }}
            />
        </View>
    )
}

export default FormInputCheck

const styles = StyleSheet.create({})