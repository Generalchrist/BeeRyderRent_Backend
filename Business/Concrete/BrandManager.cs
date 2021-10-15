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
    public class BrandManager : IBrandService {

        IBrandDal _brand;

        public BrandManager(IBrandDal brand) {
            _brand = brand;
        }

        public IResult Add(Brand brand) {
            _brand.Add(brand);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Brand brand) {
            _brand.Delete(brand);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IDataResult<List<Brand>> GetAll() {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<Brand>> GetByBrandId(int Id) {
            return new SuccessDataResult<List<Brand>>(_brand.GetAll(b => b.Id == Id), Messages.CarsListed);

        }

        public IResult Update(Brand brand) {
            _brand.Update(brand);
            return new SuccessResult(Messages.CarUpdated);

        }
    }
}
