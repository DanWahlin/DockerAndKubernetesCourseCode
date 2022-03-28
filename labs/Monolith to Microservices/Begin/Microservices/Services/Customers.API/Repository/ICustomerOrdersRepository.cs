using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.API.Models;

namespace Customers.API.Repository
{
    public interface ICustomerOrdersRepository
    {
        Task<Customer> GetCustomerOrdersAsync(int id);
    }
}