using Business.Abstract;
using Core.Utilities.Results.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete {
    public class FindexManager:IFindexService {
        public IDataResult<int> GetCustomerFindexScore(string customerNationalIdentity) {
            //its all lie
            var rand = new Random().Next(400, 1900);
            return new SuccessDataResult<int>(rand);
        }

    }
}
