using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Results.Data;
using Core.Utilities.Security.Hashing;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete {
    public class UserManager : IUserService {

        IUserDal _userDal;
        ICustomerService _customerService;

        public UserManager(
            IUserDal userDal,
            ICustomerService customerService
            ) {
            _userDal = userDal;
            _customerService = customerService;
        }

        public IResult Add(User user) {

            _userDal.Add(user);
            Customer c = new Customer() {
                CustomerId = user.Id
            };
            _customerService.Add(c);
            
            return new SuccessResult();
        }
        public IDataResult<User> GetByMail(string email) {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user) {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

        public IDataResult<UserDto> GetUser(int id) {
            var result = _userDal.Get(u => u.Id == id);
            if (result != null) {
                return new SuccessDataResult<UserDto>(new UserDto {
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email
                });
            }
            return new ErrorDataResult<UserDto>(Messages.UserDoesntExists);
        }

        public IResult Update(User user) {
            var userToUpdate = GetByMail(user.Email).Data;

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            _userDal.Update(userToUpdate);
            return new SuccessResult(Messages.InformationUpdated);
        }
        public IResult ChangePassword(ChangePasswordDto user) {
            var userToUpdate = GetByMail(user.Email).Data;
            if (HashingHelper.VerifyPasswordHash(user.OldPassword, userToUpdate.PasswordHash, userToUpdate.PasswordSalt)) {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(user.NewPassword, out passwordHash, out passwordSalt);
                userToUpdate.PasswordHash = passwordHash;
                userToUpdate.PasswordSalt = passwordSalt;
                _userDal.Update(userToUpdate);
                return new SuccessResult(Messages.PasswordUpdated);
            }
            else return new ErrorResult(Messages.PasswordError);
        }
    }
}
