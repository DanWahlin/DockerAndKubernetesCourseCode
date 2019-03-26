using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using AspNetCorePostgreSQLDockerApp.Repository;

namespace AspNetCorePostgreSQLDockerApp.Controllers
{
    public class HomeController : Controller
    {

        IDockerCommandsRepository _repo;

        public HomeController(IDockerCommandsRepository repo) {
          _repo = repo;
        }

        public async Task<IActionResult> Index()
        {
            //Call into PostgreSQL
            var commands = await _repo.GetDockerCommandsAsync();
            return View(commands);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        // public IActionResult Error()
        // {
        //     return View();
        // }
    }
}
