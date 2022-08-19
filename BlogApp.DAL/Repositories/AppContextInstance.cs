using System;
using BlogApp.DAL.Models;

namespace BlogApp.DAL.Repositories
{
    public class AppContextInstance
    {
        private static readonly BlogApp.DAL.Models.AppContext AppContext = new BlogApp.DAL.Models.AppContext();
        public static BlogApp.DAL.Models.AppContext GetInstance()
        {
            return AppContext;
        }
    }
}
