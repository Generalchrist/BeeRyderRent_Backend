using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface ICustomerService {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        public IDataResult<Customer> Get(int id);
        public IDataResult<List<Customer>> GetAll();

    }
}
