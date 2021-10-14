using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework {
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal {
        public List<CarDetailDto> GetCarDetailDto() {
            using (NorthwindContext context = new NorthwindContext()) {
                var result = from b in context.Brands
                             join c in context.Colors
                             on b.Id equals c.Id
                             join ca in context.Cars
                             on c.Id equals ca.Id
                             select new CarDetailDto {
                                 BrandName = b.Name,
                                 ColorName = c.Name,
                                 DailyPrice = ca.DailyPrice,
                                 CarDescription = ca.Description
                             };
                return result.ToList();
            }
        }
    }
}
