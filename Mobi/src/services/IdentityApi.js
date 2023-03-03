import AsyncStorage from "@react-native-async-storage/async-storage"
import { RequestAxios } from "../utils"

const SignIn = async () => {
    try {

    } catch (error) {

    }
}
const ExternalLogin = async (Provider, ProviderKey) => {
    try {
        var response = await RequestAxios.post("/IdentityService/Account/ExternalLogin",
            {
                Provider: Provider,
                ProviderKey: ProviderKey
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

        var response = await RequestAxios.patch("/IdentityService/Manage/ChangeEmailUser",
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
const UserInfomation = async () => {
    try {
        const token = await AsyncStorage.getItem('Token');
        const userId = await AsyncStorage.getItem('userId');
        var response = await RequestAxios.get("/IdentityService/Manage/GetInfomation",
            {
                params: {
                    userId: userId
                }
            },
            {
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            });
        return response;
    } catch (error) {
        console.log(error);
    }
}
const AddPhoneNumber = async (phoneNumber) => {
    try {
        const token = await AsyncStorage.getItem('Token');
        const userId = await AsyncStorage.getItem('userId');

        const response = await RequestAxios.patch("/IdentityService/Manage/AddPhoneNumber",
            {
                "userId": userId,
                "phoneNumber": phoneNumber
            },
            {
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            });
        return response
    } catch (error) {
        console.log(error);
    }
}

const VerifyPhoneNumber = async (code, phoneNumber) => {
    try {
        const token = await AsyncStorage.getItem('Token');
        const userId = await AsyncStorage.getItem('userId');
        var response = await RequestAxios.post("/IdentityService/Manage/VerifyPhoneNumber",
            {
                "userId": userId,
                "phoneNumber": phoneNumber,
                "code": code
            },
            {
                headers: {
                    "Authorization": `Bearer ${token}`
                }
            });
        return response;
    } catch (error) {
        console.log(error);

    }

}

const EditExtraProfileUser = async ({ sex = null, DateOfBirth = null, Job = null, UserName = null }) => {
    try {
        const token = await AsyncStorage.getItem('Token');
        const userId = await AsyncStorage.getItem('userId');

        const response = await RequestAxios.put("/IdentityService/Manage/EditExtraProfileUser",
            {
                "UserId": userId,
                "Sex": sex,
                "DateOfBirth": DateOfBirth,
                "Job": Job,
                "UserName": UserName
            },
            {
                headers: {
                    "Content-Type": "multipart/form-data",
                    "Authorization": `Bearer ${token}`
                }
            });
        console.log(response.data);
        return response;
    } catch (error) {
        console.log(error);
    }
}
const IdentityApi = {
    SignIn,
    ExternalLogin,
    ChangeEmailUser,
    UserInfomation,
    EditExtraProfileUser,
    AddPhoneNumber,
    VerifyPhoneNumber
}
export default IdentityApi;
