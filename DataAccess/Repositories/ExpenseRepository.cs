using System;
using System.Collections.Generic;
using DataAccess.Entities;
using System.Linq;

namespace DataAccess.Repositories
{
    public class ExpenseRepository
    {
        private readonly MonnyDbContext dbContext;
        public ExpenseRepository()
        {
            dbContext = new MonnyDbContext();
        }
        public List<Expense> GetExpensesForThismonth(int userId)
        {
            return dbContext.Set<Expense>().Where(
                expense => expense.Date.Month == DateTime.Now.Month &&
                expense.UserId == userId).ToList();
        }
        public IEnumerable<object> GetFromTo(int userId, DateTime fromDate, DateTime toDate)
        {
            List<Expense> expenses = dbContext.Set<Expense>().ToList();
            List<Category> categories = dbContext.Set<Category>().ToList();
            List<CustomCategory> customCategories = dbContext.Set<CustomCategory>().ToList();
            
            var basicCategoriesExpenses = from expense in expenses
                join category in categories
                    on expense.CategoryId equals category.Id
                where expense.UserId == userId
                    && expense.Date >= fromDate
                    && expense.Date <= toDate
                group expense by category into gEbC
                select new
                    {
                        category = gEbC.Key.Name,
                        expenses = gEbC.Sum(expense => expense.AmountOfMoney)
                    };
            
            var customCategoriesExpenses = from expense in expenses 
                join customCategory in customCategories
                    on expense.CustomCategoryId equals customCategory.Id
                where expense.UserId == userId
                    && expense.Date >= fromDate
                    && expense.Date <= toDate
                group expense by customCategory into gEbC
                select new
                    {
                        category = gEbC.Key.Name,
                        expenses = gEbC.Sum(expense => expense.AmountOfMoney)
                    };
            
            var exps = basicCategoriesExpenses.Concat(customCategoriesExpenses);
            
            return exps;
        }
        public void Create(Expense item)
        {
            dbContext.Set<Expense>().Add(item);
            dbContext.SaveChanges();
        }
    }
}
