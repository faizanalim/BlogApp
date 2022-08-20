﻿using BlogApp.Helper;
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
        public BaseController()
        {
            SessionHelper = new SessionHelper();
        }
    }
}