import axios from "axios";

const RequestAxios = axios.create({
    baseURL: 'http://10.0.2.2:5027'
})

export default RequestAxios

