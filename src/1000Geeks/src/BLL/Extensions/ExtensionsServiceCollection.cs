using BLL.Interfaces;
using BLL.Services;
using DAL.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace BLL.Extensions
{
    public static class ExtensionsServiceCollection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, string connectionString)
        {
            return services
                    .AddContext(connectionString)
                    .AddTransient<IPicturesService, PicturesService>();
        }
    }
}