using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new Position
                {
                    PositionId = 1,
                    Name = "HR"
                },
                new Position
                {
                    PositionId = 2,
                    Name = "IT"
                },
                   new Position
                   {
                       PositionId = 3,
                       Name = "CEO"
                   }
            );
       
        }
    }
}
