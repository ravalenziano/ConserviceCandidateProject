using Conservice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public interface IEmployeeService
    {
        List<Position> GetPositions();
    }
}
