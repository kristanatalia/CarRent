﻿using System;

namespace CarRent.Database.Models
{
    public class CarUpdateDataRequest
    {
        public Int64 Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProdYear { get; set; }
        public decimal Price { get; set; }
    }
}