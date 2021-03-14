using Conservice.Data;
using Conservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public class EmployeeService : IEmployeeService
    {
       private  readonly ConserviceContext _context;
        private readonly IEmailService _emailService;
        public EmployeeService(ConserviceContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public List<EmployeeChangeEventViewModel> GetChangeEvents()
        {

            List<EmployeeChangeEventViewModel> changeEvents = _context.EmployeeChangeEvents
                .Include(x => x.Employee)
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

        public void AddPosition(Position position)
        {
            _context.Add(position);
            _context.SaveChanges();
        }

        public void RemovePosition(int id)
        {
            var pos = _context.Positions.FirstOrDefault(x => x.PositionId == id);
            if(pos != null)
            {
                _context.Remove(pos);
                _context.SaveChanges();
            }
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

       public void AddDepartment(Department department)
        {
            _context.Add(department);
            _context.SaveChanges();
        }

        public void RemoveDepartment(int id)
        {
            var dep = _context.Departments.FirstOrDefault(x => x.DepartmentId == id);
            if (dep != null)
            {
                _context.Remove(dep);
                _context.SaveChanges();
            }
        }

        public List<EmployeeViewModel> GetEmployees()
        {
            var asdfdsa = _context.Employees.ToList();
            var test =  _context.Employees
                 .Include(x => x.Position)
                 .Include(x => x.Department)
                 .Include(x => x.Manager)
                 .ToList();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="rootPath">IWebHostEnviornment.WebRootPath</param>
        /// <param name="file"></param>
        /// <returns></returns>
        public async Task UploadEmployeeFile(int employeeId, string rootPath, IFormFile file)
        {
            string fileName = getRandomFileName(file);
            string filePath = getRandomFilePath( file, rootPath, fileName);
            if (file.Length > 0)
            {
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileSteam);
                }

                Employee employee = GetEmployee(employeeId);
                if(employee.Photo != null)
                {
                    //Delete old photo
                    File.Delete(Path.Combine(rootPath, "images", employee.Photo));
                }

                employee.Photo = fileName;
               await _context.SaveChangesAsync();
            }
        }

        private string getRandomFilePath(IFormFile file,string rootPath, string fileName)
        {
           // var fileName = getRandomFileName(file);
            var filePath = Path.Combine(rootPath, "images", fileName);
            return filePath;
        }

        private string getRandomFileName(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            //  String rootPath = _hostEnv.WebRootPath;
            return string.Format(@"{0}{1}", Guid.NewGuid(), ext);
        }

        //private string getRandomFileName(string fileExtension)
        //{
        //    return string.Format(@"{0}{1}", Guid.NewGuid(), fileExtension); 
        //}

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

        //Probably shoud be soft delete
        public void DeleteEmployee(int id)
        {
            Employee employee = GetEmployee(id);
            if(employee != null)
            {
                _context.Remove(employee);
                _context.SaveChanges();
            }
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

                //TODO refactor
                var changeEvt = new EmployeeChangeEvent
                {
                    EmployeeId = existing.EmployeeId,
                    Old = oldManager == null ? "" : oldManager.Name,
                    New = newManager == null ? "" : newManager.Name,
                    Time = time,
                    ChangeEventType = changeType,
                };
                changeList.Add(changeEvt);

                SendAlerts(changeEvt);
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
                var changeEvt = new EmployeeChangeEvent
                {
                    EmployeeId = existing.EmployeeId,
                    Old = oldPos.Name,
                    New = newPos.Name,
                    Time = time,
                    ChangeEventType = changeType,

                };
                changeList.Add(changeEvt);

                SendAlerts(changeEvt);
            }

            if (existing.EmploymentStatus != newData.EmploymentStatus)
            {
                EmployeeChangeEventTypeEnum changeType = EmployeeChangeEventTypeEnum.StatusChange;

                var changeEvt = new EmployeeChangeEvent
                {
                    EmployeeId = existing.EmployeeId,
                    Old = existing.EmploymentStatus.ToString(),
                    New = newData.EmploymentStatus.ToString(),
                    Time = time,
                    ChangeEventType = changeType,

                };
                changeList.Add(changeEvt);
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
            SendAlerts(evt);

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

        public void SendAlerts(EmployeeChangeEvent changeEvent)
        {
            var subscriptions = _context.NotrificationSubscriptions
                .Include(x => x.Employee)
                .ToList();
            foreach(var sub in subscriptions)
            {
                string subject = "Change Event Notificaiton";
                string body = alertEmailBody(changeEvent, sub.Employee.Name);
                string recipient = sub.Employee.Email;
                _emailService.SendMail(subject, body, recipient);
            }
        }

        private string alertEmailBody(EmployeeChangeEvent changeEvent, string employeeName)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Change Type: " + changeEvent.ChangeEventType.ToString());
            builder.AppendLine("Employee " + employeeName);
            builder.AppendLine("Old: " + changeEvent.Old);
            builder.AppendLine("New: " + changeEvent.New);
            builder.AppendLine("Date: " + changeEvent.Time.ToString());
            return builder.ToString();
        }

        public void AddSubscription(NotificationSubscription subscription)
        {
            _context.Add(subscription);
            _context.SaveChanges();
        }

        public void DeleteSubscription(int id)
        {
            var sub =_context.NotrificationSubscriptions.FirstOrDefault(x => x.NotificationSubscriptionId == id);
            if(sub != null)
            {
                _context.Remove(sub);
                _context.SaveChanges();
            }
            
        }

        public List<EmployeeViewModel> GetSubscriptionOptions()
        {
            List<EmployeeViewModel> employeeOptions = _context.Employees
             .Where(x => x.Subscriptions.Count == 0)
             .Select(x => new EmployeeViewModel(x)).ToList();
            return employeeOptions;
        }

        public List<SubscriptionViewModel> GetSubscriptions()
        {

            List<EmployeeViewModel> employeeOptions = GetSubscriptionOptions();
           var list = _context.NotrificationSubscriptions
                .Include(x => x.Employee).ToList()
                .Select(x => new SubscriptionViewModel(x, employeeOptions)).ToList();
            return list;
        }

        public bool EmployeeEmailExists(string email, int employeeId)
        {
           
            return _context.Employees.Any(x => x.Email == email && employeeId != x.EmployeeId);
        }

     


    }
}
