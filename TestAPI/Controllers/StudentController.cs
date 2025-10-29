using CQRS_lib.DATA.DTO;
using CQRS_lib.DATA.Models;
using CQRS_lib.REPO.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentRepo _StudentRepo;

        public StudentController(IStudentRepo StudentRepo, ILogger<StudentController> logger)
        {
            _StudentRepo = StudentRepo;
            _logger = logger;
        }

        // ===========================================
        // GET: api/Student
        // ===========================================
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            _logger.LogInformation("Fetching all students...");
            var students = _StudentRepo.GetAll();

            if (students == null || !students.Any())
            {
                _logger.LogWarning("No students found in the database.");
                return NotFound("No students found.");
            }

            _logger.LogInformation("Retrieved {Count} students successfully.", students.Count());
            return Ok(students);
        }

        // ===========================================
        // POST: api/Student
        // ===========================================
        [HttpPost]
        public async Task<IActionResult> AddStudent(StudentDTO dto)
        {
            if (dto == null)
            {
                _logger.LogWarning("AddStudent called with null DTO.");
                return BadRequest("Student data is required.");
            }

            if (dto.Age < 18 || dto.Age > 22)
            {
                _logger.LogWarning("Invalid student age: {Age}. Must be between 18 and 22.", dto.Age);
                return BadRequest("Age must be between 18 and 22.");
            }

            var student = new Student
            {
                Name = dto.Name,
                Age = dto.Age,
                Address = dto.Address,
                imageUrl = dto.imageUrl,
                DepartmentID = dto.DepartmentID
            };

            try
            {
                _logger.LogInformation("Adding new student: {Name}, Age: {Age}", student.Name, student.Age);
                _StudentRepo.Add(student);
                _StudentRepo.Save();
                _logger.LogInformation("Student added successfully with ID {Id}", student.ID);

                return Ok(new
                {
                    Message = "Student added successfully.",
                    StudentId = student.ID
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding student {Name}", dto.Name);
                return StatusCode(500, "An error occurred while saving the student.");
            }
        }

        // ===========================================
        // PUT: api/Student
        // ===========================================
        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student student)
        {
            _logger.LogInformation("Updating student with ID {Id}", student.ID);
            var existing = _StudentRepo.GetById(student.ID);

            if (existing == null)
            {
                _logger.LogWarning("Attempted to update non-existent student with ID {Id}", student.ID);
                return NotFound($"Student with ID {student.ID} not found.");
            }

            existing.Name = student.Name;
            existing.Age = student.Age;
            existing.Address = student.Address;
            existing.imageUrl = student.imageUrl;
            existing.DepartmentID = student.DepartmentID;

            try
            {
                _StudentRepo.Save();
                _logger.LogInformation("Student with ID {Id} updated successfully.", student.ID);
                return Ok(existing);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating student with ID {Id}", student.ID);
                return StatusCode(500, "An error occurred while updating the student.");
            }
        }

        // ===========================================
        // DELETE: api/Student/{id}
        // ===========================================
        [HttpDelete]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation("Deleting student with ID {Id}", id);
            var student = _StudentRepo.GetById(id);

            if (student == null)
            {
                _logger.LogWarning("Attempted to delete non-existent student with ID {Id}", id);
                return NotFound($"Student with ID {id} not found.");
            }

            try
            {
                _StudentRepo.Delete(id);
                _StudentRepo.Save();
                _logger.LogInformation("Student with ID {Id} deleted successfully.", id);
                return Ok(student);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting student with ID {Id}", id);
                return StatusCode(500, "An error occurred while deleting the student.");
            }
        }
    }
}
