using StringConverter.Data.Interfaces;
using StringConverter.Data.Repositories;
using StringConverter.Data.Utilities;

namespace StringConverter.Data
{
    public static class ApplicationService
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        { 
            services.
                AddScoped<IStringConverterRepository, StringConverterRepository> ();
            services.
                AddHostedService<StartUpService>();    
            return services;
        }
    }
}
