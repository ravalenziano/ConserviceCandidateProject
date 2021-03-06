using Conservice.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Models
{
    public class EmployeeViewModel
    {
        public int? EmployeeId { get; set; }
        [Required]
        public string Name { get; set; }
        
        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
 
        [Required]
        public int PositionId { get; set; }

        public string PositionName { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public DateTime Start { get; set; }

        public string StartStr { get
            {
                return Start.ToString("MM/dd/yyyy");
            } }
        public DateTime? End { get; set; }
        public string EndStr
        {
            get
            {
                return End.HasValue ? End.Value.ToString("MM/dd/yyyy") : "";
            }
        }
        public EmploymentStatusEnum EmploymentStatus { get; set; }

        public String EmploymentStatusString { get
            {
                return Enum.GetName(typeof(EmploymentStatusEnum), EmploymentStatus);
            } }
        public TimeSpan ShiftStart { get; set; }

        public TimeSpan ShiftEnd { get; set; }
   
        public int? ManagerId { get; set; }

        public string ManagerName { get; set; }
        public string Photo { get; set; }


        [MaxFileSize(5 * 1024 * 1024)]
        [AllowedExtensions(new string[] { ".jpg", ".png" })]
        public IFormFile PhotoFile { get; set; }

        public string Color { get; set; }

        public string Error { get; set; }


        public List<SelectListItem> PositionOptions { get; set; }
   

        public List<SelectListItem> DepartmentOptions { get; set; }


        public List<SelectListItem> ManagerOptions { get; set; }
        
        public List<SelectListItem> EmploymentStatusOptions { get; set; }

        public Employee ToEmployee()
        {
            
             Employee employee = new Employee();

            employee.EmployeeId = EmployeeId.HasValue ? EmployeeId.Value : 0;
            employee.Name = Name;
            employee.Address = Address;
            employee.Email = Email;
            employee.PhoneNumber = PhoneNumber;
            employee.PositionId = PositionId;
            employee.DepartmentId = DepartmentId;
            employee.Start = Start;
            employee.End = End;
            employee.EmploymentStatus = EmploymentStatus;
            employee.ShiftStart = ShiftStart;
            employee.ShiftEnd = ShiftEnd;
            employee.ManagerId = ManagerId;
            employee.Photo = Photo;
            employee.Color = Color;

            return employee;
        }


        public EmployeeViewModel(List<PositionViewModel> positionOptions,
            List<DepartmentViewModel> departmentOptions, List<EmployeeViewModel> managerOptions, Employee employee = null)

        {
            this.Start = DateTime.Now;

            if (employee != null)
            {
                initEmployeeData(employee);
            }
            this.InitOptions(positionOptions, departmentOptions, managerOptions);

           

           
        }

        public EmployeeViewModel(Employee employee) {
            initEmployeeData(employee);
        }

        private void initEmployeeData(Employee employee)
        {
            EmployeeId = employee.EmployeeId;
            Name = employee.Name;
            Address = employee.Address;
            Email = employee.Email;
            PhoneNumber = employee.PhoneNumber;
            
            PositionId = employee.Position.PositionId;
            PositionName = employee.Position.Name;

            DepartmentId = employee.Department.DepartmentId;
            DepartmentName = employee.Department.Name;

            Start = employee.Start;
            End = employee.End;
            EmploymentStatus = employee.EmploymentStatus;
            ShiftStart = employee.ShiftStart;
            ShiftEnd = employee.ShiftEnd;
            ManagerId = employee.ManagerId;
            ManagerName = employee.Manager != null ? employee.Manager.Name : null;
            Photo = employee.Photo;
            Color = employee.Color;
        }

        public EmployeeViewModel() { }

        public void InitOptions(List<PositionViewModel> positionOptions,
            List<DepartmentViewModel> departmentOptions, List<EmployeeViewModel> managerOptions)
        {
            PositionOptions = positionOptions.Select(x => new SelectListItem(x.Name, x.PositionId.ToString(),
                x.PositionId == PositionId) ).ToList();
            DepartmentOptions = departmentOptions.Select(x => new SelectListItem(x.Name, x.DepartmentId.ToString(),
                x.DepartmentId == DepartmentId)
                ).ToList();
            ManagerOptions = new List<SelectListItem>();

            ManagerOptions.Add(new SelectListItem("None", "", ManagerId == null));

            managerOptions.Where(x => EmployeeId != x.EmployeeId).Select(x => new SelectListItem(x.Name, x.EmployeeId.ToString(),
                x.EmployeeId == ManagerId)).ToList().ForEach(elem =>
                {
                    ManagerOptions.Add(elem);
                });
            
            EmploymentStatusOptions = new List<SelectListItem>();
            var esOptions = (EmploymentStatusEnum[])Enum.GetValues(typeof(EmploymentStatusEnum));
            for (int i = 0; i < esOptions.Length; i++)
            {
                EmploymentStatusOptions.Add(new SelectListItem(esOptions[i].ToString(), i.ToString()));
            }
        }
    }

    

    public class PositionViewModel
    {
        public int PositionId { get; set; }
        [Required]
        public string Name { get; set; }


        public Position ToPosition()
        {
            return new Position
            {
                PositionId = PositionId,
                Name = Name,
            };
        }
       public  PositionViewModel(Position position)
        {
            Name = position.Name;
            PositionId = position.PositionId;
        }

        public PositionViewModel()
        {

        }
       
    
    }

    public class DepartmentViewModel
    {
        public int DepartmentId { get; set; }
        [Required]
        public string Name { get; set; }

        public Department ToDepartment()
        {
            return new Department
            {
                DepartmentId = DepartmentId,
                Name = Name
            };
        }

        public DepartmentViewModel(Department department)
        {
            Name = department.Name;
            DepartmentId = department.DepartmentId;
        }

        public DepartmentViewModel()
        {

        }
    }
}
