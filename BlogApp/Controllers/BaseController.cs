using BlogApp.BAL.Interfaces;
using BlogApp.BAL.Service;
using BlogApp.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogApp.Controllers
{
    public class BaseController : Controller
    {
        protected readonly SessionHelper SessionHelper;
        protected readonly IUserService UserService;
        protected readonly IBlogService BlogService;
        protected readonly IAPIService APIService;
        public BaseController()
        {
            SessionHelper = new SessionHelper();
            UserService = new UserService();
            BlogService = new BlogService();
            APIService = new APIService();
        }
    }
}