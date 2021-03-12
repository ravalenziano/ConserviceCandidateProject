using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Models
{
    public class MetricsViewModel
    {
        public List<TerminatedReportViewModel> TerminatedReport { get; set; }
        public List<HireReportViewModel> HireReport { get; set; }

       
    }
    public class TerminatedReportViewModel
    {
        public int Year { get; set; }
        public int Number { get; set; }

        public TerminatedReportViewModel(int Year, int Number)
        {
            this.Year = Year;
            this.Number = Number;
        }
    }

    public class HireReportViewModel
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public int Number { get; set; }

        public HireReportViewModel(int Year, int Week, int Number)
        {
            this.Year = Year;
            this.Week = Week;
            this.Number = Number;
        }
    }
}
