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
using System.Linq;

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

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car) {
            if (car.Description.Length < 2) {
                return new ErrorResult(Messages.NameInvalid);
            }
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        public IDataResult<Car> Get(int id) {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id));
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAll() {
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

        public IDataResult<List<CarDetailDto>> GetCarDetailsDto() {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsDto(),Messages.CarsListed);
        }

        public IDataResult <CarDetailDto> GetCarDetailDto(int id) {
            return new SuccessDataResult<CarDetailDto>(_carDal.GetCarDetailsDto().Find(p=>p.CarId==id));
        }

        public IDataResult<List<CarDetailDto>> GetFilteredCars(FilterOptions filters) {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetailsDto(car => 
                (filters.Brands == null || filters.Brands.Contains(car.BrandId)) &&
                (filters.Colors == null || filters.Colors.Contains(car.ColorId)) &&
                (filters.MinModelYear == null || filters.MinModelYear <= car.ModelYear) &&
                (filters.MaxPrice == null || filters.MaxPrice <= car.DailyPrice) &&
                (filters.MinPrice == null || filters.MinPrice >= car.DailyPrice)

            ),Messages.FilteredItemsListed);
        }

        [CacheAspect]
        public IDataResult<List<int>> GetCarsModelYears() {
            return new SuccessDataResult<List<int>>(_carDal.GetAll().GroupBy(c => c.ModelYear).Select(x => x.Key).ToList());
        }

        [CacheAspect]
        public IDataResult<List<string>> GetCarsModels() {
            return new SuccessDataResult<List<string>>(_carDal.GetAll().GroupBy(c=> c.Model).Select(x => x.Key).ToList());
        }
    }
}
