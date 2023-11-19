using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Service.Services
{
    public interface IApplicationDbContext
    {
        public int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
