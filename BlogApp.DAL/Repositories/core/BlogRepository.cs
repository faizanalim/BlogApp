using BlogApp.DAL.Models;
using BlogApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.DAL.Repositories.core
{
    public class BlogRepository : IBlogRepository
    {
        private IUserRepository UserRepository { get; set; }

        public BlogRepository()
        {
            UserRepository = new UserRepository();
        }
        public async Task<AppResponse> Create(string userId, string title, string content)
        {
            var user = await UserRepository.GetIdentityUserById(userId);
            var appContext = AppContextInstance.GetInstance();
            {
                var blog = new Blog()
                {
                    Content = content,
                    Title = title,
                    CreatedOn = DateTime.UtcNow,
                    ModifiedOn = DateTime.UtcNow,
                    PublishedDate = DateTime.UtcNow,
                    User = user,
                    IsPublished = true,
                    IsDeleted = false,
                };
                appContext.Blogs.Add(blog);
                await appContext.SaveChangesAsync();
                return new AppResponse(true, string.Empty);
            }
        }

        public async Task<List<BlogModel>> GetAll(string userId)
        {
            var appContext = AppContextInstance.GetInstance();
            var blogs = appContext.Blogs.Where(i => i.User.Id == userId)
                .ToList();
            return (from b in blogs
                    select new BlogModel()
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Content = b.Content,
                        PublishedDate = b.PublishedDate.Value
                    }).ToList();
        }

        public async Task<BlogModel> GetById(string userId, int id)
        {
            var appContext = AppContextInstance.GetInstance();
            var blog = appContext.Blogs.Where(i => i.User.Id == userId)
                .FirstOrDefault();
            return new BlogModel()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content
            };
        }


        public async Task<AppResponse> ImportBlogs(string userId, List<Blog> blogs, string userLoggedIn)
        {
            try
            {
                // user check
                var user = await UserRepository.GetIdentityUserById(userId);

                var appContext = AppContextInstance.GetInstance();
                {
                    foreach (var b in blogs)
                    {
                        var blog = new Blog()
                        {
                            Content = b.Content,
                            Title = b.Title,
                            CreatedOn = DateTime.UtcNow,
                            ModifiedOn = DateTime.UtcNow,
                            //ModifiedBy = userLoggedIn,
                            //CreatedBy = userLoggedIn,
                            PublishedDate = DateTime.UtcNow,
                            User = user,
                            IsPublished = true,
                            IsDeleted = false,
                        };
                        appContext.Blogs.Add(blog);
                    }

                    await appContext.SaveChangesAsync();
                    return new AppResponse(true, string.Empty);
                }
            }
            catch (Exception e) { return new AppResponse(false, e.Message); }
        }
    }
}
