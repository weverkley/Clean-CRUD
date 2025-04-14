using Backend.Infrastructure.Contexts;
using Backend.Domain.Entities;
using Backend.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Infrastructure.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Customer>> GetAllWithAddressesAsync()
        {
            return await _context.Customers.Include(c => c.Addresses)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> IsCpfCnpjUnique(string cpfCnpj)
        {
            var cliente = await _context.Customers
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.CPFCNPJ == cpfCnpj);
            return cliente == null;
        }
    }
}
