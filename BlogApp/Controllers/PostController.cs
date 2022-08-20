using BlogApp.BAL.Service;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class PostController : BaseController
    {
        // GET: Post
        public ActionResult Index()
        {
            var userId = SessionHelper.GetUserId();

            if (string.IsNullOrWhiteSpace(userId))
                return Redirect("/Users/Login");

            var blogs = BlogService.GetAll(userId);
            return View(blogs);
        }

       
       
    }
}