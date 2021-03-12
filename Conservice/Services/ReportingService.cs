using Conservice.Data;
using Conservice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
//using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public class ReportingService : IReportingService
    {
        readonly ConserviceContext _context;
        private readonly IEmployeeService _employeeService;
        public ReportingService(ConserviceContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }
        public List<TerminatedReportViewModel> TerminatedReport()
        {
             List<TerminatedReportViewModel> list =  _context.EmployeeChangeEvents
                .Where(x => x.ChangeEventType == EmployeeChangeEventTypeEnum.StatusChange
                && x.New == EmploymentStatusEnum.Terminated.ToString())
                .GroupBy(x => x.Time.Year)
                .Select(x => new TerminatedReportViewModel(
                    x.Key,
                    x.Count()

                    )).ToList();

            return list;

        }

        public List<HireReportViewModel> HireReport()
        {
            //TODO Fix, this only works for one week
            List<HireReportViewModel> list = _context.Employees.ToList()
                .GroupBy(e => yearWeekProjector(e.Start))
                .Select(x => new HireReportViewModel(
                    Int32.Parse(x.Key.Split("_")[0]),
                    Int32.Parse(x.Key.Split("_")[1]),
                    x.Count()))
                .OrderByDescending(x => x.Year)
                .ThenByDescending(x => x.Week)
                .ToList();
            return list; 
        }

        /*
         *Reference: https://stackoverflow.com/questions/8561782/how-to-group-dates-by-week
         */
        Func<DateTime, String> yearWeekProjector =
    d => {
        return  d.Year.ToString() + "_" +
     CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d,
       CalendarWeekRule.FirstFourDayWeek,
       DayOfWeek.Sunday).ToString();
    };
    }
}
