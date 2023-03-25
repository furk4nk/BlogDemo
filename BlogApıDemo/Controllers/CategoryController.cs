using BlogApıDemo.DataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApıDemo.Controllers
{
    [Route("api/V1/Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryController(ICategoryDal categoryDal )
        {
            _categoryDal = categoryDal;
        }
        [HttpGet]
        public IActionResult GetListCategory()
        {
            var values = _categoryDal.GetAll();
            return Ok(values);
        }
    }
}
