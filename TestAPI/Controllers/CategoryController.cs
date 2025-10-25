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


    }
}
