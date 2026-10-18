using Inventra.IMS.Application.Features.Commands.Country.CreateCountry;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Inventra.IMS.WebAPI.Controllers
{
    [Route("api/v1/countries")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CountryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("post", Name = "PostCountry")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Post(
            [FromForm] CreateCountryCommandRequest request, CancellationToken cancellationToken)
        {
            CreateCountryCommandResponse response =
                await mediator.Send(request, cancellationToken);

            return StatusCode(
                StatusCodes.Status201Created,
                response);
        }
    }
}
