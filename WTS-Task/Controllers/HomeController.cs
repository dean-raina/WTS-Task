using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WTS_Task.DataDB;

namespace WTS_Task.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Methods.Employee employee = new Methods.Employee();
            List<Models.EmployeeWithHours> model = employee.GetAllEmployeesWithHours();

            return View(model);
        }

    }
}
