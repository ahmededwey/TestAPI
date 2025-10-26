using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Repo.Categories.ICategoryRepo _categoryRepo;
        public CategoryController(Repo.Categories.ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = _categoryRepo.GetAll();
            return Ok(categories);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(Category c)
        {
            _categoryRepo.Add(c);
            return Ok(c);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCategory(Category category)
        {
            var c = _categoryRepo.GetById(category.Id);
            if(c==null)
            {
                return BadRequest();
            }
           c.Name = category.Name;
            _categoryRepo.Save();
            return Ok(c);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var c = _categoryRepo.GetById(id);
            if (c == null)
            {
                return BadRequest();
            }
            _categoryRepo.Delete(id);
            _categoryRepo.Save();
            return Ok(c);


        }


    }


}
