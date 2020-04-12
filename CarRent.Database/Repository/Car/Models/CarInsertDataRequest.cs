using CarRent.Database.Models;

namespace CarRent.Database.Repository.Car.Models
{
    public class CarInsertDataRequest : BaseInsertDataRequest
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProdYear { get; set; }
        public decimal Price { get; set; }
    }
}
