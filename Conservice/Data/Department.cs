using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Data
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        [InverseProperty("Department")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
