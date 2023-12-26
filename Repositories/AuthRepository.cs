using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomersApi.Repositories
{
    public class AuthRepository : DbContext, IAuthRepository
    {

        public AuthRepository(DbContextOptions<AuthRepository> options) : base(options){}

        public DbSet<Auth> Auths { get; set; }

        public async Task<Auth?> Auth(string username, string password)
        {
            return await Auths.FirstOrDefault(a => a.User_name == username && a.Password == password);

        }
            
    }
    public class Auth
    {
        public string User_name { get; set; }

        public string Password { get; set; }
    }
}
