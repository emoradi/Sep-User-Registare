using SEP.User.Registare.Domain.Models.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Persistance.Repositories.Zaers
{
    public class UserRepository : IUserRepository
    {
        private readonly SEPDBContext _SEPDBContext;
        public UserRepository(SEPDBContext sepDBContext)
        {
            this._SEPDBContext = sepDBContext;
        }

        public async Task<Domain.Models.Users.User> Add(Domain.Models.Users.User user, CancellationToken cancellationToken)
        {
            await _SEPDBContext.Users.AddAsync(user, cancellationToken);
            return user;
        }

        public async Task<Domain.Models.Users.User> DeleteByEmail(Domain.Models.Users.User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Models.Users.User>> GetAll(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Domain.Models.Users.User>> GetAllWithPagination(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Models.Users.User> GetByEmail(Domain.Models.Users.User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Models.Users.User> Update(Domain.Models.Users.User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
        //public async Task Add(Domain.Models.Users.User user, CancellationToken cancellationToken)
        //{
        //    await _SEPDBContext.Users.AddAsync(user,cancellationToken);
        //}
    }
}
