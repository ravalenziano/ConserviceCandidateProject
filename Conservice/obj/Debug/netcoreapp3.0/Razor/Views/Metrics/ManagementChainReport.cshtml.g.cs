#pragma checksum "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\ManagementChainReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a4f481453682229a26c8a4ae33e53eee41b861a8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Metrics_ManagementChainReport), @"mvc.1.0.view", @"/Views/Metrics/ManagementChainReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a4f481453682229a26c8a4ae33e53eee41b861a8", @"/Views/Metrics/ManagementChainReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08cd474ba88f6c3f90324cce2e122c124d677135", @"/Views/_ViewImports.cshtml")]
    public class Views_Metrics_ManagementChainReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Conservice.Models.ManagementChainViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<h1>Management Chain Report</h1>\r\n");
#nullable restore
#line 10 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\ManagementChainReport.cshtml"
 foreach (var tree in Model.TreeList)
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\ManagementChainReport.cshtml"
Write(Html.Raw(tree.ToHtmlElement()));

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\raval\Documents\Projects\conservice-mvc\Conservice\Conservice\Views\Metrics\ManagementChainReport.cshtml"
                                   ;
    
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Conservice.Models.ManagementChainViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
