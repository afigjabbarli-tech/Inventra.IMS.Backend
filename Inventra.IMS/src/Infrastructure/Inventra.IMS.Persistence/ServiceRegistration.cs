using Inventra.IMS.Application.Abstractions.Repositories.Country;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Persistence.Concretes.Repositories.Country;
using Inventra.IMS.Persistence.Concretes.Services;
using Inventra.IMS.Persistence.Contexts;
using Inventra.IMS.Persistence.UofW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Inventra.IMS.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceDescriptors,
            string connectionString)
        {
            serviceDescriptors.AddDbContext<InventraDbContext>(opt =>
            {
                opt.UseNpgsql(connectionString);
            });

            serviceDescriptors.AddScoped<ICountryReadRepository, CountryReadRepository>();
            serviceDescriptors.AddScoped<ICountryWriteRepository, CountryWriteRepository>();

            serviceDescriptors.AddScoped<ICountryService, CountryService>();

            serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
