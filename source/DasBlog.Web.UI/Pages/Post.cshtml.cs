using AutoMapper;
using DasBlog.Core;
using DasBlog.Managers.Interfaces;
using DasBlog.Web.Models.BlogViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DasBlog.Web.Pages
{
	public class PostModel : PageModel
	{
		private readonly IBlogManager blogManager;
		private readonly IDasBlogSettings dasBlogSettings;
		private readonly IMapper mapper;

		public PostModel(IBlogManager blogManager, IDasBlogSettings dasBlogSettings, IMapper mapper)
		{
			this.blogManager = blogManager;
			this.dasBlogSettings = dasBlogSettings;
			this.mapper = mapper;
		}

		public PostViewModel Post { get; private set; }

		public void OnGet(string postTitle)
		{
			if (!string.IsNullOrEmpty(postTitle))
			{
				var entry = blogManager.GetBlogPost(postTitle);
				Post = mapper.Map<PostViewModel>(entry);
			}
		}
	}
}
