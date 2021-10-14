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
    

            Brand brand = new Brand(){Id=1,Name="Ferrari"};
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Update(brand);
            
            Car car = new Car() { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2021, DailyPrice = 100, Description = "458 spider" };
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Update(car);
            foreach (var item in carManager.GetCarsByColorId(1)) {
                Console.WriteLine(item.Description);
            }


        }
    }
}
