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
            List<Department> departments = new List<Department> {
                new Department
                {
                    DepartmentId = 1,
                    Name = "HR"
                },
              new Department
              {
                  DepartmentId = 2,
                  Name = "IT"
              },
                 new Department
                 {
                     DepartmentId = 3,
                     Name = "Executive"
                 }
            };
            modelBuilder.Entity<Department>().HasData(
              departments
          );

            List<Position> positions = new List<Position>
            {
                    new Position
                {
                    PositionId = 1,
                    Name = "Recruiter",

                },
                new Position
                {
                    PositionId = 2,
                    Name = "Senior Recruiter",

                },
                 new Position
                 {
                     PositionId = 3,
                     Name = "Developer",

                 },
                 new Position
                 {
                     PositionId = 4,
                     Name = "Senior Developer",

                 },
                 new Position
                 {
                     PositionId = 5,
                     Name = "CTO",

                 },
                  new Position
                  {
                      PositionId = 6,
                      Name = "COO",

                  },
                   new Position
                   {
                       PositionId = 7,
                       Name = "CEO",

                   }
            };
            modelBuilder.Entity<Position>().HasData(
               positions
            );



            modelBuilder.Entity<Employee>().HasData(
             new Employee
             {
                 EmployeeId = 1,
                 Name = "Bilbo Baggins",
                 Address = "101 Fake St",
                 Email = "bilbobagginsfake@gmail.com",
                 PhoneNumber = "9192342534",
                 PositionId = positions[0].PositionId, // recruiter
                 DepartmentId = departments[0].DepartmentId,
                 Start = new DateTime(1995, 1, 15, 0, 0, 0, 0),
                 End = null,
                 EmploymentStatus = EmploymentStatusEnum.Active,
                 ShiftStart = new TimeSpan(12, 0, 0),
                 ShiftEnd = new TimeSpan(22, 0, 0),
                 ManagerId = 2,
                 Photo = null,
                 Color = "Pink",
             },
            new Employee
            {
                EmployeeId = 2,
                Name = "Sally Summers",
                Address = "102 Fake St",
                Email = "sallysummersfake@gmail.com",
                PhoneNumber = "9192353534",
                PositionId = positions[1].PositionId, //Senior recruiter
                DepartmentId = departments[0].DepartmentId,
                Start = new DateTime(1995, 1, 15, 0, 0, 0, 0),
                End = null,
                EmploymentStatus = EmploymentStatusEnum.Active,
                ShiftStart = new TimeSpan(12, 0, 0),
                ShiftEnd = new TimeSpan(21, 0, 0),
                ManagerId = 3,
                Photo = null,
                Color = "Blue",
            },
                new Employee
                {
                    EmployeeId = 3,
                    Name = "Alex Honnold",
                    Address = "103 Fake St",
                    PhoneNumber = "9192342344",
                    Email = "alexhonnoldfake@gmail.com",
                    PositionId = positions[6].PositionId, //CEO
                    DepartmentId = departments[2].DepartmentId,
                    Start = new DateTime(1996, 1, 15, 0, 0, 0, 0),
                    End = null,
                    EmploymentStatus = EmploymentStatusEnum.Active,
                    ShiftStart = new TimeSpan(12, 0, 0),
                    ShiftEnd = new TimeSpan(22, 0, 0),
                    ManagerId = null,
                    Photo = null,
                    Color = "Pink",
                },
                new Employee
                {
                    EmployeeId = 4,
                    Name = "Richard Valenziano",
                    Address = "104 Fake St",
                    Email = "ravalenziano@gmail.com",
                    PhoneNumber = "9192362344",
                    PositionId = positions[2].PositionId, //Developer
                    DepartmentId = departments[1].DepartmentId,
                    Start = new DateTime(2021, 1, 15, 0, 0, 0, 0),
                    End = null,
                    EmploymentStatus = EmploymentStatusEnum.Active,
                    ShiftStart = new TimeSpan(12, 0, 0),
                    ShiftEnd = new TimeSpan(22, 0, 0),
                    ManagerId = 4,
                    Photo = null,
                    Color = "Blue",
                },

                new Employee
                {
                    EmployeeId = 5,
                    Name = "Terry Tao",
                    Email = "terrytaofake@gmail.com",
                    Address = "104 Fake St",
                    PhoneNumber = "9192362344",
                    PositionId = positions[3].PositionId, //Senior Developer
                    DepartmentId = departments[1].DepartmentId,
                    Start = new DateTime(2018, 1, 15, 0, 0, 0, 0),
                    End = null,
                    EmploymentStatus = EmploymentStatusEnum.Active,
                    ShiftStart = new TimeSpan(12, 0, 0),
                    ShiftEnd = new TimeSpan(22, 0, 0),
                    ManagerId = 3,
                    Photo = null,
                    Color = "Blue",
                }
         );

        }
    }
}
