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

        public async Task<AppResponse> Register(UserModel model)
        {
            var response = await UserRepository.Register(model);
            if (response.IsSuccess)
            {
                var user = await UserRepository.GetById(Convert.ToString(response.Data));
                response.Data = user;
            }
            return response;
        }

        public async Task<UserModel> GetUserByUsername(string username)
        {
            var user = await UserRepository.GetUserByUsername(username);
            return user;
        }
    }
}
