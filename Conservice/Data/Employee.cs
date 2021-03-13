using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conservice.Data
{
    public enum EmploymentStatusEnum
    {
        Active,
        Inactive,
        Terminated
    }

    public enum ShiftEnum
    {

    }
    public class Employee
    {
      
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

       
        public int PositionId { get; set; }
        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

      
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public EmploymentStatusEnum EmploymentStatus { get; set; }
        public TimeSpan ShiftStart { get; set; }

        public TimeSpan ShiftEnd { get; set; }
     
        public int? ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public virtual Employee Manager { get; set; }
        public string Photo { get; set; }
        public string Color { get; set; }

        [InverseProperty("Employee")]
        public virtual ICollection<EmployeeChangeEvent> ChangeEvents { get; set; }

       // public virtual ICollection<Employee> Subordinates { get; set; }

    }
}
