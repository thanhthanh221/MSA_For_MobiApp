import AsyncStorage from "@react-native-async-storage/async-storage"
import { RequestAxios } from "../utils"

const SignIn = async () => {
    try {

    } catch (error) {

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
const EditExtraProfileUser = async ({ sex = null, DateOfBirth = null, Job = null, UserName = null }) => {
    try {
        const token = await AsyncStorage.getItem('Token');
        const userId = await AsyncStorage.getItem('userId');

        const response = await RequestAxios.put("/IdentityService/Manage/EditExtraProfileUser",
            {
                "UserId" : userId,
                "Sex" : sex,
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
    ChangeEmailUser,
    UserInfomation,
    EditExtraProfileUser
}
export default IdentityApi;
