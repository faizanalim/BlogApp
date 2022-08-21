using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogApp.Helper
{
    public class SessionHelper
    {
        private readonly HttpContext Context;
        public SessionHelper()
        {
            Context = HttpContext.Current;
        }
        public void SaveUserSession(string userId, string displayName, string userRole)
        {
            Context.Session["UserID"] = userId;
            Context.Session["DisplayName"] = displayName;
            Context.Session["UserRole"] = userRole;

        }
        public void DestroyUserSession()
        {
            Context.Session["UserID"] = string.Empty;
            Context.Session["DisplayName"] = string.Empty;
            Context.Session["UserRole"] = string.Empty;
        }
        public string GetUserId()
        {
            try
            {
                var id = Convert.ToString(Context.Session["UserID"]);
                new Guid(id);
                return id;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
        public UserRole GetUserRole()
        {
            try
            {
                var userRole = Convert.ToString(Context.Session["UserRole"]);
                if (string.IsNullOrEmpty(userRole))
                    return UserRole.Anonymous;
                switch (userRole.ToLower())
                {
                    case "admin":
                        return UserRole.Admin;
                    case "consumer":
                        return UserRole.Consumer;
                    default:
                        return UserRole.Anonymous;
                }
            }
            catch
            {
                return UserRole.Anonymous;
            }
        }
        public bool IsAdmin()
        {
            var id = GetUserId();
            var userRole = GetUserRole();
            return !string.IsNullOrEmpty(id) && userRole == UserRole.Admin;
        }

        public string DisplayName()
        {

            try
            {
                var displayName = Convert.ToString(Context.Session["DisplayName"]);

                return displayName;
            }
            catch
            {
                return null;
            }
        }
    }
}