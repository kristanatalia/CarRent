using CarRent.Database.Models;
using System;

namespace CarRent.Database.Repository.Car.Models
{
    public class CarUpdateDataRequest : BaseUpdateDataRequest
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProdYear { get; set; }
        public decimal Price { get; set; }
    }
}
