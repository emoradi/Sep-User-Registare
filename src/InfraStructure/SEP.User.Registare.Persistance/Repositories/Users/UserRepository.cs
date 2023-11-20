using Microsoft.EntityFrameworkCore;
using SEP.User.Registare.Domain.Models.Users.Contracts;
using SEP.User.Registare.Domain.Models.Users.ValueObjects;
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

        public Task<Domain.Models.Users.User> Add(Domain.Models.Users.User user, CancellationToken cancellationToken)
        {
            _SEPDBContext.Users.AddAsync(user, cancellationToken);
            return Task.FromResult(user);
        }

        public async Task<Domain.Models.Users.User> DeleteByEmail(Domain.Models.Users.User user, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<List<Domain.Models.Users.User>> GetAll(CancellationToken cancellationToken)
        {
            return _SEPDBContext.Users.ToListAsync(cancellationToken);
        }

        public async Task<List<Domain.Models.Users.User>> GetAllWithPagination(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.Models.Users.User?> GetByEmail(string email, CancellationToken cancellationToken)
        {

            EmailAddress emailAddressValue = new EmailAddress(email);
            return _SEPDBContext.Users.Where(x => x.EmailAddress == emailAddressValue).SingleOrDefaultAsync();

        }

        public Task<Domain.Models.Users.User> Update(Domain.Models.Users.User user, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            _SEPDBContext.Users.Update(user);
            return Task.FromResult(user);
        }
        //public async Task Add(Domain.Models.Users.User user, CancellationToken cancellationToken)
        //{
        //    await _SEPDBContext.Users.AddAsync(user,cancellationToken);
        //}
    }
}
