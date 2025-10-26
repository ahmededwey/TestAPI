using TestApI.Models;
using TestAPI.Models;

namespace TestAPI.Repo.Items
{
    public class ItemRepo : IItemRepo
    {
        private readonly AppDbContext _Db;
        public ItemRepo(AppDbContext context)
        {
            _Db = context;
        }
        void IGenaricRepo<Item>.Add(Item entity)
        {
            if (entity != null)
            {
                _Db.Items.Add(entity);
            }
        }

        void IGenaricRepo<Item>.Delete(int id)
        {
            throw new NotImplementedException();
        }

        void IGenaricRepo<Item>.Edit(Item entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Item> IGenaricRepo<Item>.GetAll()
        {
            throw new NotImplementedException();
        }

        Item? IGenaricRepo<Item>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        Item? IGenaricRepo<Item>.GetByName(string name)
        {
            throw new NotImplementedException();
        }

        void IGenaricRepo<Item>.Save()
        {
            throw new NotImplementedException();
        }
    }
}
