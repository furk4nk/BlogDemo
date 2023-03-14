using BlogApıDemo.DataAccess.Concrete;
using BlogApıDemo.Entities.concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BlogApıDemo.Controllers
{
    [Route("api/v1/Blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBlogList()
        {
            Context c = new Context();
            var values = c.Set<Blog>();

            if (values is null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(statusCode: StatusCodes.Status200OK,values);

        }

        [HttpPost]
        public IActionResult PostBlog(Blog blog)
        {
            Context c = new Context();
            if(blog is null) return NotFound();
            c.Add(blog);
            c.SaveChanges();
            return Created(uri:blog.ID.ToString(),value: blog);
        }
        [HttpGet("{id}")]
        public IActionResult GetByBlog(Guid id)
        {
            Context context = new Context();

            var result =context.Set<Blog>().Find(id);
            if (result is null) return StatusCode(statusCode: StatusCodes.Status404NotFound);
            return StatusCode(statusCode:StatusCodes.Status200OK,result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(Guid id)
        {
            Context context = new Context();

            var temp = context.Set<Blog>().Find(keyValues:id);
            if (temp is null) return StatusCode(statusCode: StatusCodes.Status404NotFound);
            context.Remove(entity:temp);
            context.SaveChanges();
            return StatusCode(statusCode: StatusCodes.Status204NoContent);
        }

        [HttpPut]
        public IActionResult UpdateBlog(Blog blog)
        {
            Context c =new Context();

            var temp = c.Set<Blog>().Find(blog.ID);
            if (temp is null) return StatusCode(statusCode: StatusCodes.Status404NotFound);
            temp.BlogDescription = blog.BlogDescription is null && blog.BlogDescription is not null ? temp.BlogDescription : blog.BlogDescription;
            temp.BlogName = blog.BlogName !=temp.BlogName && blog.BlogName is not null ? blog.BlogName : temp.BlogName;
            temp.BlogType = blog.BlogType != temp.BlogType && blog.BlogType is not null ? blog.BlogType : temp.BlogType;
            c.Update(entity:temp);
            c.SaveChanges();
            return StatusCode(statusCode: StatusCodes.Status200OK,temp);
                
        }
    }
    
}
// crud işlemleri api ile tamamlandı şimdi sıra ana proje ile haberleştirmeye ana porjeden burdaki api ile yapmakta sıra