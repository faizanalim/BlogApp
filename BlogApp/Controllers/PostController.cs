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
            return View();
        }

       
        public ActionResult Add()
        {
            BlogModel obj = new BlogModel();
            return View(obj);
        }

        [HttpPost]
        public async  Task<ActionResult> Add(BlogModel model)
        {
            var result = await BlogService.Create(model.Id.ToString(), model.Title, model.Content);
            // return View();
            // return RedirectToAction("ThankYou", "Account", new { whatever = message });
            return RedirectToAction("Index", "POST");
        }

    }
}