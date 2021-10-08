using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory {
    public class InMemoryCarDal : ICarDal {

        List<Car> _cars;

        public InMemoryCarDal() {
            _cars = new List<Car>{
                new Car{CarId=1,ColorId=1,BrandId=1,DailyPrice=100,Description="mclaren",ModelYear="2000"},
                new Car{CarId=2,ColorId=2,BrandId=1,DailyPrice=10,Description="reno",ModelYear="2001"},
                new Car{CarId=3,ColorId=3,BrandId=1,DailyPrice=120,Description="ferrari",ModelYear="2002"},
                new Car{CarId=4,ColorId=4,BrandId=1,DailyPrice=90,Description="merc",ModelYear="2003"},
                new Car{CarId=5,ColorId=5,BrandId=1,DailyPrice=70,Description="alfa",ModelYear="2004"},
            };
        }

        public void Add(Car car) {
            _cars.Add(car);
        }

        public void Delete(Car car) {
            Car carToBeDeleted = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            _cars.Remove(carToBeDeleted);
        }

        public List<Car> GetAll() {
            return _cars;
        }

        public List<Car> GetById(int CarId) {
            return _cars.Where(c=>c.CarId==CarId).ToList();
        }

        public void Update(Car car) {
            Car upDatedCar = _cars.SingleOrDefault(c=>c.CarId==car.CarId);
            upDatedCar.ColorId=car.ColorId;
            upDatedCar.BrandId=car.BrandId;
            upDatedCar.DailyPrice=car.DailyPrice;
            upDatedCar.Description=car.Description;
            upDatedCar.ModelYear=car.ModelYear;
        }
    }
}
