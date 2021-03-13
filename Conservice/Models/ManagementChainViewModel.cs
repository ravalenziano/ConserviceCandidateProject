using Conservice.Data;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Conservice.Models
{
    public class ManagementChainViewModel
    {
       public List<EmployeeNodeTree> TreeList { get; set; }


        public ManagementChainViewModel(List<EmployeeNodeTree> tree)
        {
            TreeList = tree;
        }
        //public ManagementChainViewModel FromEmployees(List<Employee> employees)
        //{
        //    List<EmployeeNodeTree> list = new List<EmployeeNodeTree>();
        //    Dictionary<int, EmployeeNode> employeeMap = new Dictionary<int, EmployeeNode>();

        //    foreach(var emp in employees)
        //    {
        //        EmployeeNode node = new EmployeeNode(emp);

        //        //If manager has already been added to a tree, add employee as a child
        //        if (emp.ManagerId.HasValue && employeeMap.ContainsKey(emp.ManagerId.Value))
        //        {
        //            employeeMap[emp.ManagerId.Value].Children.Add(node);

        //        }
        //        else
        //        {
        //            //Otherwise add topmost manager first
        //            EmployeeNode managerNode = new EmployeeNode(emp.)
        //        }




        //        employeeMap[emp.EmployeeId] = node;
        //    }
            
        //}
    }


    public class EmployeeNodeTree
    {
        public EmployeeNode root { get; set; }

        public HtmlString ToHtmlElement()
        {
            string html = root.ToHtml();
            var asdf = new HtmlString(html); 
            return new HtmlString(html);
        }
    }

    public class EmployeeNode
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        public List<EmployeeNode> Children { get; set; }

        public EmployeeNode(Employee emp)
        {
            EmployeeId = emp.EmployeeId;
            Name = emp.Name;
            Children = new List<EmployeeNode>();
        }

        public string ToHtml()
        {
            TagBuilder tb = ToTagBuilder();
            String result;
            using (var writer = new StringWriter())
            {

                tb.WriteTo(writer, HtmlEncoder.Default);
                result = writer.ToString();
            }
            return result;
        }

        public TagBuilder ToTagBuilder()
        {
            TagBuilder name = new TagBuilder("div");
            name.InnerHtml.Append(this.Name);

            TagBuilder list = new TagBuilder("ul");

            foreach (var child in Children)
            {

                TagBuilder liTag = new TagBuilder("li");
                var innerTag = child.ToTagBuilder();
                liTag.InnerHtml.AppendHtml(innerTag);
                list.InnerHtml.AppendHtml(liTag);
            }
            TagBuilder container = new TagBuilder("div");

            container.InnerHtml.AppendHtml(name);
            container.InnerHtml.AppendHtml(list);
     
            return container;
        }

    }
}
