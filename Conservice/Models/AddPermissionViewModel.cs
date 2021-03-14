using Conservice.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Models
{
    public class PermissionsViewModel
    {
        public List<EmployeePermissionViewModel> CurrentPermissions { get; set; }

        public List<SelectListItem> PermissionOptions { get; set; }

        public int EmployeeId { get; set; }

      //  public int PermissionSelection { get; set; }

        public PermissionsViewModel(int employeeId, List<EmployeePermissionViewModel> currentPermissions)
        {
            EmployeeId = employeeId;
            CurrentPermissions = currentPermissions;
            InitOptions();
        }

        public PermissionsViewModel() { }


        public void InitOptions()
        {

            PermissionOptions = new List<SelectListItem>();
            var peOptions = (PermissionEnum[])Enum.GetValues(typeof(PermissionEnum));
            for (int i = 0; i < peOptions.Length; i++)
            {
                if(CurrentPermissions.Any(x => x.Permission == peOptions[i]))
                {
                    //Don't include an option if employee already has that permission
                    continue;
                }
                PermissionOptions.Add(new SelectListItem(peOptions[i].ToString(), i.ToString()));
            }
        }
    }

    public class EmployeePermissionViewModel
    {
        [Required]
        [Range(1, double.MaxValue)]
        public int EmployeeId { get; set; }
        [Required]
        public PermissionEnum Permission {get; set; }

        public int EmployeePermissionId { get; set; }

        public EmployeePermissionViewModel(EmployeePermission ep)
        {
            EmployeeId = ep.EmployeeId;
            Permission = ep.Permission;
            EmployeePermissionId = ep.EmployeePermissionId;
        }
    }
    public class AddPermissionViewModel
    {
        public int EmployeeId { get; set; }
        public PermissionEnum Permission { get; set; }
    }

    public class RemovePermissionViewModel
    {
        public int EmployeePermissionId { get; set; }

        public int EmployeeId { get; set; }
    }

    //public class PermissionsListViewModel
    //{
    //    List<EmployeePermissionsViewModel>
    //}

    public class EmployeePermissionsViewModel
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public List<PermissionEnum> Permissions { get; set; }

        public string PermissionsString { get
            {
                return string.Join(",", Permissions);
            } }

    }
}
