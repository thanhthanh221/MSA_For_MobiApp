import axios from "axios";

export const RequestAxios = axios.create({
    baseURL: ' https://e2f5-2402-9d80-26d-1954-25cb-3061-ba59-60ec.ap.ngrok.io'
});

export default RequestAxios

