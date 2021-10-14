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

            // anlamadığım bir şekilde GetCarsByBrandId ve GetCarsByColorId fonksiyonları
            // bozuldu çözemedim aynı zamanda tablolar arasında bilgi de alamıyorum 
            
            /*
            CarManager car =new CarManager(new EfCarDal());
            foreach (var cars in car.GetCarsByColorId(1)) {
                Console.WriteLine(cars.ColorName);
            }
            */




            Brand brand = new Brand(){Id=1,Name="Ferrari"};
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            //brandManager.Update(brand);
            
            Car car = new Car() { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2021, DailyPrice = 100, Description = "458 spider" };
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Update(car);
            foreach (var item in carManager.GetCarsByBrandId(1)) {
                Console.WriteLine(item.Description);
            }




        }
    }
}
