using CustomersApi.Repositories;

namespace CustomersApi
{
    public interface IAuthService
    {
        Task<Auth> Auth(string username, string password);
    }
}