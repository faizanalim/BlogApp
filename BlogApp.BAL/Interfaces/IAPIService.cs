using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BAL.Interfaces
{
    public interface IAPIService
    {
        Task<List<SQ1APIBlog>> GetBlogsApiData(string url);
        Task<string> ExecuteGet(string url);
    }
}
