# Application MSA(Microservice Architecture)/BackEnd - React Native(Js) Mobi

- Backend Project: (Aspnet Web Api) separates modules according to business logics (Product, Coupon, Category, Identity, Message, Notification, ....) and 1 gateway Apigaway connection, 1 common BuildingBlocks for services to use parts shared.
- Mobi Project : (React Native) : cross-platform Mobi App (Androids, Ios): render Screen UI, Call Api, Navigation App

> ![Aspnet Api](https://www.pragimtech.com/wp-content/uploads/2019/03/ASP.NET-Web-api.jpg)
> ![React Native](https://i1.wp.com/blog.alexdevero.com/wp-content/uploads/2018/12/react-native-expo-how-to-build-your-first-mobile-app.jpg?fit=1024%2C635&ssl=1)

## Project Pictures
- Identiy Api
> ![Identiy Api](https://github.com/thanhthanh221/MSA_For_MobiApp/blob/Production/Images/IdentityApi.png)

- Screen Application (Android)
> ![Screen 1](https://github.com/thanhthanh221/MSA_For_MobiApp/blob/Production/Images/mb1.png)
> ![Screen 2](https://github.com/thanhthanh221/MSA_For_MobiApp/blob/Production/Images/mb2.png)
> ![Screen 3](https://github.com/thanhthanh221/MSA_For_MobiApp/blob/Production/Images/mb3.png)


## Settings
- Clone Project 
```
    git clone https://github.com/thanhthanh221/MSA_For_MobiApp.git
    1. Mobi: npm install
    2. Server: restore nuget (Vs code) 
```
- Run Project

```
    1. Mobi:
        Android: npx react-native run-android
        Ios: npx react-native run-ios (MacOs)
    2. Server: 
        Step 1: Api GateWay: Dotnet watch run;
        Step 2: Run Service: Dotnet watch run (In Service);
```

## References
1. ASPNET API: https://dotnet.microsoft.com/en-us/apps/aspnet/apis;
2. Identiy AspNet: https://learn.microsoft.com/en-us/aspnet/identity/overview/getting-started/introduction-to-aspnet-identity
3. React Native: https://reactnative.dev/;
4. React Navigation: https://reactnavigation.org/

## Author
BVQ(Thanhthanh221)






