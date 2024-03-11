using Bilgi_SayarUI.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Bilgi_SayarUI.Infrastructure.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]//Html elemanı değildir demek
        public ViewContext? ViewContext { get; set; }//Görünüm çalıştığında göürünümü temsil eder. Link Üretmek için

        public Pagination PageModel { get; set; }

        public String? PageAction { get; set; }

        public bool PageClassesEnable { get; set; } = false;
        public string PageClass { get; set; } = String.Empty;
        public string PageClassNormal { get; set; } = String.Empty;
        public string PageClassSelected { get; set; } = String.Empty;

        private readonly IUrlHelperFactory _urlHelperFactory;// link oluşturmak için 

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext is not null && PageModel is not null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);// link oluşturduk
                TagBuilder result = new TagBuilder("div");

                for (int i = 1; i <= PageModel.TotalPages; i++)
                {

                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { PageNumber = i });

                    if (PageClassesEnable)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }


                    tag.InnerHtml.Append(i.ToString());
                    result.InnerHtml.AppendHtml(tag);

                }
                output.Content.AppendHtml(result.InnerHtml);
            }
        }



    }
}


