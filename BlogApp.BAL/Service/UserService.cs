using BlogApp.DAL.Repositories;
using BlogApp.DAL.Repositories.core;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BAL.Service
{
    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; set; }
        public UserService()
        {
            UserRepository = new UserRepository();
        }
        public async Task<UserModel> Login(string username, string password)
        {
            return await UserRepository.Login(username, password);
        }

        public async Task<AppResponse> Register(UserModel user)
        {
            return await UserRepository.Register(user);
        }
    }
}
