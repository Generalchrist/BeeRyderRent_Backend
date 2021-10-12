using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface ICarService {

        public List<Car> GetAll();

        public List<Brand> GetCarsByBrandId(int brandId);
        public List<Color> GetCarsByColorId(int colorId);
        public List<Car> GetCarsByDailyPrice(int min, int max);

        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);


    }
}
