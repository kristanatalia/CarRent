using System;

namespace CarRent.Core.Services.Calculator.Models
{
    public class CalculatorRequest
    {
        public Int64 CarId { get; set; }
        public int Days { get; set; }
    }
}
