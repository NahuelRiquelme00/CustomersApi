using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CustomersApi.Repositories
{
    public class AuthRepository : DbContext, IAuthRepository
    {

        private readonly CustomerDatabaseContext _customerDatabaseContext;

        public AuthRepository(CustomerDatabaseContext customerDatabaseContext)
        {
            _customerDatabaseContext = customerDatabaseContext;
        }

        public async Task<AuthEntity?> Auth(string username, string password)
        {
            return await _customerDatabaseContext.Auths
                .FirstOrDefaultAsync(a => a.User_name == username && a.Password == password);
        }
            
    }
    public class AuthEntity
    {
        public long Id { get; set; }

        public string User_name { get; set; }

		public string Password { get; set; }
	}
}
