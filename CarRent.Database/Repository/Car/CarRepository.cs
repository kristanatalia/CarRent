using CarRent.Database.Models;
using System;
using System.Collections.Generic;

namespace CarRent.Database.Repository.Car
{
    public class CarRepository : Connection, IMasterRepository
    {
        public List<T> GetData<T>()
        {
            return ExecuteQuery<T>("SP_MST_CAR_READ", new List<string>());
        }

        public int Insert(BaseInsertDataRequest baseInsertDataRequest)
        {
            return ExecuteQuery("SP_MST_CAR_INSERT", baseInsertDataRequest);
        }

        public int Update(BaseUpdateDataRequest baseUpdateDataRequest)
        {
            return ExecuteQuery("SP_MST_CAR_UPDATE", baseUpdateDataRequest);
        }

        public int Delete(BaseDeleteDataRequest baseDeleteDataRequest)
        {
            return ExecuteQuery("SP_MST_CAR_DELETE", baseDeleteDataRequest);
        }

        public void Truncate()
        {
            ExecuteNonQuery("SP_MST_CAR_TRUNCATE", null);
        }
    }
}
