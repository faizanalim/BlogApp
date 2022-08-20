using BlogApp.DAL.Models;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories
{
    public interface IUserRepository
    {
        Task<UserModel> Login(string username, string password);
        Task<AppResponse> Register(UserModel user);
        Task<User> GetIdentityUserById(string id);
        Task<UserModel> GetById(string id);
    }
}
