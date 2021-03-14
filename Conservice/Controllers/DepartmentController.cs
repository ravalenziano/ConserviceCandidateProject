using Conservice.Models;
using Conservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public DepartmentController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            List<DepartmentViewModel> departments = _employeeService.GetDepartments();
            return View(departments);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(DepartmentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

           var department = model.ToDepartment();
            _employeeService.AddDepartment(department);


            return RedirectToAction("Index");
        }

        public IActionResult RemoveDepartment(int id)
        {
            _employeeService.RemoveDepartment(id);
            return RedirectToAction("Index");
        }
    }
}
