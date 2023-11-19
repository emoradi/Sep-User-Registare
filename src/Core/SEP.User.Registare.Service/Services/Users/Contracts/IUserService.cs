using SEP.User.Registare.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Service.Services.Users.Contracts
{
    public interface IUserService
    {
        UserDTO Create(UserDTO zaerDTO);
        UserDTO Update(UserDTO zaerDTO);
        void Delete(UserDTO zaerDTO);
        UserDTO Get(UserDTO zaerDTO);
        Task<List<UserDTO>> GetAll(CancellationToken cancellationToken);
    }
}
