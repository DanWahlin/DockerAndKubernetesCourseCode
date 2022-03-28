using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using Customers.API.Models;

namespace Customers.API.Repository
{
    public class OrdersRepository : IOrdersRepository
    {

        private readonly CustomersDbContext _Context;
        private readonly ILogger _Logger;

        public OrdersRepository(CustomersDbContext context, ILoggerFactory loggerFactory) {
          _Context = context;
          _Logger = loggerFactory.CreateLogger("CustomersRepository");
        }

        public async Task<Customer> GetCustomerOrdersAsync(int id)
        {
            return await _Context.Customers.Where(c => c.Id == id)
                                 .Include(c => c.Orders)
                                 .SingleOrDefaultAsync();
        }

    }
}