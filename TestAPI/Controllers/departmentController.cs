using CQRS_lib.DATA.Models;
using CQRS_lib.REPO.Departments;
using Microsoft.AspNetCore.Mvc;


namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _DepartmentRepo;
        public DepartmentController(IDepartmentRepo DepartmentRepo)
        {
            _DepartmentRepo = DepartmentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var categories = _DepartmentRepo.GetAll();
            return Ok(categories);
        }
      


        [HttpPost]
        public async Task<IActionResult> AddDepartment(Department D)
        {
            if (D == null)
                return BadRequest("Department data is required.");
            if(D.OpenDate >= DateTime.Now)
                return BadRequest("OpenDate must be in the past.");
            _DepartmentRepo.Add(D);
            return Ok(D);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateDepartment(Department department)
        {
            var D = _DepartmentRepo.GetById(department.DeptID);
            if (D == null)
            {
                return BadRequest();
            }
            D.Name = department.Name;
            _DepartmentRepo.Save();
            return Ok(D);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var D = _DepartmentRepo.GetById(id);
            if (D == null)
            {
                return BadRequest();
            }
            _DepartmentRepo.Delete(id);
            _DepartmentRepo.Save();
            return Ok(D);


        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllDepartments(int id)
          {
            var D = _DepartmentRepo.GetById(id);
            if (D == null)
            {
                return BadRequest();
            }
     
            return Ok(D);


        }


    }
}
