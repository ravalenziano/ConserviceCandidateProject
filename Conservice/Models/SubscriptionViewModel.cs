using Conservice.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Models
{
    public class SubscriptionViewModel
    {
        public int NotificationSubscriptionId { get; set; }

        public int EmployeeId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        

        public List<SelectListItem> SubscriberOptions { get; set; }

        public NotificationSubscription ToSubscription()
        {
            return new NotificationSubscription
            {
                EmployeeId = EmployeeId,
                NotificationSubscriptionId = NotificationSubscriptionId
            };
        }

        public SubscriptionViewModel(NotificationSubscription subscription, List<EmployeeViewModel> employeeOptions)
        {
            EmployeeId = subscription.EmployeeId;
            Name = subscription.Employee.Name;
            Email = subscription.Employee.Email;
            NotificationSubscriptionId = subscription.NotificationSubscriptionId;

            this.InitOptions(employeeOptions);
        }

        public void InitOptions(List<EmployeeViewModel> employeeOptions)
        {
            SubscriberOptions = employeeOptions.Select(x => new SelectListItem(x.Name, x.EmployeeId.ToString())).ToList();
        }

        public SubscriptionViewModel(List<EmployeeViewModel> employeeOptions)
        {
            this.InitOptions(employeeOptions);
        }


        public SubscriptionViewModel()
        {

        }
    }

   
}
