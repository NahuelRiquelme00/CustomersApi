using Microsoft.EntityFrameworkCore;

namespace CustomersApi.Repositories
{
    public interface IAuthRepository
    {
        public Task<Auth?> Auth(string username, string password);
    }
}
