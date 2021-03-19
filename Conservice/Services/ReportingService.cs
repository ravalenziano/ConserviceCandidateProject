using Conservice.Data;
using Conservice.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
//using System.Data.Entity.SqlServer;
using System.Linq;
using System.Threading.Tasks;

namespace Conservice.Services
{
    public class ReportingService : IReportingService
    {
        readonly ConserviceContext _context;
        public ReportingService(ConserviceContext context)
        {
            _context = context;
        }
        public List<TerminatedReportViewModel> TerminatedReport()
        {
            List<TerminatedReportViewModel> list = _context.EmployeeChangeEvents
               .Where(x => x.ChangeEventType == EmployeeChangeEventTypeEnum.StatusChange
               && x.New == EmploymentStatusEnum.Terminated.ToString())
               .GroupBy(x => x.Time.Year)
               .Select(x => new TerminatedReportViewModel(
                   x.Key,
                   x.Count()

                   )).ToList();

            return list;

        }

        public List<HireReportViewModel> HireReport()
        {
            List<HireReportViewModel> list = _context.Employees.ToList()
                .GroupBy(e => yearWeekProjector(e.Start))
                .Select(x => new HireReportViewModel(
                    Int32.Parse(x.Key.Split("_")[0]),
                    Int32.Parse(x.Key.Split("_")[1]),
                    x.Count()))
                .OrderByDescending(x => x.Year)
                .ThenByDescending(x => x.Week)
                .ToList();
            return list;
        }

        /*
         *Reference: https://stackoverflow.com/questions/8561782/how-to-group-dates-by-week
         */
        Func<DateTime, String> yearWeekProjector =
    d =>
    {
        return d.Year.ToString() + "_" +
     CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(d,
       CalendarWeekRule.FirstFourDayWeek,
       DayOfWeek.Sunday).ToString();
    };

        public ManagementChainViewModel ManagementChainReport()
        {
            var tree = GetEmployeeNodeTree();
            return new ManagementChainViewModel(tree);
        }

        //Determine if adding this employee will cause a manager cycle
        public bool WillContainCycles(int employeeId, int? managerId)
        {
            if(managerId == null)
            {
                return false;
            }
            if(employeeId == managerId)
            {
                return true;
            }

            var manager = _context.Employees.FirstOrDefault(x => x.EmployeeId == managerId);

            while(manager != null && manager.ManagerId != null)
            {
                if(manager.EmployeeId == employeeId)
                {
                    //Cycle detected
                    return true;
                }
                manager = _context.Employees.FirstOrDefault(x => x.EmployeeId == manager.ManagerId);
            }
            if (manager.EmployeeId == employeeId)
            {
                //Cycle detected
                return true;
            }
            return false;
        }

        public Employee GetTopLevelManager(Employee employee)
        {
            if(employee.ManagerId == null)
            {
                return null;
            }
            var manager = this._context.Employees.FirstOrDefault(x => x.EmployeeId == employee.ManagerId.Value);

            while(manager.ManagerId != null)
            {
                manager = this._context.Employees.FirstOrDefault(x => x.EmployeeId == employee.ManagerId.Value);
            }

            return manager;
        }

        /// <summary>
        /// Get a stack of employees, starting with the employee passed in and ending with the topmost manager
        /// </summary>
        /// <param name="emp"></param>
        /// <param name="employeeList"></param>
        /// <returns></returns>
        private Stack<EmployeeNode> getEmployeeStack(Employee emp, List<Employee> employeeList)
        {
            Stack<EmployeeNode> nodeStack = new Stack<EmployeeNode>();
            EmployeeNode node = new EmployeeNode(emp);
            nodeStack.Push(node);
            Employee current = emp;

            while (current.ManagerId.HasValue)
            {
                current = employeeList.FirstOrDefault(x => x.EmployeeId == current.ManagerId.Value);
                EmployeeNode managerNode = new EmployeeNode(current);
                nodeStack.Push(managerNode);
            }
            return nodeStack;
        }

