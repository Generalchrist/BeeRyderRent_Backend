using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete {
    public class RentalManager:IRentalService {

        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal) {
            _rentalDal = rentalDal;
        }
        public IResult IsCarAvailable(int carId) {
            if (_rentalDal.GetAll(r => (r.CarId == carId) && (r.ReturnDate == null)).Any()) {
                return new SuccessResult();

            }
            return new ErrorResult();
        }

        public IResult Add(Rental rental) {
            var result = IsCarAvailable(rental.CarId);
            if (result.Success) {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else {
                return new ErrorResult(Messages.NameInvalid);
            }
        }

        public IResult Delete(Rental rental) {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.UserDeleted);

        }

        public IDataResult<List<Rental>> GetAll() {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.UserListed);

        }



        public IResult Update(Rental rental) {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UserUpdated);


        }

        public IResult IsCarReturned(int carId) {
            if (_rentalDal.GetAll(r => (r.CarId == carId) && (r.ReturnDate == null)).Any()) {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
