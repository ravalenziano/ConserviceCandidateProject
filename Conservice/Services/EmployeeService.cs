using Conservice.Data;
using Conservice.Models;
using Microsoft.EntityFrameworkCore;
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

        public List<EmployeeChangeEventViewModel> GetChangeEvents()
        {

            List<EmployeeChangeEventViewModel> changeEvents = _context.EmployeeChangeEvents
                .Include(x => (x as EmployeeChangeEvent).Employee)
                .OrderByDescending(x => x.Time)
                .ToList()
                .Select(x => new EmployeeChangeEventViewModel(x))
                
                .ToList();
            return changeEvents;
        }

        public List<PositionViewModel> GetPositions()
        {
            List<PositionViewModel> positions = _context.Positions.ToList()
                .Select(x => new PositionViewModel(x)).ToList();
            return positions;
        }

        public Position GetPosition(int id)
        {
            var position = _context.Positions
                .FirstOrDefault(x => x.PositionId == id);
            return position;
        }

        public List<DepartmentViewModel> GetDepartments()
        {
            List<DepartmentViewModel> departments = _context.Departments.ToList()
                .Select(x => new DepartmentViewModel(x)).ToList();
            return departments;
        }

        public Department GetDepartment(int id)
        {
            var department = _context.Departments
                .FirstOrDefault(x => x.DepartmentId == id);
            return department;
        }



        public List<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> employees = _context.Employees
                .Include(x => x.Position)
                .Include(x => x.Department)
                .Include(x => x.Manager)
                .ToList()
                .Select(x => new EmployeeViewModel(x)).ToList();
            return employees;
        }

        public Employee GetEmployee(int id)
        {
            var employee = _context.Employees
                 .Include(x => x.Position)
                .Include(x => x.Department)
                .Include(x => x.Manager)
                  .FirstOrDefault(x => x.EmployeeId == id);
            return employee;
        }

        public void SaveEmployee(Employee employee)
        {
            if(employee.EmployeeId == 0)
            {
                _context.Add<Employee>(employee);
            }
            else
            {
                Employee existing = GetEmployee(employee.EmployeeId);
                List<EmployeeChangeEvent> changeEvents = getChanges(existing, employee);
                foreach(var ce in changeEvents)
                {
                    _context.Add(ce);
                }
                updateEmployee(existing, employee);

            }
  
            _context.SaveChanges(); 
        }

        private void updateEmployee(Employee existing, Employee newData)
        {
            existing.Name = newData.Name;
            existing.Address = newData.Address;
            existing.Email = newData.Email;
            existing.PhoneNumber = newData.PhoneNumber;
            existing.PositionId = newData.PositionId;
            existing.DepartmentId = newData.DepartmentId;
            existing.Start = newData.Start;
            existing.End = newData.End;
            existing.EmploymentStatus = newData.EmploymentStatus;
            existing.ShiftStart = newData.ShiftStart;
            existing.ShiftEnd = newData.ShiftEnd;
            existing.ManagerId = newData.ManagerId;
            existing.Photo = newData.Photo;
            existing.Color = newData.Color;
        }

        List<EmployeeChangeEvent> getChanges(Employee existing, Employee newData)
        {
            var time = DateTime.Now;
            List<EmployeeChangeEvent> changeList = new List<EmployeeChangeEvent>();

            if(existing.ManagerId != newData.ManagerId)
            {

                EmployeeChangeEventTypeEnum changeType = EmployeeChangeEventTypeEnum.ManagerChange;

                Employee oldManager = existing.ManagerId == null ? null :  GetEmployee(existing.ManagerId.Value);

                Employee newManager = newData.ManagerId == null ? null : GetEmployee(newData.ManagerId.Value);



                changeList.Add(new EmployeeChangeEvent
                {
                    EmployeeId = existing.EmployeeId,
                    Old = oldManager.Name,
                    New = newManager.Name,
                    Time = time,
                    ChangeEventType = changeType,
                });
            }
            if(existing.PositionId != newData.PositionId)
            {
                EmployeeChangeEventTypeEnum changeType = EmployeeChangeEventTypeEnum.PositionChange;
                Position newPos = GetPosition(newData.PositionId);

                Position oldPos;
                if(existing.Position != null)
                {
                    oldPos = new Position { Name = existing.Position.Name, PositionId = existing.PositionId };
                }
                else
                {
                    oldPos = GetPosition(existing.PositionId); 
                }

                changeList.Add(new EmployeeChangeEvent
                {
                    EmployeeId = existing.EmployeeId,
                    Old = oldPos.Name,
                    New = newPos.Name,
                    Time = time,
                    ChangeEventType = changeType,

                });
            }

            if (existing.EmploymentStatus != newData.EmploymentStatus)
            {
                EmployeeChangeEventTypeEnum changeType = EmployeeChangeEventTypeEnum.StatusChange;
                changeList.Add(new EmployeeChangeEvent
                {
                    EmployeeId = existing.EmployeeId,
                    Old = existing.EmploymentStatus.ToString(),
                    New = newData.EmploymentStatus.ToString(),
                    Time = time,
                    ChangeEventType = changeType,

                });
            }
            return changeList;
        }

        public List<EmployeePermissionViewModel> GetPermissions(int employeeId)
        {
            var eps = _context.EmployeePermissions
                .Where(x => x.EmployeeId == employeeId)
                .Select(x => new EmployeePermissionViewModel(x))
                .ToList();
            return eps;
        }

        public void AddPermission(int employeeId, PermissionEnum permission)
        {
            List<EmployeePermission> previous = _context.EmployeePermissions.Where(x => x.EmployeeId == employeeId).ToList();
            EmployeePermission ep = new EmployeePermission
            {
                EmployeeId = employeeId,
                Permission = permission
            };
            _context.Add(ep);
            _context.SaveChanges();

            List<EmployeePermission> current = _context.EmployeePermissions.Where(x => x.EmployeeId == employeeId).ToList();
            addPermissionChange(employeeId, previous, current);
        }
        

        private void addPermissionChange(int employeeId, List<EmployeePermission> previous, List<EmployeePermission> current)
        {
            string prevString = string.Join(",", previous.Select(x => x.Permission.ToString()));
            string currentString = string.Join(",", current.Select(x => x.Permission.ToString()));
            EmployeeChangeEventTypeEnum changeType = EmployeeChangeEventTypeEnum.PermissionChange;
           var evt = new EmployeeChangeEvent
            {
                EmployeeId = employeeId,
                Old = prevString,
                New = currentString,
                Time = DateTime.Now,
                ChangeEventType = changeType,

            };
            _context.Add(evt);
            _context.SaveChanges();
        }

        public void RemovePermission(int employeePermissionId)
        {
            var ep =_context.EmployeePermissions.FirstOrDefault(
                x => x.EmployeePermissionId == employeePermissionId);

            if(ep != null)
            {
                List<EmployeePermission> previous = _context.EmployeePermissions.Where(x => x.EmployeeId == ep.EmployeeId).ToList();
                _context.Remove(ep);
                _context.SaveChanges();
                List<EmployeePermission> current = _context.EmployeePermissions.Where(x => x.EmployeeId == ep.EmployeeId).ToList();
                addPermissionChange(ep.EmployeeId, previous, current);
            }
            
        }
    }
}
