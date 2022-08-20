using BlogApp.DAL.Models;
using BlogApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> Import(string Username, string ImportData)
        {
            var user = await UserService.GetUserByUsername(Username);
            if (user == null)
            {
                ViewBag.ErrorMessage = "User not found";
                return View("Index");
            }
            var userId = SessionHelper.GetUserId();
            var userBlogs = await APIService.GetBlogsApiData(ImportData);
            var blogs = new List<Blog>();
            foreach (var b in userBlogs)
            {
                DateTime date;
                DateTime.TryParse(b.PublicationDate, out date);
                blogs.Add(new Blog() 
                { 
                    Title = b.Title,
                    Content = b.Description,
                    PublishedDate = date
                });
            }
            //var data = JsonConvert.DeserializeObject<SQ1APIBlogData>(json);
            await BlogService.ImportBlogs(user.Id, blogs, userId);
            
            return Redirect("/");
        }
    }
}