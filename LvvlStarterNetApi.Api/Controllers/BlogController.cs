using LvvlStarterNetApi.SharedKernel.Models;
using LvvlStarterNetApi.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LvvlStarterNetApi.Api.Controllers
{
    [Route("api/blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _BlogService;

        public BlogController(
            IBlogService BlogService
            )
        {
            _BlogService = BlogService;
        }

        /// <summary>
        /// Retrieves all Blogs from the Db.
        /// </summary>
        [HttpGet("GetBlogs")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<List<Blog>> Get()
        {
            return _BlogService.GetAllBlogs();
        }

        /// <summary>
        /// Retrieves a single Blog by Id from the MongoDb.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult<Blog> GetById(string id)
        {
            return _BlogService.GetBlogById(id);
        }

        /// <summary>
        /// Adds an Blog to the MongoDb.
        /// </summary>
        [HttpPost("AddBlog")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult Post(Blog Blog)
        {
            _BlogService.AddBlog(Blog);
            return StatusCode(201);
        }


        /// <summary>
        /// Deletes an Blog to the MongoDb by a given Id.
        /// </summary>
        [HttpDelete("DeleteBlog")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public ActionResult Delete(string id)
        {
            _BlogService.DeleteBlog(id);
            return StatusCode(204);
        }
        
        /// <summary>
        /// Comments on post with given Id.
        /// </summary>
        [HttpPost("Comment")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public ActionResult Comment(string id, string message)
        {
            _BlogService.AddComment(id, message);
            return StatusCode(201);
        }
        
        /// <summary>
        /// Gets comments from post with given Id.
        /// </summary>
        [HttpGet("GetCommentsOnPost")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<List<string>> GetComment(string id)
        {
            return _BlogService.GetCommentsOnBlog(id);
        }
    }
}