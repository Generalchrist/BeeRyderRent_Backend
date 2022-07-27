using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface IRentalService {
        IResult Add(Rental rental, CreditCard card);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        public IDataResult<List<Rental>> GetAll();
        public IDataResult<List<RentalDetailDto>> GetRentalDetailDto();
        IDataResult<Rental> Get(int rentalId);
        IDataResult<List<DateTime>> GetOccupiedDates(int carId);


    }
}
