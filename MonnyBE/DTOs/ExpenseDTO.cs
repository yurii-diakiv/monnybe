using System;
using System.Collections.Generic;
using System.Text;

namespace MonnyBE.DTOs
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double AmountOfMoney { get; set; }
        public int? CategoryId { get; set; }
        public int? CustomCategoryId { get; set; }
        public int UserId { get; set; }
    }
}