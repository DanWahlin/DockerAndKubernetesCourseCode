using System.Collections.Generic;
using System.Threading.Tasks;
using MonolithToMicroservices.Models;

namespace MonolithToMicroservices.Repository
{
    public interface IOrdersRepository
    {
        Task<Customer> GetCustomerOrdersAsync(int id);
    }
}