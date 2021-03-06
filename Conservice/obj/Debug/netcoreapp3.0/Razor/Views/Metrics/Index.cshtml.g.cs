#pragma checksum "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d0a70254da767cb42f1db912825ae9d9d0f81c04"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Metrics_Index), @"mvc.1.0.view", @"/Views/Metrics/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d0a70254da767cb42f1db912825ae9d9d0f81c04", @"/Views/Metrics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08cd474ba88f6c3f90324cce2e122c124d677135", @"/Views/_ViewImports.cshtml")]
    public class Views_Metrics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Conservice.Models.MetricsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral(@"
<h1>Retention Metrics</h1>

<h2>Hired</h2>
<table id=""hireTable"" class=""table table-striped table-bordered"" style=""width:100%"">
    <thead>
        <tr>
            <th>Year</th>
            <th>Week</th>
            <th>Number</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 21 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
         foreach (var entry in Model.HireReport)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 24 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
           Write(entry.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 25 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
           Write(entry.Week);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 26 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
           Write(entry.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 28 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<h2>Terminated</h2>
<table id=""terminatedTable"" class=""table table-striped table-bordered"" style=""width:100%"">
    <thead>
        <tr>
            <th>Year</th>
            <th>Number</th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 41 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
         foreach (var entry in Model.TerminatedReport)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 44 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
           Write(entry.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>");
#nullable restore
#line 45 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
           Write(entry.Number);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n");
#nullable restore
#line 47 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Conservice.Models.MetricsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
