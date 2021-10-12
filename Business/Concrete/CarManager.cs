using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete {
    public class CarManager : ICarService {

        ICarDal _carDal;
        IBrandDal _brandDal;
        IColorDal _colorDal;

        public CarManager(IColorDal colorDal) {
            _colorDal = colorDal;
        }

        public CarManager(IBrandDal brandDal) {
            _brandDal = brandDal;
        }

        public CarManager(ICarDal carDal) {
            _carDal = carDal;
        }

        public void Add(Car car) {
            if (car.CarDescription.Length>2) {
                _carDal.Add(car);

            }
            else Console.WriteLine("fck off");

        }




        public void Delete(Car car) {
            _carDal.Delete(car);
        }

        public List<Car> GetAll() {
            return _carDal.GetAll();
        }

        public List<Brand> GetCarsByBrandId(int brandId) {
            return _brandDal.GetAll(p=> p.BrandId==brandId);
        }

        public List<Color> GetCarsByColorId(int colorId) {
            return _colorDal.GetAll(p=> p.ColorId==colorId);
        }

        public List<Car> GetCarsByDailyPrice(int min, int max) {
            return _carDal.GetAll(p=> p.CarUnitPrice>=min && p.CarUnitPrice<=max);
        }

        public void Update(Car car) {
             _carDal.Update(car);
        }
    }
}
