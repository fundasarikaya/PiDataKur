#pragma checksum "C:\Users\funda\Desktop\PiData.Proje\PiData.WebUI\Views\Currency\CurrencyRateList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fba21b0e56a479014ade3cf1a3f810bf537256e8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Currency_CurrencyRateList), @"mvc.1.0.view", @"/Views/Currency/CurrencyRateList.cshtml")]
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
#line 1 "C:\Users\funda\Desktop\PiData.Proje\PiData.WebUI\Views\_ViewImports.cshtml"
using PiData.WebUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\funda\Desktop\PiData.Proje\PiData.WebUI\Views\_ViewImports.cshtml"
using PiData.WebUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fba21b0e56a479014ade3cf1a3f810bf537256e8", @"/Views/Currency/CurrencyRateList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9ea0a5554ddb91edfabefae5ceedbf37827dd3d5", @"/Views/_ViewImports.cshtml")]
    public class Views_Currency_CurrencyRateList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<PiData.Business.Common.ExchangeListDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("option"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<section class=""content"">
    <div class=""row"">
        <div class=""col-md-12"">
            <div class=""form-group"">
                <label>Para Birimi</label>
                <select class=""form-control select2"" multiple=""multiple"" data-placeholder=""Para Birimi""
                        style=""width: 100%;"" id=""multicurrencies"">
");
#nullable restore
#line 9 "C:\Users\funda\Desktop\PiData.Proje\PiData.WebUI\Views\Currency\CurrencyRateList.cshtml"
                     foreach (var item in Model.Currencies)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "fba21b0e56a479014ade3cf1a3f810bf537256e84162", async() => {
#nullable restore
#line 11 "C:\Users\funda\Desktop\PiData.Proje\PiData.WebUI\Views\Currency\CurrencyRateList.cshtml"
                                                                 Write(item.Currency);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 11 "C:\Users\funda\Desktop\PiData.Proje\PiData.WebUI\Views\Currency\CurrencyRateList.cshtml"
                           WriteLiteral(item.Currency);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 12 "C:\Users\funda\Desktop\PiData.Proje\PiData.WebUI\Views\Currency\CurrencyRateList.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </select>
            </div>
        </div>
    </div>
    <div class=""row"">
        <div class=""col-xs-12"">
            <div class=""box"">
                <div class=""box-header"">
                    <h3 class=""box-title"">Güncel Kurlar</h3>
                    <a href=""#"" class=""btn btn-success pull-right"" id=""ListeleCurrency"">Güncelle</a>
                </div>

                <div class=""box-body table-responsive no-padding"">
                    <div class=""col-md-3"">
                        <div class=""form-group"">
                            <br />
                           
                        </div>
                    </div>
                </div>
                <div id=""CurrencyRateList"">
              
                </div>

            </div>
        </div>
    </div>

</section>
<script>
    $(document).ready(function () {
        $('#ListeleCurrency').click(function () {
            $(""#CurrencyRateList"").empty();
            var url = '");
#nullable restore
#line 46 "C:\Users\funda\Desktop\PiData.Proje\PiData.WebUI\Views\Currency\CurrencyRateList.cshtml"
                  Write(Url.Action("GetCurrencyRateList", "Currency"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"';

            var currencyP = new Array();
            var index = 0;
            $('#multicurrencies :selected').each(function () {
                currencyP.push($(this).text());
                //currencyP[index] = $(this).text();
                //index++;
            });
            
            $.ajax({
                type: ""GET"",
                url: url,
                data: { currencyP: currencyP.toString() },
                success: function (data) {
                    console.log(data);
                    $(""#CurrencyRateList"").html(data);
                },
            });
        })
    })
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<PiData.Business.Common.ExchangeListDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591
