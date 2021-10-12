using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using System;

namespace ConsoleUI {
    class Program {
        static void Main(string[] args) {
            ICarService car=new CarManager(new EfCarDal());
            foreach (var cars in car.GetAll()) {
                Console.WriteLine(cars);
            }

        }
    }
}
