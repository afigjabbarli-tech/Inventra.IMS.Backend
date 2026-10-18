using Inventra.IMS.Application.Abstractions.Repositories.Country;
using Inventra.IMS.Persistence.Contexts;

namespace Inventra.IMS.Persistence.Concretes.Repositories.Country
{
    public sealed class CountryReadRepository
        : ReadRepository<Domain.Entities.Country, Guid, DateTimeOffset>,
        ICountryReadRepository
    {
        public CountryReadRepository(InventraDbContext inventraDbContext)
            : base(inventraDbContext) { }
    }
}
