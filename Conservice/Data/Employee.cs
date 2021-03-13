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

        [ForeignKey("Position")]
        public int PositionId { get; set; }
        public Position Position { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public EmploymentStatusEnum EmploymentStatus { get; set; }
        public TimeSpan ShiftStart { get; set; }

        public TimeSpan ShiftEnd { get; set; }
        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }

        public Employee Manager { get; set; }
        public string Photo { get; set; }
        public string Color { get; set; }

    }
}
