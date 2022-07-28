using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface ICarService {

        public IDataResult<List<Car>> GetAll();
        public IDataResult<Car> Get(int id);
        public IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        public IDataResult<List<Car>> GetCarsByColorId(int colorId);
        public IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max);
        public IDataResult<List<CarDetailDto>> GetCarDetailsDto();
        public IDataResult<CarDetailDto> GetCarDetailDto(int id);
        public IDataResult<List<CarDetailDto>> GetFilteredCars(FilterOptions filters);
        public IDataResult<List<int>> GetCarsModelYears();
        public IDataResult<List<string>> GetCarsModels();




        public IResult Add(Car car);
        public IResult Update(Car car);
        public IResult Delete(Car car);
        public IResult AddTransactionalTest(Car car);


    }
}
