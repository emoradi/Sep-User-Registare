namespace SEP.User.Registare.Web
{
    public static class ConfigureService
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllersWithViews();
            
            return services;
        }
        }
}
