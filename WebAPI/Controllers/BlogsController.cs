

using DatabaseAccess.Context;
using DatabaseAccess.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Build.Evaluation;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Xml.XPath;
using WebAPI.Common;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class BlogsController : ControllerBaseOptions
    {
        BlogContext _db;

        public BlogsController(BlogContext ctx)
        {
            _db = ctx;
        }

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _db.Blogs.ToList();
        }

        [HttpGet]
        [Route("{id?}")]
        public Blog? Get(string id)
        {
            Uri url = new Uri(HttpUtility.UrlDecode(id));
            return _db.Blogs.SingleOrDefault(b => b.Url == url);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Blog blog)
        {
            _db.Blogs.Add(blog);
            await _db.SaveChangesAsync();
            return Ok(blog);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Blog blog)
        {
            _db.Blogs.Update(blog);
            await _db.SaveChangesAsync();
            return Ok(blog);
        }

        //[HttpPatch]
        //public IActionResult Patch(JsonPatchDocument<Blog> blog)
        //{
        //    if (blog != null)
        //    {
        //        var bb = new Blog();
        //        blog.ApplyTo(bb);

        //        return Ok(bb);
        //    }

        //    return NotFound();
        //}

    }
}
