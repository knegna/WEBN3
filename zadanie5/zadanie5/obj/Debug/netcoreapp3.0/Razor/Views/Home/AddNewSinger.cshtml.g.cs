#pragma checksum "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\Home\AddNewSinger.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59360fe720ec8f142d71cdc50173d6745283fd9d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AddNewSinger), @"mvc.1.0.view", @"/Views/Home/AddNewSinger.cshtml")]
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
#line 1 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\_ViewImports.cshtml"
using zadanie5;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\_ViewImports.cshtml"
using zadanie5.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59360fe720ec8f142d71cdc50173d6745283fd9d", @"/Views/Home/AddNewSinger.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e5b78dc9f255c33fa03528d0825e9eab5ef3f139", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AddNewSinger : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\Home\AddNewSinger.cshtml"
  
    ViewData["Title"] = "Add new singer";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 5 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\Home\AddNewSinger.cshtml"
 using (Html.BeginForm("AddNewSinger", "Home", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n\r\n        <p>\r\n            ");
#nullable restore
#line 10 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\Home\AddNewSinger.cshtml"
       Write(Html.Label("name", "Enter singer name"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 11 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\Home\AddNewSinger.cshtml"
       Write(Html.TextBox("name", "ivanivanov"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n        <p>\r\n            ");
#nullable restore
#line 15 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\Home\AddNewSinger.cshtml"
       Write(Html.Label("birthdate", "Enter birthdate"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 16 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\Home\AddNewSinger.cshtml"
       Write(Html.TextBox("birthdate", "00.00.00"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
        </p>

        <span class=""col-md-offset-2 col-md-10"">
            <button type=""submit"" value=""Submit"" name=""Submit"">Submit</button>
            <button type=""submit"" value=""Cancel"" name=""Cancel"">Cancel</button>
        </span>
    </div>
");
#nullable restore
#line 24 "C:\Users\R\source\repos\zadanie5\zadanie5\zadanie5\Views\Home\AddNewSinger.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591