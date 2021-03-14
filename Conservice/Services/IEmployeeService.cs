using Conservice.Data;
using Conservice.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public interface IEmployeeService
    {
        List<PositionViewModel> GetPositions();

        List<EmployeeViewModel> GetEmployees();

        List<DepartmentViewModel> GetDepartments();


        void SaveEmployee(Employee employee);

        Employee GetEmployee(int id);

        List<EmployeeChangeEventViewModel> GetChangeEvents();

        void AddPermission(int employeeId, PermissionEnum permission);

        void RemovePermission(int employeePermissionId);

        List<EmployeePermissionViewModel> GetPermissions(int employeeId);


        void DeleteEmployee(int id);

        void AddDepartment(Department department);

        void AddPosition(Position position);

        Task UploadEmployeeFile(int employeeId, string rootPath, IFormFile file);

        void DeleteSubscription(int id);

        void AddSubscription(NotificationSubscription subscription);

        List<SubscriptionViewModel> GetSubscriptions();

        List<EmployeeViewModel> GetSubscriptionOptions();

        void RemoveDepartment(int id);

        void RemovePosition(int id);

        bool EmployeeEmailExists(string email, int employeeId);

        bool EmployeeIsManager(int id);

        List<EmployeePermissionsViewModel> GetPermissionList();

    }
}
