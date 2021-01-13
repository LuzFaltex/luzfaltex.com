using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LuzFaltex.Web.TagHelpers
{
    [HtmlTargetElement("github")]
    public class GithubTagHelper : TagHelper
    {
        public string Name { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Attributes.Add("href", $"https://github.com/{Name}");
            output.Attributes.Add("target", "_blank");
            output.Attributes.Add("rel", "noopener");
            output.Content.SetHtmlContent(Name);
        }
    }
}