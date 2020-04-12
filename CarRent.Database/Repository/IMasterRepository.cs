using CarRent.Database.Models;
using System.Collections.Generic;

namespace CarRent.Database.Repository
{
    public interface IMasterRepository
    {
        List<T> GetData<T>();
        int Insert(BaseInsertDataRequest baseInsertDataRequest);
        int Update(BaseUpdateDataRequest baseUpdateDataRequest);
        int Delete(BaseDeleteDataRequest baseDeleteDataRequest);
        void Truncate();
    }
}
