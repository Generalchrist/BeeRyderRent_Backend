using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete {
    public class CarManager : ICarService {

        ICarDal _carDal;


        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        public IResult Add(Car car) {
            if (car.Description.Length<2) {
                return new ErrorResult(Messages.NameInvalid);
            }   
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car) {
            if (car.Description.Length < 2) {
                return new ErrorResult(Messages.NameInvalid);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }

        public IDataResult<List<Car>> GetAll() {
            if (DateTime.Now.Hour==19) {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed); 
        }

        
        public IDataResult<List<Car>> GetCarsByColorId(int colorId) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=> p.ColorId==colorId));
        }
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=> p.DailyPrice>=min && p.DailyPrice<=max));
        }

        public IResult Update(Car car) {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        


    }
}
