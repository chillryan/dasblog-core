using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DasBlog.Managers.Interfaces;
using DasBlog.Web.Models.BlogViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DasBlog.Web.Pages
{
	public class BlogModel : PageModel
	{
		private readonly IBlogManager blogManager;
		private readonly IMapper mapper;

		public BlogModel(IBlogManager blogManager, IMapper mapper)
		{
			this.blogManager = blogManager;
			this.mapper = mapper;
		}

		public IEnumerable<PostViewModel> Posts { get; private set; }

		public void OnGet()
		{
			var frontPagePosts = from p in blogManager.GetFrontPagePosts(Request.Headers["Accept-Language"])
								 select mapper.Map<PostViewModel>(p);

			Posts = frontPagePosts;
		}
	}
}
