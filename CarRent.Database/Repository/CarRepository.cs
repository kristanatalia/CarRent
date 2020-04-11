using CarRent.Database.Models;
using System;
using System.Collections.Generic;

namespace CarRent.Database.Repository
{
    public class CarRepository : Connection
    {
        public List<CarModel> GetData()
        {
            return ExecuteQuery<CarModel>("SP_MST_CAR_READ", new List<string>());
        }

        public void Insert(CarInsertDataRequest carInsertDataRequest)
        {
            ExecuteQuery("SP_MST_CAR_INSERT", carInsertDataRequest);
        }

        public void Update(CarUpdateDataRequest carUpdateDataRequest)
        {
            ExecuteQuery("SP_MST_CAR_UPDATE", carUpdateDataRequest);
        }

        public void Delete(CarDeleteDataRequest carDeleteDataRequest)
        {
            ExecuteQuery("SP_MST_CAR_DELETE", carDeleteDataRequest);
        }
    }
}
