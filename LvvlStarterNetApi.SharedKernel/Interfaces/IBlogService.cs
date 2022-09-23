using System.Collections.Generic;
using MongoDB.Bson;
using LvvlStarterNetApi.SharedKernel.Models;

namespace LvvlStarterNetApi.SharedKernel.Interfaces
{
    public interface IBlogService
    {
        List<Blog> GetAllBlogs();

        void AddBlog(Blog Blog);

        Blog GetBlogById(string id);

        void DeleteBlog(string id);

        void AddComment(string id, string comment);

        List<string> GetCommentsOnBlog(string id);
    }
}
