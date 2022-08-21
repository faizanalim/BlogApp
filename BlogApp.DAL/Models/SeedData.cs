using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Models
{
    public static class SeedData
    {
        public static void CreateSeedData(Models.AppContext context)
        {
            context.Roles.AddOrUpdate(x => x.Id,
              new IdentityRole() { Id = "1", Name = "Admin" },
              new IdentityRole() { Id = "2", Name = "Consumer" }
            );
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var user = new User
            {
                FirstName = "App",
                LastName = "Owner",
                Email = "admin@gmail.com",
                UserName = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = userManager.PasswordHasher.HashPassword("Admin!123"),
                LockoutEnabled = true,
            };
            userManager.Create(user);
            userManager.AddToRole(user.Id, "Admin");

            var userConsumer = new User
            {
                FirstName = "Muhammad",
                LastName = "Faizan",
                Email = "faizan@gmail.com",
                UserName = "faizan@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = userManager.PasswordHasher.HashPassword("Test!123"),
                LockoutEnabled = true,
            };
            userManager.Create(userConsumer);
            userManager.AddToRole(userConsumer.Id, "Consumer");
        }
    }
}
