using BlogApıDemo.DataAccess.Abstract;
using BlogApıDemo.Entities.concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BlogApıDemo.Controllers
{
    [Route("api/v1/Blogs")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogDal _blogDal;

        public BlogController(IBlogDal blogDal)
        {
            this._blogDal=blogDal;
        }

        [HttpGet]
        public IActionResult GetBlogList()
        {
            var values = _blogDal.GetAll();

            if (values is null) return StatusCode(StatusCodes.Status404NotFound);
            return StatusCode(statusCode: StatusCodes.Status200OK,values);
        }

        [HttpPost]
        public IActionResult PostBlog(Blog blog)
        {
            if(blog is null) return NotFound();
            _blogDal.Insert(blog);
            return Created(uri:blog.BlogID.ToString(),value: blog);
        }
        [HttpGet("{id}")]
        public IActionResult GetByBlog(int id)
        {
            var result = _blogDal.GetByID(id);
            if (result is null) return StatusCode(statusCode: StatusCodes.Status404NotFound);
            return StatusCode(statusCode:StatusCodes.Status200OK,result);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBlog(int id)
        {
            var temp = _blogDal.GetByID(id);
            if (temp is null) return StatusCode(statusCode: StatusCodes.Status404NotFound);
            _blogDal.Delete(temp);
            return StatusCode(statusCode: StatusCodes.Status204NoContent);
        }

        [HttpPut]
        public IActionResult UpdateBlog(Blog blog)
        {
            var temp = _blogDal.GetByID(blog.BlogID);
            if (temp is null) return StatusCode(statusCode: StatusCodes.Status404NotFound);
            temp.BlogContext = blog.BlogContext is null && blog.BlogContext is not null ? temp.BlogContext : blog.BlogContext;
            temp.BlogTitle = blog.BlogTitle !=temp.BlogTitle && blog.BlogTitle is not null ? blog.BlogTitle : temp.BlogTitle;
            temp.BlogImage = blog.BlogImage != temp.BlogImage && blog.BlogImage is not null ? blog.BlogImage : temp.BlogImage;
            _blogDal.Update(blog);
            return StatusCode(statusCode: StatusCodes.Status200OK,temp);            
        }
    }   
}
// crud işlemleri api ile tamamlandı şimdi sıra ana proje ile haberleştirmeye ana porjeden burdaki api ile yapmakta sıra