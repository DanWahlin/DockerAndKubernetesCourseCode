using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonolithToMicroservices.Repository;
using Microsoft.Extensions.Logging;

namespace MonolithToMicroservices.Controllers
{
    public class OrdersController : Controller
    {
        ICustomersRepository _CustomersRepo;
        ILogger _Logger;

        public OrdersController(ICustomersRepository customersRepo,
            ILoggerFactory loggerFactory)
        {
            _CustomersRepo = customersRepo;
            _Logger = loggerFactory.CreateLogger(nameof(OrdersController));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Index(int id)
        {
            var customer = await _CustomersRepo.GetCustomerOrdersAsync(id);
            return View(customer);
        }
    }
}