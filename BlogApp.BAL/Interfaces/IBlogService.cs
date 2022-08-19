using BlogApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlogApp.BAL.Service
{
    public interface IBlogService 
    {
        Task<BlogModel> GetById(string userId, int id);
        Task<List<BlogModel>> GetAll(string userId);
        Task<AppResponse> Create(string userId, string title, string content);
    }
}
