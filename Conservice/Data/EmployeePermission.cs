using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Conservice.Data
{
    public enum PermissionEnum
    {
        Create,
        Update,
        Delete
    }
    public class EmployeePermission
    {
        public int EmployeePermissionId { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }


        public PermissionEnum Permission { get; set; }
    }
}
