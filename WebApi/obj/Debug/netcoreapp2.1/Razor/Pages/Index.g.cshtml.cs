#pragma checksum "C:\Users\al3238\Desktop\MyKitchenWebApi\MyKitchen\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9c1bde05b1d43981fcfced79ef4c4441f7fd36b7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(MyKitchen.Pages.Pages_Index), @"mvc.1.0.razor-page", @"/Pages/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Index.cshtml", typeof(MyKitchen.Pages.Pages_Index), null)]
namespace MyKitchen.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\al3238\Desktop\MyKitchenWebApi\MyKitchen\Pages\_ViewImports.cshtml"
using MyKitchen;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c1bde05b1d43981fcfced79ef4c4441f7fd36b7", @"/Pages/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b7b9f8248afd6333b0821df2c85f11b0b712da6", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Index : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\al3238\Desktop\MyKitchenWebApi\MyKitchen\Pages\Index.cshtml"
  
    ViewData["Title"] = "Welcome";

#line default
#line hidden
            BeginContext(69, 1085, true);
            WriteLiteral(@"
<div class=""jumbotron"">
    <h1>My Kitchen</h1>
</div>
<div class=""row"">
    <div class=""col-md-4"">
        <h2>Welcome to My Kitchen Web API</h2>
        <p>
            This is a sample application that is backed with Asp.Net Core and EF Core. More details to be added soon.
        </p>
    </div>
    <div class=""col-md-4"">
        <h2>Build it from scratch</h2>
        <p>You can build the application by following the steps in a series of tutorials.</p>
        <p>
            <a class=""btn btn-default""
               href=""https://docs.microsoft.com/aspnet/core/data/ef-rp/intro"">
                See the tutorial &raquo;
            </a>
        </p>
    </div>
    <div class=""col-md-4"">
        <h2>Download it</h2>
        <p>You can download the completed project from GitHub.</p>
        <p>
            <a class=""btn btn-default""
               href=""https://github.com/aspnet/Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/cu-final"">
                See project source cod");
            WriteLiteral("e &raquo;\r\n            </a>\r\n        </p>\r\n    </div>\r\n</div>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<IndexModel>)PageContext?.ViewData;
        public IndexModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
