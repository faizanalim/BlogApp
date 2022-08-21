using BlogApp.Helper;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace BlogApp.Controllers
{
    
    public class HomeController : BaseController
    {

        [OutputCache(Duration = 10, VaryByParam = "none", VaryByCustom = "LoggedUserName")]
        public async Task<ActionResult> Index()
        {
            var userId = SessionHelper.GetUserId();
            System.Web.HttpContext.Current.Session["Id"] = userId;
            
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
            return RedirectToAction("Index");
        }
    }
}