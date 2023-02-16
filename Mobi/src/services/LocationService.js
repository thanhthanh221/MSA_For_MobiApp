import { Platform } from 'react-native';
import { request,PERMISSIONS } from 'react-native-permissions';
import Geolocation from 'react-native-geolocation-service';
import axios from 'axios';

const LocationUser = () => {
    Geolocation.getCurrentPosition(
        position => {
            getPlaceName(position.coords.latitude, position.coords.longitude)
        },
        error => {
            console.log(error.code, error.message);
        },
        { enableHighAccuracy: true, timeout: 15000, maximumAge: 10000 },
    );
}
const RequestLocationPermission = async () => {
    if (Platform.OS === 'ios') {
        const status = await request(PERMISSIONS.IOS.LOCATION_WHEN_IN_USE);
        if (status === 'granted') {
            // Quyền truy cập vị trí đã được cấp
            LocationUser()
        }
    } else if (Platform.OS === 'android') {
        const status = await request(PERMISSIONS.ANDROID.ACCESS_FINE_LOCATION);
        if (status === 'granted') {
            // Quyền truy cập vị trí đã được cấp
            LocationUser()
        }
    }
};
const getPlaceName = async (latitude, longitude) => {
    try {
        const API_KEY = "AIzaSyCpN0xxEYjXr7dtnBrYHEl0KvR634nZU2M"
      const response = await axios.get(
        `https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=${latitude},${longitude}&key=${API_KEY}`,
      );
      return response.data;
    } catch (error) {
      console.error(error);
    }
  };

export default RequestLocationPermission