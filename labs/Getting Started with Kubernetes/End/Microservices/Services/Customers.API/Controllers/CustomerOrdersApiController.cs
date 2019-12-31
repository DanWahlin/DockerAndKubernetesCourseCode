using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Customers.API.Models;
using Customers.API.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Cors;

namespace Customers.API.Controllers
{
    //Can version API many ways (good discussion here: https://www.troyhunt.com/your-api-versioning-is-wrong-which-is/)
    //Going with version in route to keep it simple
    [ApiController]
    [Route("api/v1/orders")]
    public class CustomerOrdersApiController : ControllerBase
    {
        ICustomersRepository _CustomersRepo;
        ICustomerOrdersRepository _CustomerOrdersRepo;
        ILogger _Logger;

        public CustomerOrdersApiController(ICustomersRepository customersRepo,
            ICustomerOrdersRepository ordersRepo,
            ILoggerFactory loggerFactory)
        {
            _CustomersRepo = customersRepo;
            _CustomerOrdersRepo = ordersRepo;
            _Logger = loggerFactory.CreateLogger(nameof(CustomersApiController));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCustomerOrdersAsync(int id)
        {
            try
            {
                var customer = await _CustomerOrdersRepo.GetCustomerOrdersAsync(id);
                return Ok(customer);
            }
            catch (Exception exp)
            {
                _Logger.LogError(exp.Message);
                return BadRequest(new ApiResponse { Status = false });
            }


        }
    }
}
