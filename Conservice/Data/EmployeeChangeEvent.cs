using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conservice.Data
{
    public enum EmployeeChangeEventTypeEnum
    {
        PermissionChange,
        ManagerChange,
        PositionChange,
        StatusChange
    }
    public class EmployeeChangeEvent
    {
        public int EmployeeChangeEventId { get; set; }


        public EmployeeChangeEventTypeEnum ChangeEventType { get; set; }


        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee;

        public DateTime Time { get; set; }

        public string Old { get; set; }

        public string New { get; set; }
    }
}
