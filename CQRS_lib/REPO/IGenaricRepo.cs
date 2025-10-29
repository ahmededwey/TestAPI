using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS_lib.REPO
{
    public interface IGenaricRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        T? GetByName(string name);

        void Add(T entity);
        void Edit(T entity);
        void Delete(int id);
        void Save();
    }
}
