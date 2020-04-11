using System.Collections.Generic;

namespace CarRent.Core.Models
{
    public class CalculatorTotalResponse
    {
        public decimal SubTotal { get; set; }
        public decimal Discount { get; set; }
        public decimal GrandTotal { get; set; }
        public List<CalculatorResponse> CalculatorResponse { get; set; } = new List<CalculatorResponse>();
}
}
