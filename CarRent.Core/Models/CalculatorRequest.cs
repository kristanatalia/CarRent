using System;

namespace CarRent.Core.Models
{
    public class CalculatorRequest
    {
        public Int64 CarId { get; set; }
        public int Days { get; set; }
    }
}
