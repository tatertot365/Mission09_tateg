using System;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;
using Mission09_BookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mission09_BookStore.Controllers.Infrastructure
{
	// This creates the pagination for the index page
	[HtmlTargetElement("div", Attributes = "page-blah")]
	public class PaginationTagHelper : TagHelper
	{
		private IUrlHelperFactory uhf;

		public PaginationTagHelper(IUrlHelperFactory temp)
		{
			uhf = temp;
		}

		[ViewContext]
		[HtmlAttributeNotBound]
		public ViewContext vc { get; set; }

		// All of these allow for front-end enablement such as classes
		public PageInfo PageBlah { get; set; }
		public string PageAction { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

		// This functions tracks and outputs page numbers to the front-end it also controls how classes are activated for page numbers
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
			IUrlHelper uh = uhf.GetUrlHelper(vc);

			TagBuilder final = new TagBuilder("div");

			for (int i = 1; i <= PageBlah.TotalPages; i++)
			{
				TagBuilder tb = new TagBuilder("a");

				tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageBlah.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }

                tb.InnerHtml.Append(i.ToString());
				final.InnerHtml.AppendHtml(tb);
			}

			output.Content.AppendHtml(final.InnerHtml);
        }
    }
}

