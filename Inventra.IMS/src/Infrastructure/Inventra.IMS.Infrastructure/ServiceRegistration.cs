using Inventra.IMS.Application.Abstractions.Capabilities;
using Inventra.IMS.Infrastructure.Services.Capabilities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Inventra.IMS.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            string uploadRootPath, IHttpContextAccessor httpContextAccessor)
        {
            services.AddScoped<IFileStorageService>(provider =>
            {
                var accessor = provider.GetRequiredService<IHttpContextAccessor>();

                return new LocalFileStorageService(
                    uploadRootPath,
                    httpContextAccessor);
            });

            return services;
        }
    }
}
