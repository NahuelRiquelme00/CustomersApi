using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Repositories
{
    public interface IAuthRepository
    {
        Task<AuthEntity?> Auth(string username, string password);
    }
}
