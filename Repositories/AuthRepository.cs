using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomersApi.Repositories
{
    public class AuthRepository : DbContext, IAuthRepository
    {

        public AuthRepository(DbContextOptions<AuthRepository> options) : base(options){}

        public DbSet<AuthEntity> Auths { get; set; }

        public async Task<AuthEntity?> Auth(string username, string password)
        {
            return await Auths.FirstOrDefault(a => a.User_name == username && a.Password == password);

        }
            
    }
    public class AuthEntity
    {
		public string User_name { get; set; }

		public string Password { get; set; }
	}
}
