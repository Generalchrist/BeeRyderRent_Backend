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

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        public IDataResult<List<Car>> GetCarsByColorId(int colorId);
        public IDataResult<List<Car>> GetCarsByDailyPrice(int min, int max);
        public IDataResult<List<CarDetailDto>> GetCarDetailsDto();
        public IDataResult<CarDetailDto> GetCarDetailDto(int id);
        public IDataResult<List<CarDetailDto>> GetFilteredCars(FilterOptions filters);
        public IDataResult<List<int>> GetCarsModelYears();
        public IDataResult<List<string>> GetCarsModels();




        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IResult AddTransactionalTest(Car car);


    }
}
