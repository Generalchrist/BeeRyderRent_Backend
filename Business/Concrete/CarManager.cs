using Business.Abstract;
using Business.BussinesAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete {
    public class CarManager : ICarService {

        ICarDal _carDal;


        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add,admin")]
        [CacheRemoveAspect("ICarService.Get")]
        //[TransactionScopeAspect]
        //[PerformanceAspect(5)]
        public IResult Add(Car car) {

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

        [CacheAspect]
        public IDataResult<List<Car>> GetAll() {
            //if (DateTime.Now.Hour==19) {
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarsListed); 
        }

        
        public IDataResult<List<Car>> GetCarsByColorId(int colorId) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=> p.ColorId==colorId));
        }


        [CacheAspect]
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p => p.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max) {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(p=> p.DailyPrice>=min && p.DailyPrice<=max));
        }
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car) {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        //[TransactionScopeAspect]
        public IResult AddTransactionalTest(Car car) {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarDetailDto>> GetCarDetailDto() {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailDto(),Messages.CarsListed);
        }

        public IDataResult <CarDetailDto> GetCarDetailDtoById(int id) {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailDto().Find(p=>p.CarId==id));
        }

    }
}
