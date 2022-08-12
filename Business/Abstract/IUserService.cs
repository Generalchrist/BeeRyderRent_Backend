using Core.Entities.Concrete;
using Core.Utilities.Results.Data;
using System.Collections.Generic;
using Core.Utilities.Results;
using Entities.DTOs;

namespace Business.Abstract {
    public interface IUserService {
        IDataResult<List<OperationClaim>> GetClaims(UserDTO user);
        IResult Add(UserDTO user);
        IResult Update(UserDTO user);
        IDataResult<UserDTO> GetByMail(string email);
        IResult ChangePassword(ChangePasswordDto user);
        IDataResult<UserDto> GetUser(int id);
    }

}
