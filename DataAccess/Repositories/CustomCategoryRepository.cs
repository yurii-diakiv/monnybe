using System.Collections.Generic;
using DataAccess.Entities;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CustomCategoryRepository
    {
        private readonly MonnyDbContext dbContext;
        public CustomCategoryRepository()
        {
            dbContext = new MonnyDbContext();
        }
        public List<CustomCategory> GetItems(int userId)
        {
            return dbContext.Set<CustomCategory>().Where(customCategory => 
                    customCategory.UserId == userId).ToList();
        }
        public void Create(CustomCategory item)
        {
            dbContext.Set<CustomCategory>().Add(item);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            IEnumerable<Expense> expenses =  dbContext.Set<Expense>().Where(exp => exp.CustomCategoryId == id);
            dbContext.Set<Expense>().RemoveRange(expenses);
            CustomCategory item = dbContext.Set<CustomCategory>().Find(id);
            dbContext.Set<CustomCategory>().Remove(item);
            dbContext.SaveChanges();
        }
    }
}
