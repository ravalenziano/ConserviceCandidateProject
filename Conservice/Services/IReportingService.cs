using Conservice.Data;
using Conservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public interface IReportingService
    {
        List<TerminatedReportViewModel> TerminatedReport();
        List<HireReportViewModel> HireReport();

        ManagementChainViewModel ManagementChainReport();

        EmployeeCountViewModel EmployeeCountReport();

        bool WillContainCycles(int employeeId, int? managerId);
    }
}
