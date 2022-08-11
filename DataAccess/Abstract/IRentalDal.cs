using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract {
    public interface IRentalDal :IEntityRepository<Rental>{
        public List<RentalDetailDto> GetRentalDetailDto(Expression<Func<RentalDetailDto, bool>> expression=null);
    }
}
