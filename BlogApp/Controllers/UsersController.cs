using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class UsersController : BaseController
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
        [HttpPost]
        public async Task<ActionResult> Register(UserRegisterViewModel model)
        {
            var response = await UserService.Register(new UserModel()
            {
                EmailAddress = model.EmailAddress,
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserRole = UserRole.Consumer,
                Password = model.Password,
            }); ;
            if (response.IsSuccess)
            {
                var user = (UserModel)response.Data;
                SessionHelper.SaveUserSession(user.Id, string.Format("{0} {1}", user.FirstName, user.LastName), user.UserRole.ToString());
                return Redirect("/");
            }

            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(UserLoginViewModel model)
        {
            var authResponse = await UserService.Login(model.Username, model.Password);
            var isAuthenticated = authResponse != null && !string.IsNullOrEmpty(authResponse.Id);
            if (isAuthenticated)
            {
                SessionHelper.SaveUserSession(authResponse.Id, string.Format("{0} {1}", authResponse.FirstName, authResponse.LastName), authResponse.UserRole.ToString());
                return Redirect("/");
            }

            return View();
        }

        public ActionResult LogOut()
        {
            SessionHelper.DestroyUserSession();

            return RedirectToAction("Login", "Users");
        }
    }
}