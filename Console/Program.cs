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
    

            Brand brand = new Brand(){Id=4,Name="Alpine"};
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            //var result = brandManager.Add(brand);
            //Console.WriteLine(result.Message);
            
            Car car = new Car() { Id = 2, BrandId = 2, ColorId = 1, ModelYear = 2021, DailyPrice = 100, Description = "bişi" };
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Delete(car);

            Customer customer = new Customer{CustomerId=1,CompanyName="Daimler"};
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            //var result = customerManager.Add(customer);
            //Console.WriteLine(result.Message);




            /*
            foreach (var item in customerManager) {
                Console.WriteLine(item.Description);
            }
            */


        }
    }
}
