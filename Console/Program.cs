using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI {
    class Program {
        static void Main(string[] args) {
    

            Brand brand = new Brand(){Id=3,Name="Red Bull"};
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            //var result = brandManager.Add(brand);
            //Console.WriteLine(result.Message);
            
            Car car = new Car() { Id = 2, BrandId = 2, ColorId = 1, ModelYear = 2021, DailyPrice = 100, Description = "bişi" };
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Delete(car);

            /*
            foreach (var item in carManager.GetCarsByColorId(1)) {
                Console.WriteLine(item.Description);
            }
            */


        }
    }
}
