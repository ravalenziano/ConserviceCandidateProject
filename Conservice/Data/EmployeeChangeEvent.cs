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


        
        public int EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        public DateTime Time { get; set; }

        public string Old { get; set; }

        public string New { get; set; }

    }
}
