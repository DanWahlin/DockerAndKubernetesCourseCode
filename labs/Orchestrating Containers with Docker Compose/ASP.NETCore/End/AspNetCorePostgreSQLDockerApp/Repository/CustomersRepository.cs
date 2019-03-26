using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;
using AspNetCorePostgreSQLDockerApp.Models;

namespace AspNetCorePostgreSQLDockerApp.Repository
{
    public class CustomersRepository : ICustomersRepository
    {

        private readonly CustomersDbContext _context;
        private readonly ILogger _logger;

        public CustomersRepository(CustomersDbContext context, ILoggerFactory loggerFactory) {
          _context = context;
          _logger = loggerFactory.CreateLogger("CustomersRepository");
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.OrderBy(c => c.LastName).ToListAsync();
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            return await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<State>> GetStatesAsync()
        {
            return await _context.States.OrderBy(s => s.Abbreviation).ToListAsync();
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            _context.Add(customer);
            try
            {
              await _context.SaveChangesAsync();
            }
            catch (System.Exception exp)
            {
               _logger.LogError($"Error in {nameof(InsertCustomerAsync)}: " + exp.Message);
            }

            return customer;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            //Will update all properties of the Customer
            _context.Customers.Attach(customer);
            _context.Entry(customer).State = EntityState.Modified;
            try
            {
              return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (Exception exp)
            {
               _logger.LogError($"Error in {nameof(UpdateCustomerAsync)}: " + exp.Message);
            }
            return false;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            //Extra hop to the database but keeps it nice and simple for this demo
            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            _context.Remove(customer);
            try
            {
              return (await _context.SaveChangesAsync() > 0 ? true : false);
            }
            catch (System.Exception exp)
            {
               _logger.LogError($"Error in {nameof(DeleteCustomerAsync)}: " + exp.Message);
            }
            return false;
        }

    }
}