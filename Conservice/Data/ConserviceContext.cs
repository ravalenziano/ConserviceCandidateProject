using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Conservice.Data
{
    public class ConserviceContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeChangeEvent> EmployeeChangeEvents { get; set; }
        public DbSet<EmployeePermission> EmployeePermissions { get; set; }

        public DbSet<NotificationSubscription> NotrificationSubscriptions { get; set; }


        public DbSet<Position> Positions { get; set; }

        public ConserviceContext(DbContextOptions<ConserviceContext> options)
           : base(options)
        {}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Employee>().HasOne(s => s.Manager)
            .WithMany()
            .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<EmployeeChangeEvent>().HasOne(s => s.Employee)
            .WithMany()
            .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Seed();
        }
    }
}
