using SEP.User.Registare.Service.Services.Users.Contracts;
using SEP.User.Registare.Service.Services.Users;
using Microsoft.Extensions.DependencyInjection;
using SEP.User.Registare.Service.Services;

namespace SEP.User.Registare.Service
{
    public static class ConfigureService
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUserService), typeof(UserService));
            
            return services;
        }
    }
}

