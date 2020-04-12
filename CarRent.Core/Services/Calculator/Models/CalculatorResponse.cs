using System;

namespace CarRent.Core.Services.Calculator.Models
{
    public class CalculatorResponse
    {
        public Int64 Id { get; set; }
        public Int64 CarId { get; set; }
        public string Car { get; set; }
        public int ProdYear { get; set; }
        public decimal Price { get; set; }
        public int Days { get; set; }
        public decimal PriceBeforeDiscount { get; set; }
        public decimal Discount { get; set; }
        public decimal PriceAfterDiscount { get; set; }
    }
}
