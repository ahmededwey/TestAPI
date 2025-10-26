
using Microsoft.EntityFrameworkCore;
using TestApI.Models;
using TestAPI.Models;
using TestAPI.Repo;

namespace APIITI.Repo.Students
{
    public class StudentRepo : IStudentRepo
    {
        private readonly AppDbContext _Db;

        public StudentRepo(AppDbContext Db)
        {
            _Db = Db;
        }

        void IGenaricRepo<Student>.Add(Student entity)
        {
            if (entity != null)
            {
                _Db.Students.Add(entity);
            }
        }

        void IGenaricRepo<Student>.Delete(int id)
        {
            var student = _Db.Students.Find(id);
            if (student != null)
            {
                _Db.Students.Remove(student);
            }
        }

        void IGenaricRepo<Student>.Edit(Student entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _Db.Students.Update(entity);
        }

        IEnumerable<Student> IGenaricRepo<Student>.GetAll()
        {
            return _Db.Students.AsNoTracking().ToList();
        }

        Student? IGenaricRepo<Student>.GetById(int id)
        {
            return _Db.Students
                .FirstOrDefault(s => s.ID == id);
        }

        Student? IGenaricRepo<Student>.GetByName(string name)
        {
            return _Db.Students
                .FirstOrDefault(s => s.Name == name);
        }

        void IGenaricRepo<Student>.Save()
        {
            _Db.SaveChanges();
        }
    }
}