        /// <summary>
        /// Get a tree of employees for each employee with null ManagerId
        /// </summary>
        /// <returns></returns>
        public List<EmployeeNodeTree> GetEmployeeNodeTree()
        {
            List<Employee> employees = _context.Employees.ToList();
            List<EmployeeNodeTree> list = new List<EmployeeNodeTree>();
            Dictionary<int, EmployeeNode> employeeMap = new Dictionary<int, EmployeeNode>();

            foreach(var emp in employees)
            {
                
                if (employeeMap.ContainsKey(emp.EmployeeId))
                {
                    //Node has already been added so no action needed
                    continue;
                }

                // Get a stack of employees, starting with the employee passed in and ending with the topmost manager
                Stack<EmployeeNode> employeeStack = getEmployeeStack(emp, employees);


                //Get topmost manager
                EmployeeNode current = employeeStack.Pop();

                if (!employeeMap.ContainsKey(current.EmployeeId))
                {
                    //If topmost manager is not already added, create a new tree
                    list.Add(new EmployeeNodeTree
                    {
                        root = current
                    }
                    );
                    //Add empty node to map
                    employeeMap[current.EmployeeId] = current;
                }
                else
                {
                    //Current node already exists in a tree so use that instead of empty one
                    current = employeeMap[current.EmployeeId];
                }

                EmployeeNode currentManager = current;

                while (employeeStack.Count > 0)
                {
                    current = employeeStack.Pop();
                    if (!employeeMap.ContainsKey(current.EmployeeId))
                    {
                        //Add empty node to map
                        employeeMap[current.EmployeeId] = current;
                    }
                    else
                    {
                        //Current node already exists in a tree so use that instead of empty one
                        current = employeeMap[current.EmployeeId];
                    }

                    //If manager does not already have this employee as a child, add it.
                    if (!currentManager.Children.Any(x => x.EmployeeId == current.EmployeeId))
                    {
                        currentManager.Children.Add(current);
                    }

                    currentManager = current;
                }
            }
            return list;
        }


        //    public List<EmployeeNodeTree> GetEmployeeNodeTree()
        //{
        //    List<Employee> employees = _context.Employees.ToList();

        //    List<EmployeeNodeTree> list = new List<EmployeeNodeTree>();
        //    Dictionary<int, EmployeeNode> employeeMap = new Dictionary<int, EmployeeNode>();

        //    foreach (var emp in employees)
        //    {
        //        EmployeeNode node = new EmployeeNode(emp);
        //        if (employeeMap.ContainsKey(emp.EmployeeId))
        //        {
        //            continue;
        //        }
        //        //If manager has already been added to a tree, add employee as a child

        //        Employee topLevelManager = GetTopLevelManager(emp);
        //        if (emp.ManagerId.HasValue && employeeMap.ContainsKey(topLevelManager.ManagerId.Value))
        //        {
        //            employeeMap[emp.ManagerId.Value].Children.Add(node);
        //            employeeMap[emp.EmployeeId] = node;
        //        }
        //        else
        //        {
        //            Stack<EmployeeNode> nodeStack = new Stack<EmployeeNode>();
        //            nodeStack.Push(node);

        //            Employee current = emp;

        //            while (current.ManagerId.HasValue)
        //            {
        //                current = this._context.Employees.FirstOrDefault(x => x.EmployeeId == current.ManagerId.Value);
        //                EmployeeNode managerNode = new EmployeeNode(current);
        //                nodeStack.Push(managerNode);
        //            }


        //            EmployeeNodeTree tree = new EmployeeNodeTree
        //            {
        //                root = nodeStack.Pop()
        //            };
        //            var currentNode = tree.root;

        //            employeeMap[emp.EmployeeId] = node;
        //            employeeMap[currentNode.EmployeeId] = currentNode;

        //            while (nodeStack.Count > 0)
        //            {
        //                var stackNode = nodeStack.Pop();
        //                currentNode.Children.Add(stackNode);
        //                employeeMap[currentNode.EmployeeId] = currentNode;

        //                currentNode = stackNode;
        //            }
        //            list.Add(tree);
        //        }

               
        //    }
        //    return list;
        //}

        public EmployeeCountViewModel EmployeeCountReport()
        {
            var model = new EmployeeCountViewModel
            {
                DepartmentCounts = EmployeeCountByDepartment(),
                ManagerCounts = EmployeeCountByManager()
            };
            return model;
        }

        public List<DepartmentCountViewModel> EmployeeCountByDepartment()
        {

            List<DepartmentCountViewModel>  departmentList = _context.Employees.Include(x => x.Department).ToList()
                .GroupBy(x => x.Department)
                .Select(x => new DepartmentCountViewModel(x.Key.Name, x.Count())).ToList();
            return departmentList;
        }

        public List<ManagerCountViewModel> EmployeeCountByManager()
        {
            List<ManagerCountViewModel> managerList = _context.Employees.Include(x => x.Department).ToList()
                .GroupBy(x => x.Manager)
                .Select(x => new ManagerCountViewModel(x.Key != null ? x.Key.Name : "None", x.Count())).ToList();
            return managerList;
        }







    }
}
