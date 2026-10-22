using MediatR;

namespace Inventra.IMS.Application.Features.Queries.Country.GetCountryByUid
{
    public class GetCountryByUidQueryRequest : IRequest<GetCountryByUidQueryResponse>
    {
        public Guid Uid { get; set; }
    }
}
