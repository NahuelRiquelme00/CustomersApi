using CustomersApi.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CustomersApi.Repositories
{
    public class CustomerDatabaseContext : DbContext
    {
        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options): base(options)
        {
            
        }


        public DbSet<CustomerEntity> Customers {  get; set; }

        public DbSet<AuthEntity> Auths { get; set; }

        public async Task<CustomerEntity?> Get(long id)
        {
            return await Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> Delete(long id)
        {
            CustomerEntity entity = await Get(id);
            Customers.Remove(entity);
            SaveChanges();
            return true;
        }

        public async Task<CustomerEntity> Add(CreateCustomerDto customerDto)
        {
            CustomerEntity entity = new CustomerEntity()
            {
                Address = customerDto.Address,
                Email = customerDto.Email,
                FirstName = customerDto.FirstName,
                LastName = customerDto.LastName,
                Phone = customerDto.Phone,
            };

            EntityEntry<CustomerEntity> response = await Customers.AddAsync(entity);
            await SaveChangesAsync();
            return await Get(response.Entity.Id);
        }

        public async Task<bool> Actualizar(CustomerEntity customerEntity)
        {
            Customers.Update(customerEntity);
            await SaveChangesAsync();

            return true;
        }
    } 

    public class CustomerEntity
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public CustomerDto toDto()
        {
            return new CustomerDto()
            {
                Id = Id,
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Phone = Phone,
                Address = Address
            };
        }
    }
}
