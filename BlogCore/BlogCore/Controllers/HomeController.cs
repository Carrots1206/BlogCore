using BlogCoreService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCore.Controllers
{
    public class HomeController : Controller
    {
        public BlogPostsService postsService;
        public HomeController(BlogPostsService blogPostsService)
        {
            postsService = blogPostsService;
        }

        public IActionResult Index()
        {
            var List = postsService.GetBlogPostsList();
            return View(List);
        }
    }
}
