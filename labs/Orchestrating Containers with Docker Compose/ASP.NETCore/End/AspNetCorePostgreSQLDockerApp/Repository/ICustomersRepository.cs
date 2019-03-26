using System.Collections.Generic;
using System.Threading.Tasks;

using AspNetCorePostgreSQLDockerApp.Models;

namespace AspNetCorePostgreSQLDockerApp.Repository
{
    public interface ICustomersRepository
    {     
        Task<List<Customer>> GetCustomersAsync();

        Task<Customer> GetCustomerAsync(int id);
        
        Task<Customer> InsertCustomerAsync(Customer customer);
        Task<bool> UpdateCustomerAsync(Customer customer);
        Task<bool> DeleteCustomerAsync(int id);
        Task<List<State>> GetStatesAsync();
    }
}