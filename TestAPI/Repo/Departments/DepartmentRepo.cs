using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestApI.Models;
using TestAPI.Models;

namespace TestAPI.Repo.departments
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly AppDbContext _Db;

        public DepartmentRepo(AppDbContext db)
        {
            _Db = db;
        }

        void IGenaricRepo<Department>.Add(Department entity)
        {
            if (entity != null)
            {
                _Db.departments.Add(entity);
                _Db.SaveChanges();
            }
        }

        void IGenaricRepo<Department>.Delete(int id)
        {
            var department = _Db.departments.Find(id);
            if (department != null)
            {
                _Db.departments.Remove(department);
                _Db.SaveChanges();
            }
        }

        void IGenaricRepo<Department>.Edit(Department entity)
        {
            if (entity != null)
            {
                _Db.Entry(entity).State = EntityState.Modified;
                _Db.SaveChanges();
            }
        }

        IEnumerable<Department> IGenaricRepo<Department>.GetAll()
        {
            return _Db.departments.ToList();
        }

        Department? IGenaricRepo<Department>.GetById(int id)
        {
            return _Db.departments.Find(id);
        }

        Department? IGenaricRepo<Department>.GetByName(string name)
        {
            return _Db.departments.FirstOrDefault(d => d.Name == name);
        }

        void IGenaricRepo<Department>.Save()
        {
            _Db.SaveChanges();
        }
    }
}
