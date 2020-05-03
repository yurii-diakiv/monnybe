using DataAccess.Entities;
using System.Linq;

namespace DataAccess.Repositories
{
    public class UserRepository
    {
        private readonly MonnyDbContext dbContext;
        public UserRepository()
        {
            dbContext = new MonnyDbContext();
        }
        public User GetItem(int id)
        {
            return dbContext.Set<User>().Find(id);
        }
        public void Create(User item)
        {
            dbContext.Set<User>().Add(item);
            dbContext.SaveChanges();

            Limitation limitation = new Limitation();
            limitation.Limit = 10000;
            limitation.UserId = item.Id;

            dbContext.Set<Limitation>().Add(limitation);
            dbContext.SaveChanges();
        }
        public User Login(string email, string password)
        {
            User user = dbContext.Set<User>().ToList().Find(u => (u.Email == email && u.Password == password));
            return user;
        }
    }
}
