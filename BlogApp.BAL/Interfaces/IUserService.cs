using BlogApp.Model;
using System.Threading.Tasks;

namespace BlogApp.BAL.Service
{
    public interface IUserService 
    {
        Task<UserModel> Login(string username, string password);
        Task<AppResponse> Register(UserModel user);
    }
}
