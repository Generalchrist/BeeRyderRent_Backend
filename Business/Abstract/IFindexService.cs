using Core.Utilities.Results.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface IFindexService {
        IDataResult<int> GetCustomerFindexScore(string customerNationalIdentity);
    }
}
