using Inventra.IMS.Application.Abstractions.Repositories.Country;
using Inventra.IMS.Persistence.Contexts;

namespace Inventra.IMS.Persistence.Concretes.Repositories.Country
{
    public sealed class CountryWriteRepository
        : WriteRepository<Domain.Entities.Country, Guid, DateTimeOffset>,
        ICountryWriteRepository
    {
        public CountryWriteRepository(InventraDbContext inventraDbContext)
            : base(inventraDbContext) { }
    }
}
