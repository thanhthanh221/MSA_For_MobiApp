using CategoryApi.Models;
using Newtonsoft.Json;

namespace CategoryApi.Services
{
    public class CategoryCallApi : ICategoryCallApi
    {
        private readonly IHttpClientFactory httpClientFactory;

        public CategoryCallApi(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<List<CategoryClientRes>> GetAllCategoryCallApi()
        {
            var categoryClient = httpClientFactory.CreateClient("CategoryClient");
            var resGetCategory = await categoryClient.GetAsync($"/CategoryService/Category/GetAllCategory");

            if (resGetCategory.IsSuccessStatusCode) {
                string responseBody = await resGetCategory.Content.ReadAsStringAsync();
                dynamic resConver = responseBody;
                var DataCate = JsonConvert.DeserializeObject<List<CategoryClientRes>>(resConver.Data.ToString());
                return DataCate;
            }
            else { return null; }
        }

        public async Task<CategoryClientRes> GetCategoryByIdCallApi(Guid CategoryId)
        {
            var categoryClient = httpClientFactory.CreateClient("CategoryClient");
            var resGetCategory = await categoryClient.GetAsync($"/CategoryService/Category/GetCategoryById/{CategoryId}");

            if (resGetCategory.IsSuccessStatusCode) {
                string responseBody = await resGetCategory.Content.ReadAsStringAsync();
                dynamic resConver = responseBody;
                var DataCate = JsonConvert.DeserializeObject<CategoryClientRes>(resConver.Data.ToString());
                return DataCate;
            }
            else { return null; }
        }
    }
}