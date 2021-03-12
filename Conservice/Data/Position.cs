using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Data
{
    public class Position
    {
        
        public int PositionId { get; set; }
        public string Name { get; set; }

    }
}
