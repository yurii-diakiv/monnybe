using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Expense> Expenses { get; set; }
    }
}
