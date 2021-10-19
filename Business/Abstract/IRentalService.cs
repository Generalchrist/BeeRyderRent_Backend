using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface IRentalService {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IResult IsCarAvailable(int carId);
        public IResult IsCarReturned(int carId);
        public IDataResult<List<Rental>> GetAll();

    }
}
