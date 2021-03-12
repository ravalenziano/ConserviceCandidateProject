using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Conservice.Data;
using Conservice.Services;
using Conservice.Models;

namespace Conservice.Controllers
{
    public class HomeController : Controller
    {
      

        private readonly IEmployeeService _employeeService;

        public HomeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            List<EmployeeViewModel> employees = _employeeService.GetEmployees();
            return View(employees);
        }

        public IActionResult AddEmployee()
        {
            var positionOptions = _employeeService.GetPositions();
            var departmentOptions = _employeeService.GetDepartments();
            var managerOptions = _employeeService.GetEmployees();
            var model = new EmployeeViewModel(positionOptions, departmentOptions, managerOptions);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployee(id);
            if(employee == null)
            {
                //TODO error
            }

            var positionOptions = _employeeService.GetPositions();
            var departmentOptions = _employeeService.GetDepartments();
            var managerOptions = _employeeService.GetEmployees();

            return View("AddEmployee", new EmployeeViewModel(positionOptions, departmentOptions, managerOptions, employee));
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var positionOptions = _employeeService.GetPositions();
                var departmentOptions = _employeeService.GetDepartments();
                var managerOptions = _employeeService.GetEmployees();
                model.InitOptions(positionOptions, departmentOptions, managerOptions);
                return View(model);
            }


            // Employee  employee = _employeeService.GetEmployee(model.EmployeeId.Value);
            Employee employee = model.ToEmployee();
            _employeeService.SaveEmployee(employee);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddEmployee(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var positionOptions = _employeeService.GetPositions();
                var departmentOptions = _employeeService.GetDepartments();
                var managerOptions = _employeeService.GetEmployees();
                model.InitOptions(positionOptions, departmentOptions, managerOptions);
                return View(model);
            }
            Employee employee;
        
                employee = model.ToEmployee();
            

            _employeeService.SaveEmployee(employee);
            return RedirectToAction("Index");
        }

        public IActionResult Permissions(int id)
        {
            var permissions = _employeeService.GetPermissions(id);
            var model = new PermissionsViewModel(id, permissions);
            return View(model);
        }

        [HttpPost]
        public IActionResult AddPermission(AddPermissionViewModel model)
        {
            if (!ModelState.IsValid)
            {
          
                return View(model);
            }
            _employeeService.AddPermission(model.EmployeeId, model.Permission);

            return RedirectToAction("Permissions", new { id = model.EmployeeId });
        }

        public IActionResult RemovePermission(RemovePermissionViewModel model)
        {
            if (!ModelState.IsValid)
            {

                return View(model);
            }
            _employeeService.RemovePermission(model.EmployeePermissionId);

            return RedirectToAction("Permissions", new { id = model.EmployeeId });
        }



    }
}
