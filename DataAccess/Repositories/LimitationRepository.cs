using DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class LimitationRepository
    {
        private readonly MonnyDbContext dbContext;
        public LimitationRepository()
        {
            dbContext = new MonnyDbContext();
        }
        public Limitation GetItemByUserId(int id)
        {
            return dbContext.Set<Limitation>().FirstOrDefault(l => l.UserId == id);
        }
        public void Update(Limitation item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
