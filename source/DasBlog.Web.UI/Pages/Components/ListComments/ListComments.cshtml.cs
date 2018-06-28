using DasBlog.Web.Models.BlogViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DasBlog.Web.Pages.Components.ListComments
{
	[ViewComponent(Name = nameof(ListComments))]
	public class ListComments : ViewComponent
	{
		public IViewComponentResult Invoke(ListCommentsViewModel comments)
		{
			return View(nameof(ListComments), comments);
		}
	}
}
