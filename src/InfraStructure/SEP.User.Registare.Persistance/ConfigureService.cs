using Microsoft.Extensions.DependencyInjection;
using SEP.User.Registare.Service.Services.Users.Contracts;
using SEP.User.Registare.Service.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEP.User.Registare.Domain.Models.Users.Contracts;
using SEP.User.Registare.Persistance.Repositories.Zaers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SEP.User.Registare.Persistance
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SEPDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SEPConnection"),
                    builder => builder.MigrationsAssembly(typeof(SEPDBContext).Assembly.FullName)));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            return services;
        }
    }
}
