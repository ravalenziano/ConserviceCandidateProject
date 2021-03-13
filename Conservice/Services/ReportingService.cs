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
        private readonly IEmployeeService _employeeService;
        public ReportingService(ConserviceContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
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
            //TODO Fix, this only works for one week
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

        public List<EmployeeNodeTree> GetEmployeeNodeTree()
        {
            List<Employee> employees = _context.Employees.ToList();

            List<EmployeeNodeTree> list = new List<EmployeeNodeTree>();
            Dictionary<int, EmployeeNode> employeeMap = new Dictionary<int, EmployeeNode>();

            foreach (var emp in employees)
            {
                EmployeeNode node = new EmployeeNode(emp);

                //If manager has already been added to a tree, add employee as a child
                if (emp.ManagerId.HasValue && employeeMap.ContainsKey(emp.ManagerId.Value))
                {
                    employeeMap[emp.ManagerId.Value].Children.Add(node);
                    employeeMap[emp.EmployeeId] = node;
                }
                else
                {
                    Stack<EmployeeNode> nodeStack = new Stack<EmployeeNode>();
                    nodeStack.Push(node);

                    Employee current = emp;


                    //Otherwise add topmost manager first
                    while (current.ManagerId.HasValue)
                    {
                        current = this._employeeService.GetEmployee(current.ManagerId.Value);
                        EmployeeNode managerNode = new EmployeeNode(current);
                        nodeStack.Push(managerNode);
                    }


                    EmployeeNodeTree tree = new EmployeeNodeTree
                    {
                        root = nodeStack.Pop()
                    };
                    var currentNode = tree.root;
                    employeeMap[currentNode.EmployeeId] = currentNode;
                    while (nodeStack.Count > 0)
                    {
                        var stackNode = nodeStack.Pop();
                        currentNode.Children.Add(stackNode);
                        employeeMap[currentNode.EmployeeId] = currentNode;

                        currentNode = stackNode;
                    }
                    list.Add(tree);
                }

               
            }
            return list;
        }



    }
}
