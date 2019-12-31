using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MonolithToMicroservices.Infrastructure;
using MonolithToMicroservices.Models;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MonolithToMicroservices.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        IHttpClient _HttpClient;
        IApiSettings _ApiSettings;
        ILogger _Logger;

        public CustomersRepository(IHttpClient httpClient,
            IOptions<ApiSettings> settings,
            ILoggerFactory loggerFactory)
        {
            _HttpClient = httpClient;
            _ApiSettings = settings.Value;
            _Logger = loggerFactory.CreateLogger(nameof(CustomersRepository));
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            List<Customer> customers = null;
            try
            {
                var dataString = await _HttpClient.GetStringAsync(_ApiSettings.CustomersUri);
                customers = JsonSerializer.Deserialize<List<Customer>>(dataString, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception exp)
            {
                //Now what? Would need a more robust way to handle issues
                //We'll simply log the error here
                _Logger.LogError(new EventId(1),exp, exp.Message);
            }
            return customers;
        }

        public async Task<Customer> GetCustomerAsync(int id)
        {
            Customer customer = null;
            try
            {
                var dataString = await _HttpClient.GetStringAsync($"{_ApiSettings.CustomersUri}/{id}");
                customer = JsonSerializer.Deserialize<Customer>(dataString, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception exp)
            {
                //Now what? Would need a more robust way to handle issues
                //We'll simply log the error here
                _Logger.LogError(new EventId(2), exp, exp.Message);
            }
            return customer;
        }

        public async Task<Customer> GetCustomerOrdersAsync(int id)
        {
            Customer customer = null;
            try
            {
                var dataString = await _HttpClient.GetStringAsync($"{_ApiSettings.CustomerOrdersUri}/{id}");
                customer = JsonSerializer.Deserialize<Customer>(dataString, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception exp)
            {
                //Now what? Would need a more robust way to handle issues
                //We'll simply log the error here
                _Logger.LogError(new EventId(6), exp, exp.Message);
            }
            return customer;
        }

        public async Task<Customer> InsertCustomerAsync(Customer customer)
        {
            Customer newCustomer = null;
            try
            {
                var response = await _HttpClient.PostAsync(_ApiSettings.CustomersUri, customer);
                response.EnsureSuccessStatusCode(); //throw error if not success/200
                var dataString = await response.Content.ReadAsStringAsync();
                newCustomer = JsonSerializer.Deserialize<Customer>(dataString, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception exp)
            {
                //Now what? Would need a more robust way to handle issues
                //We'll simply log the error here
                _Logger.LogError(new EventId(3), exp, exp.Message);
            }
            return newCustomer;
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var response = await _HttpClient.PutAsync($"{_ApiSettings.CustomersUri}/{customer.Id}", customer);
                response.EnsureSuccessStatusCode(); //throw error if not success/200
                var dataString = await response.Content.ReadAsStringAsync();
                apiResponse = JsonSerializer.Deserialize<ApiResponse>(dataString, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception exp)
            {
                //Now what? Would need a more robust way to handle issues
                //We'll simply log the error here
                _Logger.LogError(new EventId(4), exp, exp.Message);
            }
            return apiResponse.Status;
        }

        public async Task<bool> DeleteCustomerAsync(int id)
        {
            ApiResponse apiResponse = new ApiResponse();
            try
            {
                var response = await _HttpClient.DeleteAsync($"{_ApiSettings.CustomersUri}/{id}");
                response.EnsureSuccessStatusCode(); //throw error if not success/200
                var dataString = await response.Content.ReadAsStringAsync();
                apiResponse = JsonSerializer.Deserialize<ApiResponse>(dataString, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception exp)
            {
                //Now what? Would need a more robust way to handle issues
                //We'll simply log the error here
                _Logger.LogError(new EventId(5), exp, exp.Message);
            }
            return apiResponse.Status;
        }
    }
}
