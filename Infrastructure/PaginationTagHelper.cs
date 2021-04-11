using IntexFinalMummy.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BYUEgyptIntex2.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;



        public PageLinkTagHelper(IUrlHelperFactory urlhp)
        {
            urlHelperFactory = urlhp;
        }



        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }



        public PageNumberingInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }
        public string PageParameters { get; set; }




        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);



            TagBuilder result = new TagBuilder("div");



            for (int i = 1; i <= PageModel.NumPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });
                tag.Attributes["href"] = tag.Attributes["href"] + PageParameters;
                tag.InnerHtml.Append(i.ToString());




                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }



                
                result.InnerHtml.AppendHtml(tag);
            }



            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
