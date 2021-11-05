using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface ICarImageService {
        public IDataResult<List<CarImage>> GetAll();
        IResult Add(IFormFile file, CarImage carImage);
        IResult Update(IFormFile file, CarImage carImage);
        IResult Delete(CarImage carImage);
        public IDataResult<CarImage> Get(int id);
    }
}
