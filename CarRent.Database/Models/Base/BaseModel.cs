using System;

namespace CarRent.Database.Models
{
    public class BaseModel
    {
        public Int64 Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
