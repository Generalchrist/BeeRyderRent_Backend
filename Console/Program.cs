using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI {
    class Program {
        static void Main(string[] args) {

            // anlamadığım bir şekilde GetCarsByBrandId ve GetCarsByColorId fonksiyonları
            // bozuldu çözemedim aynı zamanda tablolar arasında bilgi de alamıyorum 
            CarManager car =new CarManager(new EfCarDal());
            foreach (var cars in car.GetCarsByBrandId(1)) {
                Console.WriteLine(cars.BrandName);
            }
        
        
        
        }
    }
}
