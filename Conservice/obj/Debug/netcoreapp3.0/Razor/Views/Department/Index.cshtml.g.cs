#pragma checksum "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Department\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7896cceadc4d04778784cae6bacc7526e853f65c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Department_Index), @"mvc.1.0.view", @"/Views/Department/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\_ViewImports.cshtml"
using Conservice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\_ViewImports.cshtml"
using Conservice.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7896cceadc4d04778784cae6bacc7526e853f65c", @"/Views/Department/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08cd474ba88f6c3f90324cce2e122c124d677135", @"/Views/_ViewImports.cshtml")]
    public class Views_Department_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<DepartmentViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Departments</h1>\r\n\r\n<a class=\"btn btn-primary\"");
            BeginWriteAttribute("href", " href=\"", 216, "\"", 255, 1);
#nullable restore
#line 10 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Department\Index.cshtml"
WriteAttributeValue("", 223, Url.Action("New", "Department"), 223, 32, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Add New</a>\r\n\r\n<table id=\"departmentTable\" class=\"table table-striped table-bordered\" style=\"width:100%\">\r\n    <thead>\r\n        <tr>\r\n            <th>Name</th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n\r\n");
#nullable restore
#line 20 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Department\Index.cshtml"
         foreach (var dep in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("           <tr>\r\n               <td>");
#nullable restore
#line 23 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Department\Index.cshtml"
              Write(dep.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n           </tr>\r\n");
#nullable restore
#line 25 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Department\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n</table>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<DepartmentViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591