#pragma checksum "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4f1c6dba95bfaad705dbdbe7dea16c9dc11834e6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_OrderView), @"mvc.1.0.view", @"/Views/Home/OrderView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4f1c6dba95bfaad705dbdbe7dea16c9dc11834e6", @"/Views/Home/OrderView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b25995b076fb7f1de1c33503f1793b6c0721a8a4", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_OrderView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MartenExample.Views.ViewModel.OrderView>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
  
    ViewData["Title"] = "Order View";

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
                <th>Order ID</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>");
#nullable restore
#line 18 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
               Write(Model.customer.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 19 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
               Write(Model.customer.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 20 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
               Write(Model.order.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</td>
            </tr>
        </tbody>
    </table>
    <table border=""1"" class=""table table-bordered"">
        <thead>
            <tr class=""btn-primary"">
                <th>Product ID</th>
                <th>Product Name</th>
                <th>Price</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 33 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
             foreach (var item in Model.order.Items)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>");
#nullable restore
#line 36 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
                   Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 37 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
                   Write(item.name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td class=\"money\">");
#nullable restore
#line 38 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
                                 Write(item.price);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 40 "C:\projects\MartenExample\MartenExample\Views\Home\OrderView.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </tbody>\r\n    </table>\r\n    \r\n</div>\r\n\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral(@"
    <script>

        $('.money').each(function () {
            var item = $(this).text();
            var num = Number(item).toLocaleString('en-US', { style: 'currency', currency: 'USD' });

            $(this).text(num);
        });

    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MartenExample.Views.ViewModel.OrderView> Html { get; private set; }
    }
}
#pragma warning restore 1591