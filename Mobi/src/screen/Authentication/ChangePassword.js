import { StyleSheet, Text, View } from 'react-native'
import React from 'react'
import AuthLayout from './AuthLayout'
import { TextButton } from '../../components'

const ChangePassword = () => {
    const renderChangePass = () => {
        return (
            <View>
                
            </View>
        )
    }
    return (
        <AuthLayout
            title={"Đổi mật khẩu"}
        >
            {renderChangePass()}

        </AuthLayout>
    )
}

export default ChangePassword

const styles = StyleSheet.create({})