using Conservice.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public class EmployeeService : IEmployeeService
    {
        readonly ConserviceContext _context;
        public EmployeeService(ConserviceContext context)
        {
            _context = context;
        }

        public List<Position> GetPositions()
        {
            List<Position> positions = _context.Positions.ToList();
            return positions;
        }
    }
}
