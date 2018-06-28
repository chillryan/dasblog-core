using System;
using System.Collections.Generic;
using AutoMapper;
using DasBlog.Managers.Interfaces;
using DasBlog.Web.Models.BlogViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using newtelligence.DasBlog.Runtime;

namespace DasBlog.Web.Pages
{
	public class CreateModel : PageModel
	{
		private readonly IBlogManager blogManager;
		private readonly IMapper mapper;

		public CreateModel(IBlogManager blogManager, IMapper mapper)
		{
			this.blogManager = blogManager;
			this.mapper = mapper;
		}

		[BindProperty]
		public PostViewModel Post { get; set; }

		public IActionResult OnGet()
		{
			Post = new PostViewModel
			{
				AllCategories = mapper.Map<IList<CategoryViewModel>>(blogManager.GetCategories())
			};

			return Page();
		}

		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			try
			{
				var entry = mapper.Map<Entry>(Post);
				entry.Initialize();
				var entryState = blogManager.CreateEntry(entry);
				if (entryState == EntrySaveState.Failed)
				{
					ModelState.AddModelError("", "Failed to create blog post");
					return Page();
				}
			}
			catch (Exception)
			{
				return RedirectToPage("Error");
			}

			return RedirectToPage("Post", Post.Title);
		}
	}
}
