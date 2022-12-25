import AsyncStorage from "@react-native-async-storage/async-storage"
import { RequestAxios } from "../utils"

const SignIn = async () => {
    try {

    } catch (error) {

    }
}
const GetEmailUser = async () => {
    try {
        const token = await AsyncStorage.getItem('Token');
        const userId = await AsyncStorage.getItem('userId');
        var response = await RequestAxios.get("/IdentityService/Manage/GetEmailUser",
            {
                params: {
                    userId: userId
                },
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            });
        return response;
    } catch (error) {
        console.log(error);
    }
}
const ChangeEmailUser = async (newEmail) => {
    try {
        const token = await AsyncStorage.getItem('Token');
        const userId = await AsyncStorage.getItem('userId');

        var response = await RequestAxios.put("/IdentityService/Manage/ChangeEmailUser",
            {
                userId: userId,
                newEmail: newEmail
            },
            {
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            })
            return response;

    } catch (error) {
        console.log(error);
    }
}
const IdentityApi = {
    SignIn,
    GetEmailUser,
    ChangeEmailUser
}
export default IdentityApi;
