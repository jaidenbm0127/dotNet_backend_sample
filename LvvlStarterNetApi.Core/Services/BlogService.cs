using LvvlStarterNetApi.SharedKernel.Models;
using LvvlStarterNetApi.SharedKernel;
using LvvlStarterNetApi.SharedKernel.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver.Builders;

namespace LvvlStarterNetApi.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IMongoCollection<Blog> _blogs;

        public BlogService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _blogs = database.GetCollection<Blog>(settings.BlogsCollectionName);
        }

        public List<Blog> GetAllBlogs()
        {
            List<Blog> blogs;
            blogs = _blogs.Find(emp => true).ToList();
            return blogs;
        }

        public void AddBlog(Blog Blog)
        {
            _blogs.InsertOne(Blog);
        }

        public Blog GetBlogById(string id)
        {
            var entity = _blogs.Find(blog => blog.Id == ObjectId.Parse(id)).FirstOrDefault();
            return entity;
        }

        public void DeleteBlog(string id)
        {
            _blogs.DeleteOne(blog => blog.Id == ObjectId.Parse(id));
        }

        public void AddComment(string id, string comment)
        {
            var filter = Builders<Blog>
                .Filter.Eq(blog => blog.Id, ObjectId.Parse(id));
            
            var update = Builders<Blog>.Update
                .Push(blog => blog.Comments, comment);

            _blogs.FindOneAndUpdate(filter, update);

        }

        public List<string> GetCommentsOnBlog(string id)
        {
            var entity = _blogs.Find(document => document.Id == ObjectId.Parse(id)).FirstOrDefault();
            
            return entity.Comments;
        }
    }
}
