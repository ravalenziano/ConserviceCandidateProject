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
