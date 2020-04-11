namespace CarRent.Database.Models
{
    public class CarInsertDataRequest
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProdYear { get; set; }
        public decimal Price { get; set; }
    }
}
