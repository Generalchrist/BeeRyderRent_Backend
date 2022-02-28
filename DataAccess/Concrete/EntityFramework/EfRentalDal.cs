using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework {
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal {
        public List<RentalDetailDto> GetRentalDetailDto() {
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
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }

        // to get back use ctrl k u

    }
}
