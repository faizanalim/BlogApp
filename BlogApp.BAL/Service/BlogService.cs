using BlogApp.DAL.Models;
using BlogApp.DAL.Repositories;
using BlogApp.DAL.Repositories.core;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BAL.Service
{
    public class BlogService : IBlogService
    {
        private IBlogRepository BlogRepository { get; set; }
        public BlogService()
        {
            BlogRepository = new BlogRepository();
        }

        public async Task<List<BlogModel>> GetAll(string userId)
        {
            return await BlogRepository.GetAll(userId);
        }

        public async Task<BlogModel> GetById(string userId, int id)
        {
            return await BlogRepository.GetById(userId, id);
        }

        public async Task<AppResponse> Create(string userId, string title, string content)
        {
            return await BlogRepository.Create(userId, title, content);

        }
        public async Task<AppResponse> ImportBlogs(string userId, List<Blog> blogs, string userLoggedIn)
        {
            return await BlogRepository.ImportBlogs(userId, blogs, userLoggedIn);

        }
    }
}
