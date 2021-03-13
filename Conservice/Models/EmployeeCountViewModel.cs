using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Models
{
    public class EmployeeCountViewModel
    {
        public List<ManagerCountViewModel> ManagerCounts { get; set; }

        public List<DepartmentCountViewModel> DepartmentCounts { get; set; }
    }

    public class ManagerCountViewModel
    {
        public string ManagerName { get; set; }

        public int Count { get; set; }

        public ManagerCountViewModel(string managerName, int count)
        {
            ManagerName = managerName;
            Count = count;
        }
    }

    public class DepartmentCountViewModel
    {
        public string DepartmentName { get; set; }

        public int Count { get; set; }

        public DepartmentCountViewModel(string departmentName, int count)
        {
            DepartmentName = departmentName;
            Count = count;
        }
    }
}
