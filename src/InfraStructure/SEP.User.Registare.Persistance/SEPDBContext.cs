using Microsoft.EntityFrameworkCore;
using SEP.User.Registare.Domain.Models.Users;
using SEP.User.Registare.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Persistance
{
    public class SEPDBContext : DbContext, IApplicationDbContext
    {
        public SEPDBContext(DbContextOptions<SEPDBContext> options)
            : base(options)
        { }
        public DbSet<SEP.User.Registare.Domain.Models.Users.User> Users => Set<SEP.User.Registare.Domain.Models.Users.User>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}

