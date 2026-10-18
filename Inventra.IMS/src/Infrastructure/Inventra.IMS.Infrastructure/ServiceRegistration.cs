using Inventra.IMS.Application.Abstractions.Capabilities;
using Inventra.IMS.Infrastructure.Services.Capabilities;
using Microsoft.Extensions.DependencyInjection;

namespace Inventra.IMS.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection serviceDescriptors, string uploadRootPath)
        {
            serviceDescriptors.AddScoped<IFileStorageService>(
            _ => new LocalFileStorageService(uploadRootPath));
        }
    }
}
