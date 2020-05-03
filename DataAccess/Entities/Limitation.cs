using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Entities
{
    public class Limitation
    {
        public int Id { get; set; }
        public double Limit { get; set; }
        
        public int UserId { get; set; }
        public User User { get; set; }
    }
}