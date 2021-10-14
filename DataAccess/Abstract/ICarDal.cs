using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstract {
    public interface ICarDal:IEntityRepository<Car> {
        public List<CarDetailDto> GetCarDetailDto();
    }
}