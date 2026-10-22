using MediatR;

namespace Inventra.IMS.Application.Features.Commands.Country.DeleteCountryByUid
{
    public class DeleteCountryByUidCommandRequest : IRequest<DeleteCountryByUidCommandResponse>
    {
        public Guid Uid { get; set; }
    }
}
