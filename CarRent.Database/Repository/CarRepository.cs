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

        public int Insert(CarInsertDataRequest carInsertDataRequest)
        {
            return ExecuteQuery("SP_MST_CAR_INSERT", carInsertDataRequest);
        }

        public int Update(CarUpdateDataRequest carUpdateDataRequest)
        {
            return ExecuteQuery("SP_MST_CAR_UPDATE", carUpdateDataRequest);
        }

        public int Delete(CarDeleteDataRequest carDeleteDataRequest)
        {
            return ExecuteQuery("SP_MST_CAR_DELETE", carDeleteDataRequest);
        }

        public void Truncate()
        {
            ExecuteNonQuery("SP_MST_CAR_TRUNCATE", null);
        }
    }
}
