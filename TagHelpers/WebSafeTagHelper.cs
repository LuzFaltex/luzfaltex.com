using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LuzFaltex.Web.TagHelpers
{
    [HtmlTargetElement("WebSafe")]
    public class WebSafeTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var content = await output.GetChildContentAsync();

            var encoded = HttpUtility.HtmlEncode(content.GetContent());
            output.Content = content.SetHtmlContent(encoded);
        }
    }
}