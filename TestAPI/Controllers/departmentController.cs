using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Repo.departments;


namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentController(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        // GET: api/Department
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = _departmentRepo.GetAll();
            return Ok(departments);
        }

        // GET: api/Department/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = _departmentRepo.GetById(id);
            if (department == null)
                return NotFound($"Department with ID {id} not found.");

            return Ok(department);
        }

        // POST: api/Department
        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department d)
        {
            if (d == null)
                return BadRequest("Invalid department data.");

            _departmentRepo.Add(d);
            return Ok(d);
        }

        // PUT: api/Department
        [HttpPut]
        public async Task<IActionResult> EditDepartment(Department d)
        {
            var existing = _departmentRepo.GetById(d.Id);
            if (existing == null)
                return NotFound($"Department with ID {d.Id} not found.");

            _departmentRepo.Edit(d);
            return Ok(d);
        }

        // DELETE: api/Department/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var existing = _departmentRepo.GetById(id);
            if (existing == null)
                return NotFound($"Department with ID {id} not found.");

            _departmentRepo.Delete(id);
            return Ok($"Department with ID {id} deleted successfully.");
        }
    }
}
