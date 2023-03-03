using System.Net.Http.Headers;
using Newtonsoft.Json;
using UserApi.Data;

namespace UserApi.Services
{
    public class UserClientService : IUserClientService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public UserClientService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<UserClientData> GetUserCallApiById(Guid userId, string JsonWebToken)
        {
            var userClient = httpClientFactory.CreateClient("UserApi");
            // Gửi đi kèm theo token 
            userClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JsonWebToken);
            var resGetuser = await userClient.GetAsync($"/IdentityService/Manage/GetInfomation/{userId}");

            if (resGetuser.IsSuccessStatusCode) {
                string responseBody = await resGetuser.Content.ReadAsStringAsync();
                var DataCate = JsonConvert.DeserializeObject<UserClientData>(responseBody);
                return DataCate;
            }
            else { return null; }
        }
    }
}