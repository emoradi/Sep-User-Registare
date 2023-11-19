using SEP.User.Registare.Domain.Models.Users.Contracts;
using SEP.User.Registare.Service.DTOs;
using SEP.User.Registare.Service.Services.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public UserDTO Create(UserDTO zaerDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(UserDTO zaerDTO)
        {
            throw new NotImplementedException();
        }

        public UserDTO Get(UserDTO zaerDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = new List<UserDTO>();
            var users = await _userRepository.GetAll(cancellationToken);
            if (users == null)
                return null;

            users.ForEach(user => result.Add(new UserDTO() {FirstName=user.FirstName.value,LastName=user.LastName.value,Email=user.EmailAddress.value,PhoneNumber=user.PhoneNumber.value,DateOfBirth=user.DateOfBirth }));
            return result;
        }

        public UserDTO Update(UserDTO zaerDTO)
        {
            throw new NotImplementedException();
        }
    }
}
