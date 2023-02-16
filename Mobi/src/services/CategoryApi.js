import { RequestAxios } from "../utils";

const GetAllCategory = async () => {
    try {
        var response = await RequestAxios.get("/CategoryService/Category/GetAllCategory");
        return response;
    } catch (error) {
        console.log(error)

    }
}


const CategoryApi = {
    GetAllCategory,
}

export default CategoryApi