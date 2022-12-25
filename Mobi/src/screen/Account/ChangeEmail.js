import { Alert, Image, StyleSheet, Text, View } from 'react-native'
import React from 'react'
import AccountLayout from './AccountLayout'
import { COLORS, SIZES, icons } from '../../constants'
import { FormInput } from '../../components'
import { utils } from '../../utils'
import { IdentityApi } from '../../services'

const ChangeEmail = ({ navigation }) => {
    const [email, setEmail] = React.useState('');
    const [emailConfirmed, setEmailConfirmed] = React.useState(true);
    const [newEmail, setNewEmail] = React.useState('');

    const [newEmailError, setNewEmailError] = React.useState('');
    React.useEffect(() => {
        const CallApi = async () => {
            await IdentityApi.GetEmailUser();
            const response = await IdentityApi.GetEmailUser();
            if (response == null) { return; }
            setEmail(response.data.email);
            setEmailConfirmed(response.data.emailConfirmed);
        }
        CallApi();
    }, []);

    const checkedDisabled = () => {
        return newEmail != '' && newEmailError == '';
    }
    const CallApiChangeEmail = async () => {
        const response = await IdentityApi.ChangeEmailUser(newEmail);
        Alert.alert(response.status.message);
    }
    return (
        <AccountLayout
            navigation={navigation}
            title="Thay đổi Email"
            buttonTitle={"Lưu Email"}
            disabled={!checkedDisabled()}
            onPress={() => CallApiChangeEmail()}
        >
            <View
                style={{
                    width: '100%',
                    height: 240,
                    backgroundColor: COLORS.lightGray1,
                    marginTop: 20,
                    borderRadius: SIZES.radius,
                    justifyContent: 'space-evenly',
                    alignItems: 'center'
                }}
            >
                <View
                    style={{
                        width: '100%',
                        alignItems: 'center'
                    }}
                >
                    <Text
                        style={{
                            textAlign: 'left',
                            width: '95%',
                            marginBottom: SIZES.base
                        }}
                    >
                        Email
                    </Text>
                    <View
                        style={{
                            flexDirection: 'row',
                            backgroundColor: COLORS.transparentPrimray,
                            justifyContent: 'space-between',
                            width: '96%',
                            borderWidth: 1,
                            borderRadius: SIZES.base,
                            borderColor: COLORS.darkGray2
                        }}
                    >
                        <Text
                            style={{
                                height: 55,
                                textAlign: 'left',
                                textAlignVertical: 'center',
                                fontSize: 18,
                                paddingLeft: SIZES.base,
                                fontWeight: '700',
                                color: COLORS.darkGray

                            }}
                        >
                            {email}
                        </Text>
                        <View
                            style={{
                                justifyContent: 'center',
                                alignItems: 'center',
                                paddingHorizontal: SIZES.radius,
                                borderLeftWidth: 1,
                            }}
                        >
                            <Image
                                source={emailConfirmed ? icons.correct : icons.cross}
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: emailConfirmed ? COLORS.green : COLORS.red

                                }}
                            />
                        </View>
                    </View>
                </View>

                {/* Email */}
                <FormInput
                    lable='Email mới'
                    keyboardType='email-address'
                    autoCompleteType='email'
                    onChange={(value) => {
                        utils.validateEmail(value, setNewEmailError)
                        setNewEmail(value);
                        console.log(checkedDisabled());
                    }}
                    errorMsg={newEmailError}
                    containerStyle={{
                        width: '96%',
                        justifyContent: 'center'
                    }}
                    appendComponent={
                        <View
                            style={{
                                justifyContent: 'center',
                            }}
                        >
                            <Image
                                source={
                                    newEmail == "" || (newEmail != "" && newEmailError == "")
                                        ? icons.correct : icons.cross
                                }
                                style={{
                                    height: 20,
                                    width: 20,
                                    tintColor: newEmail == "" || (newEmail != "" && newEmailError == "")
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

export default ChangeEmail

const styles = StyleSheet.create({})