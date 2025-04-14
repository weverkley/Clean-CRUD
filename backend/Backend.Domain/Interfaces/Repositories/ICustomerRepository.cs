using Backend.Domain.Entities;

namespace Backend.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<IEnumerable<Customer>> GetAllWithAddressesAsync();
        Task<bool> IsCpfCnpjUnique(string cpfCnpj);
    }
}