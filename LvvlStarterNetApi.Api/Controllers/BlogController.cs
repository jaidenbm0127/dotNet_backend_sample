using LvvlStarterNetApi.SharedKernel.Models;
using LvvlStarterNetApi.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;

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
        [ProducesResponseType(404)]
        public IActionResult GetById(string id)
        {
            return Ok(_BlogService.GetBlogById(id));
        }

        /// <summary>
        /// Adds an Blog to the MongoDb.
        /// </summary>
        [HttpPost("AddBlog")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post(Blog Blog)
        {
            _BlogService.AddBlog(Blog);
            return Ok();
        }


        /// <summary>
        /// Deletes an Blog to the MongoDb by a given Id.
        /// </summary>
        [HttpDelete("DeleteBlog")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(string id)
        {
            _BlogService.DeleteBlog(id);
            return Ok();
        }
        
        /// <summary>
        /// Comments on post with given Id.
        /// </summary>
        [HttpPost("Comment")]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public IActionResult Comment(string id, string message)
        {
            _BlogService.AddComment(id, message);
            return Ok();
        }
        
        /// <summary>
        /// Gets comments from post with given Id.
        /// </summary>
        [HttpGet("GetCommentsOnPost")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetComment(string id)
        {
            return Ok(_BlogService.GetCommentsOnBlog(id));
        }
    }
}