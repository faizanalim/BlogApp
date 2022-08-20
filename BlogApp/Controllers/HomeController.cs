using BlogApp.Helper;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class HomeController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            var userId = SessionHelper.GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
                return Redirect("/Users/Login");

            var blogs = await BlogService.GetAll(userId);
            return View(blogs);
        }
        public ActionResult Add()
        {
            BlogModel obj = new BlogModel();
            return View(obj);
        }

        [HttpPost]
        public async Task<ActionResult> Add(BlogModel model)
        {
            var userId = SessionHelper.GetUserId();
            var result = await BlogService.Create(userId, model.Title, model.Content);
            // return View();
            // return RedirectToAction("ThankYou", "Account", new { whatever = message });
            return RedirectToAction("Index");
        }
    }
}