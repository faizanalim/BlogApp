using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories
{
    public interface IBlogRepository
    {
        Task<BlogModel> GetById(string userId, int id);
        Task<List<BlogModel>> GetAll(string userId);
        Task<AppResponse> Create(string userId, string title, string content);
    }
}
