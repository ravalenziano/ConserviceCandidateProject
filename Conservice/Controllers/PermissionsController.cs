using Conservice.Models;
using Conservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Controllers
{
    public class PermissionsController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public PermissionsController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            List< EmployeePermissionsViewModel> model = _employeeService.GetPermissionList();
            return View(model);
        }
    }
}
