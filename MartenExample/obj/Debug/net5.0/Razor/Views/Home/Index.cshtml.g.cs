#pragma checksum "C:\projects\MartenExample\MartenExample\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c00dd63c313a9cd9a34f8d635ef232c3e17def19"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\projects\MartenExample\MartenExample\Views\_ViewImports.cshtml"
using MartenExample;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\projects\MartenExample\MartenExample\Views\_ViewImports.cshtml"
using MartenExample.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c00dd63c313a9cd9a34f8d635ef232c3e17def19", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b25995b076fb7f1de1c33503f1793b6c0721a8a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Customer>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\projects\MartenExample\MartenExample\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <table border=""1"" class=""table table-bordered"">
        <thead>
            <tr class=""btn-primary"">
                <th>ID</th>
                <th>Name</th>                
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 16 "C:\projects\MartenExample\MartenExample\Views\Home\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 442, "\"", 458, 2);
            WriteAttributeValue("", 449, "/", 449, 1, true);
#nullable restore
#line 19 "C:\projects\MartenExample\MartenExample\Views\Home\Index.cshtml"
WriteAttributeValue("", 450, item.Id, 450, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 19 "C:\projects\MartenExample\MartenExample\Views\Home\Index.cshtml"
                                       Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                    <td><a");
            BeginWriteAttribute("href", " href=\"", 505, "\"", 521, 2);
            WriteAttributeValue("", 512, "/", 512, 1, true);
#nullable restore
#line 20 "C:\projects\MartenExample\MartenExample\Views\Home\Index.cshtml"
WriteAttributeValue("", 513, item.Id, 513, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 20 "C:\projects\MartenExample\MartenExample\Views\Home\Index.cshtml"
                                       Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></td>\r\n                </tr>\r\n");
#nullable restore
#line 22 "C:\projects\MartenExample\MartenExample\Views\Home\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Customer>> Html { get; private set; }
    }
}
#pragma warning restore 1591
