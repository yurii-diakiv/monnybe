using System;
using System.Collections.Generic;
using System.Text;

namespace MonnyBE.DTOs
{
    public class LimitationDTO
    {
        public int Id { get; set; }
        public double Limit { get; set; }
        public int UserId { get; set; }
    }
}