import { LoginManager, Profile } from "react-native-fbsdk-next";
import IdentityApi from "./IdentityApi";
import { GoogleSignin } from "@react-native-google-signin/google-signin";

const LoginFaceBook = (navigation) => {
    LoginManager.logInWithPermissions(["public_profile", "email"]).then(
        function (result) {
            if (result.isCancelled) {
                console.log("Login cancelled");
            } else {
                Profile.getCurrentProfile().then(async (currentProfile) => {
                    if (currentProfile) {
                        const response = await IdentityApi.ExternalLogin("Facebook", currentProfile.userID);
                        console.log(response.data);
                        if (response.data.verify) {
                            navigation.navigate("Home");
                        }
                    }
                });
            }
        },
        function (error) {
            console.log("Lỗi đăng nhập với Facebook: " + error);
        }
    );
}
const LoginGoogle = async (navigation) => {
    try {
        GoogleSignin.configure();
        const userInfo = await GoogleSignin.signIn();
        console.log(userInfo);
    } catch (error) {
        console.error(error);
    }
}
const ExternalLogin = {
    LoginFaceBook,
    LoginGoogle
}
export default ExternalLogin;