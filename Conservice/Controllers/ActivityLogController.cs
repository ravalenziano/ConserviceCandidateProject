using Conservice.Models;
using Conservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Controllers
{
    public class ActivityLogController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public ActivityLogController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            var events = _employeeService.GetChangeEvents();
            ActivityLogViewModel model = new ActivityLogViewModel(events);
            return View(model);
        }
    }
}
