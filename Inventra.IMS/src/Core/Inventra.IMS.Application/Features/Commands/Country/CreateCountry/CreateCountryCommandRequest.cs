using Inventra.IMS.Application.DTOs.Country;
using MediatR;

namespace Inventra.IMS.Application.Features.Commands.Country.CreateCountry
{
    public class CreateCountryCommandRequest : IRequest<CreateCountryCommandResponse>
    {
        public CountryPostDTO CountryPostDTO { get; set; }
        public CountryFlagUploadDTO CountryFlagUploadDTO { get; set; }
    }
}
