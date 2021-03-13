﻿// <auto-generated />
using System;
using Conservice.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Conservice.Migrations
{
    [DbContext(typeof(ConserviceContext))]
    [Migration("20210313170732_AddDepartmentCollection")]
    partial class AddDepartmentCollection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Conservice.Data.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 1,
                            Name = "HR"
                        },
                        new
                        {
                            DepartmentId = 2,
                            Name = "IT"
                        },
                        new
                        {
                            DepartmentId = 3,
                            Name = "Executive"
                        });
                });

            modelBuilder.Entity("Conservice.Data.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmploymentStatus")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PositionId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("ShiftEnd")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("ShiftStart")
                        .HasColumnType("time");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("PositionId");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            EmployeeId = 1,
                            Address = "101 Fake St",
                            Color = "Pink",
                            DepartmentId = 1,
                            Email = "bilbobagginsfake@gmail.com",
                            EmploymentStatus = 0,
                            ManagerId = 2,
                            Name = "Bilbo Baggins",
                            PhoneNumber = "9192342534",
                            PositionId = 1,
                            ShiftEnd = new TimeSpan(0, 22, 0, 0, 0),
                            ShiftStart = new TimeSpan(0, 12, 0, 0, 0),
                            Start = new DateTime(1995, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 2,
                            Address = "102 Fake St",
                            Color = "Blue",
                            DepartmentId = 1,
                            Email = "sallysummersfake@gmail.com",
                            EmploymentStatus = 0,
                            ManagerId = 3,
                            Name = "Sally Summers",
                            PhoneNumber = "9192353534",
                            PositionId = 2,
                            ShiftEnd = new TimeSpan(0, 21, 0, 0, 0),
                            ShiftStart = new TimeSpan(0, 12, 0, 0, 0),
                            Start = new DateTime(1995, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 3,
                            Address = "103 Fake St",
                            Color = "Pink",
                            DepartmentId = 3,
                            Email = "alexhonnoldfake@gmail.com",
                            EmploymentStatus = 0,
                            Name = "Alex Honnold",
                            PhoneNumber = "9192342344",
                            PositionId = 7,
                            ShiftEnd = new TimeSpan(0, 22, 0, 0, 0),
                            ShiftStart = new TimeSpan(0, 12, 0, 0, 0),
                            Start = new DateTime(1996, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 4,
                            Address = "104 Fake St",
                            Color = "Blue",
                            DepartmentId = 2,
                            Email = "ravalenziano@gmail.com",
                            EmploymentStatus = 0,
                            ManagerId = 4,
                            Name = "Richard Valenziano",
                            PhoneNumber = "9192362344",
                            PositionId = 3,
                            ShiftEnd = new TimeSpan(0, 22, 0, 0, 0),
                            ShiftStart = new TimeSpan(0, 12, 0, 0, 0),
                            Start = new DateTime(2021, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            EmployeeId = 5,
                            Address = "104 Fake St",
                            Color = "Blue",
                            DepartmentId = 2,
                            Email = "terrytaofake@gmail.com",
                            EmploymentStatus = 0,
                            ManagerId = 3,
                            Name = "Terry Tao",
                            PhoneNumber = "9192362344",
                            PositionId = 4,
                            ShiftEnd = new TimeSpan(0, 22, 0, 0, 0),
                            ShiftStart = new TimeSpan(0, 12, 0, 0, 0),
                            Start = new DateTime(2018, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Conservice.Data.EmployeeChangeEvent", b =>
                {
                    b.Property<int>("EmployeeChangeEventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChangeEventType")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("New")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Old")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("EmployeeChangeEventId");

                    b.ToTable("EmployeeChangeEvents");
                });

            modelBuilder.Entity("Conservice.Data.EmployeePermission", b =>
                {
                    b.Property<int>("EmployeePermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("Permission")
                        .HasColumnType("int");

                    b.HasKey("EmployeePermissionId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("EmployeePermissions");
                });

            modelBuilder.Entity("Conservice.Data.NotificationSubscription", b =>
                {
                    b.Property<int>("NotificationSubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("NotificationSubscriptionId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("NotrificationSubscriptions");
                });

            modelBuilder.Entity("Conservice.Data.Position", b =>
                {
                    b.Property<int>("PositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionId");

                    b.ToTable("Positions");

                    b.HasData(
                        new
                        {
                            PositionId = 1,
                            Name = "Recruiter"
                        },
                        new
                        {
                            PositionId = 2,
                            Name = "Senior Recruiter"
                        },
                        new
                        {
                            PositionId = 3,
                            Name = "Developer"
                        },
                        new
                        {
                            PositionId = 4,
                            Name = "Senior Developer"
                        },
                        new
                        {
                            PositionId = 5,
                            Name = "CTO"
                        },
                        new
                        {
                            PositionId = 6,
                            Name = "COO"
                        },
                        new
                        {
                            PositionId = 7,
                            Name = "CEO"
                        });
                });

            modelBuilder.Entity("Conservice.Data.Employee", b =>
                {
                    b.HasOne("Conservice.Data.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Conservice.Data.Employee", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("Conservice.Data.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Manager");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("Conservice.Data.EmployeePermission", b =>
                {
                    b.HasOne("Conservice.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Conservice.Data.NotificationSubscription", b =>
                {
                    b.HasOne("Conservice.Data.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Conservice.Data.Department", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
