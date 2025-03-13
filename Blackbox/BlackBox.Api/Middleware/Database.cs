using Microsoft.EntityFrameworkCore;
using BlackBox.Core.Constant;
using BlackBox.Domain.Database;

namespace BlackBox.Api.Middleware
{
    public static class Database
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IWebHostEnvironment environment, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(ConnectionString.Database));
               
            });
            services.AddDbContextFactory<ApplicationDbContext>(lifetime: ServiceLifetime.Scoped);

            return services;
        }
    }
}
