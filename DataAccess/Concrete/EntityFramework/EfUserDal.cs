using Core.Entities.Concrete;
using DataAccess.Abstract;
using System.Collections.Generic;
using System.Linq;
using Core.EntityFramework;

namespace DataAccess.Concrete.EntityFramework {
    public class EfUserDal : EfEntityRepositoryBase<UserDTO, NorthwindContext>, IUserDal {
        public List<OperationClaim> GetClaims(UserDTO user) {
            using (var context = new NorthwindContext()) {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
