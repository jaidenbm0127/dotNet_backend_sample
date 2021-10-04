using LvvlStarterNetApi.Core.Models;
using LvvlStarterNetApi.SharedKernel;
using LvvlStarterNetApi.SharedKernel.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<Blog> Get()
        {
            List<Blog> blogs;
            blogs = _blogs.Find(emp => true).ToList();
            return blogs;
        }


    }
}
