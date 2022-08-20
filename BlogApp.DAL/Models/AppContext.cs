using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace BlogApp.DAL.Models
{
    public class AppContext : IdentityDbContext<User>
    {
        public AppContext() : base("DefaultConnectionString")
        {
        }

        public DbSet<Blog> Blogs { get; set; }
    }
}
