using System.Threading.Tasks;
using MonolithToMicroservices.Models;
using System.Collections.Generic;

namespace MonolithToMicroservices.Repository
{
    public interface ICustomersRepository
    {
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> GetCustomerAsync(int id);
        Task<Customer> GetCustomerOrdersAsync(int id);
        Task<Customer> InsertCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
    }
}