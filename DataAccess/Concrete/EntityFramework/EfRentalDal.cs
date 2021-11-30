using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework {
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext> /*,IRentalDal*/ {
        //public List<RentalDetailDto> GetRentalDetailDto() {
        //    using (NorthwindContext context = new NorthwindContext()) {



        //    }
        //}

        // to get back use ctrl k u

    }
}
