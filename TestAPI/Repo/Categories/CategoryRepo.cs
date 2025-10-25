using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestApI.Models;
using TestAPI.Models;

namespace TestAPI.Repo.Categories
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly AppDbContext _Db;

        public CategoryRepo(AppDbContext db)
        {
            _Db = db;
        }

     

        void IGenaricRepo<Category>.Add(Category entity)
        {
            if (entity != null)
            {
                _Db.Categories.Add(entity);
                _Db.SaveChanges();
            }
        }

        void IGenaricRepo<Category>.Delete(int id)
        {
            var category = _Db.Categories.Find(id);
            if (category != null)
            {
                _Db.Categories.Remove(category);
                _Db.SaveChanges();
            }
        }

    
        void IGenaricRepo<Category>.Edit(Category entity)
        {
            if (entity != null)
            {
                _Db.Entry(entity).State = EntityState.Modified;
                _Db.SaveChanges();
            }
        }

        IEnumerable<Category> IGenaricRepo<Category>.GetAll()
        {
            return _Db.Categories.ToList();
        }

  
        Category? IGenaricRepo<Category>.GetById(int id)
        {
            return _Db.Categories.Find(id);
        }

   
        Category? IGenaricRepo<Category>.GetByName(string name)
        {
            return _Db.Categories.FirstOrDefault(c => c.Name == name);
        }

       
        void IGenaricRepo<Category>.Save()
        {
            _Db.SaveChanges();
        }
    }
}
