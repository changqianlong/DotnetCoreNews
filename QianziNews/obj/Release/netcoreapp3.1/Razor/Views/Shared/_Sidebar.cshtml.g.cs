#pragma checksum "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\Shared\_Sidebar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "164112b9f7e77e55a1b5477f8c2bbaabaedb3fbf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Sidebar), @"mvc.1.0.view", @"/Views/Shared/_Sidebar.cshtml")]
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
#line 1 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews.Models.AccountViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews.Models.CommentViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews.Models.HomeViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews.Models.ManageViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews.Models.NewsViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\_ViewImports.cshtml"
using QianziNews.Models.SearchViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"164112b9f7e77e55a1b5477f8c2bbaabaedb3fbf", @"/Views/Shared/_Sidebar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"899d69f01c9cb86a97de5f509588a11b08963faa", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Sidebar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<HomeViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!--新闻类别-->\r\n");
#nullable restore
#line 4 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\Shared\_Sidebar.cshtml"
 if (Model.CategoryNews != null)
{
    foreach (var c in Model.Categories)
    {

        var items = Model.CategoryNews.News.Where(p => p.Category.Equals(c));
        var imageItems = items.Where(n => n.Images.Count() > 0);
        items = items.Take(5);


#line default
#line hidden
#nullable disable
            WriteLiteral("        <!--新闻类别标签-->\r\n        <div class=\"col-lg-4 col-md-12\">\r\n            <div class=\"ts-category\">\r\n                <ul class=\"ts-category-list\">\r\n                    <li>\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 506, "\"", 566, 1);
#nullable restore
#line 18 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\Shared\_Sidebar.cshtml"
WriteAttributeValue("", 513, Url.Action("Category", "Home", new { category = c }), 513, 53, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"background-image: url(/foreground/images/news/category/category1.png)\">\r\n\r\n                            <span>  ");
#nullable restore
#line 20 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\Shared\_Sidebar.cshtml"
                               Write(c);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </span>
                            <span class=""bar""></span>
                            <span class=""category-count"">新闻数量</span>
                        </a>
                    </li><!-- end list 1 -->

                </ul>
            </div>
        </div><!-- Sidebar Col end -->
");
#nullable restore
#line 29 "C:\Users\Administrator.DESKTOP-N969PKM\Desktop\zaxiang\QianziNews\QianziNews\Views\Shared\_Sidebar.cshtml"

    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<HomeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
