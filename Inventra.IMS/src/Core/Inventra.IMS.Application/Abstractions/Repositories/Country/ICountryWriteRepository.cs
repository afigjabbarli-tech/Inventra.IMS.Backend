namespace Inventra.IMS.Application.Abstractions.Repositories.Country
{
    public interface ICountryWriteRepository
        : IWriteRepository<Domain.Entities.Country, Guid, DateTimeOffset>
    {

    }
}
