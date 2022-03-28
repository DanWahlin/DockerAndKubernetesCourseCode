using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MonolithToMicroservices.Repository;

namespace MonolithToMicroservices.Controllers
{
    public class OrdersController : Controller
    {
        IOrdersRepository _OrdersRepo;

        public OrdersController(IOrdersRepository ordersRepo)
        {
            _OrdersRepo = ordersRepo;
        }

        public async Task<ActionResult> Index(int id)
        {
            var orders = await _OrdersRepo.GetCustomerOrdersAsync(id);
            return View(orders);
        }
    }
}