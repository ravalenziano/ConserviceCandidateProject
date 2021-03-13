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
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Conservice.Controllers
{
    public class HomeController : Controller
    {
      

        private readonly IEmployeeService _employeeService;
        private readonly IWebHostEnvironment _hostEnv;

        public HomeController(IEmployeeService employeeService, IWebHostEnvironment  hostEnv)
        {
            _employeeService = employeeService;
            _hostEnv = hostEnv;
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

        public IActionResult DeleteEmployee(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
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
        public async Task<IActionResult> Edit(EmployeeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var positionOptions = _employeeService.GetPositions();
                var departmentOptions = _employeeService.GetDepartments();
                var managerOptions = _employeeService.GetEmployees();
                model.InitOptions(positionOptions, departmentOptions, managerOptions);
                return View("AddEmployee", model);
            }


            // Employee  employee = _employeeService.GetEmployee(model.EmployeeId.Value);
            Employee employee = model.ToEmployee();
            _employeeService.SaveEmployee(employee);

            //Upload file
            //TODO REFACTOR --> duplicate code
            if (model.PhotoFile != null && model.PhotoFile.Length > 0)
            {
                //string filePath = getRandomFilePath(model.PhotoFile);
                await _employeeService.UploadEmployeeFile(employee.EmployeeId,
                    _hostEnv.WebRootPath, model.PhotoFile);
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeViewModel model)
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

            //Upload file
            if(model.PhotoFile != null && model.PhotoFile.Length > 0)
            {
              //  string filePath = getRandomFilePath(model.PhotoFile);
                await _employeeService.UploadEmployeeFile(employee.EmployeeId,
                    _hostEnv.WebRootPath, model.PhotoFile);
            }

            return RedirectToAction("Index");
        }

        

        private string getRandomFileName(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            //  String rootPath = _hostEnv.WebRootPath;
            return string.Format(@"{0}{1}", Guid.NewGuid(), ext);
        }

        private string getRandomFilePath(IFormFile file)
        {
            var fileName = getRandomFileName(file);
            var filePath = Path.Combine(_hostEnv.WebRootPath, "images", fileName);
            return filePath;
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

        public IActionResult Subscriptions()
        {
            var model = _employeeService.GetSubscriptions();
            return View(model);
        }

        public IActionResult AddSubscription()
        {
            var options = _employeeService.GetSubscriptionOptions();
            var model = new SubscriptionViewModel(options);
            return View(model);
        }


            [HttpPost]
        public IActionResult AddSubscription(SubscriptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var options = _employeeService.GetSubscriptionOptions();
                model.InitOptions(options);
                return View(model);
            }
            _employeeService.AddSubscription(model.ToSubscription());
            return RedirectToAction("Subscriptions");
        }

        [HttpPost]
        public IActionResult RemoveSubscription(int id)
        {
            _employeeService.DeleteSubscription(id);
            return RedirectToAction("Subscriptions");
        }



    }
}
