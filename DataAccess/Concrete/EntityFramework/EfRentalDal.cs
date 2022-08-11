using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework {
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal {
        public List<RentalDetailDto> GetRentalDetailDto(Expression<Func<RentalDetailDto, bool>> expression=null) {
            using (NorthwindContext context = new NorthwindContext()) {
                var result = from r in context.Rentals
                             join ca in context.Cars
                             on r.CarId equals ca.Id
                             join b in context.Brands
                             on ca.BrandId equals b.Id
                             join u in context.Users
                             on r.CustomerId equals u.Id
                             select new RentalDetailDto {
                                 Id = r.Id,
                                 BrandName = b.Name,
                                 Model = ca.Model,
                                 CustomerId = u.Id,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return expression ==null
                    ?result.ToList()
                    :result.Where(expression).ToList();


            }
        }

        // to get back use ctrl k u

    }
}
