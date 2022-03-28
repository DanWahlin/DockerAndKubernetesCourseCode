using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonolithToMicroservices.Repository;
using Microsoft.Extensions.Logging;
using MonolithToMicroservices.Models;

namespace MonolithToMicroservices.Controllers
{
    public class HomeController : Controller
    {
        ICustomersRepository _CustomersRepo;
        ILookupRepository _LookupRepo;
        ILogger _Logger;

        public HomeController(ICustomersRepository customersRepo, 
            ILookupRepository lookupRepo, 
            ILoggerFactory loggerFactory)
        {
            _CustomersRepo = customersRepo;
            _LookupRepo = lookupRepo;
            _Logger = loggerFactory.CreateLogger(nameof(HomeController));
        }

        public async Task<ActionResult> Index()
        {
            var customers = await _CustomersRepo.GetCustomersAsync();
            return View(customers);
        }

        public async Task<ActionResult> Create()
        {
            var states = await _LookupRepo.GetStatesAsync();
            var vm = new CustomerViewModel
            {
                Customer = new Customer(),
                States = states
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Create(Customer customer)
        {
            var newCustomer = await _CustomersRepo.InsertCustomerAsync(customer);
            if (newCustomer == null)
            {
                var states = await _LookupRepo.GetStatesAsync();
                var vm = new CustomerViewModel
                {
                    Customer = customer,
                    States = states
                };
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var customer = await _CustomersRepo.GetCustomerAsync(id);
            var states = await _LookupRepo.GetStatesAsync();
            var vm = new CustomerViewModel
            {
                Customer = customer,
                States = states
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Customer customer)
        {
            var status = await _CustomersRepo.UpdateCustomerAsync(customer);
            if (!status)
            {
                return View(customer);
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            var customer = await _CustomersRepo.GetCustomerAsync(id);
            return View(customer);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _CustomersRepo.GetCustomerAsync(id);
            return View(customer);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, Customer customer)
        {
            var status = await _CustomersRepo.DeleteCustomerAsync(id);
            if (!status)
            {
                return View(customer);
            }

            return RedirectToAction("Index");
        }


    }
}