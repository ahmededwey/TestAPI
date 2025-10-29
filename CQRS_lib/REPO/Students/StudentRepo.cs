using CQRS_lib.DATA.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.REPO.Students
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
