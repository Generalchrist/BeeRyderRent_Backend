using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract {
    public interface IUserService {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        public IDataResult<List<User>> GetAll();

    }
}
