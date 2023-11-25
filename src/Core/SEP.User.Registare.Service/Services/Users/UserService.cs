using SEP.User.Registare.Domain.Exceptions;
using SEP.User.Registare.Domain.Models.Users;
using SEP.User.Registare.Domain.Models.Users.Contracts;
using SEP.User.Registare.Resource;
using SEP.User.Registare.Service.DTOs;
using SEP.User.Registare.Service.Services.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SEP.User.Registare.Service.Services.Users
{
    public class UserService : IUserService
    {

        private readonly IApplicationDbContext _context;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, IApplicationDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        public async Task<UserDTO> Create(UserDTO userDTO, CancellationToken cancellationToken)
        {
            var user = new SEP.User.Registare.Domain.Models.Users.User();
            var exitUser =await _userRepository.GetByEmail(userDTO.Email, cancellationToken);
            if (exitUser is not null)
                throw new SEPException(Errors.EmailAddressIsDuplicate);
            var newUser = user.Create(userDTO.FirstName, userDTO.LastName, userDTO.Email, userDTO.PhoneNumber, userDTO.CountryCode, userDTO.DateOfBirth);
           await _userRepository.Add(newUser, cancellationToken);
            _context.SaveChanges();
            return userDTO;
        }

        public async Task Delete(string email,CancellationToken cancellationToken)
        {
            var exitUser = _userRepository.GetByEmail(email, cancellationToken).Result;
            if (exitUser is null)
                throw new SEPException(Errors.UserNotFound);
            await _userRepository.Delete(exitUser, cancellationToken);
            _context.SaveChanges();
        }

        public Task<UserDTO> Get(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserDTO>> GetAll(CancellationToken cancellationToken)
        {
            var result = new List<UserDTO>();
            var users = await _userRepository.GetAll(cancellationToken);
            if (users == null)
                return null;

            users.ForEach(user => result.Add(new UserDTO() { FirstName = user.FirstName.value, LastName = user.LastName.value, Email = user.EmailAddress.value, PhoneNumber = user.PhoneNumber.value, DateOfBirth = user.DateOfBirth }));
            return result;
        }

        public async Task<UserDTO> Update(UserDTO userDTO, CancellationToken cancellationToken)
        {
            var exitUser = await _userRepository.GetByEmail(userDTO.Email, cancellationToken);
            if (exitUser is null)
                throw new SEPException(Errors.UserNotFound);
            exitUser.Update(userDTO.FirstName, userDTO.LastName, userDTO.PhoneNumber, userDTO.CountryCode, userDTO.DateOfBirth);
            await _userRepository.Update(exitUser, cancellationToken);
            _context.SaveChanges();
            return userDTO;
        }
        public async Task<UserDTO> GetByEmail(string email, CancellationToken cancellationToken)
        {
            var exitUser = await _userRepository.GetByEmail(email, cancellationToken);
            if (exitUser is null)
                throw new SEPException(Errors.UserNotFound);
            return new UserDTO() { FirstName = exitUser.FirstName.value, LastName = exitUser.LastName.value, PhoneNumber = exitUser.PhoneNumber.value, DateOfBirth = exitUser.DateOfBirth, Email = exitUser.EmailAddress.value, CountryCode = exitUser.PhoneNumber.value.Substring(0, 3) };
        }
    }
}
