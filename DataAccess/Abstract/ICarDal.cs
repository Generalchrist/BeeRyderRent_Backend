using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.DataAccess;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract {
    public interface ICarDal:IEntityRepository<Car> {
        public List<CarDetailDto> GetCarDetailsDto(Expression<Func<CarDetailDto, bool>> filter = null);
        public CarDetailDto GetCarDetailDto(int carId);
    }
}