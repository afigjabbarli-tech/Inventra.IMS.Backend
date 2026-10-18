namespace Inventra.IMS.Application.Abstractions.Repositories.Country
{
    public interface ICountryReadRepository
        : IReadRepository<Domain.Entities.Country, Guid, DateTimeOffset>
    {

    }
}
