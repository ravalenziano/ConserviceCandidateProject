using Conservice.Models;
using Conservice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Controllers
{
    public class MetricsController : Controller
    {
        private readonly IReportingService _reportingService;

        public MetricsController(IReportingService reportingService)
        {
            _reportingService = reportingService;
        }
        public IActionResult Index()
        {
            var terminatedReport = _reportingService.TerminatedReport();
            var hireReport = _reportingService.HireReport();

            MetricsViewModel model = new MetricsViewModel
            {
                TerminatedReport = terminatedReport,
                HireReport = hireReport
            };
            return View(model);
        }


        public IActionResult ManagementChainReport()
        {
            var model = _reportingService.ManagementChainReport();
            return View(model);
        }
        
    }
}
