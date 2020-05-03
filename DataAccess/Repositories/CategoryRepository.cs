using System.Collections.Generic;
using DataAccess.Entities;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CategoryRepository
    {
        private readonly MonnyDbContext dbContext;
        public CategoryRepository()
        {
            dbContext = new MonnyDbContext();
        }
        public List<Category> GetItems()
        {
            return dbContext.Set<Category>().ToList();
        }
        public Category GetItem(int id)
        {
            return dbContext.Set<Category>().Find(id);
        }
    }
}
