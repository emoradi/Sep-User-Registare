using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Domain.Models.Users.Contracts
{
    public interface IUserRepository
    {
        Task<User> Add(User user, CancellationToken cancellationToken);
        Task<User> Update(User user, CancellationToken cancellationToken);
        Task<User?> GetByEmail(string email, CancellationToken cancellationToken);
        Task<List<User>> GetAll(CancellationToken cancellationToken);
        Task<List<User>> GetAllWithPagination(int pageSize, int pageNumber,CancellationToken cancellationToken);
        Task Delete(User exitUser, CancellationToken cancellationToken);
    }
}
