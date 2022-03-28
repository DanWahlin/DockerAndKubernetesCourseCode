using System.Collections.Generic;
using System.Threading.Tasks;
using Customers.API.Models;

namespace Customers.API.Repository
{
    public interface IOrdersRepository
    {
        Task<Customer> GetCustomerOrdersAsync(int id);
    }
}