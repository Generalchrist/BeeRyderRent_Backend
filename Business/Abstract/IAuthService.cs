using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract {
    public interface IAuthService {
        IDataResult<UserDTO> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<UserDTO> Login(UserForLoginDto userForLoginDto);
        IResult UserExists(string email);
        IDataResult<AccessToken> CreateAccessToken(UserDTO user);
    }

}
