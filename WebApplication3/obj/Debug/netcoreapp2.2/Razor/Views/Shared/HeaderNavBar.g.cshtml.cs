#pragma checksum "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "82f69aa575f35a14d75469a6da7d19ed0882feac"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_HeaderNavBar), @"mvc.1.0.view", @"/Views/Shared/HeaderNavBar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/HeaderNavBar.cshtml", typeof(AspNetCore.Views_Shared_HeaderNavBar))]
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
#line 1 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3;

#line default
#line hidden
#line 2 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3.Models;

#line default
#line hidden
#line 2 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 3 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#line default
#line hidden
#line 4 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
using WebApplication3.Data;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"82f69aa575f35a14d75469a6da7d19ed0882feac", @"/Views/Shared/HeaderNavBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"463d1c12e8fc14b2589daa67feec3183fea97611", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_HeaderNavBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("logout"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("role", new global::Microsoft.AspNetCore.Html.HtmlString("form"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Logout", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(182, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(238, 38, true);
            WriteLiteral("\r\n<h1>Roux Academy of Art and Design<a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 276, "\"", 311, 1);
#line 8 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
WriteAttributeValue("", 283, Url.Action("Index", "Home"), 283, 28, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(312, 223, true);
            WriteLiteral(" title=\"home\"></a></h1>\r\n<nav id=\"pageNav\" class=\"cf\">\r\n    <ul>\r\n        <li><a href=\"programs/programs.htm\" title=\"programs\">Programs</a></li>\r\n        <li><a href=\"admissions.htm\" title=\"admissions\">Admissions</a></li>\r\n");
            EndContext();
#line 13 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
         if (SignInManager.IsSignedIn(User))
        {

#line default
#line hidden
            BeginContext(592, 18, true);
            WriteLiteral("            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 610, "\"", 656, 2);
#line 15 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
WriteAttributeValue("", 617, Url.Action("myPictures", "Home"), 617, 33, false);

#line default
#line hidden
            WriteAttributeValue("", 650, "title=", 650, 6, true);
            EndWriteAttribute();
            BeginContext(657, 42, true);
            WriteLiteral(" student portal\">Student Portal</a></li>\r\n");
            EndContext();
#line 16 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
        }
        else
        {

#line default
#line hidden
            BeginContext(735, 18, true);
            WriteLiteral("            <li><a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 753, "\"", 794, 2);
#line 19 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
WriteAttributeValue("", 760, Url.Action("Login", "Home"), 760, 28, false);

#line default
#line hidden
            WriteAttributeValue("", 788, "title=", 788, 6, true);
            EndWriteAttribute();
            BeginContext(795, 42, true);
            WriteLiteral(" student portal\">Student Portal</a></li>\r\n");
            EndContext();
#line 20 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
        }

#line default
#line hidden
            BeginContext(848, 243, true);
            WriteLiteral("\r\n        <li><a href=\"campus_portal.htm\" title=\"campus portal\">Campus</a></li>\r\n        <li><a href=\"alumni.htm\" title=\"alumni\">Alumni</a></li>\r\n        <li><a href=\"about/about.htm\" title=\"about Roux Academy\">About</a></li>\r\n\r\n        <li>\r\n");
            EndContext();
#line 27 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
             if (SignInManager.IsSignedIn(User))
            {

#line default
#line hidden
            BeginContext(1156, 16, true);
            WriteLiteral("                ");
            EndContext();
            BeginContext(1172, 172, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "82f69aa575f35a14d75469a6da7d19ed0882feac8447", async() => {
                BeginContext(1244, 93, true);
                WriteLiteral("\r\n                    <input type=\"submit\" value=\"Logout\" class=\"Logout\" />\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1344, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 32 "M:\CTF\NET Core Apps\WebApplication3\WebApplication3\Views\Shared\HeaderNavBar.cshtml"
            }

#line default
#line hidden
            BeginContext(1361, 36, true);
            WriteLiteral("        </li>\r\n\r\n    </ul>\r\n</nav>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
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
