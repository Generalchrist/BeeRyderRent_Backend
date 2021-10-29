﻿using Business.Abstract;
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


        public IResult Add(Rental rental) {
            var result = _rentalDal.Get(r => r.CarId == rental.CarId);
            if (result==null || result.ReturnDate < DateTime.Now.Date) {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }
            else {
                return new ErrorResult(Messages.NameInvalid);
            }
        }
        public IResult Update(Rental rental) {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.UserUpdated);


        }

        public IResult Delete(Rental rental) {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.UserDeleted);

        }

        public IDataResult<List<Rental>> GetAll() {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.UserListed);

        }

    }
}
