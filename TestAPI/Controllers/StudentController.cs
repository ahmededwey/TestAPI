using APIITI.Repo.Students;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _StudentRepo;
        public StudentController(IStudentRepo StudentRepo)
        {
            _StudentRepo = StudentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = _StudentRepo.GetAll();
            return Ok(students);
        }


        [HttpPost]
        public async Task<IActionResult> AddStudent(Student S)
        {
            _StudentRepo.Add(S);
            return Ok(S);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            var S = _StudentRepo.GetById(student.ID);
            if (S == null)
            {
                return BadRequest();
            }
            S.Name = S.Name;
            _StudentRepo.Save();
            return Ok(S);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var S = _StudentRepo.GetById(id);
            if (S == null)
            {
                return BadRequest();
            }
            _StudentRepo.Delete(id);
            _StudentRepo.Save();
            return Ok(S);


        }


    }




}
