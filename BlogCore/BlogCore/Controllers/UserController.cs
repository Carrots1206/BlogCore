using BlogCoreServce;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogCore.Controllers
{
    public class UserController : Controller
    {
        private BlogUserService userService;
        public UserController(BlogUserService blogUserService)
        {
            userService = blogUserService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UserVerify(string email, string password)
        {
            string username = string.Empty;
            var response = userService.UserVerify(email, password,out username);
            return Json(response);
        }
    }
}
