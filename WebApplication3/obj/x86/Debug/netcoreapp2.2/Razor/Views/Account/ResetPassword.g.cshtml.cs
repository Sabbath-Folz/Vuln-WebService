#pragma checksum "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a07966c0e4ee919be415c4b2f8154c2b7cd610b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_ResetPassword), @"mvc.1.0.view", @"/Views/Account/ResetPassword.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Account/ResetPassword.cshtml", typeof(AspNetCore.Views_Account_ResetPassword))]
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
#line 1 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3;

#line default
#line hidden
#line 2 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\_ViewImports.cshtml"
using WebApplication3.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a07966c0e4ee919be415c4b2f8154c2b7cd610b", @"/Views/Account/ResetPassword.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"463d1c12e8fc14b2589daa67feec3183fea97611", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_ResetPassword : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApplication3.Models.ResetPasswordViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
  
    ViewBag.Title = "Reset password";

#line default
#line hidden
            BeginContext(100, 6, true);
            WriteLiteral("\r\n<h2>");
            EndContext();
            BeginContext(107, 13, false);
#line 6 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
            EndContext();
            BeginContext(120, 10, true);
            WriteLiteral(".</h2>\r\n\r\n");
            EndContext();
#line 8 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
 using (Html.BeginForm("ResetPassword", "Account", FormMethod.Post, new { @class = "form-horizontal", role = "form" }))
{
    

#line default
#line hidden
            BeginContext(259, 23, false);
#line 10 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
            EndContext();
            BeginContext(284, 47, true);
            WriteLiteral("    <h4>Reset your password.</h4>\r\n    <hr />\r\n");
            EndContext();
            BeginContext(336, 58, false);
#line 13 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
Write(Html.ValidationSummary("", new { @class = "text-danger" }));

#line default
#line hidden
            EndContext();
            BeginContext(401, 35, false);
#line 14 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
Write(Html.HiddenFor(model => model.Code));

#line default
#line hidden
            EndContext();
            BeginContext(438, 38, true);
            WriteLiteral("    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(477, 73, false);
#line 16 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
   Write(Html.LabelFor(m => m.Username, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(550, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(598, 65, false);
#line 18 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
       Write(Html.TextBoxFor(m => m.Username, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(663, 68, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(732, 73, false);
#line 22 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
   Write(Html.LabelFor(m => m.Password, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(805, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(853, 66, false);
#line 24 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
       Write(Html.PasswordFor(m => m.Password, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(919, 68, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        ");
            EndContext();
            BeginContext(988, 80, false);
#line 28 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
   Write(Html.LabelFor(m => m.ConfirmPassword, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
            EndContext();
            BeginContext(1068, 47, true);
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
            EndContext();
            BeginContext(1116, 73, false);
#line 30 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
       Write(Html.PasswordFor(m => m.ConfirmPassword, new { @class = "form-control" }));

#line default
#line hidden
            EndContext();
            BeginContext(1189, 212, true);
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div class=\"form-group\">\r\n        <div class=\"col-md-offset-2 col-md-10\">\r\n            <input type=\"submit\" class=\"btn btn-default\" value=\"Reset\" />\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 38 "C:\Users\User\Desktop\Denis\CTF\CTF-Service\CTF-Service\WebApplication3\Views\Account\ResetPassword.cshtml"
}

#line default
#line hidden
            BeginContext(1404, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApplication3.Models.ResetPasswordViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591