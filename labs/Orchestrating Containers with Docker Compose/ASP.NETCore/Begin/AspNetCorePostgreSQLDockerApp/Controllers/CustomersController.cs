using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCorePostgreSQLDockerApp.Controllers
{
    public class CustomersController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
    }
}
