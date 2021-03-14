using Conservice.Models;
using Conservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Controllers
{
    public class PositionController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public PositionController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Index()
        {
            List<PositionViewModel> positions = _employeeService.GetPositions();
            return View(positions);
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult New(PositionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var position = model.ToPosition();
            _employeeService.AddPosition(position);


            return RedirectToAction("Index");
        }

        public IActionResult RemovePosition(int id)
        {
            _employeeService.RemovePosition(id);
            return RedirectToAction("Index");
        }
    }
}
