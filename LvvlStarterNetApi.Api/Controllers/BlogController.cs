using LvvlStarterNetApi.Core.Models;
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
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<List<Blog>> Get()
        {
            return _BlogService.Get();
        }

        /// <summary>
        /// Retrieves a single Blog by Id from the MongoDb.
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            return null;
        }

        /// <summary>
        /// Adds an Blog to the MongoDb.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public IActionResult Post(Blog Blog)
        {
            return null;
        }


        /// <summary>
        /// Deletes an Blog to the MongoDb by a given Id.
        /// </summary>
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult Delete(int id)
        {
            return null;
        }


    }
}