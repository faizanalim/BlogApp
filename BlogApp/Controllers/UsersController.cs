using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
       // private UserContext db = new UserContext();
        // GET: Users
        [Authorize]
        public ActionResult Index()
        {
            return Redirect("/Users/Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {

            return View();
        }
    }
}