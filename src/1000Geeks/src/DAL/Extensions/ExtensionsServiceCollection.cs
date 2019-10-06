using DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class ExtensionsServiceCollection
    {
        public static IServiceCollection AddContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
    }
}