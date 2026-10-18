using Microsoft.Extensions.DependencyInjection;

namespace Inventra.IMS.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
            });

            serviceDescriptors.AddAutoMapper(
                _ => { },
                typeof(ServiceRegistration).Assembly);
        }
    }
}
