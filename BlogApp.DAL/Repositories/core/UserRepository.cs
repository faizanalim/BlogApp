using BlogApp.DAL.Models;
using BlogApp.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.core
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> UserManager;

        public UserRepository()
        {
            UserManager = new UserManager<User>(new UserStore<User>(AppContextInstance.GetInstance()));
        }

        public async Task<UserModel> Login(string username, string password)
        {
            return await GetAuthentication(username, password);
        }

        public async Task<AppResponse> Register(UserModel user)
        {
            return await CreateUser(user.FirstName, user.LastName, user.EmailAddress, user.Password, UserRole.Consumer.ToString());
        }

        public async Task<User> GetIdentityUserById(string id)
        {
            return await UserManager.FindByIdAsync(id);
        }
        public async Task<UserModel> GetById(string id)
        {
            var user = await GetIdentityUserById(id);
            var userRole = (await UserManager.GetRolesAsync(user.Id)).FirstOrDefault();

            UserRole userRoleParsed;
            if (!Enum.TryParse<UserRole>(userRole, out userRoleParsed))
                return null;

            return new UserModel()
            {
                EmailAddress = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                UserRole = userRoleParsed
            };
        }
        public async Task<UserModel> GetUserByUsername(string username)
        {
            var user = await UserManager.FindByNameAsync(username);
            if(user == null)
                return null;

            var userRole = (await UserManager.GetRolesAsync(user.Id)).FirstOrDefault();

            UserRole userRoleParsed;
            if (!Enum.TryParse<UserRole>(userRole, out userRoleParsed))
                return null;

            return new UserModel()
            {
                EmailAddress = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                UserRole = userRoleParsed
            };
        }
        private async Task<AppResponse> CreateUser(string firstName, string lastName, string emailAddress, string password, string userRole)
        {
            var user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = emailAddress,
                Email = emailAddress,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };
            var result = await UserManager.CreateAsync(user, password);
            await UserManager.AddToRoleAsync(user.Id, userRole);
            return new AppResponse(true, string.Empty, user.Id);
        }
        private async Task<UserModel> GetAuthentication(string username, string password)
        {
            var user = await UserManager.FindByEmailAsync(username);
            var isValid = await UserManager.CheckPasswordAsync(user, password);
            if (!isValid)
                throw new Exception("User authentication failed.");

            var userRole = (await UserManager.GetRolesAsync(user.Id)).FirstOrDefault();
            if (string.IsNullOrEmpty(userRole))
                throw new Exception("User authorization failed.");

            UserRole userRoleParsed;
            if (!Enum.TryParse<UserRole>(userRole, out userRoleParsed))
                return null;

            return new UserModel()
            {
                EmailAddress = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Id = user.Id,
                UserRole = userRoleParsed
            };
        }

    }
}
