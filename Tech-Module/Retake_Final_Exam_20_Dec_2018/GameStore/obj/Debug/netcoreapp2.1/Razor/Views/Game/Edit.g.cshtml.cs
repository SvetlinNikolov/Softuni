#pragma checksum "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\Game\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5a4ab781435f48c49769e27644af95999de6cd32"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Game_Edit), @"mvc.1.0.view", @"/Views/Game/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Game/Edit.cshtml", typeof(AspNetCore.Views_Game_Edit))]
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
#line 1 "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\_ViewImports.cshtml"
using GameStore;

#line default
#line hidden
#line 2 "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\_ViewImports.cshtml"
using GameStore.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5a4ab781435f48c49769e27644af95999de6cd32", @"/Views/Game/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd522b5d11be77ad5cef1f1a50a2a9e5539791e2", @"/Views/_ViewImports.cshtml")]
    public class Views_Game_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Game>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Game", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\Game\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
            BeginContext(53, 52, true);
            WriteLiteral("\r\n<h1>Edit Game</h1>\r\n<section>\r\n    <div>\r\n        ");
            EndContext();
            BeginContext(105, 1265, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "506450cf6011405dbfa0d778d7bc6ac9", async() => {
                BeginContext(190, 86, true);
                WriteLiteral("\r\n            <label for=\"name\">Name</label>\r\n            <input type=\"text\" id=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 276, "\"", 295, 1);
#line 11 "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\Game\Edit.cshtml"
WriteAttributeValue("", 284, Model.Name, 284, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(296, 98, true);
                WriteLiteral(" name=\"name\" />\r\n            <label for=\"dlc\">DLC</label>\r\n            <input type=\"text\" id=\"dlc\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 394, "\"", 412, 1);
#line 13 "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\Game\Edit.cshtml"
WriteAttributeValue("", 402, Model.Dlc, 402, 10, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(413, 124, true);
                WriteLiteral(" name=\"dlc\" />\r\n            <label for=\"price\">Price</label>\r\n            <input type=\"number\" min=\"0\" step=\"any\" id=\"price\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 537, "\"", 557, 1);
#line 15 "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\Game\Edit.cshtml"
WriteAttributeValue("", 545, Model.Price, 545, 12, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(558, 82, true);
                WriteLiteral(" name=\"price\" />\r\n            <label for=\"platform\">Platform</label>\r\n            ");
                EndContext();
                BeginContext(641, 545, false);
#line 17 "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\Game\Edit.cshtml"
       Write(Html.DropDownList(nameof(Model.Platform), new []
           {
               new SelectListItem{Text = "PC", Value = "PC", Selected = Model.Platform =="PC"},
               new SelectListItem{Text = "Mac", Value = "Mac", Selected = Model.Platform == "Mac"},
               new SelectListItem{Text = "PlayStation 3", Value = "PlayStation 3", Selected = Model.Platform == "PlayStation 3"},
               new SelectListItem{Text = "PlayStation 4", Value = "PlayStation 4", Selected = Model.Platform == "PlayStation 4"},
           }, new {}));

#line default
#line hidden
                EndContext();
                BeginContext(1186, 177, true);
                WriteLiteral("\r\n\r\n            <button class=\"button\" type=\"submit\">Edit</button>\r\n            <button class=\"cancel button\" type=\"button\" onclick=\"location.href=\'/\'\">Cancel</button>\r\n        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 9 "C:\Users\daxte\Desktop\Skeleton\Game Store\GameStore\Views\Game\Edit.cshtml"
                                                        WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1370, 24, true);
            WriteLiteral("\r\n    </div>\r\n</section>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Game> Html { get; private set; }
    }
}
#pragma warning restore 1591
