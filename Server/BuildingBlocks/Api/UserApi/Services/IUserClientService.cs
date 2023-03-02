using UserApi.Data;

namespace UserApi.Services
{
    public interface IUserClientService
    {
        Task<UserClientData> GetUserCallApiById(Guid userId, string JsonWebToken);
    }
}