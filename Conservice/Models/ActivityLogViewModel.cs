using Conservice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Models
{
    public class ActivityLogViewModel
    {
        public List<EmployeeChangeEventViewModel> ChangeEvents { get; set; }

        public ActivityLogViewModel(List<EmployeeChangeEventViewModel> events)
        {
            this.ChangeEvents = events;
        }
    }

    public class EmployeeChangeEventViewModel
    {
        public int EmployeeChangeEventId { get; set; }

        public EmployeeChangeEventTypeEnum ChangeEventType { get; set; }

        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime Time { get; set; }

        public string Old { get; set; }

        public string New { get; set; }

        public EmployeeChangeEventViewModel(EmployeeChangeEvent changeEvent)
        {
            EmployeeChangeEventId = changeEvent.EmployeeChangeEventId;
            EmployeeId = changeEvent.EmployeeId;
            EmployeeName = changeEvent.Employee.Name;
            ChangeEventType = changeEvent.ChangeEventType;
            Time = changeEvent.Time;
            Old = changeEvent.Old;
            New = changeEvent.New;
        }
    }
}
