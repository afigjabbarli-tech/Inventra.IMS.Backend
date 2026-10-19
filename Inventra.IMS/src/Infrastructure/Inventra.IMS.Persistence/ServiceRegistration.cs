using Inventra.IMS.Application.Abstractions.Repositories.Country;
using Inventra.IMS.Application.Abstractions.Repositories.FileAttachment;
using Inventra.IMS.Application.Abstractions.Repositories.FileMetadata;
using Inventra.IMS.Application.Abstractions.Services;
using Inventra.IMS.Application.UofW;
using Inventra.IMS.Persistence.Concretes.Repositories.Country;
using Inventra.IMS.Persistence.Concretes.Repositories.FileAttachment;
using Inventra.IMS.Persistence.Concretes.Repositories.FileMetadata;
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
            serviceDescriptors.AddScoped<IFileMetadataReadRepository, FileMetadataReadRepository>();
            serviceDescriptors.AddScoped<IFileMetadataWriteRepository, FileMetadataWriteRepository>();
            serviceDescriptors.AddScoped<IFileAttachmentReadRepository, FileAttachmentReadRepository>();
            serviceDescriptors.AddScoped<IFileAttachmentWriteRepository, FileAttachmentWriteRepository>();

            serviceDescriptors.AddScoped<ICountryService, CountryService>();
            serviceDescriptors.AddScoped<IFileMetadataService, FileMetadataService>();
            serviceDescriptors.AddScoped<IFileAttachmentService, FileAttachmentService>();

            serviceDescriptors.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
