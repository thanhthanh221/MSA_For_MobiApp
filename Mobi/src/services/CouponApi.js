import { RequestAxios } from "../utils";
const GetAllCoupon = async (page, pageSize) => {
    try {
        var response = await RequestAxios.get(`/CouponService/Coupon/GetAllCoupon/${page}/${pageSize}`);
        return response;
    } catch (error) {
        console.log(error)
    }
}

const CouponApi = {
    GetAllCoupon,
}

export default CouponApi;